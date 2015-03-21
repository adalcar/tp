using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyTicTacToe
{
    public partial class Form1 : Form
    {
        Button[,] jeu = new Button[3,3];
        int player;
        int acts;

        public Form1()
        {
            
            InitializeComponent();
            button10.Text = "reset";
            jeu[0,0] = button1;
            jeu[0,1] = button2;
            jeu[0,2] = button3;
            jeu[1,0] = button4;
            jeu[1,1] = button5;
            jeu[1,2] = button6;
            jeu[2,0] = button7;
            jeu[2,1] = button8;
            jeu[2,2] = button9;
            init_morpion();
        }

        public void init_morpion()
        {
            label1.Text = "Player1's turn";
            player = 1;
            acts = 0;
            foreach (Button b in jeu)
            {
                b.Enabled = true;
                b.Text = "";
            }
        }
        public void click(Button b, int A, int B)
        {
            if (player == 1)
            {
                label1.Text = "Player 2's turn ";
                b.Text = "X";
                player = 2;
            }
            else
            {
                label1.Text = "player 1's turn";
                b.Text = "O";
                player = 1;
            }
            b.Enabled = false;
            
            if (checkWin(A,B))
            {
                foreach(Button Case in jeu)
                {
                    Case.Enabled = false; 
                }
                if (player == 1)
                    label1.Text = "Player " + 2 + " wins! rematch?";
                else
                    label1.Text = "Player " + 1 + " wins! rematch?";
               
            }
            else
            {
                acts++;
                if (acts == 9)
                label1.Text = "Stalemate! retry?";
            }
            
        }
        
        public bool checkWin(int a, int b)
        {
            if (jeu[a, 0].Text == jeu[a, 1].Text &&
                jeu[a, 0].Text == jeu[a, 2].Text)
                return true;
            if (jeu[0, b].Text == jeu[1, b].Text && 
                jeu[0, b].Text == jeu[2, b].Text)
                return true;
            if (jeu[0, 0].Text == jeu[1, 1].Text &&
                jeu[0, 0].Text == jeu[2, 2].Text &&
                a == b)
                return true;
            if (jeu[0, 2].Text == jeu[1, 1].Text &&
                jeu[0, 2].Text == jeu[2, 0].Text &&
                a == 2-b)
                return true;
            return false;

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            click(button1, 0, 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            click(button2, 0, 1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            click(button3, 0, 2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            click(button4, 1, 0);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            click(button5, 1, 1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            click(button6, 1, 2);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            click(button7, 2, 0);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            click(button8, 2, 1);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            click(button9, 2, 2);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            init_morpion();
        }
    }
}
