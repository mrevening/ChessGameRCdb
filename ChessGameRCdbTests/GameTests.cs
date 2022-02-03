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
            var processed = new BoardProcessor(new Board(setup.GetStandardSetup()), new List<Log>());
            Assert.Equal(32, processed.OutputBoard.Figures.Count());
        }
        [Fact]
        public void StartAndEndPointsAreTheSame_Error()
        {
            var logList = new List<Log>()
            {
                new Log(new Coordinate(Column.D, Row.Two), new Coordinate(Column.D, Row.Two))
            };
            void action() => new BoardProcessor(new Board(setup.GetStandardSetup()), logList);
            Assert.Throws<IllegalMoveException>(action);
        }
        [Fact]
        public void StartPoint_NotPlayersFigure_Error()
        {
            var logList = new List<Log>()
            {
                new Log(new Coordinate(Column.D, Row.Seven), new Coordinate(Column.D, Row.Six))
            };
            void action() => new BoardProcessor(new Board(setup.GetStandardSetup()), logList);
            Assert.Throws<IllegalMoveException>(action);
        }
    }
}
