using System;
using System.ComponentModel.Design;
using System.IO;
using System.Threading;
using Maze.Models;
using Newtonsoft.Json;

namespace Maze.Controllers
{
    class Game
    {
        public Player Player { get; }
        public Timer Timer { get; }
        private readonly Map _map;
        private readonly GraphicalUserInterface _gui;
        private bool _gameOver;

        public Game()
        {
            Player = new Player();
            _gui = new GraphicalUserInterface(this);
            var json = File.ReadAllText("../../GameInfo.json");
            var gameInfo = JsonConvert.DeserializeObject<GameInfo>(json);
            _map = new Map(Player,gameInfo);
            Timer = new Timer();
        }
        public void Start()
        {
            Console.SetBufferSize(120, 35);
            Console.CursorVisible = false;
            _gui.Menu();
        }
        public void Play()
        {
            var win = false;
            var timer = new Thread(Timer.Start);
            _map.LoadMap();
            timer.Start();

            while (!_gameOver)
            {
                _map.DrawMap();
                _gui.PlayerInfo();
                GetInput();
                if (CheckGameOver(ref win))
                {
                    _gameOver = true;
                }
            }
            timer.Abort();
            _gui.GameOver(win);
        }
        public void GetInput()
        {
            var keyInput = Console.ReadKey(true);
            if (keyInput.Key == ConsoleKey.Escape)
            {
                _gameOver = true;
            }
            _map.MovePlayer(keyInput);
        }

        public bool CheckGameOver(ref bool win)
        {
            if (_map.IsGameFinished())
            {
                win = true;
                return true;
            }

            if (Player.Health <= 0)
            {
                win = false;
                return true;
            }

            return false;
        }

    }
}
