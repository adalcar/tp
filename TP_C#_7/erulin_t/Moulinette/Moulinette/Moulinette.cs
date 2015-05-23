using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace Moulinette
{
    class Moulinette
    {
        private List<Correction> listCorrection;
        private List<Rendu> listRendu;

        public Moulinette() 
        {
            listCorrection = new List<Correction>();
            listRendu = new List<Rendu>();
            Console.WriteLine("Moulinete v1.7734 (sabaton ftw)");
            Console.WriteLine("Author: erulin_t aka Adalcar");
            Console.WriteLine("SUPD2 2014/2015, all rights reserved");
        }

        public bool init() 
        {
            Console.Write("\n\n #---------------#\n");
            DirectoryInfo d = new DirectoryInfo("correction");
            foreach (DirectoryInfo f in d.GetDirectories())
            {
                listCorrection.Add(new Correction(f.FullName));
            }
            d = new DirectoryInfo("rendu");
            foreach (DirectoryInfo f in d.GetDirectories())
            {
                listRendu.Add(new Rendu(f.FullName));
            }
            if (listCorrection.Count != 0)
            {
                foreach (Correction c in listCorrection)
                    c.init();
                Console.Write(listCorrection.Count + " Corrections found!\n");
                if (listRendu.Count != 0)
                {
                    Console.Write(listRendu.Count + " Rendus found!\n");
                    return true;
                }
                else
                {
                    Console.Write("Report classe de branleurs! pas de rendus!");
                    return false;
                }
            }
                
            else
            {
                Console.WriteLine("\n Pas de corrections?!!??!");
                return false;
            }
        }

        public void execute() 
        {
            foreach (Rendu r in listRendu)
            {
                Console.Write("\n #---------------#\n");
                r.init();
                int i = r.runCorrection(listCorrection);
                Console.Write("Grade : {0}% ({1}/{2})\n", (i * 100) / listCorrection.Count, i, listCorrection.Count);

            }
        }
    }
}
