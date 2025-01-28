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
        string menu = @"Welcome to the Math Game app. Your main options are:
    1. Addition
    2. Subtraction
    3. Multiplication
    4. Division
    5. Previous Game History

Enter your selection number (or type Exit to exit the program)";
        Console.WriteLine(menu);
    }
}
