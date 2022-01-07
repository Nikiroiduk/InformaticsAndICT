using lab3_BlackJack.Model;
using lab3_BlackJack.View;
using System.Collections.Generic;

namespace lab3_BlackJack.Controller
{
    class GameController
    {
        private Game _Game = new Game();
       
        private void Start()
        {
            var MainWindow = new MainWindow(_Game.getPlayer(), _Game.getDealer(), _Game.getDecks());
            MainWindow.ShowDialog();
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
