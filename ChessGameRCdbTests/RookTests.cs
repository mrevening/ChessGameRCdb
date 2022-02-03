using Xunit;
using ChessGame.Logic;
using System.Collections.Generic;
using System.Linq;

namespace ChessGameTests
{
    public class RookTests
    {
        private readonly BoardSetup setup = BoardSetup.GetInstance();
        //Arrange, Act, Assert
        [Fact]
        public void RookEmptyBoard_Moves_AvailableMoves()
        {
            var init = new Coordinate(Column.D, Row.Four);
            var figures = new List<IFigure>() {
                new Rook(Color.White,init)
            };
            var correctOptions = new HashSet<MoveOption>()
            {
                new MoveOption(ActionType.Move, new Log(init, new Coordinate(Column.D, Row.Three))),
                new MoveOption(ActionType.Move, new Log(init, new Coordinate(Column.D, Row.Two))),
                new MoveOption(ActionType.Move, new Log(init, new Coordinate(Column.D, Row.One))),
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
            };
            var calculatedOptions = new BoardProcessor(new Board(figures)).CalculateBoard().GetFigure(init).MoveOptions;
            Assert.Equal(correctOptions, calculatedOptions);
        }
        [Fact]
        public void Rook_Move_Blocked()
        {
            var initPosition = new Coordinate(Column.A, Row.One);
            var correctOptions = new HashSet<MoveOption>() { };
            var calculatedOptions = new BoardProcessor(new Board(setup.GetStandardSetup())).CalculateBoard().GetFigure(initPosition).MoveOptions;
            Assert.Equal(correctOptions, calculatedOptions);
        }
        [Fact]
        public void Rook_Move_Check()
        {
            var init = new Coordinate(Column.A, Row.One);
            var end = new Coordinate(Column.A, Row.Eight);
            var end2 = new Coordinate(Column.E, Row.One);
            var king = new Coordinate(Column.E, Row.Eight);
            var figures = new List<IFigure>() {
                new King(Color.White,init),
                new King(Color.Black,king)
            };
            var checkOptions = new HashSet<MoveOption>()
            {
                new MoveOption(ActionType.Check, new Log(init, end)),
                new MoveOption(ActionType.Check, new Log(init, end2)),
            };
            var calculatedOptions = new BoardProcessor(new Board(setup.GetStandardSetup())).CalculateInitBoard(Color.Black).GetFigure(init).MoveOptions;
            Assert.Subset(checkOptions, calculatedOptions);
            Assert.Subset(checkOptions, calculatedOptions);
        }
    }
}
