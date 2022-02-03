namespace ChessGame.Logic
{
    public static class ColorExtention
    {
        public static Direction GetDirection(this Color color) => color == Color.White ? Direction.Up : Direction.Down;
        public static bool IsUp(this Color color) => color.GetDirection() == Direction.Up;
        public static int GetDirectionSign(this Color color) => color.IsUp() ? 1 : -1;
    }
}
