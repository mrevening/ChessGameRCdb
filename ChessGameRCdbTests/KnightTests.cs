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
            var correctOptions = new HashSet<MoveOption>()
            {
                new MoveOption(ActionType.Move, new Log(new Coordinate(Column.D, Row.Four), new Coordinate(Column.E, Row.Six))),
                new MoveOption(ActionType.Move, new Log(new Coordinate(Column.D, Row.Four), new Coordinate(Column.C, Row.Six))),
                new MoveOption(ActionType.Move, new Log(new Coordinate(Column.D, Row.Four), new Coordinate(Column.B, Row.Five))),
                new MoveOption(ActionType.Move, new Log(new Coordinate(Column.D, Row.Four), new Coordinate(Column.B, Row.Three))),
                new MoveOption(ActionType.Move, new Log(new Coordinate(Column.D, Row.Four), new Coordinate(Column.C, Row.Two))),
                new MoveOption(ActionType.Move, new Log(new Coordinate(Column.D, Row.Four), new Coordinate(Column.E, Row.Two))),
                new MoveOption(ActionType.Move, new Log(new Coordinate(Column.D, Row.Four), new Coordinate(Column.F, Row.Three))),
                new MoveOption(ActionType.Move, new Log(new Coordinate(Column.D, Row.Four), new Coordinate(Column.F, Row.Five)))
            };
            var calculatedOptions = new BoardProcessor(new Board(figures)).CalculateBoard().GetFigure(new Coordinate(Column.D, Row.Four)).MoveOptions;
            Assert.Equal(correctOptions, calculatedOptions);
        }
        [Fact]
        public void OneKnightInitPosition_StandardBoard_2AvailableMoves()
        {
            var initPosition = new Coordinate(Column.B, Row.Eight);
            var correctOptions = new HashSet<MoveOption>()
            {
                new MoveOption(ActionType.Move, new Log(initPosition, new Coordinate(Column.A, Row.Six))),
                new MoveOption(ActionType.Move, new Log(initPosition, new Coordinate(Column.C, Row.Six))),
            };
            var calculatedOptions = new BoardProcessor(new Board(setup.GetStandardSetup())).CalculateInitBoard(Color.Black).GetFigure(initPosition).MoveOptions;
            Assert.Equal(correctOptions, calculatedOptions);
        }
    }
}
