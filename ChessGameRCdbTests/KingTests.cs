using Xunit;
using ChessGame.Logic;
using System.Collections.Generic;
using System.Linq;

namespace ChessGameTests
{
    public class KingTests
    {
        public static IEnumerable<object[]> Data1 => new List<object[]> {
            new object[] {
                new King(Color.White, "A1"),
                new Rook(Color.Black, "B8"),
                new List<MoveOption>()
                {
                    new MoveOption(ActionType.Move, new Log("A1", "A2"))
                }
            }
            //complex move should be devided on castle, capture, promotion, 
        };
        [Theory]
        [MemberData(nameof(Data1))]
        public void FigureDeffersCheck_True(IFigure king, IFigure opponent, IEnumerable<MoveOption> expectedOptions)
        {
            var processor = new BoardProcessor(new Board(new List<IFigure>() { opponent, king })).CalculateBoard(king.Color);
            var actualMoves = processor.GetFigure(king.Coordinate).MoveOptions;
            Assert.Equal(expectedOptions, actualMoves);
        }

        public static IEnumerable<object[]> Data2 => new List<object[]> {
            new object[] {
                new Pawn(Color.White, "D2"),
                new King(Color.Black, "E5"),
                new List<MoveOption>()
                {
                    new MoveOption(ActionType.Move, new Log("D2", "D3")),
                    new MoveOption(ActionType.Check, new Log("D2", "D4"))
                }
            }
        };
        [Theory]
        [MemberData(nameof(Data2))]
        public void Check(IFigure opponent, IFigure king, IEnumerable<MoveOption> expectedOptions)
        {
            var processor = new BoardProcessor(new Board(new List<IFigure>() { opponent, king })).CalculateBoard(opponent.Color);
            var actualMoves = processor.GetFigure(opponent.Coordinate).MoveOptions;
            Assert.Equal(expectedOptions, actualMoves);
        }
        //complex move should be devided on castle, capture, promotion, 
    }
}
