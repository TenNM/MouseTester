using System.Collections.Generic;
using System.Drawing;
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
            scrollLabelPos = CycleInt(10, scrollLabelPos);
            textBoxClickPos.Text = scrollLabelPos.ToString();

            if (e.Delta > 0)
            {
                scrollLabels[scrollLabelPos].Text = "/\\";
                scrollLabels[scrollLabelPos].ForeColor = Color.Green;
                textBoxButtonName.Text = "Wheel up";
                scrollLabelPos--;
            }
            else
            {
                scrollLabels[scrollLabelPos].Text = "\\/";
                scrollLabels[scrollLabelPos].ForeColor = Color.Orange;
                textBoxButtonName.Text = "Wheel down";
                scrollLabelPos++;
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            textBoxClickPos.Text = e.Location.ToString();
            textBoxButtonName.Text = e.Button.ToString();
            ColorizePanel(downColor, e);
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            ColorizePanel(this.BackColor, e);      
        }

        private void ColorizePanel(Color c, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left: panelL.BackColor = c; break;
                case MouseButtons.Middle: panelM.BackColor = c; break;
                case MouseButtons.Right: panelR.BackColor = c; break;
                case MouseButtons.XButton1: panelX1.BackColor = c; break;
                case MouseButtons.XButton2: panelX2.BackColor = c; break;
            }
        }

        private int CycleInt(int n, int i)
        {
            return (i % n + n) % n;
        }
  
    }//class
}
