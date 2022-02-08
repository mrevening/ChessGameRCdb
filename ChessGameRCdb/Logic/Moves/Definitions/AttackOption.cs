namespace ChessGame.Logic
{
    public class AttackOption
    {
        public AttackType AttackType { get; set; }
        public Coordinate Coordinate { get; private set; }

        public AttackOption(AttackType action, Coordinate c)
        {
            AttackType = action;
            Coordinate = c;
        }

        public override string ToString() => AttackType.ToString() + Coordinate.ToString();
        public override bool Equals(object obj) => obj != null && Equals(obj as MoveOption);
        public bool Equals(AttackOption moveOption) => AttackType == moveOption.AttackType && Coordinate == moveOption.Coordinate;
        public override int GetHashCode() => (AttackType, Coordinate).GetHashCode();
    }
}
