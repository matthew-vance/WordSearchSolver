using System;
using System.Collections.Generic;
using System.Text;

namespace WordSearchSolver
{
    public interface IWordFinder
    {
        void LoadPuzzle(char[,] puzzle);
        void FindWord(Word word);
    }
}
