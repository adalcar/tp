using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvader
{
    class Program
    {
        private static int lvl, Width, Heigth, score;
        static string enemy_design, player_design;
        private static bool bossOn;
        static Random rand = new Random();

        static void Main(string[] args)
        {
            player_design = "";
            enemy_design = "";
            lvl = get_param(ref player_design, ref enemy_design);
            Heigth = Console.LargestWindowHeight / 2;
            Width = Console.LargestWindowWidth / 2;

            Console.SetWindowSize(Width, Heigth);
            Console.SetBufferSize(Width, Heigth);
            Console.WindowLeft = 0;
            Console.WindowTop = 0;
            play_game();

        }

        static int get_param(ref string player_design, ref string enemy_design)
        {
            string[] players = new string[4] { "[_/|\\_]", "/|\\", "[|]", "(T)" };
            string[] enemies = new string[4] { "[:|:]", "\\v|v/", "\\|/", "(T)" };
            for(int i = 0; i < 4; i++)
            {
                Console.WriteLine("{0} : {1}", i + 1, players[i]); 
            }
            Console.WriteLine("5 : custom \n\nChoose player design");
            int choice = Convert.ToInt32(Console.ReadLine()) - 1;
            if (choice < 4 && choice >= 0)
                player_design = players[choice];
            else
            {
                Console.WriteLine("Enter player design");
                player_design = Console.ReadLine();
            }
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("{0} : {1}", i + 1, enemies[i]);
            }
            Console.WriteLine("5 : custom \n\nChoose enemy design");
            choice = Convert.ToInt32(Console.ReadLine()) - 1;
            if (choice < 4 && choice >= 0)
                enemy_design = enemies[choice];
            else
            {
                Console.WriteLine("Enter enemy design");
                enemy_design = Console.ReadLine();
            }


            Console.WriteLine("Enter level (1-100)");


            bool fail = true;
            int param = 1;
            while (fail)
            {
                try
                {
                    param = Convert.ToInt32(Console.ReadLine());
                    if (param < 1 || param > 100)
                        throw new Exception("value!");
                    fail = false;
                }
                catch (Exception e)
                {
                    if (e.Message == "value!")
                        Console.WriteLine("doit etre un entier compris entre 1 et 100");
                    else
                        Console.WriteLine("UN ENTIER J'AI DIT!!!!");
                }
            }
            return param;
        }



        static void play_game()
        {
            
            Console.Clear();
            bossOn = false;
            score = 0;
            int time = 0;
            int end = 0;
            Player p = new Player(player_design, Width / 2, Heigth - 1);
            List<Enemy> characs = new List<Enemy> { };

            for (int i = 0; i < Heigth - 1; i++)
            {
                Console.SetCursorPosition(Width - 7, i);
                Console.Write('|');
            }

            while (end == 0)
            {
                writeInfo(p.life,characs);
                time++;
                if (!bossOn)
                    for (int a = characs.Count - 1; a >= 0; a--)
                    {
                        if (characs[a].life == 0)
                        {
                            characs[a].clear_shots();
                            Console.SetCursorPosition(characs[a].x, characs[a].y);
                            Console.Write(characs[a].refresh_str);
                            characs.Remove(characs[a]);
                            score++;
                        }
                        else
                            if (!characs[a].arrived())
                                characs[a].update(time, p);
                            else
                            {
                                p.life -= 20;
                                Console.SetCursorPosition(characs[a].x, characs[a].y);
                                Console.Write(characs[a].refresh_str);
                                characs.Remove(characs[a]);
                            }
                    }
                else
                {
                    Boss b = (Boss) characs[0];
                    if (b.life == 0)
                    {
                        Console.SetCursorPosition(b.x, b.y);
                        Console.Write(b.refresh_str);
                        characs.Remove(b);
                        bossOn = false;
                        score++;
                    }
                    else
                        b.update(time,p);

                }


                if (time % (1800 - 10 * lvl) == 0 && !bossOn)
                    Spawn_enemy(characs);
                if (score % 50 == 0 && score != 0 && !bossOn)
                    spawn_boss(ref characs);
                if (Console.KeyAvailable)
                {
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.UpArrow:
                            if (!p.stunned)
                                p.shoot("!", -1, 20);
                            break;
                        case ConsoleKey.LeftArrow:
                            if (p.x > 1 && !p.stunned)
                                p.x -= 1;
                            break;
                        case ConsoleKey.RightArrow:
                            if (p.x + p.length < Width - 8 && !p.stunned)
                                p.x += 1;
                            break;
                        case ConsoleKey.Escape:
                            spawn_boss(ref characs);
                            break;
                        default:
                            break;
                    }
                }
                p.update(time, characs);
                if (p.life <= 0)
                    end = -1;
            }
            if (end != 2)
                finish(end == 1);
                
        }


        static void finish(bool victory)
        {
            Console.Clear();
            if (victory)
            {
                Console.WriteLine("You Win! try again? (y/n)");
                if (Console.ReadKey(true).KeyChar == 'y')
                    play_game();
                else
                    if (Console.ReadKey(true).KeyChar != 'n')
                        Console.Write("(y/n)");
            }
            else
            {
                Console.WriteLine("You Lose! try again? (y/n)");
                if (Console.Read() == 'y')
                    play_game();
                else
                    if (Console.ReadKey(true).KeyChar != 'n')
                        Console.Write("(y/n)");
            }

        }
        static void Spawn_enemy(List<Enemy> enemies)
        {

            //int posX = 0;
            //bool availiable = false;
            //while (!availiable)
            //{
            //    availiable = true;
            //    posX = rand.Next(Width - enemy_design.Length);
            //}
            if (!bossOn)
                enemies.Add(new Enemy(enemy_design, rand.Next(Width - 2 * enemy_design.Length - 9)
                                        + 1, 1, 800 - lvl * 6));
        }
        static void spawn_boss(ref List<Enemy> enemies)
        {
            foreach (Enemy e in enemies)
            {
                Console.SetCursorPosition(e.x, e.y);
                Console.Write(e.refresh_str);
            }
            bossOn = true;
            enemies.Clear();
            enemies.Add(new Boss());

        }
        static void writeInfo(int hp, List<Enemy> enemies)
        {
            Console.SetCursorPosition(Width - 6, 1);
            Console.Write("SCORE:");
            Console.SetCursorPosition(Width - 4, 2);
            Console.Write("     ");
            Console.SetCursorPosition(Width - 4, 2);
            Console.Write(score);
            Console.SetCursorPosition(Width - 4, 5);
            Console.Write("     ");
            Console.SetCursorPosition(Width - 6, 4);
            Console.Write("HP:");
            Console.SetCursorPosition(Width - 5, 5);
            Console.Write(hp);
            if (bossOn)
            {
                Console.SetCursorPosition(Width - 7, 6);
                Console.Write("BOSS HP:");
                Console.SetCursorPosition(Width - 4, 7);
                Console.Write("     ");
                Console.SetCursorPosition(Width - 4, 7);
                Console.Write(enemies[0].life);
                
            }

        }
    }
}
