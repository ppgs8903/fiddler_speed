using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Fiddler;
using System.Windows.Forms;

namespace fiddle_plugin
{
    public partial class fiddleSpeed_form : Form
    {
        public FiddleSpeed_x Fs;

        public fiddleSpeed_form(FiddleSpeed_x ff)
        {
            InitializeComponent();
            Fs = ff;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void fiddleSpeed_form_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Fs.down_Load = textBox1.Text.ToString();
            Fs.up_Load = textBox2.Text.ToString();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                textBox1.Text = "0";
            if (Convert.ToInt32(textBox1.Text) > 2048)
                textBox1.Text = "2048";
        }

        private void textBox2_TextChanged(object sender, EventArgs e){
            if (textBox2.Text == "")
                textBox2.Text = "0";
            if (Convert.ToInt32(textBox2.Text) > 2048)
                textBox2.Text = "2048";
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
           if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            textBox2.Text = "0";
            Fs.down_Load = "0";
            Fs.up_Load = "0";
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
               // checkBox3.Checked = true;
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                button1.Enabled = true;
                button2.Enabled = true;
                Fs.down_Load = textBox1.Text;
                Fs.up_Load = textBox2.Text;
            }
            else
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                button1.Enabled = false;
                button2.Enabled = false;
                Fs.down_Load = "0";
                Fs.up_Load = "0";
            }
        }
    }
}
