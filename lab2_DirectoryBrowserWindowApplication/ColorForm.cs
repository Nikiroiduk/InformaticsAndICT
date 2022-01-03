using System;
using System.Windows.Forms;

namespace lab2_DirectoryBrowserWindowApplication
{
    public partial class ColorForm : Form
    {
        public ColorForm()
        {
            InitializeComponent();
            Filter.imgFiles.ForEach(a => textBox1.Text += $"\".{a}\"\t");
            pictureBox1.BackColor = Colors.imgFilesColor;

            Filter.archivesFiles.ForEach(a => textBox2.Text += $"\".{a}\"\t");
            pictureBox2.BackColor = Colors.archivesFilesColor;

            Filter.officeFiles.ForEach(a => textBox3.Text += $"\".{a}\"\t");
            pictureBox3.BackColor = Colors.officeFilesColor;

            Filter.exedllFiles.ForEach(a => textBox4.Text += $"\".{a}\"\t");
            pictureBox4.BackColor = Colors.exedllFilesColor;
        }

        private void ChangeBtn1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Colors.imgFilesColor = colorDialog1.Color;
                pictureBox1.BackColor = Colors.imgFilesColor;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Colors.archivesFilesColor = colorDialog1.Color;
                pictureBox1.BackColor = Colors.archivesFilesColor;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Colors.officeFilesColor = colorDialog1.Color;
                pictureBox1.BackColor = Colors.officeFilesColor;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Colors.exedllFilesColor = colorDialog1.Color;
                pictureBox1.BackColor = Colors.exedllFilesColor;
            }
        }
    }
}
