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
            List<Pixel> colorTable = new List<Pixel>
            {
                new Pixel
                {
                    Red = 255,
                    Green = 255,
                    Blue = 255
                },
                new Pixel
                {
                    Red = 255,
                    Green = 0,
                    Blue = 0
                },
                new Pixel
                {
                    Red = 0,
                    Green = 0,
                    Blue = 255
                },
                new Pixel
                {
                    Red = 0,
                    Green = 0,
                    Blue = 0
                }
            };
            List<Frame> frames = new List<Frame>
            {
                new Frame
                {
                    Width = 2,
                    Height = 2,
                    AnimationDelay = 100,
                    Pixels = new List<Pixel>
                    {
                        colorTable[0],
                        colorTable[0],
                        colorTable[0],
                        colorTable[0]
                    }
                },
                new Frame
                {
                    Width = 2,
                    Height = 2,
                    AnimationDelay = 100,
                    Pixels = new List<Pixel>
                    {
                        colorTable[1],
                        colorTable[1],
                        colorTable[1],
                        colorTable[1]
                    }
                }
            };
            GIFMaker maker = new GIFMaker
            {
                fileOutputPath = @"D:\income\xmas tree gif\XmasTreeGif\XmasTreeGif\file2.gif",
                Width = 2,
                Height = 2,
                ShouldRepeat = true,
                ColorTable = colorTable,
                Frames = frames
            };

            maker.CreateGIF();
            return;

            using (FileStream fs = new FileStream(@"C:\proj\xmas tree gif\XmasTreeGif\XmasTreeGif\file.gif", FileMode.Create))
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
            for (int i = 0; i < pixelImageData.Count; i++)
            {
                dictionary.Add(i.ToString(), i);
            }

            dictionary.Add(pixelImageData.Count.ToString(), pixelImageData.Count); //clear
            dictionary.Add((pixelImageData.Count + 1).ToString(), pixelImageData.Count + 1); //eoi

            string w = pixelImageData[0].ToString();// string.Empty;
                                                    //List<int> compressed = new List<int> { pixelImageData.Count };

            double codeSize = 3.0; // this is in bits
            string returnMe = Convert.ToString(((byte)(pixelImageData.Count)), 2).PadLeft((int)codeSize, '0');
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
                    //compressed.Add(dictionary[w]);
                    returnMe = Convert.ToString(((byte)dictionary[w]), 2).PadLeft((int)codeSize, '0') + returnMe;

                    // index buffer set to k
                    w = k.ToString();

                    // change code size
                    if (Math.Pow(2.0, codeSize) - 1 == dictionary[w])
                    {
                        codeSize += 1.0;
                    }
                }

                // If we have 4096 codes, we can't store another one,
                // so we need to clear out our code table as we continue
                if (dictionary.Count == 4096)
                {

                }
            }

            // write remaining output if necessary
            if (!string.IsNullOrEmpty(w))
            {
                //compressed.Add(dictionary[w]);
                returnMe = Convert.ToString(((byte)dictionary[w]), 2).PadLeft((int)codeSize, '0') + returnMe;
            }

            //compressed.Add(dictionary["5"]);
            returnMe = Convert.ToString(((byte)(pixelImageData.Count + 1)), 2).PadLeft((int)codeSize, '0') + returnMe;

            return returnMe; //compressed;
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

        public ushort Width;
        public ushort Height;
        public ushort WidthOffset;
        public ushort HeightOffset;
    }

    public class GIFMaker
    {
        private DirectoryInfo _outputPath;        
        private Dictionary<Pixel, int> _pixelToColorTableMap;

        public List<Pixel> ColorTable;
        public List<Frame> Frames;
        public ushort Width;
        public ushort Height;
        public bool ShouldRepeat;
        public string fileOutputPath;

        public GIFMaker()
        {
            _outputPath = new DirectoryInfo(AppContext.BaseDirectory);
            ColorTable = new List<Pixel>();
            Frames = new List<Frame>();
            _pixelToColorTableMap = new Dictionary<Pixel, int>();
        }

        public void CreateGIF()
        {
            if (!ColorTable.Any())
            {
                throw new Exception("GIFMaker has no color table!");
            }
            if (!Frames.Any())
            {
                throw new Exception("GIFMaker has no frames!");
            }
            if (Width == 0 || Height == 0)
            {
                throw new Exception("Width or Height cannot equal zero!");
            }
            if (string.IsNullOrEmpty(fileOutputPath))
            {
                throw new Exception("File output path cannot be empty!");
            }

            // Create the .GIF
            CreatePixelToColorTableMap();

            using (FileStream fileStream = new FileStream(fileOutputPath, FileMode.Create))
            using (BinaryWriter output = new BinaryWriter(fileStream))
            {
                output.Seek(0, SeekOrigin.Begin);

                WriteHeader(output);
                WriteLogicalScreenDescriptor(output);
                WriteGlobalColorTable(output);                
                WriteApplicationExtension(output, ShouldRepeat);

                // Need to write these values for each frame
                string LZWImageData = string.Empty;
                for (int i = 0; i < Frames.Count; i++)
                {
                    WriteGraphicControlExtension(output, Frames[i].AnimationDelay);
                    WriteImageDescriptor(output, Frames[i]);
                    LZWImageData = CreateLZWEncodedImageData(Frames[i].Pixels);
                    WriteLZWEncodedImageData(output, LZWImageData);
                }
                
                output.Write(Convert.ToByte(0x3b)); // Termination byte
            }
        }

        /// <summary>
        ///     Builds an internal mapping of pixel to color map
        ///     table index that is necessary for LZW image compression.
        /// </summary>
        private void CreatePixelToColorTableMap()
        {
            for (int i = 0; i < Frames.Count; i++)
                for (int j = 0; j < Frames[i].Pixels.Count; j++)
                    for (int k = 0; k < ColorTable.Count; k++)
                    {
                        // If the colors match
                        if (Frames[i].Pixels[j].Red == ColorTable[k].Red &&
                            Frames[i].Pixels[j].Green == ColorTable[k].Green &&
                            Frames[i].Pixels[j].Blue == ColorTable[k].Blue)
                        {
                            // Only add mapping if it doesn't already exist
                            if (!_pixelToColorTableMap.ContainsKey(Frames[i].Pixels[j]))
                            {
                                _pixelToColorTableMap.Add(Frames[i].Pixels[j], k);
                            }
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
            ret = (byte)Math.Round(Math.Log((double)ColorTable.Count, 2.0) - 1.0);

            return new BitArray(new byte[1] { ret });
        }

        private void WriteGlobalColorTable(BinaryWriter output)
        {
            // The global color table includes all colors the .GIF
            // will use, in this format (where "C" means color):
            //      C1 red value, C1 green value, C1 blue value, 
            //      C2 red value, C2 green value, C2 blue value, 
            //      ...

            for (int i = 0; i < ColorTable.Count; i++)
            {
                output.Write(ColorTable[i].Red);
                output.Write(ColorTable[i].Green);
                output.Write(ColorTable[i].Blue);
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

        /// <summary>
        ///     Creates the image data (that is encoded with LZW
        ///     compression) section that is required for .GIF files.
        /// </summary>
        /// <param name="imageData"></param>
        private string CreateLZWEncodedImageData(List<Pixel> imageData)
        {
            // Returns the image data of the frame as a LZW encoded binary string.
            // This binary string will be returned and later transformed into bytes that
            // will be placed in the .GIF file

            Dictionary<string, int> dictionary = LZWEncodedImageDataDictionary();
            double codeSize = 3.0; // In bits; this value will grow as we enter in more codes in our code table
            string w; // Holds a reference to the image data value we are looking at
            int k; // Holds a reference of the image data value (one past) w
            string encodedImageData; // What we will return; LZW compressed values of our image data

            w = _pixelToColorTableMap[imageData[0]].ToString();
            encodedImageData = ConvertToBinaryString(ColorTable.Count, codeSize); // First piece of encoded data must be the clear code

            for (int l = 1; l < imageData.Count; l++)
            {
                k = _pixelToColorTableMap[imageData[l]];

                string wc = w + k; // Build an "index buffer" that equals w + k
                if (dictionary.ContainsKey(wc))
                {
                    w = wc;
                }
                else
                {
                    // Add a code (row) for index buffer + k
                    dictionary.Add(wc, dictionary.Count);

                    // Encode the index buffer
                    encodedImageData = ConvertToBinaryString(dictionary[w], codeSize) + encodedImageData;

                    // Index buffer set to k
                    w = k.ToString();

                    // Change code size (if applicable)
                    if (Math.Pow(2.0, codeSize) - 1 == dictionary[w])
                    {
                        codeSize += 1.0;
                    }
                }

                // If we have 4096 codes, we can't store another one,
                // so we need to clear out our code table as we continue
                if (dictionary.Count >= 4096)
                {
                    dictionary = LZWEncodedImageDataDictionary();
                }
            }

            // Write remaining output if necessary
            if (!string.IsNullOrEmpty(w))
            {
                encodedImageData = ConvertToBinaryString(dictionary[w], codeSize) + encodedImageData;
            }

            // Add the end of information code, because we've reached the end of the data
            encodedImageData = ConvertToBinaryString(ColorTable.Count + 1, codeSize) + encodedImageData;

            return encodedImageData;
        }

        /// <summary>
        ///     Builds a dictionary that is used when compressing
        ///     image data with LZW compression.
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, int> LZWEncodedImageDataDictionary()
        {
            // Returns a dictionary of code | color. This dictionary should
            // contain all the colors in the global color table, as well as
            // two codes that follow the colors, the clear code and end of
            // information code.
            //
            // The clear code's presence means we need to clear out the color
            // table, as we have a strict limit of 4096 max codes in our color
            // table. The end of information code means we are finished encoding
            // image data. This is a sample dictionary where our global color table
            // has 4 total colors in it:
            //
            //      Code | Color
            //      0      0
            //      1      1
            //      2      2
            //      3      3
            //      4      clear code
            //      5      end of information code

            int sizeOfColorTable = ColorTable.Count;
            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            // Write all color codes to the dictionary
            for (int i = 0; i < sizeOfColorTable; i++)
            {
                dictionary.Add(i.ToString(), i);
            }

            // Add additional codes after
            dictionary.Add(sizeOfColorTable.ToString(), sizeOfColorTable); // Clear color code
            dictionary.Add((sizeOfColorTable + 1).ToString(), sizeOfColorTable + 1); // End of information code

            return dictionary;
        }

        /// <summary>
        ///     Returns a binary string representation of the code value, 
        ///     as according to the code size. (This process is specific to LZW
        ///     encoding for .GIF files).
        /// </summary>
        private string ConvertToBinaryString(int codeValue, double codeSize)
        {
            // The codeSize determines how many bits we need to return
            return Convert.ToString(((byte)codeValue), 2).PadLeft((int)codeSize, '0');
        }

        /// <summary>
        ///     Writes the LZW encoded image data to the
        ///     .GIF file.
        /// </summary>
        /// <param name="output"></param>
        /// <param name="LZWEncodedImageData"></param>
        private void WriteLZWEncodedImageData(BinaryWriter output, string LZWEncodedImageData)
        {            
            // The encoded image data is preceeded by the LZW minimum code size,
            // which is two. Followed by the number of bytes in a sub-block. A 
            // sub-block consists of 1-255 bytes in length (and is the lzw encoded
            // image data). 
            // A .GIF can have multiple sub-blocks encoded in the .GIF. Each sub-block
            // must first have the number of bytes the sub-block encoded preceeding the
            // sub-block. A terminator byte of 0 ends all LZW encoded image data.

            byte[] bytes = GetLZWEncodedImageDataBytes(LZWEncodedImageData);

            output.Write(Convert.ToByte(2)); // The LZW minimum code size

            int remainingBytes = GetRemainingBytesInSubBlock(bytes, 0);
            bool writeByteLength = true;
            for (int i = 0; i < remainingBytes; i++)
            {
                if (writeByteLength)
                {
                    output.Write(Convert.ToByte(remainingBytes));
                    writeByteLength = false;
                }

                output.Write(bytes[i]);

                // Write next sub-block, if applicable
                if (i + 1 == remainingBytes &&
                    GetRemainingBytesInSubBlock(bytes, i + 1) > 0)
                {
                    remainingBytes = GetRemainingBytesInSubBlock(bytes, i + 1);
                    writeByteLength = true;
                }
            }
            
            output.Write((byte)0); // Termination byte
        }

        /// <summary>
        ///     Returns byte data that is used when saving image data
        ///     in a .GIF file.
        /// </summary>
        /// <param name="LZWEncodedImageData"></param>
        /// <returns></returns>
        private byte[] GetLZWEncodedImageDataBytes(string LZWEncodedImageData)
        {
            // Add encoded image data from the end of the value (hightest byte order)
            // to the beginning of the value (lowest byte order)
            List<byte> returnMe = new List<byte>();
            int pos = LZWEncodedImageData.Length - 1;
            string working = string.Empty;

            while (pos >= 0)
            {
                working = LZWEncodedImageData[pos] + working;

                // Every 8 bits, create a byte
                if (working.Length == 8)
                {
                    returnMe.Add(Convert.ToByte(working, 2));
                    working = string.Empty;
                }

                pos--;
            }

            // If we do not have bits to fill the entire byte,
            // fill the last byte with zeroes
            if (working.Length < 8)
            {
                working = working.PadLeft(8, '0');
                returnMe.Add(Convert.ToByte(working, 2));
            }

            return returnMe.ToArray();
        }

        /// <summary>
        ///     Returns the number of bytes that belong
        ///     in this sub-block, starting at the <paramref name="startIndex"/>.
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        private int GetRemainingBytesInSubBlock(byte[] bytes, int startIndex)
        {
            // Simple case, return the number of bytes
            // if our image data only fits into one sub-block
            if (bytes.Length <= 255)
            {
                return bytes.Length;
            }

            // If we've ran out of bytes, return 0
            // (termination value)
            if (bytes.Length - 1 == startIndex)
            {
                return 0;
            }

            // Handle images that require multiple sub-blocks
            // of data
            if (bytes.Length - startIndex > 255)
            {
                return 255;
            }
            else
            {
                return bytes.Length - startIndex;
            }
        }
    }
}