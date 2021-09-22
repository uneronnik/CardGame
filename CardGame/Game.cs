using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class Game
    {

        List<Player> _players = new List<Player>();
        Deck startDeck = new Deck();
        public Game(int playersCount)
        {
            for (int i = 1; i <= playersCount; i++)
            {
                _players.Add(new Player(i));
            }


            startDeck.Shufle();

            for (int i = 0; i < 36 / _players.Count; i++)
            {
                foreach (var player in _players)
                {
                    player.Deck.Add(startDeck.Pop());
                }
            }
        }

        public void Update()
        {
            Console.Clear();

            Deck playersCards = new Deck(true);

            WritePlayersCards();

            foreach (var player in _players)
            {
                playersCards.Add(player.Deck.Pop());
            }

            Player playerWithBiggestCard = _players.ElementAt(FindIndexOfBiggestCard(playersCards.Cards.ToList<Card>()));

            Console.WriteLine($"Игрок номер {playerWithBiggestCard.Number} забирает карты");
            playersCards.Shufle();

            foreach (var card in playersCards)
            {
                playerWithBiggestCard.Deck.Add(card);
            }
            
            while(IsAnybodyLost() == true)
            {
                Console.WriteLine($"Игрок номер {FindLostPlayer().Number} выбыл");
                _players.Remove(FindLostPlayer());

            }

            if(IsAnybodyWin() == true)
            {
                Console.Clear();
                Console.WriteLine($"Игрок номер {FindWinPlayer().Number} победил!");
            }
            Console.ReadKey();
        }

        public bool IsAnybodyWin()
        {
            foreach (var player in _players)
            {
                if (player.Deck.CardCount == 36 - startDeck.CardCount)
                    return true;
            }
            return false;
        }
        private bool IsAnybodyLost()
        {
            foreach (var player in _players)
            {
                if (player.Deck.CardCount == 0)
                    return true;
            }
            return false;
        }
        private Player FindWinPlayer()
        {
            foreach (var player in _players)
            {
                if (player.Deck.CardCount == 36 - startDeck.CardCount)
                    return player;
            }
            return new Player(0);
        }
        private Player FindLostPlayer()
        {
            foreach (var player in _players)
            {
                if (player.Deck.CardCount == 0)
                    return player;
            }
            return new Player(0);
        }
        
        private void WritePlayersCards()
        {
            foreach (var player in _players)
            {
                Card playerCard = player.Deck.Peek();
                Console.WriteLine($"{player.Number}: {playerCard.Suit} {playerCard.Value}");
            }
        }
        
        private int FindIndexOfBiggestCard(List<Card> cards)
        {
            Card biggestCard = cards.ElementAt(0);

            foreach (var card in cards)
            {
                if((biggestCard as IComparable<Card>).CompareTo(card) == 1)
                    biggestCard = card;
            }

            int index = cards.FindIndex((Card card) => card == biggestCard);
            return index;
        }
        private Card FindBiggestCard(List<Card> cards)
        {
            Card biggestCard = cards.ElementAt(0);

            foreach (var card in cards)
            {
                if ((biggestCard as IComparable<Card>).CompareTo(card) == -1)
                    biggestCard = card;
            }
            return biggestCard;
        }
    }
}
