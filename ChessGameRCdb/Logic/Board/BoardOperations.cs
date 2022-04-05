using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    public static class BoardOperations
    {
        public static IFigure? GetFigure(this IBoard board, Coordinate endPoint) => board.Figures.FirstOrDefault(x => x.IsInPosition(endPoint));
        public static Color GetCurrentColor(this IBoard board, Coordinate c) => board.GetFigure(c)?.Color ?? throw new IllegalMoveException("Not touched player's figure.");
        public static void RemoveFigure(this IBoard board, Coordinate c) => board.Figures.Remove(board.GetFigure(c));
        public static bool IsPlayersFigure(this IBoard board, Coordinate coordinate, Color currentPlayer) => board.GetFigure(coordinate)?.Color == currentPlayer;
        public static bool IsOpponentFigure(this IBoard board, Coordinate coordinate, Color currentPlayer) => board.GetFigure(coordinate)?.Color != currentPlayer;
        public static bool IsAttacked(this IBoard board, Coordinate c, Color currentPlayer) => board.Figures.Where(x => x.Color != currentPlayer).Any(x => x.MoveOptions.Any(x => x.Log.EndPoint == c));
        public static bool IsEmptyField(this IBoard board, Coordinate c) => board.GetFigure(c) == null;
        public static IFigure GetPlayersKing(this IBoard board, Color currentPlayer) => board.Figures.FirstOrDefault(x => x.FigureType == FigureType.King && x.Color == currentPlayer);
        public static IFigure GetEnemysKing(this IBoard board, Color currentPlayer) => board.Figures.FirstOrDefault(x => x.FigureType == FigureType.King && x.Color != currentPlayer);
        public static IEnumerable<IFigure> GetEnemyLongDistanceFigures(this IBoard board, Color color)
            => board.Figures.Where(x => x.Color != color && new List<FigureType>() { FigureType.Bishop, FigureType.Rook, FigureType.Queen }.Contains(x.FigureType));
        public static void SetPosition(this IBoard board, Log log) {
            if (log.StartPoint == log.EndPoint) throw new IllegalMoveException("Start and end coordinates are equal.");
            var color = board.GetCurrentColor(log.StartPoint);
            if (board.IsPlayersFigure(log.EndPoint, color)) throw new IllegalMoveException("Cannot capture player's figure.");
            if (board.IsOpponentFigure(log.EndPoint, color)) board.RemoveFigure(log.EndPoint);
            board.GetFigure(log.StartPoint).SetPosition(log.EndPoint);
        }
        public static void HandleEnPassant(this IBoard board, LogEnPassant log) => board.RemoveFigure(log.EnemyPionCoordinate);
        //public static void Promote(this IBoard board, LogComplexMove log) {
        //    var player = board.GetCurrentColor(log.StartPoint);
        //    board.RemoveFigure(log.EndPoint);
        //    var typeName = typeof(IFigure).Namespace + "." + log.FigureType.ToString();
        //    var figure = (IFigure)Activator.CreateInstance(Type.GetType(typeName), new object[] { player, log.EndPoint });
        //    board.Figures.Add(figure);
        //}
        public static void EvaluateMoveOptions(this IBoard board, Color p)
        {
            UnableDefferedAttack(board, p);
            RemoveKingAttackedFieldsMoves(board, p);
        }

        private static void UnableDefferedAttack(IBoard board, Color p) => 
            board.Figures.Where(x => x.Color != p).ToList()
            .ForEach(x => x.AttackOptions.Where(a => a.AttackType == AttackType.DefferedCheck).ToList()
            .ForEach(d => board.Figures.First(f => f.Coordinate == d.Coordinate).MoveOptions = new HashSet<MoveOption>() { }));
        private static void RemoveKingAttackedFieldsMoves(IBoard board, Color p)
        {
            var king = board.Figures.FirstOrDefault(f => f.Color == p && f.FigureType == FigureType.King);
            if (king is null) return;
            var list = king.MoveOptions.ToList();
           list?.RemoveAll(kingMove => board.Figures.Where(f => f.Color != p)
           .Any(enemyFigure => enemyFigure.AttackOptions.Any(m => m.AttackType == AttackType.OpenAttack && m.Coordinate == kingMove.Log.EndPoint)));
           king.MoveOptions = list.ToHashSet();
        }
    }
}
