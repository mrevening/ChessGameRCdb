namespace ChessGame.DbModels
{
    public class NotationLogComplexMove
    {
        public int Id { get; set; }
        public virtual NotationLog NotationLog { get; set; }
        public virtual Column StartColumn { get; set; }
        public virtual Row StartRow { get; set; }
        public virtual Column EndColumn { get; set; }
        public virtual Row EndRow { get; set; }
    }
}
