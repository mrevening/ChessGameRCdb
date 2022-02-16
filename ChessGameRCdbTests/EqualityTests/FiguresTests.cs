using Xunit;
using ChessGame.Logic;
using System.Collections.Generic;
using System.Linq;

namespace ChessGameTests
{
    public class FiguresTests
    {
        public static IEnumerable<object[]> FiguresEquality => new List<object[]> {
          new object[] {
                new King(Color.White, Column.H, Row.Eight),
                new King(Color.White, new Coordinate("H8"))
            },
            new object[] {
                new King(Color.Black, new Coordinate(Column.A, Row.One)),
                new King(Color.Black, Column.A, Row.One)
            },
            new object[] {
                new Queen(Color.White, new Coordinate("A1")),
                new Queen(Color.White, new Coordinate("A1"))
            },
            new object[] {
                new Rook(Color.Black, new Coordinate("A1")),
                new Rook(Color.Black, new Coordinate("A1"))
            },
            new object[] {
                new Bishop(Color.Black, new Coordinate("A1")),
                new Bishop(Color.Black, new Coordinate("A1"))
            },
            new object[] {
                new Knight(Color.Black, new Coordinate("A1")),
                new Knight(Color.Black, new Coordinate("A1"))
            },
            new object[] {
                new Pawn(Color.Black, new Coordinate("A1")),
                new Pawn(Color.Black, new Coordinate("A1"))
            }
        };

        [Theory]
        [MemberData(nameof(FiguresEquality))]
        public void Figures_Equality_True(IFigure f1, IFigure f2)
        {
            Assert.Equal(f1, f2);
        }


        public static IEnumerable<object[]> FiguresNotEqual => new List<object[]> {
            new object[] {
                new King(Color.Black, new Coordinate("A1")),
                new King(Color.White, new Coordinate("A1"))
            },
            new object[] {
                new Queen(Color.Black, new Coordinate("A1")),
                new Queen(Color.Black, new Coordinate("A2"))
            },
            new object[] {
                new Rook(Color.Black, new Coordinate("A1")),
                new Rook(Color.Black, new Coordinate("B1"))
            },
            new object[] {
                new Bishop(Color.Black, new Coordinate("A1")),
                new Bishop(Color.Black)
            },
            new object[] {
                new Bishop(Color.Black),
                new Bishop(Color.Black, new Coordinate("A1"))
            },
            new object[] {
                new Bishop(Color.Black),
                new Bishop(Color.Black, new Coordinate("A1"))
            },
            new object[] {
                new Knight(Color.White, new Coordinate("A1")),
                null
            },
            new object[] {
                new Pawn(Color.Black, new Coordinate("A1")),
                new Queen(Color.Black, new Coordinate("A1"))
            },
        };

        [Theory]
        [MemberData(nameof(FiguresNotEqual))]
        public void Figures_Equality_False(IFigure f1, IFigure f2)
        {
            Assert.NotEqual(f1, f2);
        }
    }
}
