using System;
using System.Collections.Generic;

namespace Maze.Models
{
    struct Door
    {
        public char Icon;
        public char IconEncrypted;
        public bool IsOpen;
        public ConsoleColor Color;


        public Door(char icon, ConsoleColor color)
        {
            IsOpen = false;
            this.Icon = icon;
            this.IconEncrypted = icon;
            this.Color = color;
        }

        public void Open(char key)
        {
            if (char.ToUpper(key) == this.Icon)
            {
                IsOpen = true;
            }
        }
    }


}