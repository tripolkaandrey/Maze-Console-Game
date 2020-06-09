using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Maze.Models;

namespace Maze.Controllers
{
    class GraphicalUserInterface
    {
        private readonly Game _game;

        public GraphicalUserInterface(Game game)
        {
            _game = game;
        }
        public void Menu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("#######################################");
            Console.WriteLine("##█###███#█###█#█#███#█#██##█#███#█#█##");
            Console.WriteLine("##█###█#█#█###███#███#█#█#█#█##█##███##");
            Console.WriteLine("##█###███#███###█#██##█#█#█#█##█##█#█##");
            Console.WriteLine("##███#█#█#███#███#█#█#█#█##██##█##█#█##");
            Console.WriteLine("#######################################");

            Console.WriteLine("            New Game(N)");
            Console.WriteLine("            Instructions(I)");
            Console.WriteLine("            Change Radius(R)");
            Console.WriteLine("            Exit(Esc)");
            if (Console.ReadKey(true).Key == ConsoleKey.N)
            {
                _game.Play();
            }
            else if (Console.ReadKey(true).Key == ConsoleKey.I)
            {
                Instructions();
            }
            else if (Console.ReadKey(true).Key == ConsoleKey.R)
            {
                ChangeRadius();
            }
            else if (Console.ReadKey(true).Key == ConsoleKey.Escape)
            {
                Environment.Exit(1);
            }
        }

        public void Instructions()
        {
            Console.Clear();
            Console.WriteLine("Instructions");
            Console.WriteLine("--------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Вы в лабиринте, из которого нужно найти выход(значок %)");
            Console.WriteLine(
                "Стрелочки - для передвижения.H - HP, $ - Валюта(прибавляет валюту и количество очков), T - Ловушка(отнимает хп)");
            Console.WriteLine("В меню можно выбрать радиус поля видимости(уровень сложности)");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("Press escape to return to the menu");
            if (Console.ReadKey(true).Key == ConsoleKey.Escape)
            {
                Menu();
            }

        }
        public void ChangeRadius()
        {
            Console.Clear();
            Console.WriteLine("Enter the radius you'd like to play with(from 1 to 3)");

            var radius = Convert.ToByte(Console.ReadLine()); //Add validation
            if (radius > 0 && radius < 4)
            {
                _game.Player.ChangeRadius(radius);
                Console.WriteLine("Press escape to return to the menu");
            }
            else
            {
                Console.WriteLine("Incorrect input");
            }
            if (Console.ReadKey(true).Key == ConsoleKey.Escape)
            {
                Menu();
            }
        }
        public void PlayerInfo()
        {
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Cash:    |   Lives:     |   Score: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(6, 0);
            Console.Write("${0}", _game.Player.Cash);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(20, 0);
            Console.Write("H{0}", _game.Player.Health);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(34, 0);
            Console.Write("{0}XP", _game.Player.Score);
            Console.SetCursorPosition(48, 0);
            Console.Write("{0}s", _game.Timer.Time);
        }
        public void GameOver(bool victory = false)
        {

            Console.Clear();
            Console.ForegroundColor = victory ? ConsoleColor.White : ConsoleColor.Red;
            if (victory)
            {
                Console.WriteLine("######################");
                Console.WriteLine("##█###█###█#██#█###█##");
                Console.WriteLine("##██#███#██#██#██##█##");
                Console.WriteLine("###█#█#█#█##██#█#█#█##");
                Console.WriteLine("####██#██###██ █##██##");
                Console.WriteLine("######################");
            }
            else
            {
                Console.WriteLine("#################################################");
                Console.WriteLine("##████#████#██###██#████###████#█###█#████#████##");
                Console.WriteLine("##█####█##█#█#█#█#█#████###█##█#█###█#████#████##");
                Console.WriteLine("##█#██#████#█##█##█#█######█##█#██#██#█####██####");
                Console.WriteLine("##████#█##█#█#####█#████###████##███##████#█#██##");
                Console.WriteLine("#################################################");
            }
            Console.WriteLine("Your score: {0}", _game.Player.Score);
            Console.WriteLine("Your time: {0}s", _game.Timer.Time);
            _game.Player.Reset();
            Console.WriteLine("Press enter to open menu");
            Console.ReadKey(true);

            Menu();
        }

    }
}
