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
        private Player Player { get; }
        private Game game { get; }

        public GraphicalUserInterface(Game game,Player player)
        { 
            Player = player;
            this.game = game;
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
                game.Play();
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
            while (Console.ReadKey(true).Key != ConsoleKey.Escape)
            {

            }
            Menu();

        }
        public void ChangeRadius()
        {
            Console.Clear();
            Console.WriteLine("Enter the radius you'd like to play with(from 1 to 3)");

            var radius = Convert.ToByte(Console.ReadLine()); //Add validation
            if (radius > 0 && radius < 4)
            {
                Player.ChangeRadius(radius);
                Console.WriteLine("Press escape to return to the menu");
            }
            else
            {
                Console.WriteLine("Incorrect input");
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape)
            {
                
            }
            Menu();
        }
        public void PlayerInfo()
        {
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Cash:    |   Lives:     |   Score: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(6, 0);
            Console.Write("${0}", Player.Cash);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(20, 0);
            Console.Write("H{0}", Player.Health);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(34, 0);
            Console.Write("{0}XP", Player.Score);
            Console.SetCursorPosition(48, 0);
            Console.Write("{0}s", game.Timer.GetTime());
        }
        public void GameOver(bool victory)
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
            Console.WriteLine("Your score: {0}", Player.Score);
            Console.WriteLine("Your time: {0}s", game.Timer.GetTime());
            Console.WriteLine("Press enter to open menu");
            Console.ReadKey(true);
            Player.MapNo = 1;
            Player.Score = 0;
            Player.Health = 1;
            Menu();
        }

    }
}
