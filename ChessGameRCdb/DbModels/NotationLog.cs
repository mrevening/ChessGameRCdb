﻿using System.Collections.Generic;

namespace ChessGame.DbModels
{
    public class NotationLog
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int StartColumnId { get; set; }
        public int StartRowId { get; set; }
        public int EndColumnId { get; set; }
        public int EndRowId { get; set; }
        public bool Castle { get; set; }
        public bool EnPassant { get; set; }
        public int? PromotedFigureId { get; set; }
        public virtual Game Game { get; set; }
        public virtual Column StartColumn { get; set; }
        public virtual Row StartRow { get; set; }
        public virtual Column EndColumn { get; set; }
        public virtual Row EndRow { get; set; }
        public virtual FigureType PromotedFigure { get; set; }
    }
}
