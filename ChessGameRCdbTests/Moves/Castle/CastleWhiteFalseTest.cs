using Xunit;
using ChessGame.Logic;
using System.Collections.Generic;
using System.Linq;

namespace ChessGameTests
{
    public class CastleWhiteFalseTest
    {
        public static IEnumerable<object[]> FalseCastleWhitePosition => new List<object[]> {
            new object[] {
                new List<IFigure>() {
                    new King(Color.White, "E1"),
                    new Bishop(Color.White, "F1"),
                    new Knight(Color.White, "G1"),
                    new Rook(Color.White, "H1"),
                },
                new MoveOption(ActionType.Castle, new Log("E1", "G1"))
            },
            new object[] {
                new List<IFigure>() {
                    new King(Color.White, "E1"),
                    new Queen(Color.White, "D1"),
                    new Bishop(Color.White, "C1"),
                    new Knight(Color.White, "B1"),
                    new Rook(Color.White, "A1"),
                },
                new MoveOption(ActionType.Castle, new Log("E1", "C1"))
            }
        };
        [Theory]
        [MemberData(nameof(FalseCastleWhitePosition))]
        public void Castle_White_False(List<IFigure> figures, MoveOption move)
        {
            var calculatedOptions = new BoardProcessor(new Board(figures), new List<Log>() { }).CalculateBoard().GetFigure(figures.First().Coordinate).MoveOptions;
            Assert.DoesNotContain(move, calculatedOptions);
        }
    }
}
