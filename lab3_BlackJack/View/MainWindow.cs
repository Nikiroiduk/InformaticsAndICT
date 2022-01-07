using lab3_BlackJack.Controller;
using lab3_BlackJack.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace lab3_BlackJack
{
    public partial class MainWindow : Form
    {
        private Player Player;
        private Player Dealer;
        private List<Deck> Decks;
        private List<Deck> tmpDecks;
        private Random Random = new Random();
        private Stack<int> currentStake = new Stack<int>();
        private bool isGameStarted = false;
        private bool isGameFinished = false;

        public MainWindow(Player player, Player dealer, List<Deck> decks)
        {
            InitializeComponent();
            Player = player;
            Dealer = dealer;
            Decks = decks;
            tmpDecks = Decks;

            playerMoneyLabel.Text = Player.getMoney().ToString();
        }


        private void UpdatePlayerHand()
        {
            var width = Player.getHand()[0].getImage().Width;
            var height = Player.getHand()[0].getImage().Height;

            var bmp = new Bitmap(Player.getHand().Count * width, height - 80);
            Graphics g = Graphics.FromImage(bmp);
            for (int i = 0; i < Player.getHand().Count(); i++)
            {
                g.DrawImage(Player.getHand()[i].getImage(), new Point(i * width - i * 60, 0));
            }
            PlayerHandPBox.Image = bmp;
        }

        private void UpdateDealerHand()
        {
            var width = Dealer.getHand()[0].getImage().Width;
            var height = Dealer.getHand()[0].getImage().Height;

            var bmp = new Bitmap(Dealer.getHand().Count * width, height - 80);
            Graphics g = Graphics.FromImage(bmp);
            if (isGameFinished)
            {
                for (int i = 0; i < Dealer.getHand().Count(); i++)
                {
                    g.DrawImage(Dealer.getHand()[i].getImage(), new Point(i * width - i * 60, 0));
                }
            }
            else
            {
                g.DrawImage(Dealer.getHand()[0].getImage(), new Point(0, 0));
                g.DrawImage(Properties.Resources.Suit, new Point(width - 60, 0));
            }
            DealerHandPBox.Image = bmp;
        }

        private List<Card> getRandomHand()
        {
            var result = new List<Card>
            {
                getRandomCard(),
                getRandomCard()
            };
            return result;
        }

        private Card getRandomCard()
        {
            return tmpDecks[Random.Next(tmpDecks.Count())].getRandomCard();
        }

        private void Chip100PBox_Click(object sender, EventArgs e)
        {
            MakeStake(100);
        }

        private void Chip200PBox_Click(object sender, EventArgs e)
        {
            MakeStake(200);
        }

        private void Chip500PBox_Click(object sender, EventArgs e)
        {
            MakeStake(500);
        }

        private void MakeStake(int sum)
        {
            if (!isGameStarted)
            {
                if (Player.getMoney() - (Player.getStake() + sum) >= 0)
                {
                    Player.addStake(sum);
                    StakeLabel.Text = Player.getStake().ToString();
                    playerMoneyLabel.Text = (Player.getMoney() - Player.getStake()).ToString();
                    currentStake.Push(sum);
                    var width = Properties.Resources.Chip100.Width;
                    var height = Properties.Resources.Chip100.Height;

                    var count = 0;
                    var bmp = new Bitmap(width + currentStake.Count() * width - currentStake.Count() * (width - 20), height);
                    Graphics g = Graphics.FromImage(bmp);
                    foreach (var item in currentStake.Reverse())
                    {
                        switch (item)
                        {
                            case 100:
                                g.DrawImage(Properties.Resources.Chip100, new Point((count * width) - count * (width - 20), 0));
                                break;                                                                
                            case 200:                                                                 
                                g.DrawImage(Properties.Resources.Chip200, new Point((count * width) - count * (width - 20), 0));
                                break;                                                                
                            case 500:                                                                 
                                g.DrawImage(Properties.Resources.Chip500, new Point((count * width) - count * (width - 20), 0));
                                break;
                        }
                        count++;
                    }
                    StakePBox.Image = bmp;
                }
                if (Player.getStake() > 0)
                    DealStandBtn.Visible = true;
            }
        }

        private void StakePBox_Click(object sender, EventArgs e)
        {
            if (!isGameStarted)
            {
                if (currentStake.Count > 0)
                {
                    Player.decStake(currentStake.Peek());
                    StakeLabel.Text = Player.getStake().ToString();
                    playerMoneyLabel.Text = (Player.getMoney() - Player.getStake()).ToString();
                    currentStake.Pop();
                    var width = Properties.Resources.Chip100.Width;
                    var height = Properties.Resources.Chip100.Height;

                    var count = 0;
                    var bmp = new Bitmap(width + currentStake.Count() * width - currentStake.Count() * (width - 20), height);
                    Graphics g = Graphics.FromImage(bmp);
                    foreach (var item in currentStake.Reverse())
                    {
                        switch (item)
                        {
                            case 100:
                                g.DrawImage(Properties.Resources.Chip100, new Point((count * width) - count * (width - 20), 0));
                                break;
                            case 200:
                                g.DrawImage(Properties.Resources.Chip200, new Point((count * width) - count * (width - 20), 0));
                                break;
                            case 500:
                                g.DrawImage(Properties.Resources.Chip500, new Point((count * width) - count * (width - 20), 0));
                                break;
                        }
                        count++;
                    }
                    StakePBox.Image = bmp;
                }
                if (Player.getStake() <= 0)
                    DealStandBtn.Visible = false;
            }
        }

        private void DealStandBtn_MouseEnter(object sender, EventArgs e)
        {
            if (isGameStarted)
            {
                DealStandBtn.Image = Properties.Resources.StandBtnHover;
            }
            else
            {
                DealStandBtn.Image = Properties.Resources.DealBtnHover;
            }
        }

        private void DealStandBtn_MouseLeave(object sender, EventArgs e)
        {
            if (isGameStarted)
            {
                DealStandBtn.Image = Properties.Resources.StandBtn;
            }
            else
            {
                DealStandBtn.Image = Properties.Resources.DealBtn;
            }
        }

        private void DealStandBtn_Click(object sender, EventArgs e)
        {
            if (Player.getStake() >= Properties.Parameters.MinimalStake && !isGameStarted)
            {
                StartGame();
            }
            else if (isGameStarted)
            {
                FinishGame();
            }
        }

        private void FinishGame()
        {
            var playerVal = CountPoints(Player);
            var meh = true;
            while (meh)
            {
                var dealerVal = CountPoints(Dealer);    
                if (dealerVal > 21)
                {
                    PlayerWin();
                    meh = false;
                }
                else if (dealerVal > 16)
                {
                    if (dealerVal > playerVal)
                    {
                        PlayerLose();
                    }
                    else if (dealerVal == playerVal)
                    {
                        Draw();
                    }
                    else
                    {
                        PlayerWin();
                    }
                    meh = false;
                }
                else
                {
                    Dealer.addCard(getRandomCard());
                    UpdateDealerHand();
                }
            }
        }


        private void Draw()
        {
            isGameFinished = true;
            UpdateDealerHand();
            MessageBox.Show($"It is draw!",
                                "Draw!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

            CleanUpGame();
            playerMoneyLabel.Text = Player.getMoney().ToString();
        }

        private void ShowControls()
        {
            DealStandBtn.Image = Properties.Resources.StandBtn;
            HitBtn.Visible = true;
        }

        private void HideControls()
        {
            DealStandBtn.Image = Properties.Resources.DealBtn;
            HitBtn.Visible = false;
        }

        private void SetHands()
        {
            Player.setHand(getRandomHand());
            Dealer.setHand(getRandomHand());
            UpdatePlayerHand();
            UpdateDealerHand();
        }

        private void StartGame()
        {
            isGameStarted = true;
            ShowControls();
            SetHands();
        }

        private void HitBtn_Click(object sender, EventArgs e)
        {
            Player.addCard(getRandomCard());
            UpdatePlayerHand();
            if (CountPoints(Player) > 21)
            {
                PlayerLose();
            }
        }

        private void PlayerWin()
        {
            isGameFinished = true;
            Player.addMoney(Player.getStake() * 2);
            UpdateDealerHand();

            MessageBox.Show($"You win this game and get {Player.getStake() * 2} chips!",
                                "You Win!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

            CleanUpGame();
            playerMoneyLabel.Text = Player.getMoney().ToString();
        }

        private void PlayerLose()
        {
            isGameFinished = true;
            Player.setMoney(Player.getMoney() - Player.getStake());
            UpdateDealerHand();
            
            if (Player.getMoney() <= 0)
            {
                if (MessageBox.Show("Do you want to play again?",
                                "You lose!",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    this.Dispose();
                    var gc = new GameController();
                }
                else
                {
                    this.Dispose();
                }
            }
            else
            {
                MessageBox.Show($"You lost this game and lost {Player.getStake()} chips!", 
                                "You lose!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            CleanUpGame();
            playerMoneyLabel.Text = Player.getMoney().ToString();
        }

        private void CleanUpGame()
        {
            Player.clearHand();
            Dealer.clearHand();
            Player.setStake(0);
            currentStake.Clear();
            PlayerHandPBox.Image = null;
            DealerHandPBox.Image = null;
            StakePBox.Image = null;
            StakeLabel.Text = null;
            HideControls();

            tmpDecks = Decks;

            isGameStarted = false;
            isGameFinished = false;
        }

        private void HitBtn_MouseEnter(object sender, EventArgs e)
        {
            HitBtn.Image = Properties.Resources.HitBtnHover;
        }

        private void HitBtn_MouseLeave(object sender, EventArgs e)
        {
            HitBtn.Image = Properties.Resources.HitBtn;
        }

        private int CountPoints(Player user)
        {
            var res = 0;
            user.getHand().ForEach(s => res += s.getValue());
            return res;
        }
    }
}
