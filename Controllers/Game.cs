using System;
using System.ComponentModel.Design;
using System.Threading;
using Maze.Models;

namespace Maze.Controllers
{
    class Game
    {
        public Player Player;
        public static bool GameOver = false;
        public Map Map;
        public Ui Ui;

        public Game()
        {
            Player = new Player();
            Map = new Map();
            Ui = new Ui();
        }

        public void Start()
        { 
            Console.SetBufferSize(120,35);
            Console.CursorVisible = false;
            Ui.Menu();
            Map.LoadMap(Player);
            var state = new State();
            //var state2 = new State();
            var win = false;
            var music = new Thread(new ParameterizedThreadStart(Ui.Music));
            //var timer = new Thread(new ParameterizedThreadStart(Ui.Timer));
            music.Start(state);
            //timer.Start(state2);
            while (!GameOver || Console.ReadKey().Key != ConsoleKey.Escape)
            {
                Map.DrawMap(Player);
                Ui.Gui(Player);
                GetInput();
                if (Player.Health < 0)
                {
                    break;
                }

                if (Map.MapNo > Map.AmountOfMaps)
                {
                    win = true;
                    break;
                }
            }

            state.Cancel = true;
            //state2.Cancel = true;
            music.Join();
            Over(win);
        }
        public void Over(bool victory)
        {
            Console.Clear();
            Console.ForegroundColor = victory ? ConsoleColor.White : ConsoleColor.Red;
            Console.WriteLine(victory ? "VICTORY" : "GAME OVER");
            Console.WriteLine("Your score: {0}",Player.Score);
            Console.WriteLine("Press enter to open menu");
            Console.ReadKey(true);
            Map.MapNo = 1;
            Player.Score = 0;
            Player.Health = 0;
            Start();
        }


        public void GetInput()
        {
            var keyInput = Console.ReadKey(true);
            Map.MovePlayer(keyInput, Player);
        }

    }
}
