using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MyMiniMips
{
    class CPU
    {
        public byte[] ram;
        public int[] registres = new int[32];
        public int program_counter, filesize;
        public CPU(string fileName)
        {
            program_counter = 0;
            registres[0] = 0;
            loadFile(fileName);
        }
        public void loadFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                ram = File.ReadAllBytes(fileName);
                filesize = ram.Length;
                Array.Resize<byte>(ref ram, 0x10000);
            }
            else
                Console.Write("ERROR: file does not exist!");
        }
    }
}
