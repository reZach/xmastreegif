using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace XmasTreeGif
{
    class Program
    {

        static void Main(string[] args)
        {
            using (FileStream fs = new FileStream(@"D:\income\xmas tree gif\XmasTreeGif\XmasTreeGif\file.gif", FileMode.Create))
            {
                using (BinaryWriter outputFile = new BinaryWriter(fs))
                {
                    outputFile.Seek(0, SeekOrigin.Begin);
                    // http://www.matthewflickinger.com/lab/whatsinagif/bits_and_bytes.asp

                    // Header                
                    outputFile.Write(new char[3] { 'G', 'I', 'F' }); // signature                    
                    outputFile.Write(new char[3] { '8', '9', 'a' }); // gif format
                    outputFile.Write(Convert.ToInt16(2)); // screen width
                    outputFile.Write(Convert.ToInt16(2)); // screen height

                    BitArray array = new BitArray(new byte[1]);
                    array[7] = true; // global color table flag
                    array[6] = true; array[5] = true; array[4] = true; // color resolution
                    array[3] = false; // sort flag
                    array[2] = false; array[1] = false; array[0] = true; // global color table size
                    byte[] bytes = new byte[1];
                    array.CopyTo(bytes, 0);
                    outputFile.Write(bytes);

                    outputFile.Write(Convert.ToByte(0)); // background color index
                    outputFile.Write(Convert.ToByte(0)); // pixel aspect ratio

                    // global color table
                    outputFile.Write(Convert.ToByte(255)); // white
                    outputFile.Write(Convert.ToByte(255));
                    outputFile.Write(Convert.ToByte(255));
                    outputFile.Write(Convert.ToByte(255)); // red
                    outputFile.Write(Convert.ToByte(0));
                    outputFile.Write(Convert.ToByte(0));
                    outputFile.Write(Convert.ToByte(0)); // blue
                    outputFile.Write(Convert.ToByte(0));
                    outputFile.Write(Convert.ToByte(255));
                    outputFile.Write(Convert.ToByte(0)); // black
                    outputFile.Write(Convert.ToByte(0));
                    outputFile.Write(Convert.ToByte(0));

                    // application extension (gives us animation)
                    outputFile.Write(Convert.ToByte(0x21)); // gif extension code
                    outputFile.Write(Convert.ToByte(0xff)); // application extension label
                    outputFile.Write(Convert.ToByte(0x0b)); // length of application block (to follow)
                    outputFile.Write(Convert.ToByte('N'));
                    outputFile.Write(Convert.ToByte('E'));
                    outputFile.Write(Convert.ToByte('T'));
                    outputFile.Write(Convert.ToByte('S'));
                    outputFile.Write(Convert.ToByte('C'));
                    outputFile.Write(Convert.ToByte('A'));
                    outputFile.Write(Convert.ToByte('P'));
                    outputFile.Write(Convert.ToByte('E'));
                    outputFile.Write(Convert.ToByte('2'));
                    outputFile.Write(Convert.ToByte('.'));
                    outputFile.Write(Convert.ToByte('0'));
                    outputFile.Write(Convert.ToByte(3)); // length of data sub-block (3 bytes of data to follow)
                    outputFile.Write(Convert.ToByte(1));
                    outputFile.Write(Convert.ToByte(0xff)); // times the gif will loop
                    outputFile.Write(Convert.ToByte(0xff));
                    outputFile.Write(Convert.ToByte(0)); // data sub-block terminator

                    // graphic control extension
                    outputFile.Write(Convert.ToByte(0x21)); // extension introducer
                    outputFile.Write(Convert.ToByte(0xf9)); // graphic control label
                    outputFile.Write(Convert.ToByte(4)); // byte size
                    outputFile.Write(Convert.ToByte(4)); // packed field
                    outputFile.Write(Convert.ToInt16(100)); // delay time, in ms
                    outputFile.Write(Convert.ToByte(0)); // transparent color index
                    outputFile.Write(Convert.ToByte(0)); // block terminator

                    // image descriptor
                    outputFile.Write(Convert.ToByte(0x2c)); // img separator character
                    outputFile.Write(Convert.ToInt16(0)); // img left position
                    outputFile.Write(Convert.ToInt16(0)); // img top positon                    
                    outputFile.Write(Convert.ToInt16(2)); // img width                    
                    outputFile.Write(Convert.ToInt16(2)); // img height                    
                    array = new BitArray(new byte[1]);
                    array[0] = false; // local color table present
                    array[1] = false; // img not interlaced
                    array[2] = false; // sort flag
                    array[5] = false; // size of local color table
                    array[6] = false;
                    array[7] = false;
                    bytes = new byte[1];
                    array.CopyTo(bytes, 0);
                    outputFile.Write(bytes);


                    // image data; lzw                    
                    List<int> pixelData = new List<int>();
                    //pixelData.Add(0);
                    //pixelData.Add(1);
                    //pixelData.Add(1);
                    //pixelData.Add(1);
                    //pixelData.Add(1);
                    //pixelData.Add(1);
                    //pixelData.Add(2);
                    //pixelData.Add(2);
                    //pixelData.Add(2);
                    //pixelData.Add(2);
                    //pixelData.Add(2);
                    //pixelData.Add(1);
                    //pixelData.Add(1);
                    //pixelData.Add(1);
                    //pixelData.Add(1);
                    //pixelData.Add(1);
                    //pixelData.Add(2);
                    //pixelData.Add(2);
                    //pixelData.Add(2);
                    //pixelData.Add(2);
                    //pixelData.Add(2);
                    //pixelData.Add(3);
                    //pixelData.Add(3);
                    //pixelData.Add(3);
                    //pixelData.Add(3);
                    //pixelData.Add(3);
                    pixelData.Add(1);
                    pixelData.Add(1);
                    pixelData.Add(1);
                    pixelData.Add(1);

                    string result = LZW(pixelData);

                    bytes = GetBytes(result);
                    outputFile.Write(Convert.ToByte(2)); // lzw minimum code size
                    outputFile.Write(Convert.ToByte(bytes.Length)); // number of bytes in sub-block
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        outputFile.Write(bytes[i]);
                    }
                    outputFile.Write(Convert.ToByte(0));


                    // img 2
                    // graphic control extension
                    outputFile.Write(Convert.ToByte(0x21)); // extension introducer
                    outputFile.Write(Convert.ToByte(0xf9)); // graphic control label
                    outputFile.Write(Convert.ToByte(4)); // byte size
                    outputFile.Write(Convert.ToByte(4)); // packed field
                    outputFile.Write(Convert.ToInt16(100)); // delay time, in ms
                    outputFile.Write(Convert.ToByte(0)); // transparent color index
                    outputFile.Write(Convert.ToByte(0)); // block terminator

                    // image descriptor
                    outputFile.Write(Convert.ToByte(0x2c)); // img separator character
                    outputFile.Write(Convert.ToInt16(0)); // img left position
                    outputFile.Write(Convert.ToInt16(0)); // img top positon                    
                    outputFile.Write(Convert.ToInt16(2)); // img width                    
                    outputFile.Write(Convert.ToInt16(2)); // img height                    
                    array = new BitArray(new byte[1]);
                    array[0] = false; // local color table present
                    array[1] = false; // img not interlaced
                    array[2] = false; // sort flag
                    array[5] = false; // size of local color table
                    array[6] = false;
                    array[7] = false;
                    bytes = new byte[1];
                    array.CopyTo(bytes, 0);
                    outputFile.Write(bytes);


                    // image data; lzw                    
                    pixelData = new List<int>();
                    pixelData.Add(2);
                    pixelData.Add(2);
                    pixelData.Add(2);
                    pixelData.Add(2);

                    result = LZW(pixelData);

                    bytes = GetBytes(result);
                    outputFile.Write(Convert.ToByte(2)); // lzw minimum code size
                    outputFile.Write(Convert.ToByte(bytes.Length)); // number of bytes in sub-block
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        outputFile.Write(bytes[i]);
                    }
                    outputFile.Write(Convert.ToByte(0));

                    outputFile.Write(Convert.ToByte(0x3b)); // terminator character
                }
            }
        }


        // https://rosettacode.org/wiki/LZW_compression#C.23
        static string LZW(List<int> pixelImageData)
        {
            // build the dictionary
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            for (int i = 0; i < 4; i++)
            {
                dictionary.Add(i.ToString(), i);
            }                

            dictionary.Add(4.ToString(), 4); //clear
            dictionary.Add(5.ToString(), 5); //eoi

            string w = pixelImageData[0].ToString();// string.Empty;
            List<int> compressed = new List<int> { 4 };
            
            double codeSize = 3.0; // this is in bits
            string returnMe = Convert.ToString(((byte)4), 2).PadLeft((int)codeSize, '0');
            int k;

            for (int l = 1; l < pixelImageData.Count; l++)
            {
                k = pixelImageData[l];

                string wc = w + k;
                if (dictionary.ContainsKey(wc))
                {
                    w = wc;
                }
                else
                {
                    // add a row for index buffer + k
                    dictionary.Add(wc, dictionary.Count);

                    // output the code for just the index buffer to our code stream
                    compressed.Add(dictionary[w]);
                    returnMe = Convert.ToString(((byte)dictionary[w]), 2).PadLeft((int)codeSize, '0') + returnMe;

                    // index buffer set to k
                    w = k.ToString();

                    // change code size
                    if (Math.Pow(2.0, codeSize) - 1 == dictionary[w])
                    {
                        codeSize += 1.0;
                    }                    
                }
            }

            // write remaining output if necessary
            if (!string.IsNullOrEmpty(w))
            {
                compressed.Add(dictionary[w]);
                returnMe = Convert.ToString(((byte)dictionary[w]), 2).PadLeft((int)codeSize, '0') + returnMe;
            }

            compressed.Add(dictionary["5"]);
            returnMe = Convert.ToString(((byte)5), 2).PadLeft((int)codeSize, '0') + returnMe;

            return returnMe; //compressed;
        }

        static string reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        static byte[] GetBytes(string bitString)
        {
            List<byte> returnMe = new List<byte>();
            int pos = bitString.Length - 1;
            string working = string.Empty;

            while (pos >= 0)
            {
                working = bitString[pos] + working;

                if (working.Length == 8)
                {
                    returnMe.Add(Convert.ToByte(working, 2));
                    working = string.Empty;
                }

                pos--;
            }

            // pickup runoff
            if (working.Length < 8)
            {
                working = working.PadLeft(8, '0');
                returnMe.Add(Convert.ToByte(working, 2));
            }

            return returnMe.ToArray();
        }
    }

    public struct Pixel
    {
        public byte Red;
        public byte Green;
        public byte Blue;        
    }

    public struct Frame
    {
        public ushort AnimationDelay;
        public List<Pixel> Pixels;

        public int Width;
        public int Height;
        public int WidthOffset;
        public int HeightOffset;
    }

    public class GIFMaker
    {
        private DirectoryInfo _outputPath;
        private List<Pixel> _colorTable;
        private List<Frame> _frames;

        public ushort Width;
        public ushort Height;
        public bool ShouldRepeat;

        public GIFMaker()
        {
            _outputPath = new DirectoryInfo(AppContext.BaseDirectory);
            _colorTable = new List<Pixel>();
        }

        public void CreateGIF()
        {
            if (!_colorTable.Any())
            {
                throw new Exception("GIFMaker has no color table!");
            }
            if (!_frames.Any())
            {
                throw new Exception("GIFMaker has no frames!");
            }


            // Create the .GIF
            using (FileStream fileStream = new FileStream("", FileMode.Create))
            using (BinaryWriter output = new BinaryWriter(fileStream))
            {
                output.Seek(0, SeekOrigin.Begin);

                WriteHeader(output);
                WriteLogicalScreenDescriptor(output);
                WriteApplicationExtension(output, ShouldRepeat);

                // Need to write these values for each frame
                for (int i = 0; i < _frames.Count; i++)
                {
                    WriteGraphicControlExtension(output, _frames[i].AnimationDelay);
                    WriteImageDescriptor(output, _frames[i]);
                }
            }
        }

        /// <summary>
        ///     Writes the header section for the .GIF file.
        /// </summary>
        /// <param name="output"></param>
        private void WriteHeader(BinaryWriter output)
        {
            // GIFs must start with a header block;
            // The first 3 bytes must be "GIF",
            // the next 3 bytes must be the version
            // that we are encoding the .GIF in ("87a" or "89a")
            output.Write(new char[3] { 'G', 'I', 'F' });                  
            output.Write(new char[3] { '8', '9', 'a' });
        }

        /// <summary>
        ///     Writes the logical screen descriptor section for the .GIF file.
        /// </summary>
        /// <param name="output"></param>
        private void WriteLogicalScreenDescriptor(BinaryWriter output)
        {
            // The logical screen descriptor holds global values
            // for our .GIF file
            //
            // The first 2 bytes are the width of the canvas (the entire .GIF)
            // The second 2 bytes are the height of the canvas
            // The next byte is a packed byte:
            //      The first 3 bits are the size of the global color table
            //          (ex.  if these 3 bits equal "1" in binary, the global color table holds 2^(n+1) colors)
            //          (aka. if these 3 bits equal "1" in binary, we can use a total of 4 colors in our .GIF)
            //      The next bit is if the colors in the global color table are sorted in decreasing frequency in the image
            //          (this helps speed up decoding the .GIF; can stay at "0")
            //      The next 3 bits are the color resolution of the image 
            //          (color resolution == number of bits per primary color available to the original image, minus 1)
            //      The last bit is if we have a global color table (1 = yes, 0 = no)
            // The next byte is the background color index (the index of the color from the global color table)
            // The last byte is the pixel aspect ratio

            output.Write(Width);
            output.Write(Height);

            // Packed field
            BitArray array = new BitArray(new byte[1]);
            BitArray GCTS = LogicalScreenDescriptorGlobalColorTableSize();
            array[2] = GCTS[1]; array[1] = GCTS[1]; array[0] = GCTS[0]; // Global color table size
            array[3] = false; // Sort flag
            array[6] = true; array[5] = true; array[4] = true; // Color resolution (64 colors)
            array[7] = true; // Global color table flag ("1" since we are using a global color table)

            byte[] bytes = new byte[1];
            array.CopyTo(bytes, 0);
            output.Write(bytes);

            output.Write((byte)0); // Background color index
            output.Write((byte)0); // Pixel aspect ratio
        }

        private BitArray LogicalScreenDescriptorGlobalColorTableSize()
        {
            // Global color table size is directly related to the number
            // of colors we can have in our .GIF. A .GIF can hold anywhere
            // between 2-256 colors, and has this relationship between the
            // global color table size
            //
            //      GCTS | Total colors available
            //      0      2
            //      1      4
            //      2      8
            //      3      16
            //      4      32
            //      5      64
            //      6      128
            //      7      256
            //
            // Where:
            //      total colors available = 2^(GCTS+1)
            //
            // We will perform the inverse since we know the
            // colors we want to use

            byte ret = 1;

            // log2(total colors) - 1
            ret = (byte)Math.Round(Math.Log((double)_colorTable.Count, 2.0) - 1.0);

            return new BitArray(new byte[1] { ret });
        }

        private void WriteGlobalColorTable(BinaryWriter output)
        {            
            // The global color table includes all colors the .GIF
            // will use, in this format (where "C" means color):
            //      C1 red value, C1 green value, C1 blue value, 
            //      C2 red value, C2 green value, C2 blue value, 
            //      ...
            
            for (int i = 0; i < _colorTable.Count; i++)
            {
                output.Write(_colorTable[i].Red);
                output.Write(_colorTable[i].Green);
                output.Write(_colorTable[i].Blue);
            }
        }

        /// <summary>
        ///     Writes the application extension section for the .GIF file.
        /// </summary>
        /// <param name="output"></param>
        private void WriteApplicationExtension(BinaryWriter output, bool shouldRepeat)
        {
            // This section allows us to animate our .GIF file.
            // Without this section, our .GIF would play through
            // once and stop.
            //
            // The first byte is the extension code, this "extension" code
            //      (extension codes are specific to the 89a .GIF specification, as opposed to the 87a specification)
            // The second byte says this extension is an application extension "0xff"
            // The third byte is the length of the application extension (fixed value, "0x0b")
            // The next 8 bytes are "NETSCAPE" - this is the application identifier
            // The next 3 bytes are "2.0" - this is the application authentication code
            // The next byte is a "3" - the length of the bytes to follow
            // The next byte is a "1"
            // The next 2 bytes are how many times the .GIF file should loop in the animation
            // The last byte is a termination character

            output.Write((byte)0x21); // GIF extension code
            output.Write((byte)0xff); // Application extension label
            output.Write((byte)0x0b); // Length of application block (to follow)
            output.Write('N');
            output.Write('E');
            output.Write('T');
            output.Write('S');
            output.Write('C');
            output.Write('A');
            output.Write('P');
            output.Write('E');
            output.Write('2');
            output.Write('.');
            output.Write('0');
            output.Write((byte)3); // Length of data sub-block (3 bytes of data to follow)
            output.Write((byte)1);

            if (shouldRepeat)
            {
                output.Write((byte)0xff); // Times the GIF will loop
                output.Write((byte)0xff);
            }
            else
            {
                output.Write((byte)0);
                output.Write((byte)0);
            }
            
            output.Write((byte)0); // Data sub-block terminator
        }

        /// <summary>
        ///     Writes the graphic control extension section for the .GIF file.
        ///     This section is optional for each frame of your .GIF file if you
        ///     are not animating your .GIF file with multiple frames.
        /// </summary>
        /// <param name="output"></param>
        /// <param name="delay"></param>
        private void WriteGraphicControlExtension(BinaryWriter output, ushort delay)
        {
            // The graphic control extension allows us to control
            // aspects related to our .GIF's animation.
            //
            // The first byte is the extension code, this "extension" code
            // The second byte says this extension is a graphics control extension "0xf9"
            // The third byte is the byte size (this should stay at 4)
            // The fourth byte is a packed byte:
            //      The first bit is if we want to make our transparent color index, transparent
            //          (the transparent color index is an index of the global color table we want to make transparent)
            //      The second bit is if we require user input before moving to the next frame in an animated .GIF
            //      The next three bits are the disposal method - which defines what happens to the current image before we move onto the next
            //          (a value of "1" indicates the image should remain in place, and draw the next image over it)
            //          (a value of "2" indicates the canvas should be restored to the background color (as indicated in the logical screen descriptor))
            //          (a value of "3" indicates the canvas should restore state to the previous state before the current image was drawn)
            //      The next three bits are reserved and not used as of today
            // The next 2 bytes are the value in centiseconds should wait before moving onto the next frame
            //      (100 centiseconds = 1 second)
            // The next byte is the transparent color index (that matches a color in the global color table)
            // The last byte is a termination character
            
            output.Write((byte)0x21); // GIF extension code
            output.Write((byte)0xf9); // Graphic control extension label
            output.Write((byte)4); // Byte size

            // Packed field
            BitArray array = new BitArray(new byte[1]);
            array[0] = false; // Transparent color flag
            array[1] = false; // User input flag
            array[4] = false; array[3] = false; array[2] = true; // Disposal method            

            byte[] bytes = new byte[1];
            array.CopyTo(bytes, 0);
            output.Write(bytes);

            output.Write(delay); // Delay time, in centiseconds
            output.Write((byte)0); // Transparent color index
            output.Write((byte)0); // Block terminator
        }

        /// <summary>
        ///     Writes the image descriptor section for the .GIF file.
        ///     This section is necessary for each frame of your .GIF file.
        /// </summary>
        /// <param name="output"></param>
        private void WriteImageDescriptor(BinaryWriter output, Frame frame)
        {
            // The image descriptor contains information of
            // how large and where the frame's pixels will
            // be drawn on the canvas
            //
            // The first byte is an image separator character, and must always be 0x2c
            // The next 2 bytes are at what x position from the origin of the canvas will the image begin at
            // The next 2 bytes are at what y position from the origin of the canvas will the image begin at
            //      (note. the origin of the canvas is at the top-left of the canvas)
            // The next 2 bytes are the width of the frame
            // The next 2 bytes are the height of the frame
            // The last byte is a packed byte:
            //      The first 3 bits are the size of the local color table
            //      The next 2 bits are reserved for future use
            //      The next bit is if the colors in the local color table are sorted in decreasing frequency in the image
            //          (this helps speed up decoding the .GIF; can stay at "0")
            //      The next bit is for the interlace flag? ("0" is a default value)
            //      The last bit is if we are using a local color table for the upcoming image
            //          (local color tables take precedence over global color tables if they are present)            

            output.Write(Convert.ToByte(0x2c)); // Image separator character
            output.Write(frame.WidthOffset); // Image left position
            output.Write(frame.HeightOffset); // Image top positon                    
            output.Write(frame.Width); // Image width                    
            output.Write(frame.Height); // Image height     

            // Packed field
            BitArray array = new BitArray(new byte[1]);
            array[7] = false; array[6] = false; array[5] = false; // Size of local color table
            array[2] = false; // Sort flag
            array[1] = false; // Interlace flag
            array[0] = false; // Local color table flag
            byte[] bytes = new byte[1];
            array.CopyTo(bytes, 0);
            output.Write(bytes);
        }
    }
}