using Xunit;
using ChessGame.Logic;
using System.Collections.Generic;
using System.Linq;

namespace ChessGameTests
{
    public class LeftTest
    {
        private static IFigure f1 = new Rook(Color.White, new Coordinate("H2"));
        private static IFigure f2 = new Queen(Color.Black, new Coordinate("A2"));
        public static IEnumerable<object[]> CoordinateEquality => new List<object[]> {
            new object[] {
                new Left().GetCoordinates(f1),
                new List<Coordinate>()
                {
                    new Coordinate("G2"),
                    new Coordinate("F2"),
                    new Coordinate("E2"),
                    new Coordinate("D2"),
                    new Coordinate("C2"),
                    new Coordinate("B2"),
                    new Coordinate("A2")
                }
            },
            new object[] {
                new Left().GetCoordinates(f2),
                new List<Coordinate>(){ }
            },
        };

        [Theory]
        [MemberData(nameof(CoordinateEquality))]
        public void Directions_ProperOrder_True(IEnumerable<Coordinate>actual, IEnumerable<Coordinate> expected)
        {
            Assert.Equal(expected, actual);
        }
    }
}
