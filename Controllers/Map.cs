using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Maze.Controllers;
using Maze.Models;

namespace Maze.Controllers
{
    class Map
    {
        private GameObject[,] _gameMap;
        private string[] _mapValues;
        private readonly Player _player;
        private readonly byte _amountOfMaps;
        private readonly string _path;
        private Dictionary<char,string> _icons = new Dictionary<char, string>
        {
            {'#',"Wall"},
            {'T',"Trap"},
            {'o',"Player"},
            {'$',"Cash"},
            {'H',"Life"},
            {'%',"Exit"},
            {' ',"EmptyCell"}
        };

        public Map(Player player, GameInfo gameInfo)
        {
            _player = player;
            _amountOfMaps = gameInfo.AmountOfMaps;
            _path = gameInfo.Path;
        }
        public void LoadMap()
        {
            InitializeGameMap();

            for (int row = 0; row <= _gameMap.GetUpperBound(0); row++)
            {
                for (int coll = 0; coll <= _gameMap.GetUpperBound(1); coll++)
                {
                    LoadElement(row, coll);
                }
            }
        }

        private void LoadElement(int row, int coll)
        {
            var current = _icons[_mapValues[row][coll]];
            if (current == "Player")
            {
                _gameMap[row, coll] = _player;
                _player.X = coll;
                _player.Y = row;
            }
            else
            {
                Type type = Type.GetType("Maze.Models." + current);
                _gameMap[row, coll] = (GameObject) Activator.CreateInstance(type);
            }
        }

        public void DrawMap()
        {
            Console.Clear();
            var radius = GetRadius();

            for (int row = radius.Y[0]; row < radius.Y[1]; row++)
            {
                for (int coll = radius.X[0]; coll < radius.X[1]; coll++)
                {
                    var gameObject = _gameMap[row, coll];

                    Console.SetCursorPosition(coll, 1 + row);
                    Console.ForegroundColor = gameObject.Color;
                    Console.Write(gameObject.Icon);
                }
                Console.WriteLine();
            }
        }
        public void MovePlayer(ConsoleKeyInfo arrow)
        {
            switch (arrow.Key)
            {
                case ConsoleKey.UpArrow:
                    ProcessMove(_player.X,_player.Y - 1);
                    break;
                case ConsoleKey.DownArrow:
                    ProcessMove(_player.X,_player.Y + 1);
                    break;
                case ConsoleKey.LeftArrow:
                    ProcessMove(_player.X - 1,_player.Y);
                    break;
                case ConsoleKey.RightArrow:
                    ProcessMove(_player.X + 1,_player.Y);
                    break;
            }
        }
        private void ProcessMove(int cellX, int cellY)
        {
            if (cellY > _gameMap.GetUpperBound(0) ||
                cellY < 0 ||
                cellX < 0 ||
                cellX > _gameMap.GetUpperBound(1) ||
                _gameMap[cellY, cellX] is Wall) return;

            _gameMap[cellY, cellX].Process(_player);

            if (_gameMap[cellY, cellX] is Exit)
            {
                LoadMap();
                return;
            }

            _gameMap[_player.Y,_player.X] = new EmptyCell();
            _gameMap[cellY, cellX] = _player;
            _player.Y = cellY;
            _player.X = cellX;
        }

        public bool IsGameFinished()
        {
            return _player.MapNo > _amountOfMaps;
        }
        private void InitializeGameMap()
        {
            var fileLoader = new StreamReader(_path + _player.MapNo + ".map");
            _mapValues = File.ReadAllLines(_path + _player.MapNo + ".map");
            var height = _mapValues.Length;
            var length = fileLoader.ReadLine().Length;
            _gameMap = new GameObject[height, length];
        }
        private GetRadiusResult GetRadius()//Change
        {
            var radiusX = new int[2]
            {
                _player.X - _player.Radius > 0 ? _player.X - _player.Radius : 0,
                _player.X + _player.Radius < _gameMap.GetUpperBound(1) + 1
                    ? _player.X + _player.Radius
                    : _gameMap.GetUpperBound(1) + 1
            };

            var radiusY = new int[2]
            {
                _player.Y - _player.Radius > 0 ? _player.Y - _player.Radius : 0,
                _player.Y + _player.Radius < _gameMap.GetUpperBound(0) + 1
                    ? _player.Y + _player.Radius
                    : _gameMap.GetUpperBound(0) + 1
            };

            return new GetRadiusResult(radiusX, radiusY);
        }
    }
}
