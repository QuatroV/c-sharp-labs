using System;

namespace ConsoleApp1
{

    delegate string performCalculation(int a, int b, string str);
    class Program
    {
        static string Sum(int a, int b, string str)
        {
            return $"{a + b} {str}";
        }
        static string someMethod1(double num, string str, performCalculation func)
        {
            return $"{func(1,3, "sdd")} {str} {num}";
        }

        static string someMethod2(double num, string str, Func<int, int, string, string> func)
        {
            string res = func(1, 3, "sdd");
            return $"{res} {str} {num}";
        }
        static void Main(string[] args)
        {
            performCalculation perfCalc1 = new performCalculation(Sum);

            Console.WriteLine($"First: {someMethod1(1.1, "sddss", perfCalc1)}");

            performCalculation perfCalc2 = (x, y, z) => { return $"{x + y} {z}"; };

            Console.WriteLine($"Second: {someMethod1(2.13, "sdds2dss", perfCalc2)}");

            Func<int, int, string, string> perfCalc3 = (x, y, z) => { return $"{x + y} {z}"; };

            Console.WriteLine($"Third: {someMethod2(2.23, "sdds2dss", perfCalc3)}");
        }
    }
}
