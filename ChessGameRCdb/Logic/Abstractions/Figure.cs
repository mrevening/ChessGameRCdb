using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    public abstract class Figure : IFigure, IEquatable<Figure>
    {
        public abstract FigureType FigureType { get; }
        public Color Color { get; private set; }
        public Coordinate Coordinate { get; private set; }
        public abstract IEnumerable<IMove> PossibleMoves { get; }

        public static Figure WhitePawn = new Pawn(Color.White);
        public static Figure WhiteKnight = new Knight(Color.White);
        public static Figure WhiteBishop = new Bishop(Color.White);
        public static Figure WhiteRook = new Rook(Color.White);
        public static Figure WhiteQueen = new Queen(Color.White);
        public static Figure WhiteKing = new King(Color.White);
        public static Figure BlackPawn = new Pawn(Color.Black);
        public static Figure BlackKnight = new Knight(Color.Black);
        public static Figure BlackBishop = new Bishop(Color.Black);
        public static Figure BlackRook = new Rook(Color.Black);
        public static Figure BlackQueen = new Queen(Color.Black);
        public static Figure BlackKing = new King(Color.Black);

        public Figure(Color color) { Color = color; }
        public Figure(Color color, Coordinate position) { Color = color; Coordinate = position; }
        public Figure(Color color, Column column, Row row) { Color = color; Coordinate = new Coordinate(column, row); }
        public abstract bool IsMoveAllowed(IBoard currentBoard, Coordinate endPoint);
        public abstract IEnumerable<MoveOption> MoveOptions(IBoard board);
        public virtual bool IsAttackingOpponentsKingOnPlayersMove(IBoard board) => false;
        public bool IsInPosition(Coordinate position) => Coordinate == position;
        public void SetPosition(Coordinate position) => Coordinate = new Coordinate(position.Column, position.Row);
        public bool IsPlayersFigure(Color currentPlayer, Coordinate position) => Color == currentPlayer && Coordinate == position;
        public bool IsEnemysFigure(Color currentPlayer, Coordinate position) => Color == currentPlayer.Switch() && Coordinate == position;

        public override bool Equals(object other) => other is Figure && Equals(other);
        public bool Equals(Figure f) => FigureType == f.FigureType && Color == f.Color;
        public static bool operator == (Figure lf, Figure rf) => lf.Equals(rf);
        public static bool operator != (Figure lf, Figure rf) => !lf.Equals(rf);
        public override int GetHashCode() => (FigureType, Color, Coordinate).GetHashCode();
        protected void AddLongDistanceActions(List<MoveOption> allMoveOptions, IBoard board, IEnumerable<Coordinate> coordinates)
        {
            var isLastMoveCapture = false;
            var coordinatesFreeToMoveOrCapture = coordinates.TakeWhile(c =>
            {
                if (isLastMoveCapture) return false;
                var figureInPosition = board.GetFigure(c);
                if (figureInPosition != null && figureInPosition.Color != Color) isLastMoveCapture = true;
                return figureInPosition == null || figureInPosition.Color != Color;
            }
            );
            allMoveOptions.AddRange(coordinatesFreeToMoveOrCapture.Select(c => new MoveOption(c, ActionType.Move)));
            if (isLastMoveCapture) allMoveOptions.Last().AddAction(ActionType.Capture);
        }
    }
}
