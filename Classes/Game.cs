﻿using MathGame.Models;
using System.Diagnostics;

namespace MathGame.Classes;
public class Game
{
    private Stopwatch _timer;
    private List<Record> History { get; set; }
    private int Score { get; set; }
    private const int _problemCount = 5;

    public Game()
    {
        Score = 0;
        History = new();
        _timer = new();
    }

    public void Start()
    {
        Console.WriteLine("Hello! Welcome to the Math Game!");
        Thread.Sleep(1000);
        PlayGame();
    }

    private void PlayGame()
    {
        string? readResult;
        string menuSelection = "";
        bool showMenu = true;

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
                    RunOperationGame(Operation.Addition);
                    break;
                case "2":
                    RunOperationGame(Operation.Subtraction);
                    break;
                case "3":
                    RunOperationGame(Operation.Multiplication);
                    break;
                case "4":
                    RunOperationGame(Operation.Division);
                    break;
                case "5":
                    PrintHistory();
                    break;
                case "6":
                    showMenu = false;
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
            
        } while (showMenu);
    }

    private void DisplayMenu()
    {
        string menu = @"Choose an option:
    1. Addition
    2. Subtraction
    3. Multiplication
    4. Division
    5. Previous Game History
    6. Quit

Enter your selection number:";
        Console.WriteLine(menu);
    }

    private void RunOperationGame(Operation operation)
    {
        int numberOne, numberTwo;

        do
        {
            _timer.Start();
            Score = 0;
            Console.Clear();
            Console.WriteLine($"{operation}\n----------------------------------------------------");
            for (int i = 0; i < _problemCount; i++)
            {
                (numberOne, numberTwo) = GenerateNumbers(operation);
                GenerateQuestion(numberOne, numberTwo, operation);
                CheckAnswer(CalculateAnswer(numberOne, numberTwo, operation));
            }

            _timer.Stop();
            DisplayResults();
            AddToHistory(Score, operation);
        }
        while (PlayAgain());

        Console.WriteLine("Returning to main menu...");
        Thread.Sleep(500);
    }

    private void GenerateQuestion(int numberOne, int numberTwo, Operation operation)
    {
        string operationSymbol = "";
        switch (operation)
        {
            case Operation.Addition:
                operationSymbol = "+";
                break;
            case Operation.Subtraction:
                operationSymbol = "-";
                break;
            case Operation.Multiplication:
                operationSymbol = "*";
                break;
            case Operation.Division:
                operationSymbol = "/";
                break;
        }

        Console.WriteLine($"{numberOne} {operationSymbol} {numberTwo}:");
    }

    private int CalculateAnswer(int numberOne, int numberTwo, Operation operation)
    {
        int answer = 0;
        switch(operation)
        {
            case Operation.Addition:
                answer = numberOne + numberTwo;
                break;
            case Operation.Subtraction:
                answer = numberOne - numberTwo;
                break;
            case Operation.Multiplication:
                answer = numberOne * numberTwo;
                break;
            case Operation.Division:
                answer = numberOne / numberTwo;
                break;
        }

        return answer;
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

    private void DisplayResults()
    {
        Console.WriteLine($"Your score: {Score} / {_problemCount}");
        Console.WriteLine($"Time elapsed: {_timer.Elapsed.Hours}:{_timer.Elapsed.Minutes}:{_timer.Elapsed.Seconds}.{_timer.Elapsed.Milliseconds / 10}");
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
            Console.WriteLine("There is no history to display. Press any key to continue...");
            Console.ReadLine();
            return;
        }

        foreach(var record in History)
        {
            Console.WriteLine($"{record.Date}: {record.GameType} - {record.Score} / {_problemCount}");
        }

        Console.WriteLine("Press any key to continue...");
        Console.ReadLine();
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

        //Avoid negative number answers
        if(gameType == Operation.Subtraction && numberTwo > numberOne)
        {
            int temp = numberOne;
            numberOne = numberTwo;
            numberTwo = temp;
        }

        /* Return two values using a Tuple */
        return (numberOne, numberTwo);
    }

    private bool PlayAgain()
    {
        Console.Write("Would you like to play again (y/n): ");
        var response = Console.ReadLine();

        return response.Trim().ToLower() == "y";
    }
}
