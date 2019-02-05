using System;
using System.Collections.Generic;
using System.Text;
using WordSearchSolverApp;
using Xunit;

namespace WordSearchSolverTests.App
{
    public class OutputGeneratorTests
    {
        [Fact]
        public void Should_GenerateExpectedOutput_When_CalledWithWordSearch()
        {
            // Arrange
            var expectedOutputBuilder = new StringBuilder();
            expectedOutputBuilder.AppendLine("BONES: (0,6),(0,7),(0,8),(0,9),(0,10)");
            expectedOutputBuilder.AppendLine("KHAN: (5,9),(5,8),(5,7),(5,6)");
            expectedOutputBuilder.AppendLine("KIRK: (4,7),(3,7),(2,7),(1,7)");
            expectedOutputBuilder.AppendLine("SCOTTY: (0,5),(1,5),(2,5),(3,5),(4,5),(5,5)");
            expectedOutputBuilder.AppendLine("SPOCK: (2,1),(3,2),(4,3),(5,4),(6,5)");
            expectedOutputBuilder.AppendLine("SULU: (3,3),(2,2),(1,1),(0,0)");
            expectedOutputBuilder.AppendLine("UHURA: (4,0),(3,1),(2,2),(1,3),(0,4)");
            expectedOutputBuilder.AppendLine("COMPUTER: (7,12),(8,11),(9,10),(10,9),(11,8),(12,7),(13,6),(14,5)");
            var expectedOutput = expectedOutputBuilder.ToString();

            // Act
            var output = OutputGenerator.Generate(TestHelpers.GetMockWordSearch(true));

            // Assert
            Assert.Equal(expectedOutput, output);
        }
    }
}
