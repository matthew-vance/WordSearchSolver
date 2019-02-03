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

                    wordFound = TrySearchForWord(row, column);

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

        private bool TrySearchForWord(int row, int column)
        {
            var trySearchMethods = new List<TrySearchMethodDelegate>
            {
                TrySearchDown,
                TrySearchUp,
                TrySearchBackward
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

        private delegate bool TrySearchMethodDelegate(int row, int column);

        #region Search Methods

        private bool TrySearchDown(int row, int column)
        {
            _location = new int[_word.Length, 2];

            if (_word.Length + row > _puzzle.GetLength(0))
                return false;

            for (int i = 0; i < _word.Length; i++)
            {
                var currentRow = row + i;
                var letterFound = TryFindLetter(i, currentRow, column);

                if (!letterFound)
                    return false;

            }
            return true;
        }

        private bool TrySearchUp(int row, int column)
        {
            if (row - _word.Length < 0)
                return false;

            for (int i = 0; i < _word.Length; i++)
            {
                var currentRow = row - i;
                var letterFound = TryFindLetter(i, currentRow, column);

                if (!letterFound)
                    return false;
            }
            return true;
        }

        private bool TrySearchBackward(int row, int column)
        {
            if (column - _word.Length < 0)
                return false;

            for (int i = 0; i < _word.Length; i++)
            {
                var currentColumn = column - i;
                var letterFound = TryFindLetter(i, row, currentColumn);

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

        private bool TryFindLetter(int index, int row, int column)
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
