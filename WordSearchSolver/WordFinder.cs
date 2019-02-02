using System;

namespace WordSearchSolver
{
    public class WordFinder
    {
        private readonly char[,] _puzzle;

        public WordFinder(char[,] puzzle)
        {
            _puzzle = puzzle;
        }

        public bool TryFindWord(string word)
        {
            return true;
        }
    }
}
