using System;
using System.Collections.Generic;
using System.Text;

namespace SquareLib._2D.Figures
{
    public class Circle : Figure2D
    {
        public double Radius { get;}

        public Circle(int r)
        {
            Radius = r;
        }

        public override double GetSquare()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
    }
}
