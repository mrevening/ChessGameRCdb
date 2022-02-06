using ChessGame.Logic;

namespace ChessGame.DTO
{
    public class SquareDTO
    {
        public int Column { get; set; }
        public int Row { get; set; }
        public string Name { get; set; }

        public SquareDTO(Column c, Row r) 
        {
            Column = c.Id;
            Row = r.Id;
            Name = new Coordinate(c, r).ToString();
        }
    }
}
