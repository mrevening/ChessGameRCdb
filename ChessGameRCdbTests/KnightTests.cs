using Xunit;
using ChessGame.Logic;
using System.Collections.Generic;

namespace ChessGameTests
{
    public class KnightTests
    {
        private readonly BoardSetup setup = BoardSetup.GetInstance();
        //Arrange, Act, Assert
        [Fact]
        public void OneKnight_Moves_8AvailableMoves()
        {
            var figures = new List<IFigure>() {
                new Knight(Color.White, Column.D, Row.Four)
            };
            var processor = new BoardProcessor(new Board(figures));
            var calculatedOptions = processor.CalculateInitBoard(Color.White).GetFigure(new Coordinate(Column.D, Row.Four)).MoveOptions;
            var correctOptions = new HashSet<MoveOption>()
            {
                new MoveOption(ActionType.Move, new Log(new Coordinate(Column.D, Row.Four), new Coordinate(Column.E, Row.Six))),
                new MoveOption(ActionType.Move, new Log(new Coordinate(Column.D, Row.Four), new Coordinate(Column.C, Row.Six))),
                new MoveOption(ActionType.Move, new Log(new Coordinate(Column.D, Row.Four), new Coordinate(Column.B, Row.Five))),
                new MoveOption(ActionType.Move, new Log(new Coordinate(Column.D, Row.Four), new Coordinate(Column.B, Row.Three))),
                new MoveOption(ActionType.Move, new Log(new Coordinate(Column.D, Row.Four), new Coordinate(Column.C, Row.Two))),
                new MoveOption(ActionType.Move, new Log(new Coordinate(Column.D, Row.Four), new Coordinate(Column.F, Row.Two))),
                new MoveOption(ActionType.Move, new Log(new Coordinate(Column.D, Row.Four), new Coordinate(Column.F, Row.Three))),
                new MoveOption(ActionType.Move, new Log(new Coordinate(Column.D, Row.Four), new Coordinate(Column.F, Row.Five)))
            };
            Assert.Equal(correctOptions, calculatedOptions);
        }
        [Fact]
        public void OneKnightInitPosition_StandardBoard_2AvailableMoves()
        {
            var processor = new BoardProcessor(new Board(setup.GetStandardSetup()));
            var calculatedOptions = processor.CalculateInitBoard(Color.Black).GetFigure(new Coordinate(Column.B, Row.Seven)).MoveOptions;
            var correctOptions = new HashSet<MoveOption>()
            {
                new MoveOption(ActionType.Move, new Log(new Coordinate(Column.B, Row.Seven), new Coordinate(Column.A, Row.Five))),
                new MoveOption(ActionType.Move, new Log(new Coordinate(Column.B, Row.Seven), new Coordinate(Column.C, Row.Five))),
            };
            Assert.Equal(correctOptions, calculatedOptions);
        }
    }
}
