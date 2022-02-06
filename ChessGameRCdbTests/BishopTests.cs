using Xunit;
using ChessGame.Logic;
using System.Collections.Generic;
using System.Linq;

namespace ChessGameTests
{
    public class BishopTests
    {
        private readonly BoardSetup setup = BoardSetup.GetInstance();
        //Arrange, Act, Assert
        [Fact]
        public void BishopEmptyBoard_Moves_AvailableMoves()
        {
            var init = new Coordinate(Column.D, Row.Four);
            var figures = new List<IFigure>() {
                new Bishop(Color.White,init)
            };
            var correctOptions = new HashSet<MoveOption>()
            {
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
        public void Bishop_Move_Blocked()
        {
            var initPosition = new Coordinate(Column.C, Row.One);
            var correctOptions = new HashSet<MoveOption>() { };
            var calculatedOptions = new BoardProcessor(new Board(setup.GetStandardSetup())).CalculateBoard().GetFigure(initPosition).MoveOptions;
            Assert.Equal(correctOptions, calculatedOptions);
        }
        [Fact]
        public void Bishop_Move_Check()
        {
            var init = new Coordinate(Column.A, Row.One);
            var king = new Coordinate(Column.H, Row.Eight);
            var figures = new List<IFigure>() {
                new Bishop(Color.White,init),
                new King(Color.Black,king)
            };
            var checkOptions = new HashSet<MoveOption>()
            {
                new MoveOption(ActionType.Check, new Log(init, king)),
            };
            var calculatedOptions = new BoardProcessor(new Board(figures)).CalculateInitBoard(Color.Black).GetFigure(init).MoveOptions;
            Assert.Subset(checkOptions, calculatedOptions);
        }
    }
}