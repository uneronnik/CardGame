using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    enum Suits
    {
        Heart,
        Diamond,
        Club,
        Spade
    }
    class Card : IComparable<Card>
    {
        public Card(Suits suit, int value)
        {
            Suit = suit;
            Value = value;
        }

        public Suits Suit { get; private set; }
        public int Value { get; private set; }

        int IComparable<Card>.CompareTo(Card other)
        {
            if (Value > other.Value)
                return -1;
            else if (Value < other.Value)
                return 1;
            return 0;
        }
       
    }
}
