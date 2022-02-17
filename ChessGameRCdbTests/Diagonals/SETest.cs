using Xunit;
using ChessGame.Logic;
using System.Collections.Generic;
using System.Linq;

namespace ChessGameTests
{
    public class SETest
    {
        private static IFigure f1 = new Bishop(Color.White, new Coordinate("A8"));
        private static IFigure f2 = new Queen(Color.Black, new Coordinate("H1"));
        public static IEnumerable<object[]> CoordinateEquality => new List<object[]> {
            new object[] {
                new SE().GetCoordinates(f1),
                new List<Coordinate>()
                {
                    new Coordinate("B7"),
                    new Coordinate("C6"),
                    new Coordinate("D5"),
                    new Coordinate("E4"),
                    new Coordinate("F3"),
                    new Coordinate("G2"),
                    new Coordinate("H1")
                }
            },
            new object[] {
                new SE().GetCoordinates(f2),
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
