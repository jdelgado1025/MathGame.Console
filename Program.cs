string? readResult;
string menuSelection = "";

do
{
    Console.Clear();
    DisplayMenu();

    readResult = Console.ReadLine();
    if(readResult != null)
    {
        menuSelection = readResult.ToLower(); 
    }

    switch (menuSelection)
    {
        case "1":
            Console.WriteLine("Coming soon...");
            Console.ReadLine();
            break;
        case "2":
            Console.WriteLine("Coming soon...");
            Console.ReadLine();
            break;
        case "3":
            Multiplication();
            Console.ReadLine();
            break;
        case "4":
            Division();
            break;
    }

}
while (menuSelection != "exit");

void DisplayMenu()
{
    Console.WriteLine("Welcome to the Math Game app. Your main options are:");
    Console.WriteLine("1. Addition");
    Console.WriteLine("2. Subtraction");
    Console.WriteLine("3. Multiplication");
    Console.WriteLine("4. Division");
    Console.WriteLine("5. Previous Game History");
    Console.WriteLine();
    Console.WriteLine("Enter your selection number (or type Exit to exit the program)");
}

void Division()
{
    const int DIVISOR_MAX = 500;
    const int DIVIDEND_MAX = 100;
    var rand = new Random();
    string? readResult = "";
    int result = 0;
    int quotient;
    int dividend;
    int divisor;

    do
    {
        divisor = rand.Next(1, DIVISOR_MAX);
        dividend = rand.Next(0, DIVIDEND_MAX);
    }
    while (dividend % divisor != 0);

    quotient = dividend / divisor;
    while(readResult == "" || result != quotient)
    {
        Console.Write($"{dividend} / {divisor}: ");
        readResult = Console.ReadLine();

        int.TryParse(readResult, out result);
    }

    Console.WriteLine("Correct!");
}

void Multiplication()
{
    var rand = new Random();
    string? readResult = "";
    int result = 0;
    int multiplier = rand.Next(int.MinValue, int.MaxValue);
    int multiplicand = rand.Next(int.MinValue, int.MaxValue);
    int product;

    product = multiplicand * multiplier;
    while (readResult == "" || result != product)
    {
        Console.Write($"{multiplicand} * {multiplier}: ");
        readResult = Console.ReadLine();

        int.TryParse(readResult, out result);
    }
}