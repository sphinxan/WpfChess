using System;
using System.Collections.Generic;
using System.Text;

namespace WpfChess.Logic
{
    public class FirstPlayer
    {
        public static string Name { get; set; }
        public static int Wins { get; set; }

        public FirstPlayer(string name, int wins)
        {
            Name = name;
            Wins = wins;
        }
    }
    public class SecondPlayer
    {
        public static string Name { get; set; }
        public static int Wins { get; set; }

        public SecondPlayer(string name, int wins)
        {
            Name = name;
            Wins = wins;
        }
    }
}
