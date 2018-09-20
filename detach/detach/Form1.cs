using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace detach
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Gecko.Xpcom.Initialize(Application.StartupPath + "\\xulrunner");
            timer1.Interval = 200;
            //timer1.Start();
        }
        string link = "";
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.DefaultExt = "css";
            f.Filter = "(Các file excel)|*.html|(All file)|*";
            f.AddExtension = true;
            //f.Multiselect = true;
            f.RestoreDirectory = true;
            if (f.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            else
            {
                textBox1.Text = f.FileName;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                geckoWebBrowser1.Navigate(textBox1.Text);
                link = textBox1.Text;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox c = (CheckBox)sender;
            if (c.Checked)
            {
                timer1.Start();
            }
            else
            {
                timer1.Stop();
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox c = (CheckBox)sender;
            if (c.Checked)
            {
                this.TopMost = true;
            }
            else
            {
                this.TopMost = false;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
         
            try
            {
                geckoWebBrowser1.Navigate(link);
            }
            catch
            {

            }
        }
    }
}
