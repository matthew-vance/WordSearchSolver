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
        [Fact]
        public void Should_CreateWordSearchSolver_When_InstantiatedWithWordFinder()
        {
            // Arrange
            var wordFinder = new Mock<IWordFinder>().Object;

            // Act
            var wordSearchSolver = new Solver(wordFinder);

            // Assert
            Assert.IsType<Solver>(wordSearchSolver);
        }
    }
}
