﻿using System.Collections.Generic;

namespace ChessGame.DbModels
{
    public class NotationLog
    {
        public int Id { get; set; }
        public virtual Game Game { get; set; }
        public virtual Column StartColumn { get; set; }
        public virtual Row StartRow { get; set; }
        public virtual Column EndColumn { get; set; }
        public virtual Row EndRow { get; set; }
        public virtual IEnumerable<NotationLogComplexMove> NotationLogComplexMove { get; set; }
    }
}