using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMiniMips
{
    class ALU
    {
        int zero = 0;
        int a0 = 8;
        int v0 = 2;
        int ra = 31;
        int sp = 29;
        CPU cpu;
        public ALU(CPU cpu)
        {
            this.cpu = cpu;
        }
        public void Exec(Instruction i)
        {
            Console.Write("[my_minimips] Executing pc = 0x{0}: 0x{1}: ", cpu.program_counter.ToString("X8"), i.ins.ToString("X8"));
            switch (i.Op)
            {
                case 0:
                    #region R Instructions
                    switch (i.Funct)
                    {
                        case 12:
                            #region syscall
                            Console.Write("syscall \n");
                            switch (cpu.registres[2])
                            {
                                case 1:
                                    Console.WriteLine(cpu.registres[a0]);
                                    break;
                                case 4:
                                    int pos = cpu.registres[a0];
                                    string str = "";
                                    while (cpu.ram[pos] != 0)
                                    {
                                        str += (char)cpu.ram[pos];
                                        pos++;
                                    }
                                    Console.WriteLine(str);

                                    break;
                                case 5:
                                    Console.WriteLine("enter int");
                                    if (!int.TryParse(Console.ReadLine(), out cpu.registres[v0]))
                                        Console.WriteLine("Invalid int!");
                                    break;
                                case 10:
                                    return;
                                case 11:
                                    Console.Write((char)cpu.registres[a0]);
                                    break;
                            }
#endregion
                            break;
                        case 32:
                            //add
                            Console.Write("add r{0}, r{1}, r{2} \n",i.Rd, i.Rs, i.Rt);
                            cpu.registres[i.Rd] = cpu.registres[i.Rs] + cpu.registres[i.Rt];
                            break;
                        case 33:
                            //addu
                            Console.Write("addu r{0}, r{1}, r{2} \n", i.Rd, i.Rs, i.Rt);
                            cpu.registres[i.Rd] = (int)((uint)cpu.registres[i.Rs] + (uint)cpu.registres[i.Rt]);
                            break;
                        case 34:
                            //sub
                            Console.Write("sub r{0}, r{1}, r{2} \n", i.Rd, i.Rs, i.Rt);
                            cpu.registres[i.Rd] = cpu.registres[i.Rs] - cpu.registres[i.Rt];
                            break;
                    }
                    #endregion
                    break;
                #region I instructions
                case 8:
                    //addi
                    Console.Write("addi r{0}, r{1}, {2} \n", i.Rt, i.Rs, (short)i.Imm);
                    cpu.registres[i.Rt] = cpu.registres[i.Rs] + (short)(i.Imm);
                    break;
                case 33:
                    //addiu
                    Console.Write("addiu r{0}, r{1}, {2} \n", i.Rt, i.Rs, (short)i.Imm);
                    cpu.registres[i.Rt] = (int)((uint)cpu.registres[i.Rs] + (short)i.Imm);
                    break;
                case 34:
                    //ori
                    Console.Write("ori r{0}, r{1}, {2} \n", i.Rt, i.Rs, i.Imm);
                    cpu.registres[i.Rt] = cpu.registres[i.Rs] + i.Imm;
                    break;
                case 4:
                    //beq
                    Console.Write("beq r{0}, r{1}, {2} \n", i.Rt, i.Rs, i.Imm);
                    if (cpu.registres[i.Rs] == cpu.registres[i.Rt])
                        cpu.program_counter  = cpu.program_counter +  i.Imm;
                    break;
                case 5:
                    //bne
                    Console.Write("bne r{0}, r{1}, {2} \n", i.Rt, i.Rs, i.Imm);
                        if (cpu.registres[i.Rs] != cpu.registres[i.Rt])
                            cpu.program_counter  = cpu.program_counter + i.Imm;
                    break;
                #endregion
                #region J instructions
                case 2:
                    //j
                    Console.Write("j 0x{0} \n", i.Addr.ToString("X8"));
                    cpu.program_counter = i.Addr;
                    break;
                case 3:
                    //jal
                    Console.Write("jal 0x{0} \n", i.Addr.ToString("X8"));
                    cpu.registres[ra] = cpu.program_counter + 8;
                    cpu.program_counter = i.Addr;
                    break;
                #endregion
                default:
                    Console.Write("error! instruction unknown \n");
                    break;
            }

        }
        public void run()
        {
            while (cpu.program_counter < cpu.filesize)
            {
                int c = cpu.program_counter;
                Instruction i = new Instruction((cpu.ram[c] << 24) + (cpu.ram[c + 1] << 16) + (cpu.ram[c + 2] << 8) + cpu.ram[c + 3]);
                Exec(i);
                cpu.program_counter += 4;
            }
        }
    }
}
