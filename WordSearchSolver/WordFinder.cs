using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("WordSearchSolverTests")]
namespace WordSearchSolver
{
    internal class WordFinder
    {
        private readonly char[,] _puzzle;
        private string _word;
        private int[,] _location;

        public WordFinder(char[,] puzzle)
        {
            _puzzle = puzzle;
        }

        public bool TryFindWord(string word, out int[,] location)
        {
            _word = word;
            _location = new int[_word.Length, 2];
            var shouldStopSearching = false;
            var wordFound = false;
            var wordFirstLetter = _word[0];

            int row = 0;
            while (!shouldStopSearching)
            {
                for (int column = 0; column < _puzzle.GetLength(1); column++)
                {
                    var currentPuzzleLetter = _puzzle[row, column];
                    if (currentPuzzleLetter != wordFirstLetter)
                        continue;

                    wordFound = SearchForWord(row, column);

                    if (wordFound)
                    {
                        shouldStopSearching = true;
                        break;
                    }
                }
                row++;
                if (row == _puzzle.GetLength(0))
                    shouldStopSearching = true;
            }

            location = wordFound ? _location : null;
            return wordFound;
        }

        private bool SearchForWord(int row, int column)
        {
            var trySearchMethods = new List<SearchMethodDelegate>
            {
                SearchDown,
                SearchUp,
                SearchBackward
            };

            foreach (var method in trySearchMethods)
            {
                var wordFound = method(row, column);
                if (wordFound)
                {
                    return wordFound;
                }
            }
            return false;
        }

        private delegate bool SearchMethodDelegate(int row, int column);

        #region Search Methods

        private bool SearchDown(int row, int column)
        {
            if (_word.Length + row > _puzzle.GetLength(0))
                return false;

            for (int i = 0; i < _word.Length; i++)
            {
                var currentRow = row + i;
                var letterFound = FindLetter(i, currentRow, column);

                if (!letterFound)
                    return false;

            }
            return true;
        }

        private bool SearchUp(int row, int column)
        {
            if (row - _word.Length < 0)
                return false;

            for (int i = 0; i < _word.Length; i++)
            {
                var currentRow = row - i;
                var letterFound = FindLetter(i, currentRow, column);

                if (!letterFound)
                    return false;
            }
            return true;
        }

        private bool SearchBackward(int row, int column)
        {
            if (column - _word.Length < 0)
                return false;

            for (int i = 0; i < _word.Length; i++)
            {
                var currentColumn = column - i;
                var letterFound = FindLetter(i, row, currentColumn);

                if (!letterFound)
                    return false;
            }
            return true;
        }

        #endregion

        private void UpdateLocation(int index, int column, int row)
        {
            _location[index, 0] = column;
            _location[index, 1] = row;
        }

        private bool FindLetter(int index, int row, int column)
        {
            var wordLength = _word.Length;
            if (_puzzle[row, column] == _word[index])
            {
                UpdateLocation(index, column, row);
                return true;
            }
            return false;
        }
    }
}
