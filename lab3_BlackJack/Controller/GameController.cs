using lab3_BlackJack.Model;
using lab3_BlackJack.Properties;
using lab3_BlackJack.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3_BlackJack.Controller
{
    class GameController
    {
        private Game _Game = new Game();
        private int _minStake = Parameters.MinimalMoney;
        private List<Card> getRandomHand()
        {
            return null;
        }

        private Card getRandomCard()
        {
            return null;
        }

        private int countPoints(List<Card> Hand)
        {
            return 0;
        }

        private void Start()
        {

        }

        private void Game()
        {
            var MainWindow = new MainWindow();
        }

        private void Launch()
        {
            var StartWindow = new StartWindow();
            StartWindow.ShowDialog();
            var tmp = new List<Deck>();
            for (int i = 0; i < StartWindow.NumOfDecks; i++)
            {
                tmp.Add(new Deck());
            }
            _Game.setDecks(tmp);
            _Game.setPlayer(StartWindow.PlayerName, StartWindow.PlayerMoney);
            _Game.setDealer("Dealer");
            Start();
            StartWindow.Dispose();
        }

        public GameController()
        {
            Launch();
        }

    }
}
