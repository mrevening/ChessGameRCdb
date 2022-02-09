namespace ChessGame.Logic
{
    public class AttackType : Enumeration
    {
        public static AttackType OpenAttack = new AttackType(1, nameof(OpenAttack));
        public static AttackType DefferedCheck = new AttackType(2, nameof(DefferedCheck));

        public AttackType(int id, string name) : base(id, name) { }
    }
}
