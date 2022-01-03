using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab2_DirectoryBrowserWindowApplication
{
    public partial class FontForm : Form
    {
        public FontForm()
        {
            InitializeComponent();
            textBox1.Text = "Here you can try to type something to test new font";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Font = Fonts.dataGridViewFont;

            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                Fonts.dataGridViewFont = fontDialog1.Font;
            }

            textBox1.Font = Fonts.dataGridViewFont;
        }
    }
}
