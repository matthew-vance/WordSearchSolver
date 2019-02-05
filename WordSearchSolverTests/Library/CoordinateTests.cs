using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WordSearchSolver;
using Xunit;

namespace WordSearchSolverTests
{
    public class CoordinateTests
    {
        [Fact]
        public void Should_CreateCoordinateWithRowAndColumn_When_InstantiatedWithRowAndColumn()
        {
            // Arrange
            var row = It.IsAny<int>();
            var column = It.IsAny<int>();

            // Act
            var coordinate = new Coordinate(row, column);

            // Assert
            Assert.Equal(row, coordinate.Row);
            Assert.Equal(column, coordinate.Column);
        }
    }
}
