using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Controllers
{
    class GetRadiusResult
    {
        public int[] X { get; set; }
        public int[] Y { get; set; }
        public GetRadiusResult(int[] x, int[] y)
        {
            X = x;
            Y = y;
        }
    }
}
