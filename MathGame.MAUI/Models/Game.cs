using SQLite;

namespace MathGame.MAUI.Models
{
    [Table("game")] //name of the table that will be created at the DB
    public class Game
    {
        [PrimaryKey, AutoIncrement, Column("Id")]
        public int Id { get; set; }
        public GameOperation Type { get; set; }
        public DateTime DatePlayed { get; set; }
        public int Score { get; set; }
    }

    public enum GameOperation
    {
        Addition, 
        Subtraction, 
        Multiplication, 
        Division,
    }
}
