using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab3_Copywriter
{
    public partial class cTextForm : Form
    {
        public cTextForm()
        {
            InitializeComponent();
            textBox1.Text = Settings.CopyrightText;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Settings.CopyrightText = textBox1.Text;
        }
    }
}
