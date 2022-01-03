using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace lab2_DirectoryBrowserWindowApplication
{
    public partial class MainWindow : Form
    {
        string selectedDirectory = null;
        List<myFile> myFiles = new List<myFile>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = selectedDirectory;
            DialogResult drResult = folderBrowserDialog1.ShowDialog();
            if (drResult == System.Windows.Forms.DialogResult.OK)
                selectedDirectory = folderBrowserDialog1.SelectedPath;
            initTreeView();
        }

        private void initTreeView()
        {
            DirectorytreeView1.Nodes.Clear();
            toolTip1.ShowAlways = true;
            if (selectedDirectory != null && Directory.Exists(selectedDirectory))
                LoadDirectory(selectedDirectory);
            else
                MessageBox.Show("Select Directory!!");
        }

        public void LoadDirectory(string Dir)
        {
            DirectoryInfo di = new DirectoryInfo(Dir);
            TreeNode tds = DirectorytreeView1.Nodes.Add(di.Name);
            tds.Tag = di.FullName;
            tds.StateImageIndex = 0;
            LoadSubDirectories(Dir, tds);
        }


        private void LoadSubDirectories(string dir, TreeNode td)
        {
            string[] subdirectoryEntries = Directory.GetDirectories(dir);
            foreach (string subdirectory in subdirectoryEntries)
            {

                DirectoryInfo di = new DirectoryInfo(subdirectory);
                TreeNode tds = td.Nodes.Add(di.Name);
                tds.StateImageIndex = 0;
                tds.Tag = di.FullName;
                LoadSubDirectories(subdirectory, tds);

            }
        }

        private void LoadFiles(string dir)
        {
            dataGridView1.DataSource = null;
            myFiles.Clear();
            string[] Files = Directory.GetFiles(dir, "*.*");
            foreach (string file in Files)
            {
                FileInfo fi = new FileInfo(file);
                myFiles.Add(new myFile()
                {
                    S = true,
                    Name = fi.Name.Split('.')[0],
                    Size = fi.Length / 1024 > 0 ? fi.Length / 1024 : 1,
                    Type = fi.Extension.Split('.')[1]
                });
            }
            dataGridView1.DataSource = myFiles;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            UpdateData();
        }

        private void DirectorytreeView1_MouseMove(object sender, MouseEventArgs e)
        {   
            TreeNode theNode = this.DirectorytreeView1.GetNodeAt(e.X, e.Y);  

            if (theNode != null && theNode.Tag != null)  
            {  
                if (theNode.Tag.ToString() != this.toolTip1.GetToolTip(this.DirectorytreeView1))  
                    this.toolTip1.SetToolTip(this.DirectorytreeView1, theNode.Tag.ToString());

            }  
            else
            {  
                this.toolTip1.SetToolTip(this.DirectorytreeView1, "");
            }
        }
        private void DirectorytreeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            LoadFiles($"{selectedDirectory.Split(':')[0]}://{e.Node.FullPath}//");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["S"].Index)
            {
                myFiles[e.RowIndex].S = !myFiles[e.RowIndex].S;
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = myFiles[e.RowIndex].S;
            }
            UpdateData();
        }

        private void UpdateData()
        {
            long sum = 0;
            int selected = 0;
            foreach (var item in myFiles)
            {
                if (item.S)
                {
                    selected++;
                    sum += item.Size;
                }
            }

            toolStripStatusLabel1.Text = sum.ToString() + " KiB";
            toolStripStatusLabel2.Text = $"{selected} of {myFiles.Count} items selected";
            dataGridView1.Font = Fonts.dataGridViewFont;
            DrawChart();
        }

        private void DrawChart()
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);
            StringFormat sf = new StringFormat();
            Font fn = new Font("Arial", 10, FontStyle.Bold);
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            int startX = 10;
            int endX = pictureBox1.Width - 10;
            int startY = 10;
            int endY = pictureBox1.Height - 25;
            g.DrawLine(new Pen(Color.Black, 1), startX, endY, endX, endY);
            g.DrawLine(new Pen(Color.Black, 1), startX, startY, startX, endY);
            Dictionary<string, long> elements = new Dictionary<string, long>();
            var xxx = myFiles.Where(a => a.S == true);
            if (xxx.Count() <= 0) return;
            var unique = from n in xxx
                         group n.Type by n.Type into nGroup
                         where nGroup.Count() > 0
                         select nGroup.Key;
            var tmp = new Dictionary<string, long>();
            foreach (var item in unique)
            {
                tmp.Add(item, 0);
                elements.Add(item, 0);
            }
            foreach (var item in elements)
            {
                foreach (var file in xxx)
                {
                    if (item.Key == file.Type)
                        if (tmp[item.Key] < file.Size)
                            tmp[item.Key] = file.Size;
                }
            }
            elements = tmp;
            long max = elements.Max(a => a.Value);
            double mash = 5.0;
            double dy = (endY - startY) / (max / mash);
            int widthRect = ((endX - startX) / elements.Count) / 2;
            SolidBrush sb = new SolidBrush(Color.FromArgb(255, 155, 0));
            Pen p = new Pen(Color.FromArgb(25, 0, 0, 0), 2)
            {
                DashStyle = DashStyle.Solid
            };
            fn = new Font("Arial", 8, FontStyle.Bold);
            sf.Alignment = StringAlignment.Near;
            sf.LineAlignment = StringAlignment.Center;
            foreach (var item in elements)
            {
                g.DrawLine(p, startX - 5, endY - (int)(dy * (item.Value / mash)), endX, endY - (int)(dy * (item.Value / mash)));
                g.DrawString(item.Value.ToString(), fn, Brushes.Black, new Rectangle(1, endY - (int)(dy * (item.Value / mash)) - (int)fn.Size, 100, 20), sf);
            }
            int x = startX + widthRect;
            foreach (var item in elements)
            {
                Rectangle rect = new Rectangle(x, endY - (int)(dy * (item.Value / mash)), widthRect, (int)(dy * (item.Value  / mash)));
                g.FillRectangle(sb, rect);
                x += 2 * widthRect;
            }
            sf.Alignment = StringAlignment.Center;
            x = startX + widthRect + widthRect / 2;
            foreach (var item in elements)
            {
                g.DrawLine(new Pen(Color.Black, 1), x, endY - 5, x, endY + 5);
                g.DrawString(item.Key, fn, Brushes.Black, new Rectangle(x - 25, endY, 50, 22), sf);
                x += 2 * widthRect;
            }
        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var tmp = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString().ToLower();

            if (Filter.imgFiles.Contains(tmp))
            {
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Colors.imgFilesColor;
            }
            else if (Filter.officeFiles.Contains(tmp))
            {
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(215, 127, 161);
            }
            else if (Filter.archivesFiles.Contains(tmp))
            {
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(163, 218, 141);
            }
            else if (Filter.exedllFiles.Contains(tmp))
            {
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 211, 154);
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ff = new FontForm();
            ff.ShowDialog();
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cf = new ColorForm();
            cf.ShowDialog();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var hf = new HelpForm();
            hf.ShowDialog();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamWriter file = new StreamWriter("dataGridViewData.txt");
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Rows[i].Cells.Count; j++)
                {
                    file.Write(dataGridView1.Rows[i].Cells[j].Value.ToString() + ' ');
                }
                file.WriteLine();
            }
            file.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
