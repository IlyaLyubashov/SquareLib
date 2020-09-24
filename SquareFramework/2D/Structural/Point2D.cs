using System;
using System.Collections.Generic;
using System.Text;

namespace SquareLib
{
    /// <summary>
    /// I know YAGNI, but this class with high probability may be helpful in the future :)
    /// </summary>
    internal struct Point2D : IEquatable<Point2D>
    {
        public Point2D(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; }

        public double Y { get; }

        public override bool Equals(object obj)
        {
            if (obj is Point2D otherPoint)
                Equals(otherPoint);
            return false;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return X.GetHashCode() + 13 * Y.GetHashCode();
            }
        }

        public bool Equals(Point2D other)
        {
            if (Math.Abs(X - other.X) <= double.Epsilon
                 && Math.Abs(Y - other.Y) <= double.Epsilon)
                return true;
            return false;
        }

        public static bool operator ==(Point2D p1, Point2D p2)
            => p1.Equals(p2);

        public static bool operator !=(Point2D p1, Point2D p2)
            => !(p1 == p2);


        public static readonly Point2D Zero = new Point2D(0, 0); 
    }
}
