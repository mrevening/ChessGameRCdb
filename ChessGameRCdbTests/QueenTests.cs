using Xunit;
using ChessGame.Logic;
using System.Collections.Generic;
using System.Linq;

namespace ChessGameTests
{
    public class QueenTests
    {
        private readonly BoardSetup setup = BoardSetup.GetInstance();
        //Arrange, Act, Assert
        [Fact]
        public void QueenEmptyBoard_Moves_AvailableMoves()
        {
            var init = new Coordinate(Column.D, Row.Four);
            var figures = new List<IFigure>() {
                new Queen(Color.White,init)
            };
            var correctOptions = new HashSet<MoveOption>()
            {
                new MoveOption(ActionType.Move, new Log(init, new Coordinate(Column.D, Row.One))),
                new MoveOption(ActionType.Move, new Log(init, new Coordinate(Column.D, Row.Two))),
                new MoveOption(ActionType.Move, new Log(init, new Coordinate(Column.D, Row.Three))),
                new MoveOption(ActionType.Move, new Log(init, new Coordinate(Column.D, Row.Five))),
                new MoveOption(ActionType.Move, new Log(init, new Coordinate(Column.D, Row.Six))),
                new MoveOption(ActionType.Move, new Log(init, new Coordinate(Column.D, Row.Seven))),
                new MoveOption(ActionType.Move, new Log(init, new Coordinate(Column.D, Row.Eight))),

                new MoveOption(ActionType.Move, new Log(init, new Coordinate(Column.A, Row.Four))),
                new MoveOption(ActionType.Move, new Log(init, new Coordinate(Column.B, Row.Four))),
                new MoveOption(ActionType.Move, new Log(init, new Coordinate(Column.C, Row.Four))),
                new MoveOption(ActionType.Move, new Log(init, new Coordinate(Column.E, Row.Four))),
                new MoveOption(ActionType.Move, new Log(init, new Coordinate(Column.F, Row.Four))),
                new MoveOption(ActionType.Move, new Log(init, new Coordinate(Column.G, Row.Four))),
                new MoveOption(ActionType.Move, new Log(init, new Coordinate(Column.H, Row.Four))),

                new MoveOption(ActionType.Move, new Log(init, new Coordinate(Column.A, Row.One))),
                new MoveOption(ActionType.Move, new Log(init, new Coordinate(Column.B, Row.Two))),
                new MoveOption(ActionType.Move, new Log(init, new Coordinate(Column.C, Row.Three))),
                new MoveOption(ActionType.Move, new Log(init, new Coordinate(Column.E, Row.Five))),
                new MoveOption(ActionType.Move, new Log(init, new Coordinate(Column.F, Row.Six))),
                new MoveOption(ActionType.Move, new Log(init, new Coordinate(Column.G, Row.Seven))),
                new MoveOption(ActionType.Move, new Log(init, new Coordinate(Column.H, Row.Eight))),

                new MoveOption(ActionType.Move, new Log(init, new Coordinate(Column.A, Row.Seven))),
                new MoveOption(ActionType.Move, new Log(init, new Coordinate(Column.B, Row.Six))),
                new MoveOption(ActionType.Move, new Log(init, new Coordinate(Column.C, Row.Five))),
                new MoveOption(ActionType.Move, new Log(init, new Coordinate(Column.E, Row.Three))),
                new MoveOption(ActionType.Move, new Log(init, new Coordinate(Column.F, Row.Two))),
                new MoveOption(ActionType.Move, new Log(init, new Coordinate(Column.G, Row.One))),
            };
            var calculatedOptions = new BoardProcessor(new Board(figures)).CalculateBoard().GetFigure(init).MoveOptions;
            Assert.Equal(correctOptions, calculatedOptions);
        }
        [Fact]
        public void Queen_Move_Blocked()
        {
            var initPosition = new Coordinate(Column.A, Row.One);
            var correctOptions = new HashSet<MoveOption>() { };
            var calculatedOptions = new BoardProcessor(new Board(setup.GetStandardSetup())).CalculateBoard().GetFigure(initPosition).MoveOptions;
            Assert.Equal(correctOptions, calculatedOptions);
        }
        [Fact]
        public void Queen_Move_Check()
        {
            var init = new Coordinate(Column.A, Row.One);
            var end = new Coordinate(Column.A, Row.Eight);
            var end2 = new Coordinate(Column.E, Row.Eight);
            var end3 = new Coordinate(Column.E, Row.Four);
            var end4 = new Coordinate(Column.H, Row.Eight);
            var king = new Coordinate(Column.E, Row.Eight);
            var figures = new List<IFigure>() {
                new Queen(Color.White,init),
                new King(Color.Black,king)
            };
            var checkOptions = new HashSet<MoveOption>()
            {
                new MoveOption(ActionType.Check, new Log(init, end)),
                new MoveOption(ActionType.Check, new Log(init, end2)),
            };
            var calculatedOptions = new BoardProcessor(new Board(figures)).CalculateInitBoard(Color.Black).GetFigure(init).MoveOptions;
            Assert.Subset(checkOptions, calculatedOptions);
            Assert.Subset(checkOptions, calculatedOptions);
        }
    }
}
