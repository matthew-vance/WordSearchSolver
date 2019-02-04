using System;
using WordSearchSolver;
using System.Collections.Generic;
using Xunit;
using Moq;

namespace WordSearchSolverTests
{
    public class WordSearchTests
    {
        [Fact]
        public void Should_CreateWordSearchWIthWordsAndPuzzle_When_InstantiatedWithWordsAndPuzzle()
        {
            // Arrange
            var words = It.IsAny<IList<string>>();
            var puzzle = It.IsAny<char[,]>();

            // Act
            var wordSearch = new WordSearch(words, puzzle);

            // Assert
            Assert.Equal(words, wordSearch.Words);
            Assert.Equal(puzzle, wordSearch.Puzzle);
        }
    }
}
