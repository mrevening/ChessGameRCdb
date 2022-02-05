namespace ChessGame.Logic
{
    public static class Validator
    {
        public static bool Validate(this Column c) => c > Column.Min && c < Column.Max;
    }
}
