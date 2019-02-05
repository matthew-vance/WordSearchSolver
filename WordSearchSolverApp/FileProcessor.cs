using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;
using System.Text;
using WordSearchSolver;

namespace WordSearchSolverApp
{
    public class FileProcessor
    {
        private readonly IFileSystem _fileSystem;

        public FileProcessor(IFileSystem fileSystem = null)
        {
            _fileSystem = fileSystem ?? new FileSystem();
        }

        public WordSearch Process(string path)
        {
            var fileLines = _fileSystem.File.ReadAllLines(path);

            var words = fileLines[0].Split(',').ToList().Select(w => new Word(w)).ToList();
            var puzzleRows = fileLines.Length - 1;
            var puzzleColumns = fileLines[1].Split(',').Length;
            var puzzle = new char[puzzleRows, puzzleColumns];

            for (int i = 1; i <= puzzleRows; i++)
            {
                var rowCharArray = string.Join(string.Empty, fileLines[i].Split(',')).ToCharArray();
                for (int j = 0; j < puzzleColumns; j++)
                {
                    puzzle[i - 1, j] = rowCharArray[j];
                }
            }

            return new WordSearch(words, puzzle);
        }
    }
}
