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
                                 {'S','C','O','T','T','Y','K','Z','R','E','P','P','X','P','F'},
                                 {'B','L','Q','S','L','N','E','E','E','V','U','L','F','M','Z'},
                                 {'O','K','R','I','K','A','M','M','R','M','F','B','A','P','P'},
                                 {'N','U','I','I','Y','H','Q','M','E','M','Q','R','Y','F','S'},
                                 {'E','Y','Z','Y','G','K','Q','J','P','C','Q','W','Y','A','K'},
                                 {'S','J','F','Z','M','Q','I','B','D','B','E','M','K','W','D'},
                                 {'T','G','L','B','H','C','B','E','C','H','T','O','Y','I','K'},
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
            yield return new object[] { "KHAN", true, new int[4, 2] { {5, 9}, {5, 8}, {5, 7}, {5, 6} } }; // Search up
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
