using Xunit;
using ChessGame.Logic;
using System.Collections.Generic;
using System.Linq;

namespace ChessGameTests
{
    public class KingTests
    {
        public static IEnumerable<object[]> Data => new List<object[]> {
            new object[] {
                new King(Color.White, "A1"),
                new Rook(Color.Black, "B8"),
                new List<MoveOption>()
                {
                    new MoveOption(ActionType.Move, new Log("A1", "A2"))
                }
            }
            //new object[] {
            //    new King(Color.White, "E1"),
            //    new Rook(Color.White, "A1"),
            //    new List<MoveOption>()
            //    {
            //        new MoveOption(ActionType.Castle, new Log("A1", "A2", new List<LogComplexMove>() { new LogComplexMove(new CO) }))
            //    }
            //}
        };
        [Theory]
        [MemberData(nameof(Data))]
        public void FigureDeffersCheck_True(IFigure king, IFigure opponent, IEnumerable<MoveOption> expectedOptions)
        {
            var processor = new BoardProcessor(new Board(new List<IFigure>() { opponent, king })).CalculateInitBoard(king.Color);
            var actualMoves = processor.GetFigure(king.Coordinate).MoveOptions;
            Assert.Equal(expectedOptions, actualMoves);
        }
    }
}
