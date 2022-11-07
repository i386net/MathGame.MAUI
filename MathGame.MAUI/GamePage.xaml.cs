using MathGame.MAUI.Models;
namespace MathGame.MAUI;

public partial class GamePage : ContentPage
{
	public string GameType { get; set; }
	private int firstNumber = 0;
	private int secondNumber = 0;
	private int score = 0;
	private const int totalQuestions = 3;
	private int questionsLeft = totalQuestions;
	public GamePage(string gameType)
	{
		InitializeComponent();
		GameType = gameType;
		BindingContext = this;
		CreateNewQuestion();
	}

	private void CreateNewQuestion()
	{
		var random = new Random();
		firstNumber = GameType != "÷" ? random.Next(1, 9) : random.Next(1, 99);
		secondNumber = GameType != "÷" ? random.Next(1, 9) : random.Next(1, 99);
		AnswerEntry.Text = ""; // clear text field

		if (GameType == "÷")
		{
			while (firstNumber < secondNumber || firstNumber % secondNumber != 0)
			{
				firstNumber = random.Next(1, 99);
				secondNumber = random.Next(1, 99);
			}
		}
		QuestionLabel.Text = $"{firstNumber} {GameType} {secondNumber}";
	}
	private void OnAnswerSubmitted(object sender, EventArgs e)
	{
		// check for incorrect input
		int.TryParse(AnswerEntry.Text, out int answerNumber);
		bool isCorrect = false;

		switch (GameType)
		{
			case "+":
				isCorrect = answerNumber == firstNumber + secondNumber;
				break;
			case "−":
				isCorrect = answerNumber == firstNumber - secondNumber;
				break;
			case "×":
				isCorrect = answerNumber == firstNumber * secondNumber;
				break;
			case "÷":
				isCorrect = answerNumber == firstNumber / secondNumber;
				break;
			default:
				break;
		}
		ProcessAnswer(isCorrect);
		questionsLeft -= 1;
		//AnswerLabel.Text = ""; // clear label 
		if (questionsLeft > 0)
		{
			CreateNewQuestion();
		}
		else
		{
			GameOver();
		}
	}

	private void GameOver()
	{

		GameOperation gameOperation = GameType switch
		{
            "+" => GameOperation.Addition,
            "−" => GameOperation.Subtraction,
            "×" => GameOperation.Multiplication,
            "÷" => GameOperation.Division,
		};

		BackToMenu.IsVisible = true;
		QuestionArea.IsVisible = false;
		GameOverLabel.Text = $"Game over! Your got {score} out of {totalQuestions}";

		App.GameRepository.Add(new Game
		{
			DatePlayed = DateTime.Now,
			Score = score,
			Type = gameOperation,
		});
	}

	private void OnBackToMenu(object sender, EventArgs e)
	{
		score = 0;
		questionsLeft = totalQuestions;
		Navigation.PushAsync(new MainPage());
	}

    private void ProcessAnswer(bool isCorrect)
	{
		if (isCorrect)
		{
			score += 1;
		}
		AnswerLabel.Text = isCorrect ? "Correct!" : "Incorrect";
	}
}