using System;
using System.Collections.Generic;
using System.Text;

namespace WordSearchSolver
{
    public class WordSearch
    {
        public readonly IList<string> Words;
        public readonly char[,] Puzzle;

        public WordSearch(IList<string> words, char[,] puzzle)
        {
            Words = words;
            Puzzle = puzzle;
        }
    }
}
