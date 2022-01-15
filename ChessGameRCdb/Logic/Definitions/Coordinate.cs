using ChessGame.Logic;
using ChessGame.Logic;
using ChessGame.Logic;
using System;

namespace ChessGame.Logic
{
    public class Coordinate : IEquatable<Coordinate>
    {
        public Column Column { get; private set; }
        public Row Row { get; private set; }

        public Coordinate(Column column, Row row)
        {
            Column = column;
            Row = row;
        }
        public Coordinate(int column, int row)
        {
            Column = Enumeration.FromValue<Column>(column);
            Row = Enumeration.FromValue<Row>(row); ;
        }

        public override string ToString() => Column.ToString() + Row.Id.ToString(); 
        public override bool Equals(object other) => other is Coordinate && Equals(other);
        public bool Equals(Coordinate p) => Column == p.Column && Row == p.Row;
        public static bool operator == (Coordinate lhs, Coordinate rhs) => lhs.Equals(rhs);
        public static bool operator != (Coordinate lhs, Coordinate rhs) => !lhs.Equals(rhs);
        public override int GetHashCode() => (Column, Row).GetHashCode();
    }
}
