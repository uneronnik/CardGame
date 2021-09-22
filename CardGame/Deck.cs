using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class Deck
    {
        Queue<Card> _cards = new Queue<Card>();
        public Deck(bool isEmpty = false)
        {
            if (isEmpty == false)
            {
                for (Suits suit = Suits.Heart; suit <= Suits.Spade; suit++)
                {
                    for (int value = 6; value <= 14; value++)
                    {
                        _cards.Enqueue(new Card(suit, value));
                    }
                }
            }
        }
        public int CardCount { 
            get
            {
                return _cards.Count;
            } 
        }

        internal Queue<Card> Cards { get => _cards; }

        public void Shufle()
        {
            Card[] cardsTmp = _cards.ToArray();

            Random random = new Random();
            for (int i = cardsTmp.Length - 1; i >= 1; i--)
            {
                int j = random.Next(i + 1);

                var temp = cardsTmp[j];
                cardsTmp[j] = cardsTmp[i];
                cardsTmp[i] = temp;
            }

            _cards.Clear();
            foreach (var card in cardsTmp)
            {
                _cards.Enqueue(card);
            }
        }

        public void Add(Card card)
        {
            _cards.Enqueue(card);
        }

        public Card Pop()
        {
            return _cards.Dequeue();
        }
        public Card Peek()
        {
            return _cards.Peek();
        }

        public bool IsEmpty()
        {
            if (_cards.Count == 0)
                return true;
            return false;
        }

        public IEnumerator<Card> GetEnumerator()
        {
            foreach (var card in _cards)
            {
                yield return card;
            }
        }
    }
}
