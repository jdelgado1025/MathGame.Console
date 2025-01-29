namespace MathGame.Models;
internal class Record
{
    public DateTime Date { get; set; }
    public int Score { get; set; }
    public Operation GameType { get; set; }
}

internal enum Operation
{
    Addition,
    Subtraction,
    Multiplication,
    Division
}