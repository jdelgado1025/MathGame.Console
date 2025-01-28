using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame.Classes;
public class Game
{
    public List<string> History { get; set; }
    private int Score { get; set; }
    private const int _problemCount = 5;

    public Game()
    {
        Score = 0;
        History = new();
    }

    public void Start()
    {
        Score = 0;
        PlayGame();
    }

    private void PlayGame()
    {
        string? readResult;
        string menuSelection = "";

        Console.Clear();
        DisplayMenu();

        readResult = Console.ReadLine();
        if (readResult != null)
        {
            menuSelection = readResult.ToLower().Trim();
        }

        switch (menuSelection)
        {
            case "1":
                Addition();
                break;
            case "2":
                Subtraction();
                break;
            case "3":
                Multiplication();
                break;
            case "4":
                Division();
                break;
            case "exit":
                Console.Write("Goodbye! Thanks for playing!");
                break;
            default:
                Console.WriteLine("Invalid input");
                break;
        }
    }

    private void DisplayMenu()
    {
        string menu = @"Choose an option:
    1. Addition
    2. Subtraction
    3. Multiplication
    4. Division
    5. Previous Game History

Enter your selection number (or type Exit to exit the program)";
        Console.WriteLine(menu);
    }

    private void Addition()
    {
        for(int i = 0; i < _problemCount; i++)
        {
            var (addendOne, addendTwo) = GenerateNumbers(GameType.Addition);
            Console.WriteLine($"What is {addendOne} + {addendTwo}");
            CheckAnswer(addendOne + addendTwo);
        }

        GetScore();
    }

    private void Subtraction()
    {
        for(int i = 0; i < _problemCount; i++)
        {
            var (minuend, subtrahend) = GenerateNumbers(GameType.Subtraction);
            Console.WriteLine($"What is {minuend} - {subtrahend}");
            CheckAnswer(minuend - subtrahend);
        }

        GetScore();
    }

    private void Multiplication()
    {
        for (int i = 0; i < _problemCount; i++)
        {
            var (multiplicand, multiplier) = GenerateNumbers(GameType.Multiplication);
            Console.WriteLine($"What is {multiplicand} * {multiplier}");
            CheckAnswer(multiplicand * multiplier);
        }

        GetScore();
    }

    private void Division()
    {
        for (int i = 0; i < _problemCount; i++)
        {
            var (dividend, divisor) = GenerateNumbers(GameType.Division);
            Console.WriteLine($"What is {dividend} / {divisor}");
            CheckAnswer(dividend / divisor);
        }

        GetScore();
    }

    private void CheckAnswer(int answer)
    {
        if (int.TryParse(Console.ReadLine(), out var userAnswer) && userAnswer == answer)
        {
            Console.WriteLine("You answered correctly!");
            Score++;
        }
        else
            Console.WriteLine("You answered incorrectly!");
    }

    private void GetScore()
    {
        Console.WriteLine($"Your score: {Score} / {_problemCount}");
    }

    private (int, int) GenerateNumbers(GameType gameType)
    {
        int numberOne, numberTwo;
        Random rand = new Random();

        if (gameType == GameType.Division)
        {
            /* Ensure the divisor is not 0 and result is a whole number */
            do
            {
                numberOne = rand.Next(0, 100);
                numberTwo = rand.Next(1, 100);
            }
            while (numberOne % numberTwo != 0);
        }
        else
        {
            numberOne = rand.Next(1, 100);
            numberTwo = rand.Next(1, 100);
        }

        /* Return two values using a Tuple */
        return (numberOne, numberTwo);
    }

    private bool PlayAgain()
    {
        Console.WriteLine("Would you like to play again(y/n)");
        var response = Console.ReadLine();

        return response.Trim().ToLower() == "y";
    }

    internal enum GameType
    {
        Addition,
        Subtraction,
        Multiplication,
        Division
    }
}
