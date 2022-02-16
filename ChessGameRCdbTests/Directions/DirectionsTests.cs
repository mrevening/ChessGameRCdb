using Xunit;
using ChessGame.Logic;
using System.Collections.Generic;
using System.Linq;

namespace ChessGameTests
{
    public class DirectionsTests
    {
        private static IFigure f = new Queen(Color.White, new Coordinate("D4"));
        public static IEnumerable<object[]> CoordinateEquality => new List<object[]> {
            new object[] {
                new Up().GetCoordinates(f),
                new List<Coordinate>()
                {
                    new Coordinate("D5"),
                    new Coordinate("D6"),
                    new Coordinate("D7"),
                    new Coordinate("D8"),
                }
            },
            new object[] {
                new Down().GetCoordinates(f),
                new List<Coordinate>()
                {
                    new Coordinate("D3"),
                    new Coordinate("D2"),
                    new Coordinate("D1")
                }
            },
            new object[] {
                new Left().GetCoordinates(f),
                new List<Coordinate>()
                {
                    new Coordinate("C4"),
                    new Coordinate("B4"),
                    new Coordinate("A4")
                }
            },
            new object[] {
                new Right().GetCoordinates(f),
                new List<Coordinate>()
                {
                    new Coordinate("E4"),
                    new Coordinate("F4"),
                    new Coordinate("G4"),
                    new Coordinate("H4"),
                }
            },
            new object[] {
                new NW().GetCoordinates(f),
                new List<Coordinate>()
                {
                    new Coordinate("C5"),
                    new Coordinate("B6"),
                    new Coordinate("A7")
                }
            },
            new object[] {
                new SW().GetCoordinates(f),
                new List<Coordinate>()
                {
                    new Coordinate("C3"),
                    new Coordinate("B2"),
                    new Coordinate("A1")
                }
            },
            new object[] {
                new SE().GetCoordinates(f),
                new List<Coordinate>()
                {
                    new Coordinate("E3"),
                    new Coordinate("F2"),
                    new Coordinate("G1")
                }
            },
            new object[] {
                new NE().GetCoordinates(f),
                new List<Coordinate>()
                {
                    new Coordinate("E5"),
                    new Coordinate("F6"),
                    new Coordinate("G7"),
                    new Coordinate("H8"),
                }
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
