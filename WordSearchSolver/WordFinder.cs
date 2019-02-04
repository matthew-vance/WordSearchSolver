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
                SearchBackward,
                SearchForward,
                SearchDownAndForward,
                SearchUpAndBackward
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
            if (WordOutOfBoundsDown(row))
                return false;

            return FindLetter((i) => row + i, (i) => column);
        }

        private bool SearchUp(int row, int column)
        {
            if (WordOutOfBoundsUp(row))
                return false;

            return FindLetter((i) => row - i, (i) => column);
        }

        private bool SearchBackward(int row, int column)
        {
            if (WordOutOfBoundsBackward(column))
                return false;

            return FindLetter((i) => row, (i) => column - i);
        }

        private bool SearchForward(int row, int column)
        {
            if (WordOutOfBoundsForward(column))
                return false;

            return FindLetter((i) => row, (i) => column + i);
        }

        private bool SearchDownAndForward(int row, int column)
        {
            if (WordOutOfBoundsDown(row) || WordOutOfBoundsForward(column))
                return false;

            return FindLetter((i) => row + i, (i) => column + i);
        }

        private bool SearchUpAndBackward(int row, int column)
        {
            if (WordOutOfBoundsUp(row) || WordOutOfBoundsBackward(column))
                return false;

            return FindLetter((i) => row - i, (i) => column - i);
        }

        #endregion

        private bool WordOutOfBoundsDown(int row)
        {
            return row + _word.Length > _puzzle.GetLength(1);
        }

        private bool WordOutOfBoundsForward(int column)
        {
            return _word.Length + column > _puzzle.GetLength(0);
        }

        private bool WordOutOfBoundsUp(int row)
        {
            return row - _word.Length + 1 < 0;
        }

        private bool WordOutOfBoundsBackward(int column)
        {
            return column - _word.Length + 1 < 0;
        }

        private void UpdateLocation(int index, int column, int row)
        {
            _location[index, 0] = column;
            _location[index, 1] = row;
        }

        private bool LetterFound(int index, int row, int column)
        {
            var wordLength = _word.Length;
            if (_puzzle[row, column] == _word[index])
            {
                return true;
            }
            return false;
        }

        private bool FindLetter(Func<int, int> rowStepper, Func<int, int> columnStepper)
        {
            for (int i = 0; i < _word.Length; i++)
            {
                var row = rowStepper(i);
                var column = columnStepper(i);

                var letterFound = LetterFound(i, row, column);

                if(letterFound)
                {
                    UpdateLocation(i, column, row);
                    continue;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }
}
