public static class GameController
{
    private static int totalCollected = 0;
    private static bool _gameOverPorInimigo = false;
    private static bool _gameOverPorTempo = false;

    public static bool gameOver => _gameOverPorInimigo || _gameOverPorTempo;
    public static bool gameOverReal => _gameOverPorInimigo || _gameOverPorTempo;
    public static int TotalColetados => totalCollected;

    public static void Init()
    {
        totalCollected = 0;
        _gameOverPorInimigo = false;
        _gameOverPorTempo = false;
    }

    public static void Collect()
    {
        totalCollected++;

        if (totalCollected % 2 == 0)
        {
            EnemySpawner.SpawnEnemy();
        }

        ColetavelSpawner.SpawnColetavel();
    }

    public static void GameOverPorInimigo()
    {
        _gameOverPorInimigo = true;
    }

    public static void GameOverPorTempo()
    {
        _gameOverPorTempo = true;
    }
}
