﻿using System;
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
        public UInt32       Unknown             { get; private set; }
        public UInt32       CategoryCount       { get; private set; }
        public UInt32       AnimationCount      { get; private set; }
        public UInt32       UnkSectorEntryCount { get; private set; }
        public UInt32       NegativesCount      { get; private set; }
        public UnknownField Zero4               { get; private set; }
        public UnknownField Zero5               { get; private set; }
        public UInt32       OffsetBlend         { get; private set; }
        public UnknownField Zero6               { get; private set; }
        public UInt32       OffsetCategory      { get; private set; }
        public UInt32       OffsetEvents        { get; private set; }
        public UInt32       OffsetUnknownSector { get; private set; }
        public UInt32       OffsetNegatives     { get; private set; }
        public UInt32       OffsetNulls         { get; private set; }
        public UInt32       NullsCount          { get; private set; }
        public UInt32       OffsetAnimation     { get; private set; }
        public UnknownField Zero7               { get; private set; }
        public UInt32       OffsetSKL           { get; private set; }
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
            Unknown = br.ReadUInt32();
            CategoryCount = br.ReadUInt32();
            AnimationCount = br.ReadUInt32();
            UnkSectorEntryCount = br.ReadUInt32();
            NegativesCount = br.ReadUInt32();
            Zero4 = new UnknownField(br.ReadUInt32(), 48, 4);
            Zero5 = new UnknownField(br.ReadUInt32(), 52, 4);

            OffsetBlend = (UInt32)br.BaseStream.Position;
            OffsetBlend += br.ReadUInt32();

            Zero6 = new UnknownField(br.ReadUInt32(), 60, 4);

            OffsetCategory = (UInt32)br.BaseStream.Position;
            OffsetCategory += br.ReadUInt32();

            OffsetEvents = (UInt32)br.BaseStream.Position;
            OffsetEvents += br.ReadUInt32();

            OffsetUnknownSector = (UInt32)br.BaseStream.Position;
            OffsetUnknownSector += br.ReadUInt32();

            OffsetNegatives = (UInt32)br.BaseStream.Position;
            OffsetNegatives += br.ReadUInt32();

            OffsetNulls = (UInt32)br.BaseStream.Position;
            OffsetNulls += br.ReadUInt32();

            NullsCount = br.ReadUInt32();

            OffsetAnimation = (UInt32)br.BaseStream.Position;
            OffsetAnimation += br.ReadUInt32();

            Zero7 = new UnknownField(br.ReadUInt32(), 80, 4);

            OffsetSKL = (UInt32)br.BaseStream.Position;
            OffsetSKL += br.ReadUInt32();

            Zero8 = new UnknownField(br.ReadUInt32(), 84, 4);
        }
    }
}
