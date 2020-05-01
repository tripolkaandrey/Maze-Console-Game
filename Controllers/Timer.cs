using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Maze.Controllers
{
    class Timer
    {
        private int _time;
        public State State { get; set; }

        public Timer()
        {
            _time = 0;
            State = new State();
        }
        public void Start()
        {
            _time = 0;
            while (State.IsAlive)
            {
                _time++;
                Thread.Sleep(1000);
            }
        }

        public int GetTime() => _time;
    }
}
