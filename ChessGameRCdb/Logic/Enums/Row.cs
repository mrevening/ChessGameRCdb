using ChessGame.Logic;
using System;

namespace ChessGame.Logic
{
    public class Row : Enumeration
    {
        public static Row One   = new Row(1, nameof(One));
        public static Row Two   = new Row(2, nameof(Two));
        public static Row Three = new Row(3, nameof(Three));
        public static Row Four  = new Row(4, nameof(Four));
        public static Row Five  = new Row(5, nameof(Five));
        public static Row Six   = new Row(6, nameof(Six));
        public static Row Seven = new Row(7, nameof(Seven));
        public static Row Eight = new Row(8, nameof(Eight));

        public Row(int id, string name) : base(id, name) { }

        public static Row operator +(Row left, int right)
        {
            if (left.Id + right > Eight.Id) throw new Exception("Cannot perform + operation");
            return FromValue<Row>(left.Id + right);
        }
        public static Row operator -(Row left, int right)
        {
            if (left.Id - right < One.Id) throw new Exception("Cannot perform - operation");
            return FromValue<Row>(left.Id - right);
        }
        public static Row operator ++(Row origin)
        {
            if (origin == Eight) throw new Exception("Cannot perform ++ operation on last Row");
            return FromValue<Row>(origin.Id + 1);
        }
        public static Row operator --(Row origin)
        {
            if (origin == One) throw new Exception("Cannot perform -- operation on first Row");
            return FromValue<Row>(origin.Id - 1);
        }
        public static bool operator >=(Row left, Row rigth)
        {
            return left.Id >= rigth.Id;
        }
        public static bool operator <=(Row left, Row rigth)
        {
            return left.Id <= rigth.Id;
        }
        public static bool operator >(Row left, Row rigth)
        {
            return left.Id > rigth.Id;
        }
        public static bool operator <(Row left, Row rigth)
        {
            return left.Id < rigth.Id;
        }
    }
}
