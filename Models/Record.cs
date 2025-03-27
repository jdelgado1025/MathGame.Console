namespace MathGame.Models;
public class Record
{
    public DateTime Date { get; set; }
    public int Score { get; set; }
    public Operation GameType { get; set; }
}

public enum Operation
{
    Addition,
    Subtraction,
    Multiplication,
    Division
}