using Xunit;
using ChessGame.Logic;
using System.Collections.Generic;
using System.Linq;

namespace ChessGameTests
{
    public class DefferedCheck
    {
        public static IEnumerable<object[]> Data => new List<object[]> {
            new object[] {
                new Rook(Color.Black, new Coordinate(Column.A, Row.Eight)),
                new Pawn(Color.White, new Coordinate(Column.A, Row.Four)),
                new King(Color.White, new Coordinate(Column.A, Row.One))
            },
            new object[] {
                new Rook(Color.Black, new Coordinate(Column.A, Row.One)),
                new Pawn(Color.White, new Coordinate(Column.D, Row.One)),
                new King(Color.White, new Coordinate(Column.H, Row.One))
            },
            new object[] {
                new Queen(Color.Black, new Coordinate(Column.D, Row.Eight)),
                new Pawn(Color.White, new Coordinate(Column.D, Row.Four)),
                new King(Color.White, new Coordinate(Column.D, Row.One))
            },
            new object[] {
                new Queen(Color.White, new Coordinate(Column.B, Row.Two)),
                new Pawn(Color.Black, new Coordinate(Column.C, Row.Two)),
                new King(Color.Black, new Coordinate(Column.D, Row.Two))
            },
            new object[] {
                new Queen(Color.Black, new Coordinate(Column.A, Row.One)),
                new Pawn(Color.White, new Coordinate(Column.D, Row.Four)),
                new King(Color.White, new Coordinate(Column.H, Row.Eight))
            },
            new object[] {
                new Queen(Color.White, new Coordinate(Column.B, Row.Seven)),
                new Pawn(Color.Black, new Coordinate(Column.C, Row.Six)),
                new King(Color.Black, new Coordinate(Column.D, Row.Five))
            },
            new object[] {
                new Bishop(Color.White, new Coordinate(Column.A, Row.One)),
                new Pawn(Color.Black, new Coordinate(Column.B, Row.Two)),
                new King(Color.Black, new Coordinate(Column.D, Row.Four))
            },
            new object[] {
                new Bishop(Color.Black, new Coordinate(Column.H, Row.Two)),
                new Pawn(Color.White, new Coordinate(Column.F, Row.Four)),
                new King(Color.White, new Coordinate(Column.E, Row.Five))
            },
            new object[] {
                new Bishop(Color.Black, new Coordinate("B4")),
                new Pawn(Color.White, new Coordinate("D2")),
                new King(Color.White, new Coordinate("E1")),
            }
        };
        [Theory]
        [MemberData(nameof(Data))]
        public void FigureDeffersCheck_True(IFigure opponent, IFigure inTheMiddle, IFigure king)
        {
            var figures = new List<IFigure>() { opponent, inTheMiddle, king };
            var o = new AttackOption(AttackType.DefferedCheck, inTheMiddle.Coordinate);
            var processor = new BoardProcessor(new Board(figures)).CalculateBoard(king.Color);
            var opponentAttackOptions = processor.GetFigure(opponent.Coordinate).AttackOptions;
            var intTheMiddleMoveOptions = processor.GetFigure(inTheMiddle.Coordinate).MoveOptions;
            Assert.Contains(o, opponentAttackOptions);
            Assert.Empty(intTheMiddleMoveOptions);
        }
    }
}
