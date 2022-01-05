using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace lab3_Copywriter
{
    public partial class MainWindow : Form
    {
        private List<string> files = new List<string>();
        private BindingList<logItem> copyrightImages = new BindingList<logItem>();

        public MainWindow()
        {
            InitializeComponent();
            dataGridView1.DataSource = copyrightImages;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files(*.bmp;*.jpg;*.png;*.jpeg)|*.bmp;*.jpg;*.png;*.jpeg|All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                files.Add(openFileDialog1.FileName);
                FillListView(files);
            }
        }

        private void openDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            files.Clear();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                if (folderBrowserDialog1.SelectedPath != null && Directory.Exists(folderBrowserDialog1.SelectedPath))
                {
                    String searchFolder = folderBrowserDialog1.SelectedPath;
                    var filters = new String[] { "jpg", "jpeg", "png", "bmp" };
                    files = GetFilesFrom(searchFolder, filters, false);
                    FillListView(files);
                }
            }
        }

        private void FillListView(List<string> files)
        {
            listView1.Items.Clear();
            var il = new ImageList
            {
                ImageSize = new Size(150, 150)
            };

            foreach (var item in files)
            {
                il.Images.Add(Image.FromFile(item));
            }
            listView1.View = View.LargeIcon;
            listView1.LargeImageList = il;
            for (int i = 0; i < il.Images.Count; i++)
            {
                ListViewItem lvi = new ListViewItem
                {
                    ImageIndex = i,
                };
                listView1.Items.Add(lvi);
            }
        }

        private static List<string> GetFilesFrom(String searchFolder, String[] filters, bool isRecursive)
        {
            List<String> filesFound = new List<String>();
            var searchOption = isRecursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
            foreach (var filter in filters)
            {
                filesFound.AddRange(Directory.GetFiles(searchFolder, String.Format("*.{0}", filter), searchOption));
            }
            return filesFound.ToList();
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            pictureBox1.Image = Image.FromFile(files[listView1.SelectedItems[0].Index]);
        }

        private void AddCopyrightBtn_Click(object sender, EventArgs e)
        {
            var adr = files[listView1.SelectedItems[0].Index];
            var img = new Bitmap(pictureBox1.Image.Width, pictureBox1.Image.Height);
            img = (Bitmap)Image.FromFile(adr);
            var font = new Font("Times New Roman", ((float)Math.Log10(pictureBox1.Image.Width) * 30) * 20 < pictureBox1.Image.Width ? ((float)Math.Log10(pictureBox1.Image.Width) * 30) : (float)Math.Log10(pictureBox1.Image.Width) * 20, GraphicsUnit.Pixel);
            var gr = Graphics.FromImage(img);
            gr.DrawString(Settings.CopyrightText, font, Brushes.Red, new Point(10, 10));
            pictureBox1.Image = img;
            var tmp = adr.Split('\\');
            var log = new logItem(tmp[tmp.Length - 1], Settings.CopyrightText, DateTime.Now, img.Width, img.Height);
            copyrightImages.Add(log);
        }

        private void SaveImageBtn_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif|Png Image|*.png";
            saveFileDialog1.Title = "Save an Image File";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                FileStream fs =
                    (FileStream)saveFileDialog1.OpenFile();
                switch (saveFileDialog1.FilterIndex)
                {
                    case 1:
                        this.pictureBox1.Image.Save(fs,
                          System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case 2:
                        this.pictureBox1.Image.Save(fs,
                          System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                    case 3:
                        this.pictureBox1.Image.Save(fs,
                          System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                    case 4:
                        this.pictureBox1.Image.Save(fs,
                          System.Drawing.Imaging.ImageFormat.Png);
                        break;
                }

                fs.Close();
            }

        }

        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                files.RemoveAt(listView1.SelectedItems[0].Index);
                FillListView(files);
            }
        }

        private void BatchModeBtn_Click(object sender, EventArgs e)
        {
            var i = 0;
            foreach (var item in files)
            {
                var img = (Bitmap)Image.FromFile(item);
                var font = new Font("Times New Roman", ((float)Math.Log10(img.Width) * Settings.CopyrightTextFontSize) * 20 < img.Width ? ((float)Math.Log10(img.Width) * Settings.CopyrightTextFontSize) : (float)Math.Log10(img.Width) * Settings.CopyrightTextFontSize / 2, GraphicsUnit.Pixel);
                var gr = Graphics.FromImage(img);
                gr.DrawString(Settings.CopyrightText, font, Settings.CopyrightTextColor, new Point(10, 10));
                var tmp = item.Split('\\');
                var log = new logItem(tmp[tmp.Length - 1], Settings.CopyrightText, DateTime.Now, img.Width, img.Height);
                copyrightImages.Add(log);
                img.Save($@"{Settings.CopyrightDirectory}\{i++}.png");
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var hf = new Form();
            hf.Text = "Help";
            hf.ShowDialog();
        }

        private void copyrightTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var meh = new cTextForm();
            meh.ShowDialog();
        }

        private void copyngDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                Settings.CopyrightDirectory = folderBrowserDialog1.SelectedPath;
            }
        }
    }
}
