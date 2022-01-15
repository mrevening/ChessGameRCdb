using Xunit;
using ChessGame.Logic;
using System.Linq;

namespace ChessGameTests
{
    public class GameTests
    {
        private readonly BoardSetup setup = BoardSetup.GetInstance();

        [Fact]
        public void StandardSetup_InputBoardHasAllFigures()
        {
            var game = new Game(new Board(setup.GetStandardSetup()));
            Assert.Equal(32, game.InputBoard.Figures.Count());
        }
        [Fact]
        public void StartAndEndPointsAreTheSame_Error()
        {
            var game = new Game(new Board(setup.GetOnePawnSetup()));
            void action() => game.PlayersAction(Player.White, new Coordinate(Column.D, Row.Two), new Coordinate(Column.D, Row.Two));
            Assert.Throws<StartAndEndPointAreTheSameException>(action);
        }
        [Fact]
        public void StartPoint_NotPlayersFigure_Error()
        {
            var game = new Game(new Board(setup.GetStandardSetup()));
            void action() => game.PlayersAction(Player.White, new Coordinate(Column.D, Row.Seven), new Coordinate(Column.D, Row.Six));
            Assert.Throws<NotPlayersFigureException>(action);
        }
    }
}
