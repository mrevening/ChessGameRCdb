using ChessGame.Logic;

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
    }
}
