using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessGame.DbModels
{
    public class NotationLog
    {
        public int Id { get; set; }
        public virtual Game Game { get; set; }
        public virtual Player Player { get; set; }
        public virtual FigureType FigureType { get; set; }
        public virtual Column StartColumn { get; set; }
        public virtual Row StartRow { get; set; }
        public virtual Column EndColumn { get; set; }
        public virtual Row EndRow { get; set; }
    }
}
