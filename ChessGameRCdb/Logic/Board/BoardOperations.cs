using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    public static class BoardOperations
    {
        public static IFigure? GetFigure(this IBoard board, Coordinate endPoint) => board.Figures.FirstOrDefault(x => x.IsInPosition(endPoint));
        public static Color GetCurrentColor(this IBoard board, Coordinate c) => board.GetFigure(c)?.Color ?? throw new IllegalMoveException("Not touched player's figure.");
        public static void RemoveFigure(this IBoard board, Log log) => board.Figures.Remove(board.GetFigure(log.EndPoint));
        public static bool IsPlayersFigure(this IBoard board, Coordinate coordinate, Color currentPlayer) => board.GetFigure(coordinate)?.Color == currentPlayer;
        public static bool IsOpponentFigure(this IBoard board, Coordinate coordinate, Color currentPlayer) => board.GetFigure(coordinate)?.Color != currentPlayer;
        public static bool IsAttacked(this IBoard board, Coordinate c, Color currentPlayer) => board.Figures.Where(x => x.Color != currentPlayer).Any(x => x.MoveOptions.Any(x => x.Log.EndPoint == c));
        public static bool IsEmptyField(this IBoard board, Coordinate c) => board.GetFigure(c) == null;
        public static IFigure GetPlayersKing(this IBoard board, Color currentPlayer) => board.Figures.First(x => x.FigureType == FigureType.King && x.Color == currentPlayer);
        public static IFigure GetEnemysKing(this IBoard board, Color currentPlayer) => board.Figures.First(x => x.FigureType == FigureType.King && x.Color != currentPlayer);
        public static IEnumerable<IFigure> GetEnemyLongDistanceFigures(this IBoard board, Color color)
            => board.Figures.Where(x => x.Color != color && new List<FigureType>() { FigureType.Bishop, FigureType.Rook, FigureType.Queen }.Contains(x.FigureType));
        public static void SetPosition(this IBoard board, Log log, Color player) {
            if (log.StartPoint == log.EndPoint) throw new IllegalMoveException("Start and end coordinates are equal.");
            if (board.IsPlayersFigure(log.EndPoint, player)) throw new IllegalMoveException("Cannot capture player's figure.");
            if (board.IsOpponentFigure(log.EndPoint, player)) board.RemoveFigure(log);
            board.GetFigure(log.StartPoint).SetPosition(log.EndPoint);
        }
        public static void HandleExtraMove(this IBoard board, LogComplexMove log, Color player)
        {
            if (log.FigureType != null) board.Promote(log);
            else board.SetPosition(log, player);
        }
        public static void Promote(this IBoard board, LogComplexMove log) {
            var player = board.GetCurrentColor(log.StartPoint);
            board.RemoveFigure(log);
            var typeName = typeof(IFigure).Namespace + "." + log.FigureType.ToString();
            var figure = (IFigure)Activator.CreateInstance(Type.GetType(typeName), new object[] { player, log.EndPoint });
            board.Figures.Add(figure);
        }
        public static void VerifyMoveOptions(this IBoard board, Color p)
        {
            //var c = board.GetPlayersKing(p);
            //board.Figures.ForEach(x => x.MoveOptions.Any(o => o.Log.EndPoint == c.))
            //board.Where
            //remove check possibleCoordinates.RemoveAll(x => board.IsAttacked(x, figure.Color));

        }
    }
}
