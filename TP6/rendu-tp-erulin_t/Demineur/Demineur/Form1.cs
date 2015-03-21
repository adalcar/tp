using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demineur
{
    public partial class Form1 : Form
    {
        Random GetPos = new Random();
        Button[] places = new Button[9];
        TextBox t = new TextBox();
        private int clicks;
        private int MinePos;
        private Color basicColor;

        public Form1()
        {
            InitializeComponent();
            places[0] = Pos1;
            places[1] = Pos2;
            places[2] = Pos3;
            places[3] = Pos4;
            places[4] = Pos5;
            places[5] = Pos6;
            places[6] = Pos7;
            places[7] = Pos8;
            places[8] = Pos9;
            init_minesweeper();
            basicColor = Pos1.BackColor;
        }


        public void init_minesweeper()
        {
            clicks = 0;
            MinePos = GetPos.Next(1, 10);
            Control.Text = "...";
            Control.BackColor = Color.Blue;
            foreach (Button b in places)
            {
                b.BackColor = basicColor;
                b.Text = "";
                b.Enabled = true;
                t.Text = "new game";
            }
        }

        public void Not_boom(Button b)
        {
            b.BackColor = Color.Azure;
            b.Enabled = false;
            clicks++;
            if (clicks == 8)
                Win();
        }
        public void Mine_boom(Button b)
        {
            Control.Text = "BOOM";
            b.Text = "X";
            Control.BackColor = Color.Red;
            foreach (Button a in places)
            {
                a.Enabled = false;
            }
        }
        public void Win()
        {
            places[MinePos - 1].Enabled = false;
            places[MinePos - 1].ForeColor = Color.Red;
            places[MinePos - 1].Text = "!";
            Control.BackColor = Color.Green;
            Control.Text = "WIN !!";
        }

        private void Control_Click(object sender, EventArgs e)
        {
            t.Text = "Click!";
            init_minesweeper();
        }
        private void Pos1_Click(object sender, EventArgs e)
        {
            if (MinePos == 1)
                Mine_boom(Pos1);
            else
                Not_boom(Pos1);


        }
        private void Pos2_Click(object sender, EventArgs e)
        {
            if (MinePos == 2)
                Mine_boom(Pos2);
            else
                Not_boom(Pos2);
        }
        private void Pos3_Click(object sender, EventArgs e)
        {
            if (MinePos == 3)
                Mine_boom(Pos3);
            else
                Not_boom(Pos3);
        }
        private void Pos4_Click(object sender, EventArgs e)
        {
            if (MinePos == 4)
                Mine_boom(Pos4);
            else
                Not_boom(Pos4);

        }
        private void Pos5_Click(object sender, EventArgs e)
        {
            if (MinePos == 5)
                Mine_boom(Pos5);
            else
                Not_boom(Pos5);
        }
        private void Pos6_Click(object sender, EventArgs e)
        {
            if (MinePos == 6)
                Mine_boom(Pos6);
            else
                Not_boom(Pos6);
        }
        private void Pos7_Click(object sender, EventArgs e)
        {
            if (MinePos == 7)
                Mine_boom(Pos7);
            else
                Not_boom(Pos7);
        }
        private void Pos8_Click(object sender, EventArgs e)
        {
            if (MinePos == 8)
                Mine_boom(Pos8);
            else
                Not_boom(Pos8);
        }
        private void Pos9_Click(object sender, EventArgs e)
        {
            if (MinePos == 9)
                Mine_boom(Pos9);
            else
                Not_boom(Pos9);

        
        }
    }
}
