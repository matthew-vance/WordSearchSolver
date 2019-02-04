using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WordSearchSolver;
using Xunit;

namespace WordSearchSolverTests
{
    public class WordTests
    {
        [Fact]
        public void Should_CreateWordWithText_When_InstantiatedWithText()
        {
            // Arrange
            var text = It.IsAny<string>();

            // Act
            var word = new Word(text);

            // Assert
            Assert.Equal(text, word.Text);
        }
    }
}
