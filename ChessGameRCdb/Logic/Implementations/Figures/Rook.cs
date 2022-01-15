using ChessGame.Logic;
using ChessGame.Logic;
using ChessGame.Logic;
using ChessGame.Logic;
using ChessGame.Logic;
using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    internal class Rook : Figure
    {
        public override FigureType FigureType { get { return FigureType.Rook; } }
        public override IEnumerable<IMove> PossibleMoves { get => new List<IMove>() { MoveType.DiagonalAllDirection }; }

        public Rook(Player player) : base(player) { }
        public Rook(Player player, Column column, Row row) : base(player, column, row) { }
        public Rook(Player player, Coordinate position) : base(player, position) { }

        public override bool IsMoveAllowed(IBoard currentBoard, Coordinate endPoint)
        {
            return true;
        }
        public override IEnumerable<Coordinate> MoveOptions(IBoard board)
        {
            //select all hypothetical moves
            //var captureMoves = new List<Coordinate>();
            //var freeMoves = new List<Coordinate>();

            //var figuresInSameCol = board.Figures.Where(x => x.Coordinate.Column == Coordinate.Column);




            //for (var c = Coordinate.Column + 1; c <= Column.H; c++)
            //{
            //    if (board.Figures.Any(x => x.Coordinate == new Coordinate(c, Coordinate.Row)))
            //    {
            //        if (board.Figures.Any(x => x.Coordinate == new Coordinate(c, Coordinate.Row) && x.Player == Player)) break;
            //        else if (board.Figures.Any(x => x.Coordinate == new Coordinate(c, Coordinate.Row) && x.Player == Player))
            //        {
            //            captureMoves.Add(new Coordinate(c, Coordinate.Row));
            //            break;
            //        }
            //        else
            //        {
            //            freeMoves.Add(new Coordinate(c, Coordinate.Row));
            //        }
            //    }
            //}


            var cols = Enumeration.GetAll<Column>().Where(x => x != Coordinate.Column).Select(c => new Coordinate(c, Coordinate.Row));
            var rows = Enumeration.GetAll<Row>().Where(x => x != Coordinate.Row).Select(r => new Coordinate(Coordinate.Column, r));
            var hypothetics = cols.Concat(rows);
            var freeMoves = hypothetics.Where(x => !board.Figures.Any(f => x == f.Coordinate));
            var strikes = hypothetics.Where(x => board.Figures.Any(f => x == f.Coordinate && f.Player != Player));
            //remove all not allowed moves
            //var real = hypothetics.Where(h => board.Figures.Any(f => f.Coordinate == h && (f.Player != Player || )));

            var real = freeMoves.Concat(strikes);


            return real;
        }

        private void Moves(IBoard board, ColOrRow colOrRow, Direction direction, Enumeration maxEnumeration )
        {
            var captureMoves = new List<Coordinate>();
            var freeMoves = new List<Coordinate>();

            var coo = colOrRow == ColOrRow.Col ? Coordinate.Column.Id : Coordinate.Row.Id;
            var max = 
                colOrRow == ColOrRow.Col ? 
                    direction == Direction.UpRight ? Column.H.Id : Column.A.Id 
                    : direction == Direction.UpRight ? Row.Eight.Id : Row.One.Id ;


            for (var val = Coordinate.Column.Id + 1; val <= max; val++)
            {
                if (board.Figures.Any(x => x.Coordinate == new Coordinate(val, Coordinate.Row.Id)))
                {
                    if (board.Figures.Any(x => x.Coordinate == new Coordinate(val, Coordinate.Row.Id) && x.Player == Player)) break;
                    else if (board.Figures.Any(x => x.Coordinate == new Coordinate(val, Coordinate.Row.Id) && x.Player == Player))
                    {
                        captureMoves.Add(new Coordinate(val, Coordinate.Row.Id));
                        break;
                    }
                    else
                    {
                        freeMoves.Add(new Coordinate(val, Coordinate.Row.Id));
                    }
                }
            }
        }
        private enum ColOrRow { Col, Row}
        private enum Direction { UpRight = 1, DownLeft = -1}
    }
}
