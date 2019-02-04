using System;
using System.Collections.Generic;
using System.Text;

namespace WordSearchSolver
{
    public class Word
    {
        public string Text { get; set; }
        public IList<Coordinate> Location { get; set; }

        public Word(string text)
        {
            Text = text;
        }
    }
}
