﻿using ChessGame.Logic;
using ChessGame.Logic;
using System.Collections.Generic;

namespace ChessGame.Logic
{
    public interface IFigure
    {
        Player Player { get; }
        Coordinate Coordinate { get; }
        FigureType FigureType { get; }
        IEnumerable<IMove> PossibleMoves { get; }
        IEnumerable<Coordinate> MoveOptions(IBoard board);
        bool IsMoveAllowed(IBoard currentBoard, Coordinate endPoint);
        bool IsPlayersFigure(Player player, Coordinate endPoint);
        bool IsEnemysFigure(Player player, Coordinate endPoint);
        bool IsInPosition(Coordinate endPoint);
        void SetPosition(Coordinate endPoint);
    }
}
