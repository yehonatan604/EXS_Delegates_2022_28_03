using System;

namespace EXS_Delegates_2022_28_03
{
    public delegate int MethodReturnIntAndGetNoParams();
    public delegate double MethodReturnDoubleAndGetTwoDoubles(double dbl1, double dbl2);

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("please enter 2 numbers to calc:");
            double dbl1 = Convert.ToDouble(Console.ReadLine());
            double dbl2 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("\n================= with invoke ==============================\n");

            MethodReturnIntAndGetNoParams methodReturnIntAndGetNoParams = GetVoidAndReturnTime;
            MethodReturnDoubleAndGetTwoDoubles methodReturnDoubleAndGetTwoDoubles = AddTwoDoubles;

            Console.WriteLine("current hour is: " + methodReturnIntAndGetNoParams.Invoke());
            Console.WriteLine($"{dbl1}+{dbl2}= " + methodReturnDoubleAndGetTwoDoubles.Invoke(dbl1, dbl2) + "\n");

            Console.WriteLine("\n================= no invoke ==============================\n");

            Console.WriteLine("current hour is: " + methodReturnIntAndGetNoParams());
            Console.WriteLine($"{dbl1}+{dbl2}= " + methodReturnDoubleAndGetTwoDoubles(dbl1, dbl2));

            Console.WriteLine("\n================= calc everything ==============================\n");

            Calculator? calc = new();
            calc.OnGetResult.Invoke(dbl1, dbl2);

            Console.WriteLine("\n================= calc specific method ==============================\n");

            CalcMethod(calc, "+").Invoke(dbl1, dbl2);

            Console.WriteLine("\n================= calc chosen method ==============================\n");

            Console.WriteLine("please enter calc method:");
            string? calcuMethodString = Console.ReadLine();
            calc = new(calcuMethodString);
            calc.OnGetResult.Invoke(dbl1, dbl2);


        }
        //static methods
        static MethodReturnDoubleAndGetTwoDoubles CalcMethod(Calculator calc, string sign)
        {
            switch (sign)
            {
                case "+":
                    {
                        return calc.AddTwoDoubles;
                    }
                case "-":
                    {
                        return calc.HisurTwoDoubles;
                    }
                case "/":
                    {
                        return calc.DivideTwoDoubles;
                    }
                case "*":
                    {
                        return calc.MultiplyTwoDoubles;
                    }
                default: throw new NotImplementedException();
            }
        }

        static double AddTwoDoubles(double num1, double num2)
        {
            return num1 + num2;
        }
        static int GetVoidAndReturnTime()
        {
            return DateTime.Now.Hour;
        }
    }
}
