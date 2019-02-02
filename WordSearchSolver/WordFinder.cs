using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("WordSearchSolverTests")]
namespace WordSearchSolver
{
    internal class WordFinder
    {
        private readonly char[,] _puzzle;

        public WordFinder(char[,] puzzle)
        {
            _puzzle = puzzle;
        }

        public bool TryFindWord(string word, out int[,] location)
        {
            var shouldStopSearching = false;
            var wordFound = false;
            location = null;
            var wordFirstLetter = word[0];

            int row = 0;
            while (!shouldStopSearching)
            {
                for (int column = 0; column < _puzzle.GetLength(1); column++)
                {
                    var currentPuzzleLetter = _puzzle[row, column];
                    if (currentPuzzleLetter != wordFirstLetter)
                        continue;

                    wordFound = TrySearchForWord(word, row, column, out int[,] foundLocation);

                    if (wordFound)
                    {
                        location = foundLocation;
                        shouldStopSearching = true;
                        break;
                    }
                }
                row++;
                if (row == _puzzle.GetLength(0))
                    shouldStopSearching = true;
            }

            return wordFound;
        }

        private bool TrySearchForWord(string word, int row, int column, out int[,] location)
        {
            location = null;
            var trySearchMethods = new List<TrySearchMethodDelegate>
            {
                TrySearchDown,
                TrySearchUp
            };

            foreach (var method in trySearchMethods)
            {
                var wordFound = method(word, row, column, out location);
                if (wordFound)
                {
                    return wordFound;
                }
            }
            return false;
        }

        private delegate bool TrySearchMethodDelegate(string word, int row, int column, out int[,] location);

        #region Search Methods

        private bool TrySearchDown(string word, int row, int column, out int[,] location)
        {
            var wordLength = word.Length;
            location = new int[wordLength, 2];

            if (wordLength + row > _puzzle.GetLength(0))
                return false;

            for (int i = 0; i < wordLength; i++)
            {
                var currentRow = row + i;
                if (_puzzle[currentRow, column] == word[i])
                {
                    UpdateLocation(i, column, currentRow, location);
                }
                else
                    return false;
            }
            return true;
        }

        private bool TrySearchUp(string word, int row, int column, out int[,] location)
        {
            var wordLength = word.Length;
            location = new int[word.Length, 2];

            if (row - wordLength < 0)
                return false;

            for (int i = 0; i < wordLength; i++)
            {
                var currentRow = row - i;
                if (_puzzle[currentRow, column] == word[i])
                {
                    UpdateLocation(i, column, currentRow, location);
                }
                else
                    return false;
            }
            return true;
        }

        #endregion

        private void UpdateLocation(int index, int column, int row, int[,] location)
        {
            location[index, 0] = column;
            location[index, 1] = row;
        }
    }
}
