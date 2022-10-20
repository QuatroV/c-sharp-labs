// See https://aka.ms/new-console-template for more information

string[] AVAILABLE_OPERATORS = {"+", "-", "/", "*"};

float getResult(float firstArg, string? operatorStr, float secondArg){
   switch (operatorStr) {
    case "+":
        return firstArg + secondArg;
    case "-":
        return firstArg - secondArg;
    case "*":
        return firstArg * secondArg;
    case "/":
        return firstArg / secondArg;
    default:
        throw new Exception("Unknown operator");
   }   
}

Console.WriteLine("Welcome to calculator console app! Enter the first argument:");

string? firstArgStr = Console.ReadLine();
float firstArg;
bool firstArgIsNum = float.TryParse(firstArgStr, out firstArg);

while(!firstArgIsNum){
    Console.WriteLine("First argument must be integer number! Please try again:");
    firstArgStr = Console.ReadLine();
    firstArgIsNum = float.TryParse(firstArgStr, out firstArg);
}

Console.WriteLine("Enter the operator:");

string? operatorStr = Console.ReadLine();

while(!AVAILABLE_OPERATORS.Contains(operatorStr)){
    Console.WriteLine($"Operator must be one of {string.Join(", ", AVAILABLE_OPERATORS)}! Please try again:");
    operatorStr = Console.ReadLine();
}

Console.WriteLine("Enter the second argument:");

string? secondArgStr = Console.ReadLine();
float secondArg;
bool secondArgIsNum = float.TryParse(secondArgStr, out secondArg);
bool divideByZero = operatorStr == "/" && secondArg == 0 && secondArgIsNum;

while(!secondArgIsNum || divideByZero){
    string errText = divideByZero ?  "Cannot divide by zero!" : "Second argument must be integer number!" ;
    Console.WriteLine($"{errText} Please try again:");
    secondArgStr = Console.ReadLine();
    secondArgIsNum = float.TryParse(secondArgStr, out secondArg);
    divideByZero = operatorStr == "/" && secondArg == 0 && secondArgIsNum;
}

Console.WriteLine($"The result is {getResult(firstArg, operatorStr, secondArg)}");