using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LVR_Task_Project
{
    public partial class Form2 : Form
    {
        private int count;
        private int minCount;

        public Form2()
        {
            InitializeComponent();
            groupBox1.AllowDrop = groupBox2.AllowDrop = groupBox3.AllowDrop = true;
        }
        public void Form2_Load(object sender, EventArgs e)
        {
            Random r = new Random();
            int n = (int)Convert.ToInt32(numericUpDown1.Value),
                w = groupBox1.Width,
                h = groupBox1.Height;
            for (int i = 0; i < n; i++)
            {
                Label lb = new Label();
                lb.BorderStyle = BorderStyle.FixedSingle;
                lb.Size = new Size((w - 10) * (n - i) / n, (h - 15) / n);
                lb.Location =
                    new Point((w - lb.Width) / 2, h - 2 - (i + 1) * lb.Height);
                lb.BackColor = Color.FromArgb(0, 0, 0);
                lb.Parent = groupBox1;
                lb.MouseDown += label_MouseDown;
            }
            count = 0;
            minCount = (int)Math.Round(Math.Pow(2, n)) - 1;
            Info();
            label2.Visible = false;
        }
        private void label_MouseDown(object sender, MouseEventArgs e)
        {
            if (!button1.Enabled)
                return;
            if (e.Button == MouseButtons.Left)
                DoDragDrop(sender, DragDropEffects.Move);
        }
        private void label_Dispose(GroupBox gb)
        {
            for (int i = gb.Controls.Count - 1; i >= 0; i--)
                gb.Controls[i].Dispose();
        }

        private void label_Move(Label lb, GroupBox gb)
        {
            lb.Parent = gb;
            lb.Top = gb.Height - 2 - gb.Controls.Count * lb.Height;
            count++;
            Info();
            if (groupBox2.Controls.Count == Convert.ToInt32(numericUpDown1.Text) || groupBox3.Controls.Count == Convert.ToInt32(numericUpDown1.Text))
            {
                label2.Visible = true;
                Form1 f1 = new Form1();
                f1.pictureBox1.Show();
            }
        }

        private void groupBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (label2.Visible)
            {
                e.Effect = DragDropEffects.None;
                return;
            }
            Label lb = e.Data.GetData(typeof(Label)) as Label;
            int k = int.MaxValue;
            GroupBox gb = sender as GroupBox;
            if (gb.Controls.Count > 0)
                k = gb.Controls[gb.Controls.Count - 1].Width;
            if (lb.Parent.Controls[lb.Parent.Controls.Count - 1] != lb
                || lb.Width > k)
                e.Effect = DragDropEffects.None;
            else
                e.Effect = DragDropEffects.Move;
        }

        private void groupBox1_DragDrop(object sender, DragEventArgs e)
        {
            Label lb = e.Data.GetData(typeof(Label)) as Label;
            GroupBox gb = sender as GroupBox;
            if (gb == lb.Parent)
                return;
            label_Move(lb, gb);
        }

        private void Info()
        {
            label1.Text = string.Format("Число ходов: {0} ({1})", count, minCount);
        }

        private void Step(int n, GroupBox src, GroupBox dst, GroupBox tmp)
        {
            if (n == 0)
                return;
            Step(n - 1, src, tmp, dst);
            if (button1.Enabled)
                return;
            label_Move(src.Controls[src.Controls.Count - 1] as Label, dst);
            Application.DoEvents();
            System.Threading.Thread.Sleep(1500 / ((int)Convert.ToInt32(numericUpDown1.Text)) - 1);
            Step(n - 1, tmp, dst, src);
        }

        private void numericUpDown1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label_Dispose(groupBox1);
            label_Dispose(groupBox2);
            label_Dispose(groupBox3);
            Form2_Load(this, null);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            Form f1 = new Form1();
            f1.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            numericUpDown1.Enabled = button1.Enabled = !button1.Enabled;
            if (!button1.Enabled)
            {
                if (groupBox1.Controls.Count != numericUpDown1.Value)
                    numericUpDown1_ValueChanged_1(null, null);
                Step((int)numericUpDown1.Value, groupBox1, groupBox3, groupBox2);
                numericUpDown1.Enabled = button1.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label_Dispose(groupBox1);
            label_Dispose(groupBox2);
            label_Dispose(groupBox3);
            Form2_Load(this, null);
        }

        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {
            label_Dispose(groupBox1);
            label_Dispose(groupBox2);
            label_Dispose(groupBox3);
            Form2_Load(this, null);
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
        }
    }
}


/*if (Town1 == true)
    for (int i = 1; i < 6; i++)
    {
        if (Hanoi[1] == 1 && NumberHanoi[1, i] == 0) { button1.Location = new Point(pictureBox1.Location.X + 28, 353 * i); NumberHanoi[1, i] = 1; }
        else if (Hanoi[2] == 1 && NumberHanoi[1, i] == 0) { button2.Location = new Point(pictureBox1.Location.X + 40, 353 * i); NumberHanoi[1, i] = 1; }
        else if (Hanoi[3] == 1 && NumberHanoi[1, i] == 0) { button3.Location = new Point(pictureBox1.Location.X + 50, 353 * i); NumberHanoi[1, i] = 1; }
        else if (Hanoi[4] == 1 && NumberHanoi[1, i] == 0) { button4.Location = new Point(pictureBox1.Location.X + 60, 353 * i); NumberHanoi[1, i] = 1; }
        else if (Hanoi[5] == 1 && NumberHanoi[1, i] == 0) { button5.Location = new Point(pictureBox1.Location.X + 70, 353 * i); NumberHanoi[1, i] = 1; }
    }*/