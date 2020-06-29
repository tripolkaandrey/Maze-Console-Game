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
        public int Time { get; private set; }
        //public State State { get; set; }

        public Timer()
        {
            Time = 0;
            //State = new State();
        }
        public void Start()
        {
            Time = 0;
            //while (State.IsAlive)
            while(true)
            {
                Time++;
                Thread.Sleep(1000);
            }
        }

    }
}
