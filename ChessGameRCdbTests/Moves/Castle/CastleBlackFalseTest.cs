using Xunit;
using ChessGame.Logic;
using System.Collections.Generic;
using System.Linq;

namespace ChessGameTests
{
    public class CastleBlackFalseTest
    {
        public static IEnumerable<object[]> FalseCastleBlackPosition => new List<object[]> {
            new object[] {
                new List<IFigure>() {
                    new King(Color.Black, "E8"),
                    new Bishop(Color.Black, "F8"),
                    new Knight(Color.Black, "G8"),
                    new Rook(Color.Black, "H8"),
                },
                new MoveOption(ActionType.Castle, new Log("E8", "G8"))
            },
            new object[] {
                new List<IFigure>() {
                    new King(Color.Black, "E8"),
                    new Queen(Color.Black, "D8"),
                    new Bishop(Color.Black, "C8"),
                    new Knight(Color.Black, "B8"),
                    new Rook(Color.Black, "A8"),
                },
                new MoveOption(ActionType.Castle, new Log("E8", "C8"))
            },
        };
        [Theory]
        [MemberData(nameof(FalseCastleBlackPosition))]
        public void Castle_Black_False(List<IFigure> figures, MoveOption move)
        {
            var calculatedOptions = new BoardProcessor(new Board(figures), new List<Log>() { }).CalculateBoard(Color.Black).GetFigure(figures.First().Coordinate).MoveOptions;
            Assert.DoesNotContain(move, calculatedOptions);
        }
    }
}
