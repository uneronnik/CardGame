﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(5);
            while(!game.IsAnybodyWin())
            {
                game.Update();
            }
            Console.ReadKey();
        }
    }
}
