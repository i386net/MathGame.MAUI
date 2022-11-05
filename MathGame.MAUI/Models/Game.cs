namespace MathGame.MAUI.Models
{
    public class Game
    {
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
