using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Timers;



namespace WordPad_X
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            rchTxtBoxWrdPad.Visible = true;
            rchTxtBoxWrdPad.ReadOnly = false;
        }


        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
        
        }


        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close(); // Close form
        }


        private void aboutWordpadToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void rchTxtBoxWrdPad_TextChanged(object sender, EventArgs e)
        {

        }

        private void chkCharacterCounter_CheckedChanged(object sender, EventArgs e)
        {
            System.Timers.Timer aTimer;

            if (chkCharacterCounter.Checked)
            {
                
                aTimer = new System.Timers.Timer();
                aTimer.Interval = 3000;
                aTimer.Start();
                aTimer.Elapsed += ATimer_Elapsed; 
                aTimer.AutoReset = true;
                aTimer.Enabled = true;    
               
            }

        }
        private void ATimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Thread thread1 = new Thread(counter);
            thread1.Start();

        }
        private void counter()
        {
            if (InvokeRequired)
            {
                int x, y, z;
                char[] delimiters = new char[] { ' ', '\r', '\n'};

                this.Invoke(new MethodInvoker(delegate {
                    string whole_text = rchTxtBoxWrdPad.Text;
                    x = whole_text.Split(delimiters).Length;
                    y = whole_text.Length;
                    z = (y - x) + 1;
                    txtCharacterCount.Text = Convert.ToString(z);
                    
                }));

                Thread.Sleep(1000);


            }
            
        }
    }
}
