using ChessGame.Logic;

namespace ChessGame.Logic
{
    public class FigureType : Enumeration
    {
        public static FigureType Pawn = new FigureType(1, nameof(Pawn));
        public static FigureType Knight = new FigureType(2, nameof(Knight));
        public static FigureType Bishop = new FigureType(3, nameof(Bishop));
        public static FigureType Rook = new FigureType(4, nameof(Rook));
        public static FigureType Queen = new FigureType(5, nameof(Queen));
        public static FigureType King = new FigureType(6, nameof(King));

        public FigureType(int id, string name) : base(id, name) { }
    }
}
