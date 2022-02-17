using Xunit;
using ChessGame.Logic;
using System.Collections.Generic;
using System.Linq;

namespace ChessGameTests
{
    public class UpTest
    {
        private static IFigure f1 = new Rook(Color.White, new Coordinate("A1"));
        private static IFigure f2 = new Queen(Color.Black, new Coordinate("H8"));
        public static IEnumerable<object[]> CoordinateEquality => new List<object[]> {
            new object[] {
                new Up().GetCoordinates(f1),
                new List<Coordinate>()
                {
                    new Coordinate("A2"),
                    new Coordinate("A3"),
                    new Coordinate("A4"),
                    new Coordinate("A5"),
                    new Coordinate("A6"),
                    new Coordinate("A7"),
                    new Coordinate("A8")
                }
            },
            new object[] {
                new Up().GetCoordinates(f2),
                new List<Coordinate>() {}
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
