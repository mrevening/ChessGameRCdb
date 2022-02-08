namespace ChessGame.Logic
{
    public class AttackType : Enumeration
    {
        public static AttackType OpenAttack = new AttackType(1, nameof(OpenAttack));
        public static AttackType DifferedCheck = new AttackType(2, nameof(DifferedCheck));

        public AttackType(int id, string name) : base(id, name) { }
    }
}
