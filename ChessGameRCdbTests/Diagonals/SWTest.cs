using Xunit;
using ChessGame.Logic;
using System.Collections.Generic;
using System.Linq;

namespace ChessGameTests
{
    public class SWTest
    {
        private static IFigure f1 = new Bishop(Color.White, new Coordinate("H8"));
        private static IFigure f2 = new Queen(Color.Black, new Coordinate("A1"));
        public static IEnumerable<object[]> CoordinateEquality => new List<object[]> {
            new object[] {
                new SW().GetCoordinates(f1),
                new List<Coordinate>()
                {
                    new Coordinate("G7"),
                    new Coordinate("F6"),
                    new Coordinate("E5"),
                    new Coordinate("D4"),
                    new Coordinate("C3"),
                    new Coordinate("B2"),
                    new Coordinate("A1")
                }
            },
            new object[] {
                new SW().GetCoordinates(f2),
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
