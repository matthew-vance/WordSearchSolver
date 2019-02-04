using System;
using WordSearchSolver;
using Xunit;
using Moq;
using System.Collections.Generic;
using System.Collections;
using Newtonsoft.Json;

namespace WordSearchSolverTests
{
    public class WordFinderTests
    {
        DefaultWordFinder wordFinder = new DefaultWordFinder();

        [Theory]
        [ClassData(typeof(ReturnLocationTestData))]
        public void Should_ReturnWordLocation_When_PassedWordInPuzzle(string word, bool expectedWordFound, IList<Coordinate> expectedWordLocation)
        {
            // Arrange
            wordFinder.LoadPuzzle(TestHelpers.GetMockPuzzle());

            // Act
            var wordFound = wordFinder.TryFindWord(word, out IList<Coordinate> location);

            // Assert
            Assert.Equal(expectedWordFound, wordFound);
            Assert.Equal(JsonConvert.SerializeObject(expectedWordLocation), JsonConvert.SerializeObject(location));
        }
    }

    internal class ReturnLocationTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            // word, found, location
            yield return new object[] { "BONES", true, new List<Coordinate> { new Coordinate(6, 0), new Coordinate(7, 0), new Coordinate(8, 0), new Coordinate(9, 0), new Coordinate(10, 0) } }; // Search down
            yield return new object[] { "CHEKOV", false, null }; // Not in puzzle
            yield return new object[] { "KHAN", true, new List<Coordinate> { new Coordinate(9, 5), new Coordinate(8, 5), new Coordinate(7, 5), new Coordinate(6, 5) } }; // Search up
            yield return new object[] { "KIRK", true, new List<Coordinate> { new Coordinate(7, 4), new Coordinate(7, 3), new Coordinate(7, 2), new Coordinate(7, 1) } }; // Search backward
            yield return new object[] { "SCOTTY", true, new List<Coordinate> { new Coordinate(5, 0), new Coordinate(5, 1), new Coordinate(5, 2), new Coordinate(5, 3), new Coordinate(5, 4), new Coordinate(5, 5) } }; // Search forward
            yield return new object[] { "SPOCK", true, new List<Coordinate> { new Coordinate(1, 2), new Coordinate(2, 3), new Coordinate(3, 4), new Coordinate(4, 5), new Coordinate(5, 6) } }; // Search diagonal down/forward
            yield return new object[] { "SULU", true, new List<Coordinate> { new Coordinate(3, 3), new Coordinate(2, 2), new Coordinate(1, 1), new Coordinate(0, 0) } }; // Search diagonal up/backward
            yield return new object[] { "UHURA", true, new List<Coordinate> { new Coordinate(0, 4), new Coordinate(1, 3), new Coordinate(2, 2), new Coordinate(3, 1), new Coordinate(4, 0) } }; // Search diagonal down/backward
            yield return new object[] { "COMPUTER", true, new List<Coordinate> { new Coordinate(12, 7), new Coordinate(11, 8), new Coordinate(10, 9), new Coordinate(9, 10), new Coordinate(8, 11), new Coordinate(7, 12), new Coordinate(6, 13), new Coordinate(5, 14) } }; // Search diagonal up/forward
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
