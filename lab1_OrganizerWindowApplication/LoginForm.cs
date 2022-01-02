using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace lab1_OrganizerWindowApplication
{
    public partial class LoginForm : Form
    {
        public List<User> users = new List<User>();
        BinaryFormatter formatter = new BinaryFormatter();
        public User activeUser = null;

        public LoginForm()
        {
            InitializeComponent();
            PasswordTextBox.UseSystemPasswordChar = true;
            using (FileStream fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (fs.Length > 0)
                    users = (List<User>)formatter.Deserialize(fs);
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            using (FileStream fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (fs.Length > 0)
                    users = (List<User>)formatter.Deserialize(fs);
            }

            if(LoginTextBox.Text == "" || PasswordTextBox.Text == "")
            {
                errMsgLabel.Text = "Fields can't be empty!";
            }
            else
            {
                var user = new User(LoginTextBox.Text, PasswordTextBox.Text);
                var existingUser = users.FirstOrDefault(u => u.Login == user.Login);

                if (existingUser == null) errMsgLabel.Text = "This user doesn't exist!";
                else if (existingUser.Password != user.Password) errMsgLabel.Text = "Wrong password!";
                else
                {
                    activeUser = existingUser;
                    this.Close();
                } 
            }

        }

        private void SignUpBtn_Click(object sender, EventArgs e)
        {
            if (LoginTextBox.Text == "" || PasswordTextBox.Text == "")
            {
                errMsgLabel.Text = "Fields can't be empty!";
            }
            else
            {
                var user = new User(LoginTextBox.Text, PasswordTextBox.Text);
                var existingUser = users.FirstOrDefault(u => u.Login == user.Login);
                if (existingUser == null)
                {
                    users.Add(user);
                    foreach (var item in users)
                    {
                        using (FileStream fs = new FileStream("users.dat", FileMode.OpenOrCreate))
                        {
                            formatter.Serialize(fs, users);
                        }
                    }
                    activeUser = user;
                    this.Close();
                }
                else
                {
                    errMsgLabel.Text = "User with this login already exist!";
                }
            }

        }

        private void PasswordShowCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PasswordTextBox.UseSystemPasswordChar = !PasswordShowCheckBox.Checked;
        }
    }
}
