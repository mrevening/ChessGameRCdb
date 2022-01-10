using System;

namespace ChessGameCoreRedux.DTO
{
    public class SquareDTO
    {
        public string Name { get; set; }

        public SquareDTO(string name) 
        {
            Name = name;
        }
    }
}
