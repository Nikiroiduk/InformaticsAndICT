using System;
using System.Collections.Generic;
using System.Linq;

namespace lab3_BlackJack.Model
{
    public class Deck
    {
        private List<Card> _Deck { get; set; } = new List<Card>();
        private void newDeck()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 2; j < 15; j++)
                {
                    _Deck.Add(new Card(j, i));
                }
            }
        }

        private static readonly Random random = new Random();
        private readonly Random Random = random;
        public Deck()
        {
            newDeck();
        }

        public Card getRandomCard()
        {
            int rnd = Random.Next(_Deck.Count());
            Card tmp = _Deck[rnd];
            _Deck.RemoveAt(rnd);
            return tmp;
        }
    }
}
