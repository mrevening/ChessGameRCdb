namespace ChessGame.DbModels
{
    public class NotationLogEnPassant
    {
        public int Id { get; set; }
        public int EnemyPionColumnId { get; set; }
        public int EnemyPionRowId { get; set; }
        public virtual Column EnemyPionColumn { get; set; }
        public virtual Row EnemyPionRow { get; set; }
    }
}
