using System;

namespace Maze.Models
{
    struct Door
    {
        public char DoorSign;
        public char DoorKey;
        public ConsoleColor ConsoleColor;

        public Door(byte type)
        {
            DoorSign = type == 1 ? 'A' : type == 2 ? 'B' : 'C';
            DoorKey = char.ToLower(DoorSign);
            ConsoleColor = type == 1 ? ConsoleColor.Magenta : type == 2 ? ConsoleColor.Cyan : ConsoleColor.DarkBlue;
        }
    }
}