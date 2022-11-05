using SQLite;

namespace MathGame.MAUI.Models
{
    [Table("game")]
    public class Game
    {
        [PrimaryKey, AutoIncrement, Column("Id")]
        public int Id { get; set; }
        public GameType Type { get; set; }
        public DateTime DatePlayed { get; set; }
        public int Score { get; set; }
    }

    public enum GameType
    {
        Addition, Subtraction, Multiplication, Division
    }
}
