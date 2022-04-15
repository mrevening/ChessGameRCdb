using Xunit;
using ChessGame.Logic;
using System.Collections.Generic;
using System.Linq;

namespace ChessGameTests
{
    public class CastleWhiteTrueTest
    {
        public static IEnumerable<object[]> TrueCastleWhitePosition => new List<object[]> {
            //new object[] {
            //    new List<IFigure>() {
            //        new King(Color.White, "E1"),
            //        new Rook(Color.White, "H1"),
            //    },
            //    new MoveOption(ActionType.Castle, new Log("E1", "G1"))
            //},
            new object[] {
                new List<IFigure>() {
                    new King(Color.White, "E1"),
                    new Rook(Color.White, "A1"),
                },
                new MoveOption(ActionType.Castle, new Log("E1", "C1"))
            },
        };
        [Theory]
        [MemberData(nameof(TrueCastleWhitePosition))]
        public void Castle_White_True(List<IFigure> figures, MoveOption move)
        {
            var calculatedOptions = new BoardProcessor(new Board(figures), new List<Log>() { }).CalculateBoard().GetFigure(figures.First().Coordinate).MoveOptions;
            Assert.Contains(move, calculatedOptions);
        }
    }
}
