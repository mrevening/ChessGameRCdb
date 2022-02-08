using System;

namespace ChessGame.Logic
{
    public class Diagonal : IEquatable<Diagonal>
    {
        public X X { get; private set; }
        public Y Y { get; private set; }
        public C C { get; private set; }

        public Diagonal(X x, Y y, C c)
        {
            X = x;
            Y = y;
            C = c;
        }
        public Diagonal(int x, int y, int c)
        {
            if (x >= X.X_4.Id && x <= X.X4.Id && y >= Y.Y_4.Id && y <= Y.Y4.Id)
            {
                X = Enumeration.FromValue<X>(x);
                Y = Enumeration.FromValue<Y>(y);
                C = Enumeration.FromValue<C>(c);
            }
        }
        public override string ToString() => X.ToString() + Y.Id.ToString() + C.Id.ToString(); 
        public override bool Equals(object other) => other is Diagonal && Equals(other);
        public bool Equals(Diagonal p) => p is null ? false : X == p.X && Y == p.Y && C == p.C;
        public static bool operator == (Diagonal lhs, Diagonal rhs) => lhs is null ? rhs is null : lhs.Equals(rhs);
        public static bool operator != (Diagonal lhs, Diagonal rhs) => !(lhs == rhs);
        public override int GetHashCode() => (X, Y, C).GetHashCode();
    }
}
