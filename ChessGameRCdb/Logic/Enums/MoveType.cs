namespace ChessGame.Logic
{
    public class MoveType : Enumeration, IMove
    {
        public static MoveType OneTileAllDirection = new MoveType(1, nameof(OneTileAllDirection));
        public static MoveType OneTileForward = new MoveType(2, nameof(OneTileForward));
        public static MoveType TwoTilesForward = new MoveType(2, nameof(TwoTilesForward));
        public static MoveType DiagonalCapture = new MoveType(2, nameof(DiagonalCapture));
        public static MoveType EnPassant = new MoveType(2, nameof(EnPassant));
        public static MoveType Promotion = new MoveType(2, nameof(Promotion));
        public static MoveType DiagonalAllDirection = new MoveType(2, nameof(DiagonalAllDirection));
        public static MoveType CrossAllDirection = new MoveType(2, nameof(CrossAllDirection));

        public MoveType(int id, string name) : base(id, name) { }
    }
}
