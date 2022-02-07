using ChessGame.Logic;

namespace ChessGame.DTO
{
    public class SquareDTO
    {
        public string Name { get; set; }
        public Column Column { get; set; }
        public Row Row { get; set; }
        public int? Color { get; set; }

        public SquareDTO() { }

        public SquareDTO(Column c, Row r) 
        {
            Name = new Coordinate(c, r).ToString();
        }
    }
}
