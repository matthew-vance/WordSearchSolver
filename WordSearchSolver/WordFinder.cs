using System;
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
            var wordFound = false;
            location = new int[word.Length, 2];
            var wordFirstLetter = word[0];

            for (int row = 0; row < _puzzle.GetLength(0); row++)
            {
                for (int column = 0; column < _puzzle.GetLength(1); column++)
                {
                    var currentPuzzleLetter = _puzzle[row, column];
                    if (currentPuzzleLetter != wordFirstLetter)
                        continue;

                    wordFound = TrySearchDown(word, row, column, out location);
                    if (wordFound)
                        break;
                }
                if (wordFound)
                    break;
            }
            return wordFound;
        }

        private bool TrySearchDown(string word, int row, int column, out int[,] location)
        {
            location = new int[word.Length, 2];

            if (word.Length + row > _puzzle.GetLength(0))
                return false;

            for (int i = 0; i < word.Length; i++)
            {
                var currentRow = row + i;
                if (_puzzle[currentRow, column] == word[i])
                {
                    location[i, 0] = column;
                    location[i, 1] = currentRow;
                }
                else
                    return false;
            }

            return true;
        }
    }
}
