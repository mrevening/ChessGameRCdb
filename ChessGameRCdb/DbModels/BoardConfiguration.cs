using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessGame.DbModels
{
    public class BoardConfiguration
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<BoardConfigurationToFigure> BoardConfigurationToFigure { get; set; }
    }
}
