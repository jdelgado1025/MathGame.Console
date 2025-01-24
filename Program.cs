using System.Runtime.InteropServices;

string? readResult;
string menuSelection = "";

do
{
    Console.Clear();
    DisplayMenu();

    readResult = Console.ReadLine();
    if(readResult != null)
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
        default:
            Console.WriteLine("Invalid input");
            break;
    }

}
while (menuSelection != "exit");

void DisplayMenu()
{
    string menu = @"Welcome to the Math Game app. Your main options are:
    1. Addition
    2. Subtraction
    3. Multiplication
    4. Division
    5. Previous Game History

Enter your selection number (or type Exit to exit the program)";
    Console.WriteLine(menu);
    //Console.WriteLine("Welcome to the Math Game app. Your main options are:");
    //Console.WriteLine("1. Addition");
    //Console.WriteLine("2. Subtraction");
    //Console.WriteLine("3. Multiplication");
    //Console.WriteLine("4. Division");
    //Console.WriteLine("5. Previous Game History");
    //Console.WriteLine();
    //Console.WriteLine("Enter your selection number (or type Exit to exit the program)");
}

void Division()
{
    const int DIVISOR_MIN = 1;
    const int DIVISOR_MAX = 500;
    const int DIVIDEND_MIN = 0;
    const int DIVIDEND_MAX = 100;
    const string DIVIDE = "/";
    var rand = new Random();
    int dividend;
    int divisor;

    do
    {
        divisor = rand.Next(DIVISOR_MIN, DIVISOR_MAX);
        dividend = rand.Next(DIVIDEND_MIN, DIVIDEND_MAX);
    }
    while (dividend % divisor != 0);

    int quotient = dividend / divisor;

    PromptUser(quotient, dividend, divisor, DIVIDE);
}

void Multiplication()
{
    var rand = new Random();
    const string MULTIPLY = "*";
    const int MULTIPLICATION_MAX = 500;
    const int MULTIPLICATION_MIN = 0;
    int multiplier = rand.Next(MULTIPLICATION_MIN, MULTIPLICATION_MAX);
    int multiplicand = rand.Next(MULTIPLICATION_MIN, MULTIPLICATION_MAX);
    int product = multiplicand * multiplier;

    PromptUser(product, multiplicand, multiplier, MULTIPLY);
}

void Addition()
{
    var rand = new Random();
    const string ADD = "+";
    const int ADDEND_MAX = 500;
    const int ADDEND_MIN = 0;
    int addendOne = rand.Next(ADDEND_MIN, ADDEND_MAX);
    int addendTwo = rand.Next(ADDEND_MIN, ADDEND_MAX);
    int sum = addendOne + addendTwo;

    PromptUser(sum, addendOne, addendTwo, ADD);
}

void Subtraction()
{
    var rand = new Random();
    const string SUBTRACT = "+";
    const int SUBTRACTION_MAX = 500;
    const int SUBTRACTION_MIN = 0;
    int minuend = rand.Next(SUBTRACTION_MIN, SUBTRACTION_MAX);
    int subtrahend = rand.Next(SUBTRACTION_MIN, SUBTRACTION_MAX);
    int difference = minuend + subtrahend;

    PromptUser(difference, minuend, subtrahend, SUBTRACT);
}

void PromptUser(int answer, int numberOne, int numberTwo, string mathOperation)
{
    string? readResult = "";
    int userResult = 0;

    while (readResult == "" || userResult != answer)
    {
        switch(mathOperation)
        {
            case "+":
                Console.Write($"{numberOne} + {numberTwo}: ");
                break;
            case "-":
                Console.Write($"{numberOne} - {numberTwo}: ");
                break;
            case "*":
                Console.Write($"{numberOne} * {numberTwo}: ");
                break;
            case "/":
                Console.Write($"{numberOne} / {numberTwo}: ");
                break;
        }
        
        readResult = Console.ReadLine().Trim().ToLower();

        if (!int.TryParse(readResult, out userResult) || userResult != answer)
            Console.WriteLine("You answered incorrectly!!");
    }

    Console.WriteLine("You answered correctly!");
    Thread.Sleep(1000);
}