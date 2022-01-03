using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace lab1_OrganizerWindowApplication
{
    public partial class ToDoForm : Form
    {
        BinaryFormatter formatter = new BinaryFormatter();
        User activeUser = null;
        private int rowIndex;
        List<User> users = new List<User>();
        //private BindingSource meh { get; set; }

        public ToDoForm()
        {
            InitializeComponent();
        }

        private void SaveData()
        {
            using (FileStream fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, users);
            }
        }


        private void ToDoForm_Load(object sender, EventArgs e)
        {
            var lgnForm = new LoginForm();
            lgnForm.ShowDialog();
            activeUser = lgnForm.activeUser;
            users = lgnForm.users;
            if (activeUser.ToDoS == null)
            {
                activeUser.addToDo("meh", Types.Meeting, DateTime.Now, States.Active, "meh");
                dataGridView1.DataSource = new BindingSource(activeUser.ToDoS, null);
                for (int z = 0; z < dataGridView1.Columns.Count; z++)
                {
                    dataGridView1.Columns[z].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
                dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                activeUser.ToDoS.Clear();
            }
            else
            {
                dataGridView1.DataSource = new BindingSource(activeUser.ToDoS, null);
                for (int z = 0; z < dataGridView1.Columns.Count; z++)
                {
                    dataGridView1.Columns[z].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
                dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            userNameLabel.Text = activeUser.Login;
            comboBox1.SelectedIndex = 0;
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            var aeForm = new AddEditForm(activeUser);
            aeForm.ShowDialog();
            SaveData();
        }

        private void FindBtn_Click(object sender, EventArgs e)
        {

        }

        private void FilterBtn_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0 && e.RowIndex <= dataGridView1.Rows.Count)
                {
                    dataGridView1.Rows[e.RowIndex].Selected = true;
                    rowIndex = e.RowIndex;
                    dataGridView1.CurrentCell = dataGridView1.Rows[rowIndex].Cells[1];
                    this.contextMenuStrip1.Show(dataGridView1, e.Location);
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
        }

        private void EemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = $"Do you want to delete: {activeUser.ToDoS[rowIndex].Name}?";
            string title = "Delete task";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                activeUser.ToDoS.RemoveAt(this.rowIndex);
                SaveData();
            }
        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var aeForm = new AddEditForm(activeUser, rowIndex);
            aeForm.ShowDialog();
            SaveData();
        }

        private void ToDoForm_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.Control && e.KeyCode == Keys.S)
            {
                SaveData();
                e.SuppressKeyPress = true;
            }

            if (e.Control && e.KeyCode == Keys.O)
            {
                using (FileStream fs = new FileStream("users.dat", FileMode.OpenOrCreate))
                {
                    if (fs.Length > 0)
                        users = (List<User>)formatter.Deserialize(fs);
                }
                e.SuppressKeyPress = true;
            }

            if (e.KeyCode == Keys.Delete)
            {
                string message = $"Do you want to delete: {activeUser.ToDoS[rowIndex].Name}?";
                string title = "Delete task";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    activeUser.ToDoS.RemoveAt(this.rowIndex);
                    SaveData();
                }
                e.SuppressKeyPress = true;
            }
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != 0)
            {
                var converter = new ListToDataTableConverter();
                var dt = converter.ToDataTable(activeUser.ToDoS);
                DataView dv = dt.DefaultView;
                dv.RowFilter = string.Format("Type  LIKE '%{0}%'", comboBox1.SelectedItem.ToString());
                dataGridView1.DataSource = dv;
            }
            else
            {
                dataGridView1.DataSource = new BindingSource(activeUser.ToDoS, null);
            }
        }

        private void AddBtn_Click_1(object sender, EventArgs e)
        {
            var aeForm = new AddEditForm(activeUser);
            aeForm.ShowDialog();
            SaveData();
        }

        private void FindBtn_Click_1(object sender, EventArgs e)
        {
            //this.contextMenuStrip2.Show(dataGridView1, e.Location);
            //contextMenuStrip2.Show(Cursor.Position);
        }

        private void searchTextBox_Changed(object sender, EventArgs e)
        {
            var converter = new ListToDataTableConverter();
            var dt = converter.ToDataTable(activeUser.ToDoS);
            DataView dv = dt.DefaultView;
            dv.RowFilter = string.Format("Time  LIKE '%{0}%'", textBox1.Text);
            dataGridView1.DataSource = dv;
        }

        private void AddBtn_Click_2(object sender, EventArgs e)
        {
            var aeForm = new AddEditForm(activeUser);
            aeForm.ShowDialog();
            SaveData();
        }

        private void AddBtn_TextChanged(object sender, EventArgs e)
        {
            var converter = new ListToDataTableConverter();
            var dt = converter.ToDataTable(activeUser.ToDoS);
            DataView dv = dt.DefaultView;
            dv.RowFilter = string.Format("Time  LIKE '%{0}%'", textBox1.Text);
            dataGridView1.DataSource = dv;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var converter = new ListToDataTableConverter();
            var dt = converter.ToDataTable(activeUser.ToDoS);
            DataView dv = dt.DefaultView;
            dv.RowFilter = string.Format("Time  LIKE '%{0}%'", textBox1.Text);

            dataGridView1.DataSource = dv;
        }

        private void AddBtn_Click_3(object sender, EventArgs e)
        {
            var aeForm = new AddEditForm(activeUser);
            aeForm.ShowDialog();
            SaveData();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            SaveData();
        }
    }
}
