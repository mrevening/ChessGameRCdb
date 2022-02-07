using System;

namespace ChessGame.Logic
{
    public class Coordinate : IEquatable<Coordinate>
    {
        public Column Column { get; private set; }
        public Row Row { get; private set; }

        public Coordinate(Column column, Row row)
        {
            if (column is null || row is null) throw new ArgumentNullException("Coordinate cannot receive null arguments.");
            Column = column;
            Row = row;
        }
        public Coordinate(int column, int row)
        {
            if (column >= Column.A.Id && column <= Column.H.Id && row >= Row.One.Id && row <= Row.Eight.Id)
            {
                Column = Enumeration.FromValue<Column>(column);
                Row = Enumeration.FromValue<Row>(row);
            }
        }

        public Coordinate(string c)
        {
            Column = Enumeration.FromDisplayName<Column>(c[0].ToString().ToUpper());
            Row = Enumeration.FromValue<Row>(int.Parse(c.Substring(1,1)));
        }

        public override string ToString() => Column.ToString() + Row.Id.ToString(); 
        public override bool Equals(object other) => other is Coordinate && Equals(other);
        public bool Equals(Coordinate p) => Column == p.Column && Row == p.Row;
        public static bool operator == (Coordinate lhs, Coordinate rhs) => lhs.Equals(rhs);
        public static bool operator != (Coordinate lhs, Coordinate rhs) => !lhs.Equals(rhs);
        public override int GetHashCode() => (Column, Row).GetHashCode();
    }
}
