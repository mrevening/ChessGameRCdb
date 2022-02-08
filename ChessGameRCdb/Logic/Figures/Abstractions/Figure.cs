using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    public abstract class Figure : IFigure, IEquatable<Figure>
    {
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

        public abstract FigureType FigureType { get; }
        public Color Color { get; private set; }
        public Coordinate Coordinate { get; private set; }
        public abstract List<IMove> MoveTypes { get; }
        public HashSet<MoveOption> MoveOptions { get; set; }
        public bool CannotBeMoved { get; set; }

        public Figure(Color color) { Color = color; MoveOptions = new HashSet<MoveOption>(); }
        public Figure(Color color, Coordinate position) { Color = color; Coordinate = position; MoveOptions = new HashSet<MoveOption>(); }
        public Figure(Color color, Column column, Row row) { Color = color; Coordinate = new Coordinate(column, row); MoveOptions = new HashSet<MoveOption>(); }

        public bool IsInPosition(Coordinate position) => Coordinate == position;
        public void SetPosition(Coordinate position) => Coordinate = new Coordinate(position.Column, position.Row);
        public bool IsPlayersFigure(Color currentPlayer, Coordinate position) => Color == currentPlayer && Coordinate == position;
        public bool IsOpponentFigure(Color currentPlayer, Coordinate position) => Color == currentPlayer.Switch() && Coordinate == position;

        public override bool Equals(object other) => other is Figure && Equals(other);
        public bool Equals(Figure f) => FigureType == f.FigureType && Color == f.Color;
        public static bool operator == (Figure lf, Figure rf) => lf.Equals(rf);
        public static bool operator != (Figure lf, Figure rf) => !lf.Equals(rf);
        public override int GetHashCode() => (FigureType, Color, Coordinate).GetHashCode();
    }
}
