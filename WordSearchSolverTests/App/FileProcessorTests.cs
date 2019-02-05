using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO.Abstractions.TestingHelpers;
using System.Text;
using WordSearchSolverApp;
using Xunit;

namespace WordSearchSolverTests.App
{
    public class FileProcessorTests
    {
        [Fact]
        public void Should_ProcessFileIntoWordSearch_When_CalledWithPath()
        {
            // Arrange
            var fileSystem = new MockFileSystem(new Dictionary<string, MockFileData>
            {
                { @"\Path\To\File.txt", GetMockFileData() }
            });

            var fileProcessor = new FileProcessor(fileSystem);

            // Act
            var wordSearch = fileProcessor.Process(@"\Path\To\File.txt");

            // Assert
            Assert.Equal(JsonConvert.SerializeObject(TestHelpers.GetMockWordSearch()), JsonConvert.SerializeObject(wordSearch));
        }

        private MockFileData GetMockFileData()
        {
            var fileDataStringBuilder = new StringBuilder();
            fileDataStringBuilder.AppendLine("BONES,CHEKOV,KHAN,KIRK,SCOTTY,SPOCK,SULU,UHURA,COMPUTER");
            fileDataStringBuilder.AppendLine("U,M,K,H,U,L,K,I,N,V,J,O,C,W,E");
            fileDataStringBuilder.AppendLine("L,L,S,H,K,Z,Z,W,Z,C,G,J,U,Y,G");
            fileDataStringBuilder.AppendLine("H,S,U,P,J,P,R,J,D,H,S,B,X,T,G");
            fileDataStringBuilder.AppendLine("B,R,J,S,O,E,Q,E,T,I,K,K,G,L,E");
            fileDataStringBuilder.AppendLine("A,Y,O,A,G,C,I,R,D,Q,H,R,T,C,D");
            fileDataStringBuilder.AppendLine("S,C,O,T,T,Y,K,Z,R,E,P,P,X,P,R");
            fileDataStringBuilder.AppendLine("B,L,Q,S,L,N,E,E,E,V,U,L,F,E,Z");
            fileDataStringBuilder.AppendLine("O,K,R,I,K,A,M,M,R,M,F,B,T,P,P");
            fileDataStringBuilder.AppendLine("N,U,I,I,Y,H,Q,M,E,M,Q,U,Y,F,S");
            fileDataStringBuilder.AppendLine("E,Y,Z,Y,G,K,Q,J,P,C,P,W,Y,A,K");
            fileDataStringBuilder.AppendLine("S,J,F,Z,M,Q,I,B,D,M,E,M,K,W,D");
            fileDataStringBuilder.AppendLine("T,G,L,B,H,C,B,E,O,H,T,O,Y,I,K");
            fileDataStringBuilder.AppendLine("O,J,Y,E,U,L,N,C,C,L,Y,B,Z,U,H");
            fileDataStringBuilder.AppendLine("W,Z,M,I,S,U,K,U,R,B,I,D,U,X,S");
            fileDataStringBuilder.AppendLine("K,Y,L,B,Q,Q,P,M,D,F,C,K,E,A,B");

            return new MockFileData(fileDataStringBuilder.ToString());
        }
    }
}
