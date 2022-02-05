using ChessGame.Logic;
using System;

namespace ChessGame.Logic
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

        public readonly static Column Max = H;
        public readonly static Column Min = A;

        public Column(int id, string name) : base(id, name) { }

        public static bool Validate(int c) => c >= Min.Id && c <= Max.Id;
        public static Column operator +(Column left, int right)
        {
            if (left.Id + right > H.Id) return null;
            return FromValue<Column>(left.Id + right);
        }
        public static Column operator -(Column left, int right)
        {
            if (left.Id - right < A.Id) return null;
            return FromValue<Column>(left.Id - right);
        }
        public static Column operator ++(Column origin)
        {
            if (origin == H) return null;
            return FromValue<Column>(origin.Id + 1);
        }
        public static Column operator --(Column origin)
        {
            if (origin == A) return null;
            return FromValue<Column>(origin.Id - 1);
        }
        public static bool operator >=(Column left, Column rigth)
        {
            return left.Id >= rigth.Id;
        }
        public static bool operator <= (Column left, Column rigth)
        {
            return left.Id <= rigth.Id;
        }
        public static bool operator >(Column left, Column rigth)
        {
            return left.Id > rigth.Id;
        }
        public static bool operator <(Column left, Column rigth)
        {
            return left.Id < rigth.Id;
        }
    }
}
