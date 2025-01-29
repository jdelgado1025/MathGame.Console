using MathGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame.Classes;
public class Game
{
    private List<Record> History { get; set; }
    private int Score { get; set; }
    private const int _problemCount = 5;

    public Game()
    {
        Score = 0;
        History = new();
    }

    public void Start()
    {
        Console.WriteLine("Welcome to the Math Game!");
        Thread.Sleep(500);
        PlayGame();
    }

    private void PlayGame()
    {
        string? readResult;
        string menuSelection = "";

        do
        {
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
                    Score = 0;
                    Addition();
                    break;
                case "2":
                    Score = 0;
                    Subtraction();
                    break;
                case "3":
                    Score = 0;
                    Multiplication();
                    break;
                case "4":
                    Score = 0;
                    Division();
                    break;
                case "5":
                    PrintHistory();
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
            
        } while (PlayAgain());
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
        for (int i = 0; i < _problemCount; i++)
        {
            var (addendOne, addendTwo) = GenerateNumbers(Operation.Addition);
            Console.WriteLine($"What is {addendOne} + {addendTwo}");
            CheckAnswer(addendOne + addendTwo);
        }

        DisplayScore();
        AddToHistory(Score, Operation.Addition);
    }

    private void Subtraction()
    {
        for (int i = 0; i < _problemCount; i++)
        {
            var (minuend, subtrahend) = GenerateNumbers(Operation.Subtraction);
            Console.WriteLine($"What is {minuend} - {subtrahend}");
            CheckAnswer(minuend - subtrahend);
        }

        DisplayScore();
        AddToHistory(Score, Operation.Subtraction);
    }

    private void Multiplication()
    {
        for (int i = 0; i < _problemCount; i++)
        {
            var (multiplicand, multiplier) = GenerateNumbers(Operation.Multiplication);
            Console.WriteLine($"What is {multiplicand} * {multiplier}");
            CheckAnswer(multiplicand * multiplier);
        }

        DisplayScore();
        AddToHistory(Score, Operation.Multiplication);
    }

    private void Division()
    {
        for (int i = 0; i < _problemCount; i++)
        {
            var (dividend, divisor) = GenerateNumbers(Operation.Division);
            Console.WriteLine($"What is {dividend} / {divisor}");
            CheckAnswer(dividend / divisor);
        }

        DisplayScore();
        AddToHistory(Score, Operation.Division);
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

    private void DisplayScore()
    {
        Console.WriteLine($"Your score: {Score} / {_problemCount}");
    }

    private void AddToHistory(int score, Operation operation)
    {
        History.Add(
            new Record
            {
                Date = DateTime.Now,
                Score = score,
                GameType = operation
            });
    }

    private void PrintHistory()
    {
        if(History.Count == 0)
        {
            Console.WriteLine("There is no history to display.");
            return;
        }

        foreach(var record in History)
        {
            Console.WriteLine($"{record.Date}: {record.GameType} - {record.Score} / {_problemCount}");
        }
    }

    private (int, int) GenerateNumbers(Operation gameType)
    {
        int numberOne, numberTwo;
        Random rand = new Random();

        if (gameType == Operation.Division)
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
}
