using System;
using System.Collections.Generic;
using System.Text;

namespace WordSearchSolver
{
    public class Coordinate
    {
        public int Row { get; private set; }
        public int Column { get; private set; }

        public Coordinate(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}
