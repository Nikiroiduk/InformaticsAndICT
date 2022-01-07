using System;
using System.Windows.Forms;

namespace lab3_BlackJack.View
{
    public partial class StartWindow : Form
    {
        public string PlayerName;
        public int PlayerMoney;
        public int NumOfDecks;

        public StartWindow()
        {
            InitializeComponent();
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            if (NameTextBox.Text == "")
            {
                errLabel.Text = $"Name can not be empty!";
            }
            else if (MoneyTextBox.Text == "")
            {
                errLabel.Text = $"Money field need to be filled!";
            }
            else if (Convert.ToInt32(MoneyTextBox.Text) < Properties.Parameters.MinimalStake)
            {
                errLabel.Text = $"Money should be at least\nequals to {Properties.Parameters.MinimalStake}!";
            }
            else
            {
                PlayerName = NameTextBox.Text;
                PlayerMoney = Convert.ToInt32(MoneyTextBox.Text);
                NumOfDecks = numOfDecks.Value;
                this.Close();
            }
        }

        private void numOfDecks_ValueChanged(object sender, EventArgs e)
        {
            numOfDecksLabel.Text = numOfDecks.Value.ToString();
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
