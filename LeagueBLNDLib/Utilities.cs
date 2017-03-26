using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class Utilities
{
    public struct UnknownField
    {
        public object Field;
        public uint StructureOffset;
        public uint Size;
        public UnknownField(object Field, uint StructureOffset, uint Size)
        {
            this.Field = Field;
            this.StructureOffset = StructureOffset;
            this.Size = Size;
        }
    }

    public static void Seek(this BinaryReader br, uint offset, SeekOrigin origin)
    {
        br.BaseStream.Seek(offset, origin);
    }

    public static string ReadString(this BinaryReader br, int blockSize)
    {
        bool shouldStop = false;
        string toReturn = "";
        while (shouldStop != true)
        {
            toReturn += br.ReadChars(blockSize).GetCharBlock(out shouldStop);
        }
        return toReturn;
    }
    public static string GetCharBlock(this char[] charBlock, out bool shouldStop)
    {
        string toReturn = "";
        foreach (char c in charBlock)
        {
            if (c != '\u0000')
            {
                toReturn += c;
            }
            else
            {
                shouldStop = true;
                return toReturn;
            }
        }
        shouldStop = false;
        return toReturn;
    }
}
