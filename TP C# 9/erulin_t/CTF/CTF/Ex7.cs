using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTF
{
    class Ex7 : ExX
    {
        # region Attributes
        byte[] memory; /* Program memory */
        int pointer;   /* Index in memory */
        int ip;        /* Instruction pointer ( Index in code ) */
        string output; /* Program output */
        string code;   /* Brainfuck code to process */
        /* FIXME */
        # endregion

        # region Constructor
        public Ex7(string name)
            : base(name)
        {
            
        }
        # endregion
        # region Methodes
        public override string solve(string question)
        {
            code = question;
            ip = 0;
            pointer = 0;
            output = "";
            memory = new byte[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            /* FIXME : Some initialization , memory = 0, ip = 0, pointer = 0
            */

            while (ip < code.Length)
            {
                char instr = code[ip];
                ip++;
                process_instr(instr);
                /* FIXME */
                /* Store the instruction */
                /* Move forward the instruction pointer */
                /* Process the instruction */
            }

            return output;
        }
        private void process_instr(char instr)
        {
            switch (instr)
            {
                case '.':
                    output += (char)memory[pointer];
                    break;
                case '+':
                    memory[pointer]++;
                    break;
                case '-':
                    memory[pointer]--;
                    break;
                case '>':
                    pointer++;
                    break;
                case '<':
                    pointer--;
                    break;
                case '[':
                    if (memory[pointer] == 0)
                    {
                        int i = 0;
                        bool back = false;
                        while (!back)
                        {

                            ip++;
                            if (code[ip] == ']')
                                i--;
                            if (code[ip] == '[')
                                i++;
                            back = code[ip] == '[' && i == 0;
                        }
                    }
                        
                    break;
                case ']':
                    if (memory[pointer] != 0)
                    {
                        int i = 0;
                        bool back = false;
                        while (!back)
                        {

                            ip--;
                            if (code[ip] == ']')
                                i--;
                            if (code[ip] == '[')
                                i++;
                            back = code[ip] == '[' && i == 0;
                        }
                        
                    }                       
                    break; 
                default:
                    break;
            }
        }
        /* FIXME */
        # endregion
    }
}
