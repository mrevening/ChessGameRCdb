using Xunit;
using ChessGame.Logic;
using System.Collections.Generic;
using System.Linq;

namespace ChessGameTests
{
    public class AloneOnBoardTest
    {
        [Fact]
        public void Pion()
        {
            var init = new Coordinate(Column.D, Row.Four);
            var figures = new List<IFigure>() {
                new Pawn(Color.White ,init)
            };

            new BoardProcessor(new Board(figures)).CalculateBoard();
        }
        [Fact]
        public void Knight()
        {
            var init = new Coordinate(Column.D, Row.Four);
            var figures = new List<IFigure>() {
                new Knight(Color.White, init)
            };

            new BoardProcessor(new Board(figures)).CalculateBoard();
        }
        [Fact]
        public void Bishop()
        {
            var init = new Coordinate(Column.D, Row.Four);
            var figures = new List<IFigure>() {
                new Bishop(Color.White, init)
            };

            new BoardProcessor(new Board(figures)).CalculateBoard();
        }
        [Fact]
        public void Rook()
        {
            var init = new Coordinate(Column.D, Row.Four);
            var figures = new List<IFigure>() {
                new Rook(Color.White,init)
            };

            new BoardProcessor(new Board(figures)).CalculateBoard();
        }
        [Fact]
        public void Queen()
        {
            var init = new Coordinate(Column.D, Row.Four);
            var figures = new List<IFigure>() {
                new Queen(Color.White,init)
            };

            new BoardProcessor(new Board(figures)).CalculateBoard();
        }
        [Fact]
        public void King()
        {
            var init = new Coordinate(Column.D, Row.Four);
            var figures = new List<IFigure>() {
                new King(Color.White,init)
            };

            new BoardProcessor(new Board(figures)).CalculateBoard();
        }
        [Fact]
        public void PionBlack()
        {
            var init = new Coordinate(Column.D, Row.Four);
            var figures = new List<IFigure>() {
                new Pawn(Color.Black ,init)
            };

            new BoardProcessor(new Board(figures)).CalculateBoard();
        }
        [Fact]
        public void KnightBlack()
        {
            var init = new Coordinate(Column.D, Row.Four);
            var figures = new List<IFigure>() {
                new Knight(Color.Black, init)
            };

            new BoardProcessor(new Board(figures)).CalculateBoard();
        }
        [Fact]
        public void BishopBlack()
        {
            var init = new Coordinate(Column.D, Row.Four);
            var figures = new List<IFigure>() {
                new Bishop(Color.Black, init)
            };

            new BoardProcessor(new Board(figures)).CalculateBoard();
        }
        [Fact]
        public void RookBlack()
        {
            var init = new Coordinate(Column.D, Row.Four);
            var figures = new List<IFigure>() {
                new Rook(Color.Black,init)
            };

            new BoardProcessor(new Board(figures)).CalculateBoard();
        }
        [Fact]
        public void QueenBlack()
        {
            var init = new Coordinate(Column.D, Row.Four);
            var figures = new List<IFigure>() {
                new Queen(Color.Black,init)
            };

            new BoardProcessor(new Board(figures)).CalculateBoard();
        }
        [Fact]
        public void KingBlack()
        {
            var init = new Coordinate(Column.D, Row.Four);
            var figures = new List<IFigure>() {
                new King(Color.Black,init)
            };

            new BoardProcessor(new Board(figures)).CalculateBoard();
        }
    }
}
