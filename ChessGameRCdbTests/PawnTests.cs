//using Xunit;
//using ChessGame.Logic;
//using System.Collections.Generic;

//namespace ChessGameTests
//{
//    public class PawnTests
//    {
//        //Arrange, Act, Assert
//        //Add_MaximumSumResult_ThrowsOverflowException()
//        private readonly BoardSetup setup = BoardSetup.GetInstance();
//        [Fact]
//        public void Standard_OneFoward_Success()
//        {
//            var game = new ChessSession(new Board(setup.GetOnePawnSetup(), Color.White, new List<Log>()));
//            game.PlayersAction(Color.White, new Coordinate(Column.D, Row.Two), new Coordinate(Column.D, Row.Three));
//            Assert.Equal(Figure.WhitePawn, game.InputBoard.GetFigure(new Coordinate(Column.D, Row.Three)));
//        }
//        [Fact]
//        public void StartLine_TwoForward_Success()
//        {
//            var game = new Game(new Board(setup.GetOnePawnSetup()));
//            game.PlayersAction(Color.White, new Coordinate(Column.D, Row.Two), new Coordinate(Column.D, Row.Four));
//            Assert.Equal(Figure.WhitePawn, game.InputBoard.GetFigure(new Coordinate(Column.D, Row.Four)));
//        }
//        [Fact]
//        public void StartLine_TwoForward_Blocked()
//        {
//            var game = new Game(new Board(setup.GetTwoPawnsCase1Setup()));
//            var action = game.PlayersAction(Color.White, new Coordinate(Column.D, Row.Two), new Coordinate(Column.D, Row.Four));
//            Assert.Throws<BlockedMoveException>(() => action);
//        }
//        [Fact]
//        public void MovedPion_TwoForward_Failure()
//        {
//            var game = new Game(new Board(setup.GetOnePawnAlreadyMovedSetup()));
//            var action = game.PlayersAction(Color.White, new Coordinate(Column.D, Row.Three), new Coordinate(Column.D, Row.Five));
//            Assert.Throws<IllegalMoveException>(() => action);
//        }
//        [Fact]
//        public void Standard_ThreeForward_Failure()
//        {
//            var game = new Game(new Board(setup.GetOnePawnSetup()));
//            var action = game.PlayersAction(Color.White, new Coordinate(Column.D, Row.Two), new Coordinate(Column.D, Row.Five));
//            Assert.Throws<IllegalMoveException>(() => action);
//        }
//        [Fact]
//        public void TwoPionsEnface_OneFoward_Blocked()
//        {
//            var game = new Game(new Board(setup.GetTwoPawnsEnFaceSetup()));
//            var action = game.PlayersAction(Color.White, new Coordinate(Column.D, Row.Four), new Coordinate(Column.D, Row.Five));
//            Assert.Throws<BlockedMoveException>(() => action);
//        }
//        [Fact]
//        public void TwoPionsDiagonal_Capture_Success()
//        {
//            var game = new Game(new Board(setup.GetTwoPawnsDiagonalSetup()));
//            game.PlayersAction(Color.White, new Coordinate(Column.D, Row.Four), new Coordinate(Column.E, Row.Five));
//            Assert.Equal(Figure.WhitePawn, game.InputBoard.GetFigure(new Coordinate(Column.D, Row.Three)));
//        }
//        [Fact]
//        public void TwoPionsDiagonal_EnPassant_Success()
//        {
//            var game = new Game(new Board(setup.GetTwoPawnsEnPassantSetup()));
//            game.PlayersAction(Player.White, new Coordinate(Column.D, Row.Four), new Coordinate(Column.D, Row.Five));
//            game.PlayersAction(Player.Black, new Coordinate(Column.E, Row.Seven), new Coordinate(Column.E, Row.Five));
//            game.PlayersAction(Player.White, new Coordinate(Column.D, Row.Five), new Coordinate(Column.E, Row.Six));
//            Assert.Null(game.InputBoard.GetFigure(new Coordinate(Column.E, Row.Five)));
//            Assert.Equal(Figure.WhitePawn, game.InputBoard.GetFigure(new Coordinate(Column.E, Row.Six)));
//        }
//        [Fact]
//        public void TwoPionsDiagonal_EnPassant_Failure()
//        {
//            var game = new Game(new Board(setup.GetTwoPawnsEnPassantSetup()));
//            game.PlayersAction(Player.White, new Coordinate(Column.D, Row.Four), new Coordinate(Column.D, Row.Five));
//            game.PlayersAction(Player.Black, new Coordinate(Column.E, Row.Seven), new Coordinate(Column.E, Row.Five));
//            game.PlayersAction(Player.White, new Coordinate(Column.D, Row.Five), new Coordinate(Column.E, Row.Six));
//            Assert.Null(game.InputBoard.GetFigure(new Coordinate(Column.E, Row.Five)));
//            Assert.Equal(Figure.WhitePawn, game.InputBoard.GetFigure(new Coordinate(Column.E, Row.Six)));
//        }
//        [Fact]
//        public void IllegalTwoFowardNotStartLine()
//        {
//            var game = new Game(new Board(setup.GetOnePawnSetup()));
//            var action = game.PlayersAction(Player.White, new Coordinate(Column.D, Row.Two), new Coordinate(Column.D, Row.One));
//            Assert.Throws<IllegalMoveException>(() => action);
//        }
//        [Fact]
//        public void IllegalBackMove()
//        {
//            var game = new Game(new Board(setup.GetOnePawnSetup()));
//            var action = game.PlayersAction(Player.White, new Coordinate(Column.D, Row.Two), new Coordinate(Column.D, Row.One));
//            Assert.Throws<IllegalMoveException>(() => action);
//        }
//        [Fact]
//        public void IllegalThreeForward()
//        {
//            var game = new Game(new Board(setup.GetOnePawnSetup()));
//            var action = game.PlayersAction(Player.White, new Coordinate(Column.D, Row.Two), new Coordinate(Column.D, Row.Five));
//            Assert.Throws<IllegalMoveException>(() => action);
//        }
//        [Fact]
//        public void IllegalSideMove()
//        {
//            var game = new Game(new Board(setup.GetOnePawnSetup()));
//            var action = game.PlayersAction(Player.White, new Coordinate(Column.D, Row.Two), new Coordinate(Column.E, Row.Two));
//            Assert.Throws<IllegalMoveException>(() => action);
//        }
//    }
//}
