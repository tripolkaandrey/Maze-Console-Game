using System;

namespace Maze.Models
{
    public abstract class GameObject
    { 

        public virtual char Icon { get; }
        public virtual ConsoleColor Color { get; }

        protected GameObject(char icon, ConsoleColor color)
        {
            Icon = icon;
            Color = color;
        }

    }
}