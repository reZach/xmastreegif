using System;
using System.IO;

namespace Sample
{
    public class Sample
    {
        public static void Main(string[] args)
        {
            using (FileStream fileStream = new FileStream(@"C:\folder\newfile.gif", FileMode.Create))
            {
                using (BinaryWriter binaryWriter = new BinaryWriter(fileStream))
                {
                    // header
                    binaryWriter.Write(new char[3] { 'G', 'I', 'F' });
                    binaryWriter.Write(new char[3] { '8', '9', 'a' });

                    // logical screen descriptor
                    binaryWriter.Write((ushort)2);
                    binaryWriter.Write((ushort)2);
                    binaryWriter.Write((byte)0x91);
                    binaryWriter.Write((byte)0);
                    binaryWriter.Write((byte)0);

                    // global color table
                    binaryWriter.Write((byte)255);
                    binaryWriter.Write((byte)255);
                    binaryWriter.Write((byte)255);
                    binaryWriter.Write((byte)0);
                    binaryWriter.Write((byte)0);
                    binaryWriter.Write((byte)0);
                    binaryWriter.Write((byte)255);
                    binaryWriter.Write((byte)0);
                    binaryWriter.Write((byte)0);
                    binaryWriter.Write((byte)0);
                    binaryWriter.Write((byte)255);
                    binaryWriter.Write((byte)0);

                    // application extension
                    binaryWriter.Write((byte)0x21);
                    binaryWriter.Write((byte)0xff);
                    binaryWriter.Write((byte)0x0b);
                    binaryWriter.Write('N');
                    binaryWriter.Write('E');
                    binaryWriter.Write('T');
                    binaryWriter.Write('S');
                    binaryWriter.Write('C');
                    binaryWriter.Write('A');
                    binaryWriter.Write('P');
                    binaryWriter.Write('E');
                    binaryWriter.Write('2');
                    binaryWriter.Write('.');
                    binaryWriter.Write('0');
                    binaryWriter.Write((byte)3);
                    binaryWriter.Write((byte)1);
                    binaryWriter.Write((byte)0xff);
                    binaryWriter.Write((byte)0xff);
                    binaryWriter.Write((byte)0);

                    // graphic control extension
                    binaryWriter.Write((byte)0x21);
                    binaryWriter.Write((byte)0xf9);
                    binaryWriter.Write((byte)4);
                    binaryWriter.Write((byte)4);
                    binaryWriter.Write((ushort)100);
                    binaryWriter.Write((byte)0);
                    binaryWriter.Write((byte)0);

                    // image descriptor
                    binaryWriter.Write((byte)0x2c);
                    binaryWriter.Write((ushort)0);
                    binaryWriter.Write((ushort)0);
                    binaryWriter.Write((ushort)2);
                    binaryWriter.Write((ushort)2);
                    binaryWriter.Write((byte)0);

                    // image data
                    binaryWriter.Write((byte)2);
                    binaryWriter.Write((byte)3);
                    binaryWriter.Write((byte)0xc4);
                    binaryWriter.Write((byte)0x14);
                    binaryWriter.Write((byte)5);
                    binaryWriter.Write((byte)0);

                    // terminating character
                    binaryWriter.Write((byte)0x3b);
                }
            }
        }
    }
}
