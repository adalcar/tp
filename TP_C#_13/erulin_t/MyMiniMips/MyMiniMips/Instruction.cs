using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMiniMips
{
    class Instruction
    {
        public int Op, Rs, Rt, Rd, Funct, Imm, Addr, ins;

        public Instruction(int ins)
        {
            this.ins = ins;
            Op = (ins >> 26) & 0x3F;
            Rs = ins & 0x3E00000 >> 21;
            Rt = ins & 0x1F0000 >> 16;
            Rd = ins & 0xF800 >> 11;
            Funct = ins & 0x3F;
            Imm = ins & 0xFFFF;
            Addr = ins & 0x3FFFFFF;
        }

    }
}
