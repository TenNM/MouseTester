using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MouseTester
{
    public partial class Form1 : Form
    {
        Color downColor;
        List<Label> scrollLabels;
        int scrollLabelPos;
        Dictionary<MouseButtons, ButtonInfo> dictButtons;

        public Form1()
        {
            InitializeComponent();
            this.MouseWheel += Form1_MouseWheel;

            downColor = Color.GreenYellow;
            scrollLabels = new List<Label> { label1, label2, label3, label4, label5, label6, label7, label8, label9, label10 };
            scrollLabelPos = 0;
            dictButtons = new Dictionary<MouseButtons, ButtonInfo>()
            {
                { MouseButtons.Left, new ButtonInfo(panelL, numericUpDownL) },
                { MouseButtons.Middle, new ButtonInfo(panelM, numericUpDownM) },
                { MouseButtons.Right, new ButtonInfo(panelR, numericUpDownR) },
                { MouseButtons.XButton1, new ButtonInfo(panelX1, numericUpDownX1) },
                { MouseButtons.XButton2, new ButtonInfo(panelX2, numericUpDownX2) },
            };
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

            ButtonInfo bi;
            if (dictButtons.TryGetValue(e.Button, out bi))
            {
                bi._panel.BackColor = downColor;
                long tNow = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                if(tNow - bi._timeStamp < 100) bi._nud.Value++;
                bi._timeStamp = tNow;
            }
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            ButtonInfo bi;
            if (dictButtons.TryGetValue(e.Button, out bi))
            {
                bi._panel.BackColor = this.BackColor;
            }
        }

        private int CycleInt(int n, int i)
        {
            return (i % n + n) % n;
        }
  
    }//class

    internal class ButtonInfo
    {
        internal Panel _panel;
        internal NumericUpDown _nud;
        internal long _timeStamp;

        internal ButtonInfo(Panel panel, NumericUpDown nud)
        {
            _panel = panel;
            _nud = nud;
            _timeStamp = 0;
        }
    }
}
