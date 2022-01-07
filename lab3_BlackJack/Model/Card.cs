using lab3_BlackJack.Properties;
using System.Drawing;
using lab3_BlackJack.Model;
using System.Resources;

namespace lab3_BlackJack.Model
{
    class Card
    {
        private readonly Suit _Suit;
        private readonly Rank _Rank;
        private readonly Bitmap _Image;
        private readonly ResourceManager rm = Resources.ResourceManager;

        public Card(int Rank, int Suit)
        {
            this._Rank = (Rank)Rank;
            this._Suit = (Suit)Suit;
            this._Image = (Bitmap)rm.GetObject($"{_Rank}{_Suit}");
        }
        public Suit getSuit()
        {
            return _Suit;
        }

        public Rank getRank()
        {
            return _Rank;
        }

        public int getValue()
        {
            switch (_Rank)
            {
                case Rank.Jack:
                case Rank.Queen:
                case Rank.King:
                    return 10;
                case Rank.Ace:
                    return 11;
                default:
                    return (int)_Rank;
            }
        }

        public Bitmap getImage()
        {
            return _Image;
        }

    }
}
