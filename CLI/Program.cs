using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueBLNDLib;
using System.IO;

namespace CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            BLNDFile blnd = new BLNDFile("SightWardBattleCast.blnd");
        }
    }
}

/*DirectoryInfo rootCharacters = new DirectoryInfo(@"C:\WooxyPortable\extract\files\lol_game_client\DATA\Characters");
            DirectoryInfo[] characters = rootCharacters.GetDirectories();
            for(int i = 0; i < characters.Length; i++)
            {
                FileInfo[] files = characters[i].GetFiles();
                DirectoryInfo[] directories = characters[i].GetDirectories();
                DirectoryInfo[] skins;
                for(int j = 0; j < files.Length; j++)
                {
                    if(files[j].Extension == ".blnd")
                    {
                        new BLNDFile(files[j].FullName).Dump(files[j].Name + ".txt");
                    }
                }
                for(int j = 0; j < directories.Length; j++)
                {
                    if(directories[j].Name == "Skins")
                    {
                        skins = directories[j].GetDirectories();
                    }
                }
            }*/
