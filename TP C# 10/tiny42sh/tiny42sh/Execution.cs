using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace tiny42sh
{
    
    
    class Execution
    {
        public static Dictionary<int,string> errors = new Dictionary<int, string>()
        {
            {1,"No such file or directory"},
            {2,"Is not a directory"},
            {3,"Is not a File"},
            {4,"invalid number of arguments"},
        };
        #region executors
        static private int execute_command(string[] cmd)
        {
            int k = 0;
            Keyword first = Interpreter.is_keyword(cmd[0]);
            switch (first)
            {
                case Keyword.cat:
                    break;
                case Keyword.cd:
                    k = execute_cd(cmd);
                    if(k != 0)
                        Console.WriteLine("cd: {0}: {1}" ,cmd[1],errors[k]);
                    break;
                case Keyword.clear:
                    break;
                case Keyword.ls:
                    k = execute_ls(cmd);
                    break;
                case Keyword.mkdir:

                    break;
                case Keyword.pwd:
                    break;
                case Keyword.rm:
                    if (k != 0)
                        Console.WriteLine("rm: {0}: {1}", cmd[1], errors[k]);
                    break;
                case Keyword.rmdir:
                    if (k != 0)
                        Console.WriteLine("rmdir: {0}: {1}", cmd[1], errors[k]);
                    break;
                case Keyword.touch:
                    break;
                case Keyword.unknown:
                    Console.WriteLine("Unknown command: " + cmd[0]);
                    break;
                case Keyword.whoami:
                    break;
                case Keyword.crash:
                    break;
            }
            return 0;
        }


        public static int execute_input(string[][] input)
        {
            int i = 0;
            foreach (string[] s in input)
            {
                i = execute_command(s);

                Console.WriteLine("**********************");
            }
                
            return i;
        }
        #endregion

        #region Cmd_ex
        private static int show_content(string entry)
        {
            Console.WriteLine();
            if (Directory.Exists(entry))
                foreach (string s in Directory.EnumerateFileSystemEntries(entry))
                {

                    
                    if(Directory.Exists(s))
                        Console.WriteLine(Path.GetFileName(s) + "/");
                    else
                        Console.WriteLine(Path.GetFileName(s));
                }

            else
                if (File.Exists(entry))
                    Console.WriteLine(entry);
                else
                    return 1;
            return 0;

        }
        private static int execute_ls(string[] cmd)
        {
            int k = 0;
            if (cmd.Length == 1)
                k = show_content(Directory.GetCurrentDirectory());
            else
                for (int i = 1; i < cmd.Length; i++)
                {
                    k = show_content(cmd[i]);
                    if(k != 0)
                        Console.WriteLine("ls: {0}: " + errors[k],cmd[i]);
                }



            Console.WriteLine();
            return 0;
        }

        private static int execute_cd(string[] cmd)
        {
            if (cmd.Length != 2)
                return 4;
            else
            {
                if (Directory.Exists(cmd[1]))
                    Directory.SetCurrentDirectory(cmd[1]);
                else
                    if (File.Exists(cmd[1]))
                        return 2;
                    else
                        return 1;
            }
            return 0;
        }

        private static int execute_cat(string[] cmd)
        {
            if (cmd.Length == 1)
                return 4;
            else
                for (int i = 1; i < cmd.Length; i++)
                {
                    if (File.Exists(cmd[i]))
                    {
                        File.ReadAllBytes()
                    }
                }

        }
        #endregion
    }
}
