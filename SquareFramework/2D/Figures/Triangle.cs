using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SquareLib._2D.Figures
{
    public class Triangle : Figure2D
    {
        public bool IsValid { get; private set; }

        public double[] LengthArray { get; }

        public Triangle(double aLength, double bLength, double cLength)
        {
            IsValid = AreValidTriangleLength(aLength, bLength, cLength);
            if (!IsValid)
                throw new InvalidFigureException("Passsed sequence of leg's length is invalid");

            LengthArray = new double[] { aLength, bLength, cLength };
        }

        public static bool AreValidTriangleLength(double aLength, double bLength, double cLength)
        {
            var lengthSeq = new double[] { aLength, bLength, cLength };
            var lengthSeqSum = lengthSeq.Sum();
            if (lengthSeq.Any(l => 2 * l - lengthSeqSum > double.Epsilon))
                return false;
            return true;
        }

        public override double GetSquare()
        {
            var hp = GetPerimeter() / 2;
            var hp_m_0 = hp - LengthArray[0];
            var hp_m_1 = hp - LengthArray[1];
            var hp_m_2 = hp - LengthArray[2];
            return Math.Sqrt(hp * hp_m_0 * hp_m_1 * hp_m_2);
        }

        /// <summary>
        /// I decided to make this method static, not to overload object interface of triangle. Ofc, it's controversial
        /// </summary>
        public static bool IsRectangular(Triangle triangle, double ignoreDifference = Double.Epsilon)
        {
            var idxs = new int[] { 0, 1, 2 };
            for (int i = 0; i < idxs.Length; i++)
            {
                var current2Pow = Math.Pow(triangle.LengthArray[i], 2);
                var other2PowSum = idxs.Where(idx => idx != i)
                    .Select(idx => Math.Pow(triangle.LengthArray[idx], 2))
                    .Sum();
                if (Math.Abs(current2Pow - other2PowSum) <= ignoreDifference)
                    return true;
            }

            return false;
        }

        internal override double GetPerimeter()
        {
            return LengthArray.Sum();
        }
    }
}
