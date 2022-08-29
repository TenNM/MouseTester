using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MouseTester
{
    public partial class Form1 : Form
    {
        Color downColor = Color.GreenYellow;
        List<Label> scrollLabels;
        int scrollLabelPos = 0;
        public Form1()
        {
            InitializeComponent();
            this.MouseWheel += Form1_MouseWheel;
            scrollLabels = new List<Label> { label1, label2, label3, label4, label5, label6, label7, label8, label9, label10 };
        }

        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            textBoxClickPos.Text = e.Location.ToString();
            if (e.Delta > 0)
            {
                scrollLabels[scrollLabelPos % 10].Text = "/\\";
                textBoxButtonName.Text = "Wheel up";
                scrollLabels[scrollLabelPos % 10].ForeColor = Color.Blue;
            }
            else
            {
                scrollLabels[scrollLabelPos % 10].Text = "\\/";
                textBoxButtonName.Text = "Wheel down";
                scrollLabels[scrollLabelPos % 10].ForeColor = Color.Black;
            }
            scrollLabelPos++;
            
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            textBoxClickPos.Text = e.Location.ToString();
            textBoxButtonName.Text = e.Button.ToString();
            switch (e.Button)
            {
                case MouseButtons.Left: panelL.BackColor = downColor; break;
                case MouseButtons.Middle: panelM.BackColor = downColor; break;
                case MouseButtons.Right: panelR.BackColor = downColor; break;
                case MouseButtons.XButton1: panelX1.BackColor = downColor; break;
                case MouseButtons.XButton2: panelX2.BackColor = downColor; break;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left: panelL.BackColor = this.BackColor; break;
                case MouseButtons.Middle: panelM.BackColor = this.BackColor; break;
                case MouseButtons.Right: panelR.BackColor = this.BackColor; break;
                case MouseButtons.XButton1: panelX1.BackColor = this.BackColor; break;
                case MouseButtons.XButton2: panelX2.BackColor = this.BackColor; break;
            }
        }

        private void ColorizePanel(Color c)
        {

        }

       
    }//class
}
