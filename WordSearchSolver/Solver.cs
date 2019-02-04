using System;
using System.Collections.Generic;
using System.Text;

namespace WordSearchSolver
{
    public class Solver
    {
        private readonly IWordFinder _wordFinder;

        public Solver(IWordFinder wordFinder = null)
        {
            _wordFinder = wordFinder ?? new DefaultWordFinder();
        }

        public IList<int[]> Solve(WordSearch wordSearch)
        {
            return new List<int[]>();
        }
    }
}
