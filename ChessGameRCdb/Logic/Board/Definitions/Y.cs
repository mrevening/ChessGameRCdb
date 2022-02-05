namespace ChessGame.Logic
{
    public class Y : Enumeration
    {
        public readonly static Y Y_4 = new Y(-4, "-4Y");
        public readonly static Y Y_3 = new Y(-3, "-3Y");
        public readonly static Y Y_2 = new Y(-2, "-2Y");
        public readonly static Y Y_1 = new Y(-1, "-3Y");
        public readonly static Y Y0 = new Y(0, "0Y");
        public readonly static Y Y1 = new Y(1, "1Y");
        public readonly static Y Y2 = new Y(2, "2Y");
        public readonly static Y Y3 = new Y(3, "3Y");
        public readonly static Y Y4 = new Y(4, "4Y");

        public static readonly Y Max = Y4;
        public static readonly Y Min = Y_4;

        public Y(int id, string name) : base(id, name) { }

        public static Y operator +(Y left, int right)
        {
            if (left.Id + right > Y4.Id) return null;
            return FromValue<Y>(left.Id + right);
        }
        public static Y operator -(Y left, int right)
        {
            if (left.Id - right < Y_4.Id) return null;
            return FromValue<Y>(left.Id - right);
        }
        public static Y operator ++(Y origin)
        {
            if (origin == Y4) return null;
            return FromValue<Y>(origin.Id + 1);
        }
        public static Y operator --(Y origin)
        {
            if (origin == Y_4) return null;
            return FromValue<Y>(origin.Id - 1);
        }
        public static bool operator >=(Y left, Y rigth)
        {
            return left.Id >= rigth.Id;
        }
        public static bool operator <=(Y left, Y rigth)
        {
            return left.Id <= rigth.Id;
        }
        public static bool operator >(Y left, Y rigth)
        {
            return left.Id > rigth.Id;
        }
        public static bool operator <(Y left, Y rigth)
        {
            return left.Id < rigth.Id;
        }
    }
}
