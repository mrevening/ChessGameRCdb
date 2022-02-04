namespace ChessGame.Logic
{
    public class X : Enumeration
    {
        public readonly static X X_4 = new X(-3, "-4X");
        public readonly static X X_3 = new X(-3, "-3X");
        public readonly static X X_2 = new X(-2, "-2X");
        public readonly static X X_1 = new X(-1, "-1X");
        public readonly static X X0 = new X(0, "0X");
        public readonly static X X1 = new X(1, "1X");
        public readonly static X X2 = new X(2, "2X");
        public readonly static X X3 = new X(3, "3X");
        public readonly static X X4 = new X(4, "4X");

        public X(int id, string name) : base(id, name) { }


        public static X operator +(X left, int right)
        {
            if (left.Id + right > X4.Id) return null;
            return FromValue<X>(left.Id + right);
        }
        public static X operator -(X left, int right)
        {
            if (left.Id - right < X_4.Id) return null;
            return FromValue<X>(left.Id - right);
        }
        public static X operator ++(X origin)
        {
            if (origin == X4) return null;
            return FromValue<X>(origin.Id + 1);
        }
        public static X operator --(X origin)
        {
            if (origin == X_4) return null;
            return FromValue<X>(origin.Id - 1);
        }
        public static bool operator >=(X left, X rigth)
        {
            return left.Id >= rigth.Id;
        }
        public static bool operator <= (X left, X rigth)
        {
            return left.Id <= rigth.Id;
        }
        public static bool operator >(X left, X rigth)
        {
            return left.Id > rigth.Id;
        }
        public static bool operator <(X left, X rigth)
        {
            return left.Id < rigth.Id;
        }
    }
}
