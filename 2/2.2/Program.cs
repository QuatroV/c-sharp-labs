void printHumanReadableMatrix(int[,] arr){
    for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++) {
                Console.Write($"{ arr[i, j]} ");
            }
            Console.WriteLine();
        }
}

Console.WriteLine("Input number of rows");

string? rowNumStr = Console.ReadLine();

if (string.IsNullOrEmpty(rowNumStr)){
    throw new Exception("Array size ant be null");
}

int rowNum = int.Parse(rowNumStr);

Console.WriteLine("Input number of columns");

string? columnNumStr = Console.ReadLine();

if (string.IsNullOrEmpty(columnNumStr)){
    throw new Exception("Array size ant be null");
}

int columnNum = int.Parse(columnNumStr);

int[,] arr = new int[rowNum, columnNum];

Random random = new Random();

for (int i = 0; i < arr.GetLength(0); i++)
{
    for (int j = 0; j < arr.GetLength(1); j++)
    {
        arr[i,j] = random.Next(0, 10);
    }
}

Console.WriteLine("Initial array:");
printHumanReadableMatrix(arr);

for (int i = 0; i < arr.GetLength(0); i++) {
   for (int j = arr.GetLength(1) - 1; j > 0; j--) {
      for (int k = 0; k < j; k++) {
         if (arr[i, k] > arr[i, k + 1]) {
            int myTemp = arr[i, k];
            arr[i, k] = arr[i, k + 1];
            arr[i, k + 1] = myTemp;
         }
      }
   }
}

Console.WriteLine("Array sorted by columns:");
printHumanReadableMatrix(arr);

for (int i = 0; i < arr.GetLength(0); i++) {
   for (int j = arr.GetLength(1) - 1; j > 0; j--) {
      for (int k = 0; k < j; k++) {
         if (arr[k, i] > arr[k + 1, i]) {
            int myTemp = arr[k, i];
            arr[k, i] = arr[k + 1, i];
            arr[k + 1, i] = myTemp;
         }
      }
   }
}

Console.WriteLine("Array sorted by rows:");
printHumanReadableMatrix(arr);