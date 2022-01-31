namespace ChessGame.DbModels
{
    public class NotationLogComplexMove
    {
        public int Id { get; set; }
        public int NotationLogId { get; set; }
        public int? StartColumnId { get; set; }
        public int? StartRowId { get; set; }
        public int? EndColumnId { get; set; }
        public int? EndRowId { get; set; }
        public int? FigureTypeId { get; set; }
        public virtual NotationLog NotationLog { get; set; }
        public virtual Column StartColumn { get; set; }
        public virtual Row StartRow { get; set; }
        public virtual Column EndColumn { get; set; }
        public virtual Row EndRow { get; set; }
        public virtual FigureType FigureType { get; set; }
    }
}
