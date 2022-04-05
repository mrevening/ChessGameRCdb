namespace ChessGame.Logic
{
    public class LogEnPassant
    {
        public Coordinate EnemyPionCoordinate { get; private set; }
        public LogEnPassant(Coordinate enemyPion)
        {
            EnemyPionCoordinate = enemyPion;
        }

        public override string ToString() => EnemyPionCoordinate.ToString();
    }
}
