using lab3_BlackJack.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private Graphics Graphics;
        private Timer Timer = new Timer();

        public MainWindow(Player player, Player dealer, List<Deck> decks)
        {
            InitializeComponent();
            Player = player;
            Dealer = dealer;
            Decks = decks;
            tmpDecks = Decks;
        }


        private void UpdateHand()
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

        private List<Card> getRandomHand()
        {
            var result = new List<Card>();
            result.Add(getRandomCard());
            result.Add(getRandomCard());
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

        }

        private void Chip500PBox_Click(object sender, EventArgs e)
        {

        }

        private void MakeStake(int sum)
        {
            //TODO: Add Stack to get possibility to delete chips from stake.
            //TODO: Support all types of chips.
            if (Player.getMoney() - (Player.getStake() + sum) >= 0)
            {
                Player.addStake(sum);
                var width = Properties.Resources.Chip100.Width;
                var height = Properties.Resources.Chip100.Height;

                var bmp = new Bitmap(width + Player.getStake() / 100 * width - Player.getStake() / 100 * (width - 20), height);
                Graphics g = Graphics.FromImage(bmp);
                for (int i = 0; i < Player.getStake() / 100; i++)
                {
                    g.DrawImage(Properties.Resources.Chip100, new Point((i * width) - i * (width - 20), 0));
                }
                StakePBox.Image = bmp;
            }
            StakeLabel.Text = Player.getStake().ToString();
        }
    }
}
