using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3_BlackJack.Model
{
    class Game
    {
        private Player _Player { get; set; } = null;
        private Player _Dealer { get; set; } = null;
        private List<Deck> _Decks { get; set; } = null;

        public Game(){}

        public Player getPlayer()
        {
            return _Player;
        }

        public void setPlayer(string Name, int Money)
        {
            this._Player = new Player(Name, Money);
        }

        public Player getDealer()
        {
            return _Dealer;
        }

        public void setDealer(string Name, int Money = 0)
        {
            this._Dealer = new Player(Name, Money);
        }

        public void setDecks(List<Deck> Decks)
        {
            this._Decks = Decks;
        }
        public List<Deck> getDecks()
        {
            return _Decks;
        }

    }
}
