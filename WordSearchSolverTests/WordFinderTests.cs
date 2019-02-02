using System;
using WordSearchSolver;
using Xunit;
using Moq;

namespace WordSearchSolverTests
{
    public class WordFinderTests
    {
        [Fact]
        public void Should_TryFindWord_When_PassedWordInPuzzle()
        {
            // Arrange
            var wordFinder = new WordFinder();

            // Act
            var wordFound = wordFinder.TryFindWord(It.IsAny<string>());

            // Assert
            Assert.True(wordFound);
        }
    }
}
