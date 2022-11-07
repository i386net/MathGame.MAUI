using MathGame.MAUI.Models;
using SQLite;

namespace MathGame.MAUI.Data
{
    // Class to manage data in data base 
    public class GameRepository
    {
        private string _dbPath;
        private SQLiteConnection conn;

        public GameRepository(string dbPath)
        {
            _dbPath = dbPath;   
        }

        // Create table in DB
        public void Init()
        {
            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<Game>(); // <- submit the model of our table that was created in Game.cs
        }

        // Get data from DB
        public List<Game> GetAllGames()
        {
            Init();
            return conn.Table<Game>().ToList();
        }

        // Add date to the DB
        public void Add(Game game)
        {
            conn = new SQLiteConnection(_dbPath);
            conn.Insert(game);
        }

        public void Delete(int id)
        {
            conn = new SQLiteConnection(_dbPath);
            conn.Delete(new Game{ Id = id }); // check it 
        }
    }
}
