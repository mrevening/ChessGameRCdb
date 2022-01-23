using System;
using System.Collections.Generic;

namespace ChessGame.Logic
{
    public abstract class Figure : IFigure, IEquatable<Figure>
    {
        public abstract FigureType FigureType { get; }
        public Player Player { get; private set; }
        public Coordinate Coordinate { get; private set; }
        public abstract IEnumerable<IMove> PossibleMoves { get; }

        public static Figure WhitePawn = new Pawn(Player.White);
        public static Figure WhiteKnight = new Knight(Player.White);
        public static Figure WhiteBishop = new Bishop(Player.White);
        public static Figure WhiteRook = new Rook(Player.White);
        public static Figure WhiteQueen = new Queen(Player.White);
        public static Figure WhiteKing = new King(Player.White);
        public static Figure BlackPawn = new Pawn(Player.Black);
        public static Figure BlackKnight = new Knight(Player.Black);
        public static Figure BlackBishop = new Bishop(Player.Black);
        public static Figure BlackRook = new Rook(Player.Black);
        public static Figure BlackQueen = new Queen(Player.Black);
        public static Figure BlackKing = new King(Player.Black);

        public Figure(Player player) { Player = player; }
        public Figure(Player player, Coordinate position) { Player = player; Coordinate = position; }
        public Figure(Player player, Column column, Row row) { Player = player; Coordinate = new Coordinate(column, row); }
        public abstract bool IsMoveAllowed(IBoard currentBoard, Coordinate endPoint);
        public abstract IEnumerable<Coordinate> MoveOptions(IBoard board);
        public bool IsInPosition(Coordinate position) => Coordinate == position;
        public void SetPosition(Coordinate position) => Coordinate = new Coordinate(position.Column, position.Row);
        public bool IsPlayersFigure(Player currentPlayer, Coordinate position) => Player == currentPlayer && Coordinate == position;
        public bool IsEnemysFigure(Player currentPlayer, Coordinate position) => Player == currentPlayer.Switch() && Coordinate == position;

        public override bool Equals(object other) => other is Figure && Equals(other);
        public bool Equals(Figure f) => FigureType == f.FigureType && Player == f.Player;
        public static bool operator == (Figure lf, Figure rf) => lf.Equals(rf);
        public static bool operator != (Figure lf, Figure rf) => !lf.Equals(rf);
        public override int GetHashCode() => (FigureType, Player, Coordinate).GetHashCode();
    }
}
