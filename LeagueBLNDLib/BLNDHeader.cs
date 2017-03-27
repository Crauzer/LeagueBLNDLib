using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static Utilities;

namespace LeagueBLNDLib
{
    public class BLNDHeader
    {
        public string       Magic               { get; private set; }
        public UInt32       Version             { get; private set; }
        public UnknownField Zero1               { get; private set; }
        public UInt32       CreationID          { get; private set; }
        public UnknownField Zero2               { get; private set; }
        public UInt32       EntriesCount        { get; private set; }
        public UInt32       BlendCount          { get; private set; }
        public UInt32       SkinID              { get; private set; }
        public UInt32       CategoryCount       { get; private set; }
        public UInt32       AnimationCount      { get; private set; }
        public UInt32       UnkSectorEntryCount { get; private set; }
        public UInt32       NegativesCount      { get; private set; }
        public UnknownField Zero4               { get; private set; }
        public UnknownField Zero5               { get; private set; }
        public UInt32       OffsetBlend         { get; private set; }
        public UnknownField Zero6               { get; private set; }
        public UInt32       offsetCategory      { get; private set; }
        public UInt32       offsetOffsetEntries { get; private set; }
        public UInt32       offsetUnknownSector { get; private set; }
        public UInt32       offsetNegatives     { get; private set; }
        public UInt32       offsetNulls         { get; private set; }
        public UInt32       NullsCount          { get; private set; }
        public UInt32       offsetAnimation     { get; private set; }
        public UnknownField Zero7               { get; private set; }
        public UInt32       offsetSKL           { get; private set; }
        public UnknownField Zero8               { get; private set; }
        public const int    Size                = 108;
        public BLNDHeader(BinaryReader br)
        {
            if((Magic = Encoding.ASCII.GetString(br.ReadBytes(8))) != "r3d2blnd")
            {
                throw new Exception("Not a BLND file");
            }
            if ((Version = br.ReadUInt32()) != 1)
            {
                throw new Exception("Invalid BLND version");
            }
            Zero1 = new UnknownField(br.ReadUInt32(), 12, 4);
            CreationID = br.ReadUInt32();
            Zero2 = new UnknownField(br.ReadUInt32(), 18, 4);
            EntriesCount = br.ReadUInt32();
            BlendCount = br.ReadUInt32();
            SkinID = br.ReadUInt32();
            CategoryCount = br.ReadUInt32();
            AnimationCount = br.ReadUInt32();
            UnkSectorEntryCount = br.ReadUInt32();
            NegativesCount = br.ReadUInt32();
            Zero4 = new UnknownField(br.ReadUInt32(), 48, 4);
            Zero5 = new UnknownField(br.ReadUInt32(), 52, 4);

            OffsetBlend = (UInt32)br.BaseStream.Position;
            OffsetBlend += br.ReadUInt32();

            Zero6 = new UnknownField(br.ReadUInt32(), 60, 4);

            offsetCategory = (UInt32)br.BaseStream.Position;
            offsetCategory += br.ReadUInt32();

            offsetOffsetEntries = (UInt32)br.BaseStream.Position;
            offsetOffsetEntries += br.ReadUInt32();

            offsetUnknownSector = (UInt32)br.BaseStream.Position;
            offsetUnknownSector += br.ReadUInt32();

            offsetNegatives = (UInt32)br.BaseStream.Position;
            offsetNegatives += br.ReadUInt32();

            offsetNulls = (UInt32)br.BaseStream.Position;
            offsetNulls += br.ReadUInt32();

            NullsCount = br.ReadUInt32();

            offsetAnimation = (UInt32)br.BaseStream.Position;
            offsetAnimation += br.ReadUInt32();

            Zero7 = new UnknownField(br.ReadUInt32(), 80, 4);

            offsetSKL = (UInt32)br.BaseStream.Position;
            offsetSKL += br.ReadUInt32();

            Zero8 = new UnknownField(br.ReadUInt32(), 84, 4);
        }
    }
}
