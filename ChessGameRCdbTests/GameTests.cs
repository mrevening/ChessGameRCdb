using Xunit;
using ChessGame.Logic;
using System.Linq;
using System.Collections.Generic;

namespace ChessGameTests
{
    public class GameTests
    {
        private readonly BoardSetup setup = BoardSetup.GetInstance();

        [Fact]
        public void StandardSetup_InputBoardHasAllFigures()
        {
            var processed = new BoardProcessor(new Board(setup.GetStandardSetup()));
            Assert.Equal(32, processed.CalculateInitBoard(Color.White).Figures.Count());
        }
        [Fact]
        public void StartAndEndPointsAreTheSame_Error()
        {
            var logList = new List<Log>()
            {
                new Log(new Coordinate(Column.D, Row.Two), new Coordinate(Column.D, Row.Two))
            };
            void action() => new BoardProcessor(new Board(setup.GetStandardSetup())).CalculateBoard(logList);
            Assert.Throws<IllegalMoveException>(action);
        }
        [Fact]
        public void StartPoint_FreeCoordinate_Error()
        {
            var logList = new List<Log>()
            {
                new Log(new Coordinate(Column.D, Row.Six), new Coordinate(Column.D, Row.Five))
            };
            void action() => new BoardProcessor(new Board(setup.GetStandardSetup())).CalculateBoard(logList);
            Assert.Throws<IllegalMoveException>(action);
        }
        [Fact]
        public void StartPoint_NotPlayersFigure_Error()
        {
            var logList = new List<Log>()
            {
                new Log(new Coordinate(Column.D, Row.Two), new Coordinate(Column.D, Row.Four)),
                new Log(new Coordinate(Column.D, Row.Four), new Coordinate(Column.D, Row.Five))
            };
            void action() => new BoardProcessor(new Board(setup.GetStandardSetup())).CalculateBoard(logList);
            Assert.Throws<IllegalMoveException>(action);
        }
    }
}
