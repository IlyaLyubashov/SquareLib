using System;
using System.Collections.Generic;
using System.Text;

namespace SquareLib
{
    public class InvalidFigureException : Exception
    {
        public InvalidFigureException(string message) : base(message)
        {
        }
    }
}
