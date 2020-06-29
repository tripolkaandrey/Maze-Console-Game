using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Controllers
{
    class State
    {
        public bool IsAlive { get; set; }

        public State()
        {
            IsAlive = true;
        }
    }
}
