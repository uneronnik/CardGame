using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class Player
    {
        public int Number { get; set; }
        public Deck Deck { get; set; }

        public Player(int number)
        {
            Deck = new Deck(true);
            Number = number;
        }

        
    }
}
