using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;

namespace PingChecker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ping p = new Ping();
            
            try
            {
                PingReply pr;
                if(textBox1.Text.Contains(":"))
                {
                    pr = p.Send(textBox1.Text.Substring(0,textBox1.Text.IndexOf(':')));
                }
                else {
                    pr = p.Send(textBox1.Text);
                }
               
                textBox2.Text = pr.RoundtripTime.ToString() + "ms";
                long prr = pr.RoundtripTime;
                if (prr > 0 && prr <= 10)
                { textBox3.Text = "Excellent"; }
                if (prr > 10 && prr <= 100)
                { textBox3.Text = "Good"; }
                if (prr > 100 && prr <= 200)
                { textBox3.Text = "Satisfactory"; }
                if (prr > 200)
                { textBox3.Text = "Poor"; }
                if(prr==0)
                { textBox3.Text = "Error"; }
            }
            catch(PingException)
            {
                    textBox2.Text = "Error";
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
