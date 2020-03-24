using System;
using System.Threading;
using Maze.Models;

namespace Maze.Controllers
{
    class Game
    {
        private readonly Player _player;
        public static bool GameOver = false;
        public Map Map = new Map();

        public Game()
        {
            this._player = new Player();
        }

        public void Start()
        {
            Console.CursorVisible = false;
            Map.LoadMap(_player);
            Map.DrawMap();
            Thread Music = new Thread(new ThreadStart(this.Music));
            Thread Timer = new Thread(new ThreadStart(this.Music));
            Music.Start();

            while (!GameOver)
            {

                GetInput();
                Ui();
                Map.DrawMap();
            }
        }

        public void GetInput()
        {
            var keyInput = Console.ReadKey(true);
            Map.MovePlayer(keyInput, _player);
        }

        public void Ui()
        {
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Cash:    |   Lives: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(6, 0);
            Console.Write("${0}", _player.Score);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(20, 0);
            Console.Write("H{0}", _player.Health);
        }

        public void Music()
        {
            while (!GameOver)
            {
                Console.Beep(784, 150);
                Thread.Sleep(300);
                Console.Beep(784, 150);
                Thread.Sleep(300);
                Console.Beep(932, 150);
                Thread.Sleep(150);
                Console.Beep(1047, 150);
                Thread.Sleep(150);
                Console.Beep(784, 150);
                Thread.Sleep(300);
                Console.Beep(784, 150);
                Thread.Sleep(300);
                Console.Beep(699, 150);
                Thread.Sleep(150);
                Console.Beep(740, 150);
                Thread.Sleep(150);
                Console.Beep(784, 150);
                Thread.Sleep(300);
                Console.Beep(784, 150);
                Thread.Sleep(300);
                Console.Beep(932, 150);
                Thread.Sleep(150);
                Console.Beep(1047, 150);
                Thread.Sleep(150);
                Console.Beep(784, 150);
                Thread.Sleep(300);
                Console.Beep(784, 150);
                Thread.Sleep(300);
                Console.Beep(699, 150);
                Thread.Sleep(150);
                Console.Beep(740, 150);
                Thread.Sleep(150);
                Console.Beep(932, 150);
                Console.Beep(784, 150);
                Console.Beep(587, 1200);
                Thread.Sleep(75);
                Console.Beep(932, 150);
                Console.Beep(784, 150);
                Console.Beep(554, 1200);
                Thread.Sleep(75);
                Console.Beep(932, 150);
                Console.Beep(784, 150);
                Console.Beep(523, 1200);
                Thread.Sleep(150);
                Console.Beep(466, 150);
                Console.Beep(523, 150);
            }
        }
    }
}
