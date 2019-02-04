using System;
using System.Collections.Generic;
using System.Text;

namespace WordSearchSolver
{
    public interface IWordFinder
    {
        void LoadPuzzle(char[,] puzzle);
        bool TryFindWord(string word, out IList<Coordinate> location);
    }
}
