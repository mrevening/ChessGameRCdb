using Xunit;
using ChessGame.Logic;
using System.Collections.Generic;
using System.Linq;

namespace ChessGameTests
{
    public class CoordinateTests
    {
        public static IEnumerable<object[]> CoordinateEquality => new List<object[]> {
            new object[] {
                new Coordinate("A1"),
                new Coordinate("A1")
            }, 
            new object[] {
                new Coordinate(Column.B, Row.Two),
                new Coordinate(Column.B, Row.Two)
            },
            new object[] {
                new Coordinate(Column.C.Id, Row.Three.Id),
                new Coordinate(Column.C, Row.Three)
            },
            new object[] {
                new Coordinate("D4"),
                new Coordinate(Column.D.Id, Row.Four.Id)
            },
        };

        [Theory]
        [MemberData(nameof(CoordinateEquality))]
        public void Coordinates_Equality_True(Coordinate f1, Coordinate f2)
        {
            Assert.Equal(f1, f2);
        }

        public static IEnumerable<object[]> CoordinatesNotEqual => new List<object[]> {
            new object[] {
                new Coordinate("A1"),
                new Coordinate("A2")
            },
            new object[] {
                new Coordinate("B2"),
                new Coordinate("A2")
            },
            new object[] {
                new Coordinate(Column.C, Row.Two),
                new Coordinate(Column.C, Row.Three)
            },
            new object[] {
                new Coordinate(Column.C, Row.Four),
                new Coordinate(Column.D, Row.Four)
            },
            new object[] {
                new Coordinate(Column.C.Id, Row.Three.Id),
                new Coordinate(Column.D, Row.Three)
            },
            new object[] {
                new Coordinate("D4"),
                new Coordinate(Column.D.Id, Row.Five.Id)
            },
            new object[] {
                null,
                new Coordinate(Column.D.Id, Row.Five.Id)
            },
            new object[] {
                new Coordinate("D4"),
                null
            },
        };

        [Theory]
        [MemberData(nameof(CoordinatesNotEqual))]
        public void Coordinates_Equality_False(Coordinate f1, Coordinate f2)
        {
            Assert.NotEqual(f1, f2);
        }
    }
}
