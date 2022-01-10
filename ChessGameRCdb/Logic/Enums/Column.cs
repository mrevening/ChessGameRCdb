using ChessGame.Logic.SeedWork;
using System;

namespace ChessGame.Logic.Enums
{
    public class Column : Enumeration
    {
        public readonly static Column A = new Column(1, nameof(A));
        public readonly static Column B = new Column(2, nameof(B));
        public readonly static Column C = new Column(3, nameof(C));
        public readonly static Column D = new Column(4, nameof(D));
        public readonly static Column E = new Column(5, nameof(E));
        public readonly static Column F = new Column(6, nameof(F));
        public readonly static Column G = new Column(7, nameof(G));
        public readonly static Column H = new Column(8, nameof(H));

        public Column(int id, string name) : base(id, name) { }


        public static Column operator +(Column left, int right)
        {
            if (left.Id + right > H.Id) throw new Exception("Cannot perform + operation");
            return FromValue<Column>(left.Id + right);
        }
        public static Column operator -(Column left, int right)
        {
            if (left.Id - right < A.Id) throw new Exception("Cannot perform - operation");
            return FromValue<Column>(left.Id - right);
        }
        public static Column operator ++(Column origin)
        {
            if (origin == H) throw new Exception("Cannot perform ++ operation on last column");
            return FromValue<Column>(origin.Id + 1);
        }
        public static Column operator --(Column origin)
        {
            if (origin == A) throw new Exception("Cannot perform -- operation on first column");
            return FromValue<Column>(origin.Id - 1);
        }
        public static bool operator <= (Column left, Column rigth)
        {
            return left.Id <= rigth.Id;
        }
        public static bool operator >=(Column left, Column rigth)
        {
            return left.Id >= rigth.Id;
        }
    }
}
