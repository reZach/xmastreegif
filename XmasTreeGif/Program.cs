﻿using System;
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
            Dictionary<string, Pixel> ct = new Dictionary<string, Pixel>
            {
                { "o", new Pixel { Red = 185, Green = 122, Blue = 86 } }, // brown
                { "r", new Pixel { Red = 236, Green = 28, Blue = 36 } }, // red
                { "g", new Pixel { Red = 14, Green = 209, Blue = 69 } }, // green
                { "b", new Pixel { Red = 0, Green = 0, Blue = 0 } }, // black
            };
            List<Frame> frames = new List<Frame>
            {
                new Frame
                {
                    Width = 20,
                    Height = 20,
                    AnimationDelay = 100,
                    Pixels = new List<Pixel>
                    {
                        ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"],
                        ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"],
                        ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"],
                        ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["g"], ct["g"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"],
                        ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["g"], ct["g"], ct["g"], ct["g"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"],
                        ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["g"], ct["r"], ct["g"], ct["g"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"],
                        ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["g"], ct["g"], ct["g"], ct["g"], ct["g"], ct["g"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"],
                        ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["g"], ct["r"], ct["g"], ct["g"], ct["g"], ct["g"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"],
                        ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["g"], ct["g"], ct["g"], ct["g"], ct["r"], ct["g"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"],
                        ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["g"], ct["g"], ct["g"], ct["g"], ct["g"], ct["g"], ct["g"], ct["g"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"],
                        ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["g"], ct["g"], ct["g"], ct["g"], ct["r"], ct["g"], ct["g"], ct["g"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"],
                        ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["g"], ct["g"], ct["g"], ct["g"], ct["g"], ct["g"], ct["g"], ct["g"], ct["r"], ct["g"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"],
                        ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["g"], ct["r"], ct["g"], ct["g"], ct["g"], ct["g"], ct["g"], ct["g"], ct["g"], ct["g"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"],
                        ct["b"], ct["b"], ct["b"], ct["b"], ct["g"], ct["g"], ct["g"], ct["g"], ct["g"], ct["g"], ct["g"], ct["r"], ct["g"], ct["g"], ct["g"], ct["g"], ct["b"], ct["b"], ct["b"], ct["b"],
                        ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["g"], ct["g"], ct["g"], ct["g"], ct["g"], ct["g"], ct["g"], ct["g"], ct["g"], ct["g"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"],
                        ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["g"], ct["g"], ct["g"], ct["g"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"],
                        ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["o"], ct["o"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"],
                        ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["o"], ct["o"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"],
                        ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"],
                        ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"],
                    }
                },
                new Frame
                {
                    Width = 20,
                    Height = 20,
                    AnimationDelay = 100,
                    Pixels = new List<Pixel>
                    {
                        ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"],
                        ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"],
                        ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"],
                        ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["g"], ct["g"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"],
                        ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["g"], ct["g"], ct["r"], ct["g"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"],
                        ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["g"], ct["g"], ct["g"], ct["g"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"],
                        ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["g"], ct["g"], ct["g"], ct["g"], ct["g"], ct["g"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"],
                        ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["g"], ct["g"], ct["g"], ct["g"], ct["r"], ct["g"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"],
                        ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["g"], ct["g"], ct["g"], ct["g"], ct["g"], ct["g"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"],
                        ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["g"], ct["g"], ct["r"], ct["g"], ct["g"], ct["g"], ct["g"], ct["g"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"],
                        ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["g"], ct["g"], ct["g"], ct["g"], ct["g"], ct["g"], ct["g"], ct["g"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"],
                        ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["g"], ct["g"], ct["r"], ct["g"], ct["r"], ct["g"], ct["g"], ct["g"], ct["g"], ct["g"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"],
                        ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["g"], ct["g"], ct["g"], ct["g"], ct["g"], ct["g"], ct["g"], ct["g"], ct["r"], ct["g"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"],
                        ct["b"], ct["b"], ct["b"], ct["b"], ct["g"], ct["g"], ct["g"], ct["g"], ct["r"], ct["g"], ct["g"], ct["g"], ct["g"], ct["g"], ct["g"], ct["g"], ct["b"], ct["b"], ct["b"], ct["b"],
                        ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["g"], ct["g"], ct["g"], ct["g"], ct["g"], ct["r"], ct["g"], ct["g"], ct["g"], ct["g"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"],
                        ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["g"], ct["g"], ct["g"], ct["g"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"],
                        ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["o"], ct["o"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"],
                        ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["o"], ct["o"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"],
                        ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"],
                        ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"], ct["b"],
                    }
                }
            };
            
            GIFMaker maker = new GIFMaker
            {
                FileOutputPath = new DirectoryInfo(@"C:\gifmaker\xmastree.gif"),
                Width = 20,
                Height = 20,
                ShouldRepeat = true,
                ColorTable = ct,
                Frames = frames
            };

            maker.CreateGIF();
        }
    }

    /// <summary>
    ///     Encapsulates information about a pixel.
    /// </summary>
    public struct Pixel
    {
        /// <summary>
        ///     The red color (0-255) of a pixel.
        /// </summary>
        public byte Red;

        /// <summary>
        ///     The green color (0-255) of a pixel.
        /// </summary>
        public byte Green;

        /// <summary>
        ///     The blue color (0-255) of a pixel.
        /// </summary>
        public byte Blue;
    }

    /// <summary>
    ///     Encapsulates information about a frame
    ///     within a .GIF.
    /// </summary>
    public struct Frame
    {
        /// <summary>
        ///     The delay, in centiseconds, that before
        ///     displaying this frame.
        /// </summary>
        public ushort AnimationDelay;

        /// <summary>
        ///     Image data for the frame; beginning at the
        ///     most top-left pixel to the bottom-right pixel
        ///     (in rows).
        /// </summary>
        public List<Pixel> Pixels;

        /// <summary>
        ///     The width of the frame.
        /// </summary>
        public ushort Width;

        /// <summary>
        ///     The height of the frame.
        /// </summary>
        public ushort Height;

        /// <summary>
        ///     How many pixels we should start off the x-origin
        ///     of the .GIF file.
        /// </summary>
        public ushort WidthOffset;

        /// <summary>
        ///     How many pixels we should start off the y-origin
        ///     of the .GIF file.
        /// </summary>
        public ushort HeightOffset;
    }

    /// <summary>
    ///     Encapsulates information to make a .GIF file.
    /// </summary>
    public class GIFMaker
    {        
        private Dictionary<Pixel, int> _pixelToColorTableMap;

        /// <summary>
        ///     The output path of the .GIF that is created.
        /// </summary>
        public DirectoryInfo FileOutputPath;

        /// <summary>
        ///     The global color table that is used.
        /// </summary>
        public Dictionary<string, Pixel> ColorTable;

        /// <summary>
        ///     Frames that encapsulate a given .GIF.
        /// </summary>
        public List<Frame> Frames;

        /// <summary>
        ///     The width of the .GIF file.
        /// </summary>
        public ushort Width;

        /// <summary>
        ///     The height of the .GIF file.
        /// </summary>
        public ushort Height;

        /// <summary>
        ///     If the .GIF should repeat it's animation loop.        
        /// </summary>
        public bool ShouldRepeat;

        public GIFMaker()
        {
            _pixelToColorTableMap = new Dictionary<Pixel, int>();

            FileOutputPath = new DirectoryInfo(AppContext.BaseDirectory);
            ColorTable = new Dictionary<string, Pixel>();
            Frames = new List<Frame>();            
        }

        /// <summary>
        ///     Creates and writes .GIF-encoded data to a given file.
        /// </summary>
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
            if (!FileOutputPath.Parent.Exists)
            {
                throw new Exception($"The directory '{FileOutputPath.Parent}' does not exist, the .GIF file could not be made!");
            }

            CreatePixelToColorTableMap();

            // Create the .GIF
            Console.WriteLine($"Creating a new .GIF at the following path: {FileOutputPath.FullName}.");

            using (FileStream fileStream = new FileStream(FileOutputPath.FullName, FileMode.Create))
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
            for (int i = 0; i < ColorTable.Count; i++)
            {
                _pixelToColorTableMap.Add(ColorTable[ColorTable.Keys.ElementAt(i)], i);
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
            array[2] = GCTS[2]; array[1] = GCTS[1]; array[0] = GCTS[0]; // Global color table size
            array[3] = false; // Sort flag
            array[6] = true; array[5] = true; array[4] = true; // Color resolution (64 colors)            
            array[7] = true; // Global color table flag ("1" since we are using a global color table)

            byte[] bytes = new byte[1];
            array.CopyTo(bytes, 0);
            output.Write(bytes);

            output.Write((byte)0); // Background color index
            output.Write((byte)0); // Pixel aspect ratio
        }

        private BitArray LogicalScreenDescriptorGlobalColorTableSize(int? size = null)
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
            int total = size ?? ColorTable.Count; // Optionally pass in a size to get the GCTS

            // log2(total colors) - 1
            ret = (byte)Math.Ceiling(Math.Log((double)total, 2.0) - 1.0);

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
                output.Write(ColorTable[ColorTable.Keys.ElementAt(i)].Red);
                output.Write(ColorTable[ColorTable.Keys.ElementAt(i)].Green);
                output.Write(ColorTable[ColorTable.Keys.ElementAt(i)].Blue);
            }

            // Add additional placeholders if we do not have the same
            // number of colors that match the GCTS (global color table size)
            // 
            // Please see the LogicalScreenDescriptorGlobalColorTableSize
            // to see the number of colors we require for a given GCTS

            BitArray GCTS = LogicalScreenDescriptorGlobalColorTableSize();
            byte[] bytes = new byte[1];
            GCTS.CopyTo(bytes, 0);

            Pixel placeholder = new Pixel { Red = 0, Green = 0, Blue = 0 };

            for (int i = ColorTable.Count; i < (int)Math.Pow(2.0, (bytes[0] + 1)); i++)
            {
                output.Write(placeholder.Red);
                output.Write(placeholder.Green);
                output.Write(placeholder.Blue);
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
            double codeSize = GetLZWStartingCodeSize(dictionary.Count); // In bits; this value will grow as we enter in more codes in our code table
            string w; // Holds a reference to the image data value we are looking at
            int k; // Holds a reference of the image data value (one past) w
            string encodedImageData; // What we will return; LZW compressed values of our image data
            int clear = dictionary.Count - 2; // Holds the index for the clear code
            int eoi = dictionary.Count - 1; // Holds the index for the end-of-information code

            w = _pixelToColorTableMap[imageData[0]].ToString();
            encodedImageData = ConvertToBinaryString(clear, codeSize); // First piece of encoded data must be the clear code

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
                    if (Math.Pow(2.0, codeSize) == dictionary[wc])
                    {
                        codeSize += 1.0;
                    }
                }

                // If we have 4096 codes, we can't store another one,
                // so we need to clear out our code table as we continue
                if (dictionary.Count >= 4096)
                {
                    // Output the clear code
                    encodedImageData = ConvertToBinaryString(clear, codeSize) + encodedImageData;

                    // Reset
                    dictionary = LZWEncodedImageDataDictionary();
                    codeSize = GetLZWStartingCodeSize(dictionary.Count);
                }
            }

            // Write remaining output if necessary
            if (!string.IsNullOrEmpty(w))
            {
                encodedImageData = ConvertToBinaryString(dictionary[w], codeSize) + encodedImageData;
            }

            // Add the end of information code, because we've reached the end of the data
            encodedImageData = ConvertToBinaryString(eoi, codeSize) + encodedImageData;

            return encodedImageData;
        }

        /// <summary>
        ///     Returns the starting LZW code size.
        /// </summary>
        /// <param name="imageDataDictionaryCount"></param>
        /// <returns></returns>
        private double GetLZWStartingCodeSize(int imageDataDictionaryCount)
        {
            // The relationship between LZW starting code size
            // and the GCTS (global color table size) is:
            //      GCTS + 1 = starting LZW code size
            BitArray GCTS = LogicalScreenDescriptorGlobalColorTableSize(imageDataDictionaryCount);
            byte[] bytes = new byte[1];
            GCTS.CopyTo(bytes, 0);

            return (double)bytes[0] + 1.0;
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

            // Add additional placeholders if we do not have the same
            // number of colors that match the GCTS (global color table size)
            BitArray GCTS = LogicalScreenDescriptorGlobalColorTableSize();
            byte[] bytes = new byte[1];
            GCTS.CopyTo(bytes, 0);

            for (int i = sizeOfColorTable; i < (int)Math.Pow(2.0, (bytes[0] + 1)); i++)
            {
                dictionary.Add(i.ToString(), i);
            }

            // Add additional codes after
            dictionary.Add(dictionary.Count.ToString(), dictionary.Count); // Clear color code
            dictionary.Add(dictionary.Count.ToString(), dictionary.Count); // End of information code

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

            byte[] lzwMinimumCodeSize = new byte[1];
            LogicalScreenDescriptorGlobalColorTableSize(
                    LZWEncodedImageDataDictionary().Count).CopyTo(lzwMinimumCodeSize, 0);

            output.Write(lzwMinimumCodeSize[0]); // The LZW minimum code size

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
            if (working.Length >= 1 && working.Length < 8)
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
                return bytes.Length - startIndex;
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