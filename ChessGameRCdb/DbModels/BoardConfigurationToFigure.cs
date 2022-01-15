using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessGame.DbModels
{
    public class BoardConfigurationToFigure
    {
        public int Id { get; set; }
        public virtual BoardConfiguration BoardConfiguration { get; set; }
        public virtual Figure Figure { get; set; }
    }
}
