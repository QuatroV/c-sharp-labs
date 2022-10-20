// Creating first array
Console.WriteLine("Enter the elements of the first array, divided by spaces");

string? elementsStr = Console.ReadLine();

if (string.IsNullOrEmpty(elementsStr)){
    throw new Exception("No elements for the first array");
}

int[] firstArr = elementsStr.Split(" ").Select(int.Parse).ToArray();
Array.Sort(firstArr);

// Creating second array

Console.WriteLine("Enter the elements of the second array, divided by spaces");

elementsStr = Console.ReadLine();

if (string.IsNullOrEmpty(elementsStr)){
    throw new Exception("No elements for the second array");
}

int[] secondArr = elementsStr.Split(" ").Select(int.Parse).ToArray();
Array.Sort(secondArr);
Array.Reverse(secondArr);

// Sort & concatenate

int[] resultArr = firstArr.Concat(secondArr).ToArray();

Console.WriteLine($"The result is {string.Join(" , ", resultArr)}");