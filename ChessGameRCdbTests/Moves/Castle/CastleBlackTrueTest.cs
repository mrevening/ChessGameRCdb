using Xunit;
using ChessGame.Logic;
using System.Collections.Generic;
using System.Linq;

namespace ChessGameTests
{
    public class CastleBlackTrueTest
    {
        public static IEnumerable<object[]> TrueCastleBlackPosition => new List<object[]> {
            new object[] {
                new List<IFigure>() {
                    new King(Color.Black, "E8"),
                    new Rook(Color.Black, "H8"),
                },
                new MoveOption(ActionType.Castle, new Log("E8", "G8"))
            },
            new object[] {
                new List<IFigure>() {
                    new King(Color.Black, "E8"),
                    new Rook(Color.Black, "A8"),
                },
                new MoveOption(ActionType.Castle, new Log("E8", "C8"))
            },
        };
        [Theory]
        [MemberData(nameof(TrueCastleBlackPosition))]
        public void Castle_Black_True(List<IFigure> figures, MoveOption move)
        {
            var calculatedOptions = new BoardProcessor(new Board(figures), new List<Log>() { }).CalculateBoard(Color.Black).GetFigure(figures.First().Coordinate).MoveOptions;
            Assert.Contains(move, calculatedOptions);
        }
    }
}
