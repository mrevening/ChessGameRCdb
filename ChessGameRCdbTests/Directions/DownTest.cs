using Xunit;
using ChessGame.Logic;
using System.Collections.Generic;
using System.Linq;

namespace ChessGameTests
{
    public class DownTest
    {
        private static IFigure f1 = new Rook(Color.White, new Coordinate("B8"));
        private static IFigure f2 = new Queen(Color.Black, new Coordinate("B1"));
        public static IEnumerable<object[]> CoordinateEquality => new List<object[]> {
            new object[] {
                new Down().GetCoordinates(f1),
                new List<Coordinate>()
                {
                    new Coordinate("B7"),
                    new Coordinate("B6"),
                    new Coordinate("B5"),
                    new Coordinate("B4"),
                    new Coordinate("B3"),
                    new Coordinate("B2"),
                    new Coordinate("B1")
                }
            },
            new object[] {
                new Down().GetCoordinates(f2),
                new List<Coordinate>() { }
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
