using MathGame.MAUI.Models;
using SQLite;

namespace MathGame.MAUI.Data
{
    public class GameRepository
    {
        private string _dbPath;
        private SQLiteConnection conn;

        public GameRepository(string dbPath)
        {
            _dbPath = dbPath;   

        }

        public void Init()
        {
            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<Game>(); // <- submit the model of our table that was created in Game.cs
        }

        //get data from DB
        public List<Game> GetAllGames()
        {
            Init();
            return conn.Table<Game>().ToList();
        }

        public void Add(Game game)
        {
            conn = new SQLiteConnection(_dbPath);
            conn.Insert(game);
        }
    }
}
