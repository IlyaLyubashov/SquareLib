using System;
using System.Collections.Generic;
using System.Text;

namespace SquareLib._2D
{
    /// <summary>
    /// I know YAGNI, but this class with high probability may be helpful in the future :)
    /// </summary>
    internal struct Section2D : IEquatable<Section2D>
    {
        public Point2D Point1 { get; }

        public Point2D Point2 { get; }

        public double Length { get; }

        public Section2D(Point2D p1, Point2D p2)
        {
            Point1 = p1;
            Point2 = p2;

            var xLeg = Math.Pow(Point1.X - Point2.X, 2);
            var yLeg = Math.Pow(Point1.Y - Point2.Y, 2);
            Length = Math.Sqrt(xLeg + yLeg);
        }

        public override bool Equals(object obj)
        {
            if (obj is Section2D otherSection)
                Equals(otherSection);
            return false;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return Point1.GetHashCode() + 13 * Point2.GetHashCode();
            }
        }

        public bool Equals(Section2D other)
        {
            if (Point1.Equals(other.Point1) && Point2.Equals(other.Point2))
                return true;
            return false;
        }

        public static bool operator ==(Section2D s1, Section2D s2)
            => s1.Equals(s2);

        public static bool operator !=(Section2D s1, Section2D s2)
            => !(s1 == s2);

    }
}
