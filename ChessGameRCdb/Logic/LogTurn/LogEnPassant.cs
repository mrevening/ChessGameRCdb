namespace ChessGame.Logic
{
    public class LogEnPassant
    {
        public Coordinate EnemyPionCoordinate { get; private set; }
        public LogEnPassant(Coordinate enemyPion)
        {
            EnemyPionCoordinate = enemyPion;
        }
        public LogEnPassant(string enemyPion)
        {
            EnemyPionCoordinate = new Coordinate(enemyPion);
        }

        public override string ToString() => EnemyPionCoordinate.ToString();
    }
}
