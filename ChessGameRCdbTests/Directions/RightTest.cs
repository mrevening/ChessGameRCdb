using Xunit;
using ChessGame.Logic;
using System.Collections.Generic;
using System.Linq;

namespace ChessGameTests
{
    public class RightTest
    {
        private static IFigure f1 = new Rook(Color.White, new Coordinate("A1"));
        private static IFigure f2 = new Queen(Color.Black, new Coordinate("H8"));
        public static IEnumerable<object[]> CoordinateEquality => new List<object[]> {
            new object[] {
                new Right().GetCoordinates(f1),
                new List<Coordinate>()
                {
                    new Coordinate("B1"),
                    new Coordinate("C1"),
                    new Coordinate("D1"),
                    new Coordinate("E1"),
                    new Coordinate("F1"),
                    new Coordinate("G1"),
                    new Coordinate("H1"),
                }
            },
            new object[] {
                new Right().GetCoordinates(f2),
                new List<Coordinate>(){ }
            }
        };

        [Theory]
        [MemberData(nameof(CoordinateEquality))]
        public void Directions_ProperOrder_True(IEnumerable<Coordinate>actual, IEnumerable<Coordinate> expected)
        {
            Assert.Equal(expected, actual);
        }
    }
}
