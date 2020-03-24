using System;
using System.ComponentModel;

namespace Maze.Models
{
    class Player
    {
        public const char Icon = 'o';
        public const char IconEncrypted = 'P';
        public const ConsoleColor Color = ConsoleColor.Yellow;
        public int Score = 0;
        public int Health = 0;
        public int X;
        public int Y;
    }
}

