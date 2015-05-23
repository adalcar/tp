using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace Moulinette
{
    class Rendu
    {
        private string folder;
        private List<Exo> listExo;

        public Rendu(string folderName) 
        {
            folder = folderName;
            listExo = new List<Exo> { };


        }
        public bool init()
        {
            DirectoryInfo d = new DirectoryInfo(folder);
            foreach (DirectoryInfo f in d.GetDirectories())
            {
                listExo.Add(new Exo(f.FullName));
            }
            return true;
        }
        public int runCorrection(List<Correction> listCorrection)
        {
            int points = 0;
            foreach (Correction c in listCorrection) 
            {
                if (listExo.Exists(x => x.getName() == c.getName()))
                {
                    Exo e = listExo.Find(x => x.getName() == c.getName());
                    if (e.execute())
                    {
                        if (e.getStderr() == c.getStderr() && e.getStdout() == c.getStdout())
                        {
                            points++;
                            Console.Write(e.getName() + ": OK \n");
                        }
                        else
                            Console.Write(e.getName() + ": FAIL\n");
                    }
                    else
                        Console.Write(e.getName() + ": error execute()!\n");
                }
                else
                    Console.Write(c.getName() + ": not found!\n");
                    
            }
            return points;
        }
    }
}
