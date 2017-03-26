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
        public BLNDEntry(UInt32 Offset, BinaryReader br)
        {
            this.Offset = Offset;
        }
        public void Load(BinaryReader br)
        {

        }
    }
}
