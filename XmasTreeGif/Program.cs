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
                    array[6] = false; array[5] = false; array[4] = true; // color resolution
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

                    // graphic control extension
                    //outputFile.Write(Convert.ToByte(21)); // extension introducer
                    //outputFile.Write(Convert.ToByte(0xf9)); // graphic control label
                    //outputFile.Write(Convert.ToByte(4)); // byte size
                    //outputFile.Write(Convert.ToByte(0)); // packed field
                    //outputFile.Write(Convert.ToInt16(0)); // delay time
                    //outputFile.Write(Convert.ToByte(0)); // transparent color index
                    //outputFile.Write(Convert.ToByte(0)); // block terminator

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
                    pixelData.Add(2);

                    string result = LZW(pixelData);

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
}