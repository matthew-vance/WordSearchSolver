using System;
using System.Collections.Generic;
using System.Text;

namespace WordSearchSolver
{
    public class WordSearch
    {
        public readonly IList<Word> Words;
        public readonly char[,] Puzzle;

        public WordSearch(IList<Word> words, char[,] puzzle)
        {
            Words = words;
            Puzzle = puzzle;
        }
    }
}
