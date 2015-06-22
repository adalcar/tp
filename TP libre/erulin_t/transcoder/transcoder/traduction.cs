using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace transcoder
{
    class traduction
    {
        delegate char CtoC(char c);
        delegate int CtoI(char c);
        public static void translate(string filename, string outputname)
        {
            String text, translation;
            text = File.ReadAllText(filename);
            translation = "";
            Console.WriteLine("fichier charge \n" +
                              "quel code? \n\n" +
                              "1: morse \n" +
                              "2: decalage \n" +
                              "3: numerique \n" +
                              "4: vigenere \n" + 
                              "0: annuler \n");
            bool valid = false;
            while (!valid)
            {
                switch (Console.ReadKey(true).KeyChar)
                {
                    case '1':
                        #region morse
                        foreach(char c in text)
                        {
                            string ret;
                            if (!codes.morse.TryGetValue(Char.ToLower(c), out ret))
                                ret = c.ToString();
                            translation += ret + "/";
                        }
                        File.WriteAllText(outputname, translation);
                        valid = true;
                        break;
                    #endregion
                    case '2':
                        #region decal
                        Console.WriteLine("Decalage de combien?");
                        int k;
                        while (!int.TryParse(Console.ReadLine(), out k))
                            Console.WriteLine("entree invalide");
                        CtoC trans = (char c) => codes.decalage( c, k);
                        foreach (char c in text)
                             translation += trans(c);
                        File.WriteAllText(outputname, translation);
                        valid = true;
                        break;
                    #endregion
                    case '3':
                        #region tonum
                        Console.WriteLine("quel decalage?");
                        while (!int.TryParse(Console.ReadLine(), out k))
                            Console.WriteLine("entree invalide");
                        CtoI crypt = (char c) => codes.toNum(c, k);
                        foreach (char c in text)
                            translation += crypt(c).ToString() + '/';
                        File.WriteAllText(outputname, translation);
                        valid = true;
                        break;
                    #endregion
                    case '4':
                        #region Vigenere
                        Console.WriteLine("entrer la cle");
                        File.WriteAllText(outputname,codes.vigenere(Console.ReadLine().ToLower().Trim(' '), text));
                        valid = true;
                        break;
                    #endregion
                    case '0':
                        valid = true;
                        break;
                    default:
                        Console.WriteLine("entree invalide");
                        break;
                }
            }
        }
    }
}
