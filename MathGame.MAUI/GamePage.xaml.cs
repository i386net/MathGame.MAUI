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
		var gameOperand = GameType switch
		{
			"Addition" => "+",
			"Subtraction" => "-",
			"Multiplication" => "*",
			"Division" => "/",
			_ => "",
		};
		var random = new Random();
		firstNumber = GameType != "Division" ? random.Next(1, 9) : random.Next(1, 99);
		secondNumber = GameType != "Division" ? random.Next(1, 9) : random.Next(1, 99);
		AnswerEntry.Text = ""; // clear text field

		if (GameType == "Division")
		{
			while (firstNumber < secondNumber || firstNumber % secondNumber != 0)
			{
				firstNumber = random.Next(1, 99);
				secondNumber = random.Next(1, 99);
			}
		}
		QuestionLabel.Text = $"{firstNumber} {gameOperand} {secondNumber}";
	}
	private void OnAnswerSubmitted(object sender, EventArgs e)
	{
		//int answer = int.Parse(AnswerEntry.Text); // check for incorrect input
		int.TryParse(AnswerEntry.Text, out int answerNumber);
		bool isCorrect = false;

		switch (GameType)
		{
			case "Addition":
				isCorrect = answerNumber == firstNumber + secondNumber;
				break;
			case "Subtraction":
				isCorrect = answerNumber == firstNumber - secondNumber;
				break;
			case "Multiplication":
				isCorrect = answerNumber == firstNumber * secondNumber;
				break;
			case "Division":
				isCorrect = answerNumber == firstNumber / secondNumber;
				break;
			default:
				break;
		}
		ProcessAnswer(isCorrect);
		questionsLeft -= 1;
		AnswerLabel.Text = ""; // clear label 
		if (questionsLeft > 0)
		{
			CreateNewQuestion();
		}
		else
		{
			GameoVer();
		}
	}

	private void GameoVer()
	{
		GameOverLabel.Text = $"Game over! Your got {score} out of {totalQuestions}";
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