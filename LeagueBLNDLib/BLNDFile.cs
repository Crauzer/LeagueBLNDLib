using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueBLNDLib
{
    public class BLNDFile
    {
        public BLNDHeader          Header;
        public List<BLNDBlend>     Blends     { get; private set; } = new List<BLNDBlend>();
        public List<BLNDEntry>     Entries    { get; private set; } = new List<BLNDEntry>();
        public List<BLNDCategory>  Categories { get; private set; } = new List<BLNDCategory>();
        public List<BLNDAnimation> Animations { get; private set; } = new List<BLNDAnimation>();
        public string              Skeleton   { get; private set; }

        public BLNDFile(string fileLocation)
        {
            using (BinaryReader br = new BinaryReader(File.OpenRead(fileLocation)))
            {
                Header = new BLNDHeader(br);

                br.Seek(Header.OffsetBlend, SeekOrigin.Begin);
                for(int i = 0; i < Header.BlendCount; i++)
                {
                    Blends.Add(new BLNDBlend(br));
                }

                br.Seek(Header.offsetCategory, SeekOrigin.Begin);
                for(int i = 0; i < Header.CategoryCount; i++)
                {
                    Categories.Add(new BLNDCategory(br));
                }

                br.Seek(Header.offsetOffsetEntries, SeekOrigin.Begin);
                for(int i = 0; i < Header.EntriesCount; i++)
                {
                    Entries.Add(new BLNDEntry(br.ReadUInt32(), br));
                }

                br.Seek(Header.offsetAnimation, SeekOrigin.Begin);
                for(int i = 0; i < Header.AnimationCount; i++)
                {
                    Animations.Add(new BLNDAnimation(br));
                }

                br.Seek(Header.offsetSKL, SeekOrigin.Begin);
                Skeleton = br.ReadString(4);

                foreach(BLNDBlend blend in Blends)
                {
                    blend.AssignEntries(Entries[(int)blend.FromBlend], Entries[(int)blend.ToBlend]);
                }
            }
        }
    }
}
