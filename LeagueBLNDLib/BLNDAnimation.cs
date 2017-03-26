using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueBLNDLib
{
    public class BLNDAnimation
    {
        public string Name   { get; private set; }
        public UInt32 Hash   { get; private set; }
        public UInt32 Offset { get; private set; }
        public BLNDAnimation(BinaryReader br)
        {
            Hash = br.ReadUInt32();
            Offset = (UInt32)br.BaseStream.Position;
            Offset += br.ReadUInt32();
        }
        public void Rename(string Name)
        {
            this.Name = Name;
        }
    }
}
