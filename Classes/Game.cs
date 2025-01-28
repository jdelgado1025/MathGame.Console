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
        var (addendOne, addendTwo) = GenerateNumbers(GameType.Addition);
        Console.WriteLine($"What is {addendOne} + {addendTwo}");
        CheckAnswer(addendOne + addendTwo);
    }

    private void Subtraction()
    {
        var (minuend, subtrahend) = GenerateNumbers(GameType.Subtraction);
        Console.WriteLine($"What is {minuend} - {subtrahend}");
        CheckAnswer(minuend - subtrahend);
    }

    private void Multiplication()
    {
        var (multiplicand, multiplier) = GenerateNumbers(GameType.Multiplication);
        Console.WriteLine($"What is {multiplicand} * {multiplier}");
        CheckAnswer(multiplicand * multiplier);
    }

    private void Division()
    {
        var (dividend, divisor) = GenerateNumbers(GameType.Addition);
        Console.WriteLine($"What is {dividend} / {divisor}");
        CheckAnswer(dividend / divisor);
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

    internal enum GameType
    {
        Addition,
        Subtraction,
        Multiplication,
        Division
    }
}
