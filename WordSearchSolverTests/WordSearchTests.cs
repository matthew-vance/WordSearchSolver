using System;
using WordSearchSolver;
using System.Collections.Generic;
using Xunit;

namespace WordSearchSolverTests
{
    public class WordSearchTests
    {
        [Fact]
        public void Should_CreateWordSearchWIthWordsAndPuzzle_When_InstantiatedWithWordsAndPuzzle()
        {
            // Arrange
            var words = new List<string>() { "BONES", "CHEKOV", "KHAN", "KIRK", "SCOTTY", "SPOCK", "SULU", "UHURA", "COMPUTER" };
            var puzzle = TestHelpers.GetMockPuzzle();

            // Act
            var wordSearch = new WordSearch(words, puzzle);

            // Assert
            Assert.Equal(words, wordSearch.Words);
            Assert.Equal(puzzle, wordSearch.Puzzle);
        }
    }
}
