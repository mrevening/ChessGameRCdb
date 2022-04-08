using Xunit;
using ChessGame.Logic;
using System.Collections.Generic;

namespace ChessGameTests
{
    public class PawnTests
    {
        //Arrange, Act, Assert
        [Fact]
        public void WhitePionInit_Move_OneAndTwoForward()
        {
            var initCol = Column.A;
            var initCoordinate = new Coordinate(initCol, Row.Two);
            var figures = new List<IFigure>() {
                new Pawn(Color.White, initCoordinate)
            };
            var correctOptions = new HashSet<MoveOption>()
                {
                    new MoveOption(ActionType.Move, new Log(initCoordinate, new Coordinate(initCol, Row.Three))),
                    new MoveOption(ActionType.Move, new Log(initCoordinate, new Coordinate(initCol, Row.Four)))
                };
            var calculatedOptions = new BoardProcessor(new Board(figures)).CalculateBoard().GetFigure(initCoordinate).MoveOptions;
            Assert.Equal(correctOptions, calculatedOptions);
        }
        [Fact]
        public void BlackPionInit_Move_OneAndTwoForward()
        {
            var initCol = Column.A;
            var initCoordinate = new Coordinate(initCol, Row.Seven);
            var figures = new List<IFigure>() {
                new Pawn(Color.Black, initCoordinate)
            };
            var correctOptions = new HashSet<MoveOption>()
                {
                    new MoveOption(ActionType.Move, new Log(initCoordinate, new Coordinate(initCol, Row.Six))),
                    new MoveOption(ActionType.Move, new Log(initCoordinate, new Coordinate(initCol, Row.Five)))
                };
            var calculatedOptions = new BoardProcessor(new Board(figures)).CalculateBoard(Color.Black).GetFigure(initCoordinate).MoveOptions;
             Assert.Equal(correctOptions, calculatedOptions);
        }

        [Fact]
        public void OneWhiteAndOneBlackPionsInit_Move_OneAndTwoForward()
        {
            var initCol = Column.A;
            var initCoordinateWhite = new Coordinate(initCol, Row.Two);
            var initCoordinateBlack = new Coordinate(initCol, Row.Seven);
            var figures = new List<IFigure>() {
                new Pawn(Color.White, initCoordinateWhite),
                new Pawn(Color.Black, initCoordinateBlack),
            };
            var correctOptionsWhite = new HashSet<MoveOption>()
            {
                new MoveOption(ActionType.Move, new Log(initCoordinateWhite, new Coordinate(initCol, Row.Three))),
                new MoveOption(ActionType.Move, new Log(initCoordinateWhite, new Coordinate(initCol, Row.Four)))
            };
            var correctOptionsBlack = new HashSet<MoveOption>()
            {
                new MoveOption(ActionType.Move, new Log(initCoordinateBlack, new Coordinate(initCol, Row.Five))),
                new MoveOption(ActionType.Move, new Log(initCoordinateBlack, new Coordinate(initCol, Row.Six)))
            };
            var calculatedOptionsWhite = new BoardProcessor(new Board(figures)).CalculateBoard().GetFigure(initCoordinateWhite).MoveOptions;
            var calculatedOptionsBlack = new BoardProcessor(new Board(figures)).CalculateBoard(Color.Black).GetFigure(initCoordinateBlack).MoveOptions;
            Assert.Equal(correctOptionsWhite, calculatedOptionsWhite);
            Assert.Equal(correctOptionsBlack, calculatedOptionsBlack);
        }

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
                var calculatedOptions = processor.CalculateBoard().GetFigure(new Coordinate(col, Row.Two)).MoveOptions;
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
            foreach (var col in Enumeration.GetAll<Column>())
            {
                var correctOptions = new HashSet<MoveOption>()
                {
                    new MoveOption(ActionType.Move, new Log(new Coordinate(col, Row.Seven), new Coordinate(col, Row.Five))),
                    new MoveOption(ActionType.Move, new Log(new Coordinate(col, Row.Seven), new Coordinate(col, Row.Six)))
                };
                var calculatedOptions = new BoardProcessor(new Board(figures)).CalculateBoard(Color.Black).GetFigure(new Coordinate(col, Row.Seven)).MoveOptions;
                Assert.Equal(correctOptions, calculatedOptions);
            }
        }

        [Fact]
        public void Pion3rdRow_Move_1MoveOption()
        {
            var figures = new List<IFigure>() {
                new Pawn(Color.White, Column.D, Row.Three),
            };
            var correctOptions = new HashSet<MoveOption>()
            {
                new MoveOption(ActionType.Move, new Log(new Coordinate(Column.D, Row.Three), new Coordinate(Column.D, Row.Four)))
            };
            var calculatedOptionsWhite = new BoardProcessor(new Board(figures)).CalculateBoard().GetFigure(new Coordinate(Column.D, Row.Three)).MoveOptions;
            Assert.Equal(correctOptions, calculatedOptionsWhite);
        }

