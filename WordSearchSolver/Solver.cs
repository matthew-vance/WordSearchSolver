using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Solve(WordSearch wordSearch)
        {
            _wordFinder.LoadPuzzle(wordSearch.Puzzle);
            wordSearch.Words.ToList().ForEach(w => _wordFinder.FindWord(w));
        }
    }
}
