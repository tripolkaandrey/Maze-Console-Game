using System;
using System.ComponentModel;

namespace Maze.Models
{
    public class Player : GameObject
    {
        private char Icon { get; }
        private ConsoleColor Color { get; }

        public int MapNo { get; set; }
        public byte Radius { get; set; }
        public int Cash { get; set; }
        public int Score { get; set; }
        public int Health { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Player(char icon, ConsoleColor color):base(icon, color)
        {
            Icon = icon;
            Color = color;
            MapNo = 1;
            Cash = 0;
            Score = 0;
            Health = 1;
        }
        public Player(char icon, ConsoleColor color,byte radius) : this(icon, color)
        {
            Radius = radius;
        }
        public void Process(GameObject gameObject)
        {
            switch(gameObject)
            {
                case Life life:
                    Health++;
                    break;
                case Cash cash:
                    Score += 10;
                    Cash++;
                    break;
                case Trap trap:
                    Health--;
                    if (Score > 5)
                    {
                        Score -= 5;
                    } else
                    {
                        Score = 0;
                    }
                    break;
                case Exit exit:
                    MapNo++;
                    break;
            }
        }

        public void ChangeRadius(byte radius)
        {
            Radius = radius;
        }
    }
}

