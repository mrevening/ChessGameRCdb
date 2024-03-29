﻿namespace ChessGame.DbModels
{
    public class Figure
    {
        public int Id { get; set; }
        public virtual Color Color { get; set; }
        public virtual FigureType FigureType { get; set; }
        public virtual Column Column { get; set; }
        public virtual Row Row { get; set; }
    }
}
