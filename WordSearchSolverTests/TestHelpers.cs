using System;
using System.Collections.Generic;
using System.Text;
using WordSearchSolver;

namespace WordSearchSolverTests
{
    internal static class TestHelpers
    {
        public static WordSearch GetMockWordSearch(bool solved = false)
        {
            var wordsList = new List<Word>();
            var words = new Dictionary<string, IList<Coordinate>> {
                { "BONES", new List<Coordinate> { new Coordinate(6, 0), new Coordinate(7, 0), new Coordinate(8, 0), new Coordinate(9, 0), new Coordinate(10, 0) }},
                { "CHEKOV", null},
                { "KHAN", new List<Coordinate> { new Coordinate(9, 5), new Coordinate(8, 5), new Coordinate(7, 5), new Coordinate(6, 5) }},
                { "KIRK", new List<Coordinate> { new Coordinate(7, 4), new Coordinate(7, 3), new Coordinate(7, 2), new Coordinate(7, 1) }},
                { "SCOTTY",  new List<Coordinate> { new Coordinate(5, 0), new Coordinate(5, 1), new Coordinate(5, 2), new Coordinate(5, 3), new Coordinate(5, 4), new Coordinate(5, 5) }},
                { "SPOCK", new List<Coordinate> { new Coordinate(1, 2), new Coordinate(2, 3), new Coordinate(3, 4), new Coordinate(4, 5), new Coordinate(5, 6) }},
                { "SULU", new List<Coordinate> { new Coordinate(3, 3), new Coordinate(2, 2), new Coordinate(1, 1), new Coordinate(0, 0) }},
                { "UHURA", new List<Coordinate> { new Coordinate(0, 4), new Coordinate(1, 3), new Coordinate(2, 2), new Coordinate(3, 1), new Coordinate(4, 0) }},
                { "COMPUTER", new List<Coordinate> { new Coordinate(12, 7), new Coordinate(11, 8), new Coordinate(10, 9), new Coordinate(9, 10), new Coordinate(8, 11), new Coordinate(7, 12), new Coordinate(6, 13), new Coordinate(5, 14) }}
            };

            foreach (var wordKeyVal in words)
            {
                var word = new Word(wordKeyVal.Key);
                if (solved)
                    word.Location = wordKeyVal.Value;

                wordsList.Add(word);
            }
            var puzzle = new char[,] { {'U','M','K','H','U','L','K','I','N','V','J','O','C','W','E'},
                                 {'L','L','S','H','K','Z','Z','W','Z','C','G','J','U','Y','G'},
                                 {'H','S','U','P','J','P','R','J','D','H','S','B','X','T','G'},
                                 {'B','R','J','S','O','E','Q','E','T','I','K','K','G','L','E'},
                                 {'A','Y','O','A','G','C','I','R','D','Q','H','R','T','C','D'},
                                 {'S','C','O','T','T','Y','K','Z','R','E','P','P','X','P','R'},
                                 {'B','L','Q','S','L','N','E','E','E','V','U','L','F','E','Z'},
                                 {'O','K','R','I','K','A','M','M','R','M','F','B','T','P','P'},
                                 {'N','U','I','I','Y','H','Q','M','E','M','Q','U','Y','F','S'},
                                 {'E','Y','Z','Y','G','K','Q','J','P','C','P','W','Y','A','K'},
                                 {'S','J','F','Z','M','Q','I','B','D','M','E','M','K','W','D'},
                                 {'T','G','L','B','H','C','B','E','O','H','T','O','Y','I','K'},
                                 {'O','J','Y','E','U','L','N','C','C','L','Y','B','Z','U','H'},
                                 {'W','Z','M','I','S','U','K','U','R','B','I','D','U','X','S'},
                                 {'K','Y','L','B','Q','Q','P','M','D','F','C','K','E','A','B'}
            };
            return new WordSearch(wordsList, puzzle);
        }
    }
}
