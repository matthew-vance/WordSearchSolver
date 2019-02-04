using System;
using WordSearchSolver;
using Xunit;
using Moq;
using System.Collections.Generic;
using System.Collections;

namespace WordSearchSolverTests
{
    public class WordFinderTests
    {
        WordFinder wordFinder = new WordFinder(GetMockPuzzle());

        [Theory]
        [ClassData(typeof(ReturnLocationTestData))]
        public void Should_ReturnWordLocation_When_PassedWordInPuzzle(string word, bool expectedWordFound, int[,] expectedWordLocation)
        {
            // Act
            var wordFound = wordFinder.TryFindWord(word, out int[,] location);

            // Assert
            Assert.Equal(expectedWordFound, wordFound);
            Assert.Equal(expectedWordLocation, location);
        }

        private static char[,] GetMockPuzzle()
        {
            return new char[,] { {'U','M','K','H','U','L','K','I','N','V','J','O','C','W','E'},
                                 {'L','L','S','H','K','Z','Z','W','Z','C','G','J','U','Y','G'},
                                 {'H','S','U','P','J','P','R','J','D','H','S','B','X','T','G'},
                                 {'B','R','J','S','O','E','Q','E','T','I','K','K','G','L','E'},
                                 {'A','Y','O','A','G','C','I','R','D','Q','H','R','T','C','D'},
                                 {'S','C','O','T','T','Y','K','Z','R','E','P','P','X','P','R'},
                                 {'B','L','Q','S','L','N','E','E','E','V','U','L','F','E','Z'},
                                 {'O','K','R','I','K','A','M','M','R','M','F','B','T','P','P'},
                                 {'N','U','I','I','Y','H','Q','M','E','M','Q','U','Y','F','S'},
                                 {'E','Y','Z','Y','G','K','Q','J','P','C','P','W','Y','A','K'},
                                 {'S','J','F','Z','M','Q','I','B','D','M','E','M','K','W','D'},
                                 {'T','G','L','B','H','C','B','E','O','H','T','O','Y','I','K'},
                                 {'O','J','Y','E','U','L','N','C','C','L','Y','B','Z','U','H'},
                                 {'W','Z','M','I','S','U','K','U','R','B','I','D','U','X','S'},
                                 {'K','Y','L','B','Q','Q','P','M','D','F','C','K','E','A','B'}
            };
        }
    }

    internal class ReturnLocationTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            // word, found, location
            yield return new object[] { "BONES", true, new int[5, 2] { { 0, 6 }, { 0, 7 }, { 0, 8 }, { 0, 9 }, { 0, 10 } } }; // Search down
            yield return new object[] { "CHEKOV", false, null }; // Not in puzzle
            yield return new object[] { "KHAN", true, new int[4, 2] { { 5, 9 }, { 5, 8 }, { 5, 7 }, { 5, 6 } } }; // Search up
            yield return new object[] { "KIRK", true, new int[4, 2] { { 4, 7 }, { 3, 7 }, { 2, 7 }, { 1, 7 } } }; // Search backward
            yield return new object[] { "SCOTTY", true, new int[6, 2] { { 0, 5 }, { 1, 5 }, { 2, 5 }, { 3, 5 }, { 4, 5 }, { 5, 5 } } }; // Search forward
            yield return new object[] { "SPOCK", true, new int[5, 2] { { 2, 1 }, { 3, 2 }, { 4, 3 }, { 5, 4 }, { 6, 5 } } }; // Search diagonal down/forward
            yield return new object[] { "SULU", true, new int[4, 2] { { 3, 3 }, { 2, 2 }, { 1, 1 }, { 0, 0 } } }; // Search diagonal up/backward
            yield return new object[] { "UHURA", true, new int[5, 2] { { 4, 0 }, { 3, 1 }, { 2, 2 }, { 1, 3 }, { 0, 4 } } }; // Search diagonal down/backward
            yield return new object[] { "COMPUTER", true, new int[8, 2] { { 7, 12 }, { 8, 11 }, { 9, 10 }, { 10, 9 }, { 11, 8 }, { 12, 7 }, { 13, 6 }, { 14, 5 } } }; // Search diagonal up/forward
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