        [Fact]
        public void Pion_Blocked_AnyMoveOption()
        {
            var figures = new List<IFigure>() {
                new Pawn(Color.White, Column.D, Row.Four),
                new Pawn(Color.Black, Column.D, Row.Five)
            };
            var calculatedOptionsWhite = new BoardProcessor(new Board(figures)).CalculateBoard().GetFigure(new Coordinate(Column.D, Row.Four)).MoveOptions;
            var calculatedOptionsBlack = new BoardProcessor(new Board(figures)).CalculateBoard(Color.Black).GetFigure(new Coordinate(Column.D, Row.Five)).MoveOptions;
            Assert.Equal(new HashSet<MoveOption>(), calculatedOptionsWhite);
            Assert.Equal(new HashSet<MoveOption>(), calculatedOptionsBlack);
        }

        [Fact]
        public void TwoPionsDiagonal_Capture()
        {
            var initWhite = new Coordinate(Column.D, Row.Four);
            var initBlack = new Coordinate(Column.E, Row.Five);
            var figures = new List<IFigure>() {
                new Pawn(Color.White, initWhite),
                new Pawn(Color.Black,initBlack)
            };
            var calculatedOptionsWhite = new BoardProcessor(new Board(figures)).CalculateBoard().GetFigure(initWhite).MoveOptions;
            var calculatedOptionsBlack = new BoardProcessor(new Board(figures)).CalculateBoard(Color.Black).GetFigure(initBlack).MoveOptions;
            var moveOptionWhite = new HashSet<MoveOption>() 
            {
                new MoveOption(ActionType.Move, new Log(initWhite, new Coordinate(Column.D, Row.Five))),
                new MoveOption(ActionType.Capture, new Log(initWhite, initBlack))
            };
            var moveOptionBlack = new HashSet<MoveOption>() 
            {
                new MoveOption(ActionType.Move, new Log(initBlack, new Coordinate(Column.E, Row.Four))),
                new MoveOption(ActionType.Capture, new Log(initBlack, initWhite))
            };
            Assert.Equal(moveOptionWhite, calculatedOptionsWhite);
            Assert.Equal(moveOptionBlack, calculatedOptionsBlack);
        }
        [Fact]
        public void TwoPions_EnPassant_Success()
        {
            var figures = new List<IFigure>() {
                new Pawn(Color.White, Column.D, Row.Five),
                new Pawn(Color.Black, Column.E, Row.Seven),
            };
            var logs = new List<Log>()
            {
                new Log(new Coordinate(Column.E, Row.Seven), new Coordinate(Column.E, Row.Five))
            };
            var correctOptions = new HashSet<MoveOption>()
            {
                new MoveOption(ActionType.Move, new Log(new Coordinate(Column.D, Row.Five), new Coordinate(Column.D, Row.Six))),
                new MoveOption(ActionType.EnPassant, new Log(new Coordinate(Column.D, Row.Five), new Coordinate(Column.E, Row.Six)))
            };
            var calculatedOptionsWhite = new BoardProcessor(new Board(figures), logs).CalculateBoard().GetFigure(new Coordinate(Column.D, Row.Five)).MoveOptions;
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
            var logs = new List<Log>()
            {
                new Log(new Coordinate(Column.A, Row.Seven), new Coordinate(Column.A, Row.Five)),
            };
            var correctOptions = new HashSet<MoveOption>()
            {
                new MoveOption(ActionType.Move, new Log(new Coordinate(Column.D, Row.Five), new Coordinate(Column.D, Row.Six))),
            };
            var calculatedOptionsWhite = new BoardProcessor(new Board(figures), logs).CalculateBoard().GetFigure(new Coordinate(Column.D, Row.Five)).MoveOptions;

            Assert.Equal(correctOptions, calculatedOptionsWhite);
        }
        [Fact]
        public void WhitePion_Promotion_Success()
        {
            var initCol = Column.A;
            var init = new Coordinate(initCol, Row.Seven);
            var end = new Coordinate(initCol, Row.Eight);
            var figures = new List<IFigure>() {
                new Pawn(Color.White, init)
            };
            var correctOptions = new HashSet<MoveOption>()
            {
                new MoveOption(ActionType.Promotion, new Log(init, end))
            };
            var calculatedOptionsWhite = new BoardProcessor(new Board(figures)).CalculateBoard().GetFigure(init).MoveOptions;

            Assert.Equal(correctOptions, calculatedOptionsWhite);
        }
    }
}
