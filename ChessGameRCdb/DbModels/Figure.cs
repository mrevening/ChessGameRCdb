namespace ChessGame.DbModels
{
    public class Figure
    {
        public int Id { get; set; }
        public virtual Player Player { get; set; }
        public virtual FigureType FigureType { get; set; }
        public virtual Column Column { get; set; }
        public virtual Row Row { get; set; }
    }
}
