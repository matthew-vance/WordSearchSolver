using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WordSearchSolver;
using Xunit;

namespace WordSearchSolverTests
{
    public class SolverTests
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
        public void Should_SolveEachWord_When_PassedWordSearch()
        {
            // Arrange
            var wordSearchSolver = new Solver(wordFinder.Object);
            var wordSearch = TestHelpers.GetMockWordSearch();

            // Act
            wordSearchSolver.Solve(wordSearch);

            var test = new Solver();
            test.Solve(wordSearch);

            // Assert
            wordFinder.Verify(n => n.FindWord(It.IsAny<Word>()), Times.Exactly(wordSearch.Words.Count));
        }

        [Fact]
        public void Should_SetPuzzle_ForWordFinder()
        {
            // Arrange
            var wordSearchSolver = new Solver(wordFinder.Object);
            var wordSearch = TestHelpers.GetMockWordSearch();

            // Act
            wordSearchSolver.Solve(wordSearch);

            // Assert
            wordFinder.Verify(n => n.LoadPuzzle(It.IsAny<char[,]>()), Times.Once);
        }
    }
}
