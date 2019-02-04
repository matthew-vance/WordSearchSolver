using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WordSearchSolver;
using Xunit;

namespace WordSearchSolverTests
{
    public class WordSearchSolverTests
    {
        Mock<IWordFinder> wordFinder = new Mock<IWordFinder>();

        [Fact]
        public void Should_CreateWordSearchSolver_When_InstantiatedWithWordFinder()
        {
            // Act
            var wordSearchSolver = new Solver(wordFinder.Object);

            // Assert
            Assert.IsType<Solver>(wordSearchSolver);
        }

        [Fact]
        public void Should_SolveWordSearch_When_PassedWordSearch()
        {
            // Arrange
            var wordSearchSolver = new Solver(wordFinder.Object);
            var wordSearch = It.IsAny<WordSearch>();

            // Act
            var locations = wordSearchSolver.Solve(wordSearch);

            // Assert
            Assert.Equal(new List<int[]>(), locations);
        }
    }
}
