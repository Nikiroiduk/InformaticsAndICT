using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3_BlackJack.Model
{
    public class Player
    {
        private string _Name { get; set; } = "Undefinde";
        private List<Card> _Hand { get; set; } = new List<Card>();
        private int _Money { get; set; } = 0;
        private int _Stake { get; set; } = 0;

        public Player(){}

        public Player(string Name, int Money)
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                throw new ArgumentException($"'{nameof(Name)}' cannot be null or whitespace.", nameof(Name));
            }

            this._Name = Name;
            this._Money = Money;
        }

        public Player Get()
        {
            return this;
        }

        public void setStake(int Stake)
        {
            this._Stake = Stake;
        }

        public void addStake(int Stake)
        {
            this._Stake += Stake;
        }

        public string getName()
        {
            return _Name;
        }

        public List<Card> getHand()
        {
            return this._Hand;
        }

        public int getMoney()
        {
            return this._Money;
        }

        public int getStake()
        {
            return this._Stake;
        }

        public void clearHand()
        {
            this._Hand.Clear();
        }

        public void addCard(Card Card)
        {
            this._Hand.Add(Card);
        }

        public void addMoney(int Money)
        {
            this._Money += Money;
        }

        public void setHand(List<Card> Hand)
        {
            this._Hand = Hand;
        }
    }
}
