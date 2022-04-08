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
            var calculatedOptions = new BoardProcessor(new Board(figures)).CalculateBoard(Color.Black).GetFigure(init).MoveOptions;
            Assert.Subset(checkOptions, calculatedOptions);
        }


        public static IEnumerable<object[]> CoordinateEquality => new List<object[]> {
            new object[] {
                new List<IFigure>() {
                    new Bishop(Color.White, "B5"),
                    new Pawn(Color.Black, "D7"),
                    new King(Color.Black, "E8"),
                    new Knight(Color.Black, "B8"),
                },
                new Log("B8", "C6"),
                new HashSet<MoveOption>()
                {
                    new MoveOption(ActionType.Capture, new Log("B5", "C6")),
                    new MoveOption(ActionType.Move, new Log("B5", "A6")),
                    new MoveOption(ActionType.Move, new Log("B5", "A4")),
                    new MoveOption(ActionType.Move, new Log("B5", "C4")),
                    new MoveOption(ActionType.Move, new Log("B5", "D3")),
                    new MoveOption(ActionType.Move, new Log("B5", "E2")),
                    new MoveOption(ActionType.Move, new Log("B5", "F1"))
                }
            },
        };
        [Theory]
        [MemberData(nameof(CoordinateEquality))]
        public void Bishop_Move(List<IFigure> figures, Log log, HashSet<MoveOption> moves)
        {
            var calculatedOptions = new BoardProcessor(new Board(figures), new List<Log>() { log }).CalculateBoard().GetFigure(figures.First().Coordinate).MoveOptions;
            Assert.Equal(moves, calculatedOptions);
        }
    }
}
