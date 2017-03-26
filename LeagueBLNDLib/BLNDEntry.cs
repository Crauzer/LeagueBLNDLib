using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LeagueBLNDLib
{
    public class BLNDEntry
    {
        public byte[] Data     { get; private set; }
        public UInt32 Offset   { get; private set; }
        public UInt32 Size     { get; private set; }
        public UInt32 Flag     { get; private set; }
        public UInt32 Index    { get; private set; }
        public UInt32 Length1  { get; private set; }
        public UInt32 Length2  { get; private set; }
        public string Name     { get; private set; }
        public UInt32 DataFlag { get; private set; }
        public BLNDEntry(UInt32 Offset, UInt32 returnOffset, int entryIndex, BinaryReader br)
        {
            this.Offset = (UInt32)(Offset - entryIndex * 4);
            br.Seek(this.Offset, SeekOrigin.Begin);
            Size = br.ReadUInt32();
            Flag = br.ReadUInt32();
            Index = br.ReadUInt32();
            Length1 = br.ReadUInt32();
            Length2 = br.ReadUInt32();
            Name = br.ReadString(4);
            DataFlag = br.ReadUInt32();
            br.Seek(returnOffset + 4, SeekOrigin.Begin);
        }
    }
}
