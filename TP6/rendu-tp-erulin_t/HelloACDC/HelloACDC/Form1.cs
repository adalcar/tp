using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloACDC
{
    public partial class Form1 : Form
    {
        private int button_setting = 0;
        public Form1()
        {
            InitializeComponent();
            button1.ForeColor = Color.White;
            button1.BackColor = Color.Blue;
            button1.Text = "HelloACDC";
        }

        private void button1_Click(object sender, EventArgs e)
        {   
            if (button_setting == 0) {
                button1.Text = "The Bullshit is strong with this one";
                button1.BackColor = Color.Red;
                button1.ForeColor = Color.Black;
                button_setting = 1;
            }
            else {
                button1.Text = "HelloACDC";
                button1.BackColor = Color.Blue;
                button1.ForeColor = Color.White;
                button_setting = 0;
            }
        }
    }
}
