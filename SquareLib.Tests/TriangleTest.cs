using NUnit.Framework;
using SquareLib._2D;
using SquareLib._2D.Figures;
using System;

namespace SquareLib.Tests
{
    [TestFixture]
    public class TriangleTest
    {
        [TestCase(1, 2, 3, ExpectedResult = 0)]
        [TestCase(3, 4, 5, ExpectedResult = 6)]
        [TestCase(14, 21, 9, ExpectedResult = 47.83)]
        [TestCase(3.12, 3.15, 4.17, ExpectedResult = 4.88)]
        public double CalculateSquare_ProperLegLength_ReturnSquare(double a, double b, double c)
        {
            var triangle = new Triangle(a, b, c);
            return Math.Round(triangle.GetSquare(), 2);
        }

        [TestCase(1, 2, 4)]
        [TestCase(1, 2, 3.01)]
        [TestCase(3.1, 1.03, 2.01)]
        [TestCase(4.05, 8.1, 4.03)]
        public void Triangle_BadLegLength_ThrowInvalidFigure(double a, double b, double c)
        {
            Assert.That(() => new Triangle(a, b, c), Throws.TypeOf<InvalidFigureException>());
        }

        [TestCase(1, 3, 3.99)]
        [TestCase(7, 8.99, 2)]
        public void Triangle_BoundaryLength_CreateNew(double a, double b, double c)
        {
            var t = new Triangle(a, b, c);
        }


        [TestCase(3, 4, 5, ExpectedResult = true)]
        [TestCase(12, 13, 5, ExpectedResult = true)]
        [TestCase(25, 7, 24, ExpectedResult = true)]
        public bool IsRectangular_PifagorTriples(double a, double b, double c)
        {
            var t = new Triangle(a, b, c);
            return Triangle.IsRectangular(t);
        }

        [TestCase(2, 3, 4, ExpectedResult = false)]
        [TestCase(13, 10, 12, ExpectedResult = false)]
        public bool IsRectangular_NotRectungular_ReturnFalse(double a, double b, double c)
        {
            var t = new Triangle(a, b, c);
            return Triangle.IsRectangular(t);
        }

        [TestCase(3, 5, 5.83, 0.01, ExpectedResult = false)] // (3 ** 2) + (5 ** 2) - (5.83 ** 2) = 0.011 > 0.01
        [TestCase(3, 5, 5.83, 0.012, ExpectedResult = true)]
        public bool IsRectangular_SetPrecision(double a, double b, double c, double ignorePrecision)
        {
            var t = new Triangle(a, b, c);
            return Triangle.IsRectangular(t, ignorePrecision);
        }
    }
}