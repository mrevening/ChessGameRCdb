namespace ChessGame.Logic
{
    public static class ColorExtention
    {
        public static Direction GetDirection(this Color color) => color == Color.White ? Direction.Up : Direction.Down;
    }
}
