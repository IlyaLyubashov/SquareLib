using System;
using System.Collections.Generic;
using System.Text;

namespace SquareLib._2D.Figures
{
    public abstract class Figure2D
    {
        public abstract double GetSquare();

        /// <summary>
        /// If external client will have intention to calculate perimeter, 
        /// it's possible to make this method "public" and "abstract" to implement in all figures.
        /// </summary>
        internal virtual double GetPerimeter()
        {
            throw new NotImplementedException();
        }
    }
}
