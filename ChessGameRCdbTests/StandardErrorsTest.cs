using Xunit;
using ChessGame.Logic;
using System.Collections.Generic;

namespace ChessGameTests
{
    public class StandardErrorsTest
    {
        [Fact]
        public void OnePion_StartAndEndPointAreTheSame_ThrowException()
        {
            var coordinate = new Coordinate(Column.A, Row.Two);
            var figures = new List<IFigure>() {
                new Pawn(Color.White, coordinate),
            };
            var log = new List<Log>()
            {
                new Log(coordinate, coordinate)
            };
            var processor = new BoardProcessor(new Board(figures), log);
            Assert.Throws<IllegalMoveException>(() => processor.CalculateBoard());
        }
        [Fact]
        public void OnePion_StartPointIsEmptyFieds_ThrowException()
        {
            var coordinate = new Coordinate(Column.A, Row.Two);
            var emptyCoordinateStart = new Coordinate(Column.A, Row.Three);
            var emptyCoordinateEnd = new Coordinate(Column.A, Row.Four);
            var figures = new List<IFigure>() {
                new Pawn(Color.White, coordinate),
            };
            var log = new List<Log>()
            {
                new Log(emptyCoordinateStart, emptyCoordinateEnd)
            };
            var processor = new BoardProcessor(new Board(figures), log);
            Assert.Throws<IllegalMoveException>(() => processor.CalculateBoard());
        }
        [Fact]
        public void TwoWhitePions_OneCapturesAnother_ThrowException()
        {
            var coordinatePion1 = new Coordinate(Column.A, Row.Four);
            var coordinatePion2 = new Coordinate(Column.B, Row.Five);
            var figures = new List<IFigure>() {
                new Pawn(Color.White, coordinatePion1),
                new Pawn(Color.White, coordinatePion2),
            };
            var log = new List<Log>()
            {
                new Log(coordinatePion1, coordinatePion2)
            };
            var processor = new BoardProcessor(new Board(figures), log);
            Assert.Throws<IllegalMoveException>(() => processor.CalculateBoard());
        }
    }
}
