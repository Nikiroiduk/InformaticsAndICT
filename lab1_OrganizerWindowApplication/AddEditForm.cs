using System;
using System.Windows.Forms;

namespace lab1_OrganizerWindowApplication
{
    public partial class AddEditForm : Form
    {
        User user;
        int index;
        bool state = false;

        public AddEditForm(User user)
        {
            this.user = user;
            InitializeComponent();
            init();
        }

        public AddEditForm(User user, int index)
        {
            this.user = user;
            this.index = index;
            InitializeComponent();
            init(true);
        }

        private void init(bool state = false)
        {
            TypeComboBox.Items.Add(Types.Meeting);
            TypeComboBox.Items.Add(Types.Memo);
            TypeComboBox.Items.Add(Types.Task);

            StateComboBox.Items.Add(States.Active);
            StateComboBox.Items.Add(States.Completed);

            if (state)
            {
                this.state = true;
                AddEditBtn.Text = "Edit";
                RemoveCancelBtn.Text = "Remove";
                NameTextBox.Text = user.ToDoS[index].Name;
                ContentTextBox.Text = user.ToDoS[index].Content;
                TypeComboBox.SelectedItem = user.ToDoS[index].Type;
                StateComboBox.SelectedItem = user.ToDoS[index].State;
                var check = user.ToDoS[index].Date + user.ToDoS[index].Time;
                DateTime.TryParse(user.ToDoS[index].Date + " " + user.ToDoS[index].Time, out DateTime x);
                dateTimePicker1.Value = x;
            }
            else
            {
                AddEditBtn.Text = "Add";
                RemoveCancelBtn.Text = "Cancel";
            }
        }

        private void AddEditBtn_Click(object sender, EventArgs e)
        {
            if (state)
            {
                user.removeAt(index);
                user.addToDo(NameTextBox.Text,
                            (Types)TypeComboBox.SelectedItem,
                             dateTimePicker1.Value,
                            (States)StateComboBox.SelectedItem,
                             ContentTextBox.Text);
            }
            else
            {
                user.addToDo(NameTextBox.Text,
                            (Types)TypeComboBox.SelectedItem,
                             dateTimePicker1.Value,
                            (States)StateComboBox.SelectedItem,
                             ContentTextBox.Text);
            }
            this.Close();
        }

        private void RemoveCancelBtn_Click(object sender, EventArgs e)
        {
            if (state)
            {
                user.removeAt(index);
            }
            this.Close();
        }
    }
}
