using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Model
{
    public static class Shapes
    {
        #region Variables 
        private static readonly int[,] _straight = new int[4, 4]
        {
            {0, 0, 0, 0 },
            {1, 1, 1, 1 },
            {0, 0, 0, 0 },
            {0, 0, 0, 0 },
        };

        private static readonly int[,] _square = new int[2, 2]
        {
            {2, 2},
            {2, 2},
        };

        private static readonly int[,] _lType = new int[3, 3]
        {
            {3, 0, 0},
            {3, 3, 3},
            {0, 0, 0},
        };

        private static readonly int[,] _triangle = new int[3, 3]
        {
            {0, 4, 0},
            {4, 4, 4},
            {0, 0, 0},
        };

        private static readonly int[,] _sType = new int[3, 3]
        {
            {0, 5, 5},
            {5, 5, 0},
            {0, 0, 0},
        };
        #endregion

        #region Properties
        public static int[,] Straight { get { return _straight; } }

        public static int[,] Square { get { return _square; } }

        public static int[,] LType { get { return _lType; } }

        public static int[,] Triangle { get { return _triangle; } }

        public static int[,] SType { get { return _sType; } }
        #endregion
    }
}
