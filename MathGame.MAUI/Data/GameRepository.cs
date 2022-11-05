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
            conn.CreateTable<Game>();
        }
    }
}
