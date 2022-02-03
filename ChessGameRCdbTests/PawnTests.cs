using Xunit;
using ChessGame.Logic;
using System.Collections.Generic;

namespace ChessGameTests
{
    public class PawnTests
    {
        //Arrange, Act, Assert
        [Fact]
        public void WhitePionsInit_AllMoves_OneAndTwoForward()
        {
            var figures = new List<IFigure>() {
                new Pawn(Color.White, Column.A, Row.Two),
                new Pawn(Color.White, Column.B, Row.Two),
                new Pawn(Color.White, Column.C, Row.Two),
                new Pawn(Color.White, Column.D, Row.Two),
                new Pawn(Color.White, Column.E, Row.Two),
                new Pawn(Color.White, Column.F, Row.Two),
                new Pawn(Color.White, Column.G, Row.Two),
                new Pawn(Color.White, Column.H, Row.Two),
            };
            var processor = new BoardProcessor(new Board(figures));
            foreach(var col in Enumeration.GetAll<Column>())
            {
                var correctOptions = new HashSet<MoveOption>()
                {
                    new MoveOption(ActionType.Move, new Log(new Coordinate(col, Row.Two), new Coordinate(col, Row.Three))),
                    new MoveOption(ActionType.Move, new Log(new Coordinate(col, Row.Two), new Coordinate(col, Row.Four)))
                };
                var calculatedOptions = processor.CalculateInitBoard(Color.White).GetFigure(new Coordinate(col, Row.Two)).MoveOptions;
                Assert.Equal(correctOptions, calculatedOptions);
            } 
        }

        [Fact]
        public void BlackPionsInit_AllMoves_OneAndTwoForward()
        {
            var figures = new List<IFigure>() {
                new Pawn(Color.Black, Column.A, Row.Seven),
                new Pawn(Color.Black, Column.B, Row.Seven),
                new Pawn(Color.Black, Column.C, Row.Seven),
                new Pawn(Color.Black, Column.D, Row.Seven),
                new Pawn(Color.Black, Column.E, Row.Seven),
                new Pawn(Color.Black, Column.F, Row.Seven),
                new Pawn(Color.Black, Column.G, Row.Seven),
                new Pawn(Color.Black, Column.H, Row.Seven),
            };
            var processor = new BoardProcessor(new Board(figures));
            foreach (var col in Enumeration.GetAll<Column>())
            {
                var correctOptions = new HashSet<MoveOption>()
                {
                    new MoveOption(ActionType.Move, new Log(new Coordinate(col, Row.Seven), new Coordinate(col, Row.Five))),
                    new MoveOption(ActionType.Move, new Log(new Coordinate(col, Row.Seven), new Coordinate(col, Row.Six)))
                };
                var calculatedOptions = processor.CalculateInitBoard(Color.Black).GetFigure(new Coordinate(col, Row.Seven)).MoveOptions;
                Assert.Equal(correctOptions, calculatedOptions);
            }
        }

        [Fact]
        public void Pion3rdRow_Move_1MoveOption()
        {
            var figures = new List<IFigure>() {
                new Pawn(Color.White, Column.D, Row.Three),
            };
            var processor = new BoardProcessor(new Board(figures));
            var calculatedOptionsWhite = processor.CalculateInitBoard(Color.White).GetFigure(new Coordinate(Column.D, Row.Three)).MoveOptions;
            var correctOptions = new HashSet<MoveOption>()
            {
                new MoveOption(ActionType.Move, new Log(new Coordinate(Column.D, Row.Three), new Coordinate(Column.D, Row.Four)))
            };
            Assert.Equal(correctOptions, calculatedOptionsWhite);
        }

        [Fact]
        public void Pion_Blocked_AnyMoveOption()
        {
            var figures = new List<IFigure>() {
                new Pawn(Color.White, Column.D, Row.Four),
                new Pawn(Color.Black, Column.D, Row.Five)
            };
            var processor = new BoardProcessor(new Board(figures));
            var calculatedOptionsWhite = processor.CalculateInitBoard(Color.White).GetFigure(new Coordinate(Column.D, Row.Four)).MoveOptions;
            var calculatedOptionsBlack = processor.CalculateInitBoard(Color.Black).GetFigure(new Coordinate(Column.D, Row.Five)).MoveOptions;
            Assert.Equal(new HashSet<MoveOption>(), calculatedOptionsWhite);
            Assert.Equal(new HashSet<MoveOption>(), calculatedOptionsBlack);
        }

        [Fact]
        public void TwoPionsDiagonal_Capture()
        {
            var figures = new List<IFigure>() {
                new Pawn(Color.White, Column.D, Row.Four),
                new Pawn(Color.Black, Column.E, Row.Five)
            };
            var processor = new BoardProcessor(new Board(figures));
            var calculatedOptionsWhite = processor.CalculateInitBoard(Color.White).GetFigure(new Coordinate(Column.D, Row.Four)).MoveOptions;
            var calculatedOptionsBlack = processor.CalculateInitBoard(Color.Black).GetFigure(new Coordinate(Column.E, Row.Five)).MoveOptions;
            var moveOptionWhite = new HashSet<MoveOption>() { new MoveOption(ActionType.Capture, new Log(new Coordinate(Column.D, Row.Four), new Coordinate(Column.E, Row.Five))) };
            var moveOptionBlack = new HashSet<MoveOption>() { new MoveOption(ActionType.Capture, new Log(new Coordinate(Column.E, Row.Five), new Coordinate(Column.D, Row.Four))) };
            Assert.Equal(moveOptionWhite, calculatedOptionsWhite);
            Assert.Equal(calculatedOptionsBlack, moveOptionBlack);
        }
        [Fact]
        public void TwoPions_EnPassant_Success()
        {
            var figures = new List<IFigure>() {
                new Pawn(Color.White, Column.D, Row.Five),
                new Pawn(Color.Black, Column.E, Row.Seven),
            };
            var processor = new BoardProcessor(new Board(figures));
            var log = new List<Log>()
            {
                new Log(new Coordinate(Column.E, Row.Seven), new Coordinate(Column.E, Row.Five))
            };
            var calculatedOptionsWhite = processor.CalculateBoard(log).GetFigure(new Coordinate(Column.D, Row.Five)).MoveOptions;
            var correctOptions = new HashSet<MoveOption>()
            {
                new MoveOption(ActionType.Move, new Log(new Coordinate(Column.D, Row.Five), new Coordinate(Column.D, Row.Six))),
                new MoveOption(ActionType.EnPassant, new Log(new Coordinate(Column.D, Row.Five), new Coordinate(Column.E, Row.Six)))
            };
            Assert.Equal(correctOptions, calculatedOptionsWhite);
        }
        [Fact]
        public void TwoPions_EnPassant_Failure()
        {
            var figures = new List<IFigure>() {
                new Pawn(Color.White, Column.D, Row.Five),
                new Pawn(Color.Black, Column.E, Row.Four),
                new Pawn(Color.Black, Column.A, Row.Seven),
            };
            var processor = new BoardProcessor(new Board(figures));
            var log = new List<Log>()
            {
                new Log(new Coordinate(Column.A, Row.Seven), new Coordinate(Column.A, Row.Five)),
            };
            var calculatedOptionsWhite = processor.CalculateBoard(log).GetFigure(new Coordinate(Column.D, Row.Five)).MoveOptions;
            var correctOptions = new HashSet<MoveOption>()
            {
                new MoveOption(ActionType.Move, new Log(new Coordinate(Column.D, Row.Five), new Coordinate(Column.D, Row.Six))),
            };
            Assert.Equal(correctOptions, calculatedOptionsWhite);
        }
    }
}
