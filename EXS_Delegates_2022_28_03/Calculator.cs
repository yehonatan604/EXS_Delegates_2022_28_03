using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXS_Delegates_2022_28_03
{
    public class Calculator
    {
        public MethodReturnDoubleAndGetTwoDoubles OnGetResult = null;
        public Func<double, double, double> calcIt = null;
        public Action<string> acceptStringForPrintSum = null;

        public double Sum { get; set; }

        public Calculator(string? sign = "")
        {
            acceptStringForPrintSum = PrintSum;

            OnGetResult += AddTwoDoubles;
            OnGetResult += DivideTwoDoubles;
            OnGetResult += MultiplyTwoDoubles;
            OnGetResult += HisurTwoDoubles;

            calcIt += AddTwoDoubles;
            calcIt += DivideTwoDoubles;
            calcIt += MultiplyTwoDoubles;
            calcIt += HisurTwoDoubles;

            switch (sign)
            {
                case "+":
                    {
                        OnGetResult = AddTwoDoubles;
                        calcIt = (dbl1, dbl2) =>
                        {
                            Console.WriteLine(dbl1 + dbl2);
                            return dbl1 + dbl2;
                        };
                        break;
                    }
                case "-":
                    {
                        OnGetResult = HisurTwoDoubles;
                        calcIt = (dbl1, dbl2) =>
                        {
                            Console.WriteLine(dbl1 - dbl2);
                            return dbl1 - dbl2;
                        };
                        break;
                    }
                case "*":
                    {
                        OnGetResult = MultiplyTwoDoubles;
                        calcIt = (dbl1, dbl2) =>
                        {
                            Console.WriteLine(dbl1 * dbl2);
                            return dbl1 * dbl2;
                        };
                        break;
                    }
                case "/":
                    {
                        OnGetResult = DivideTwoDoubles;
                        calcIt = (dbl1, dbl2) =>
                        {
                            Console.WriteLine(dbl1 / dbl2);
                            return dbl1 / dbl2;
                        };
                        break;
                    }
            }
        }

        public void PrintSum(string msg = "")
        {
            Console.WriteLine($"{msg} {Sum}");
        }
        public double AddTwoDoubles(double num1, double num2)
        {
            Sum = num1 + num2;
            acceptStringForPrintSum.Invoke($"{num1}+{num2} = ");
            return Sum;
        }
        public double MultiplyTwoDoubles(double num1, double num2)
        {
            Sum = num1 * num2;
            acceptStringForPrintSum.Invoke($"{num1}*{num2} = ");
            return Sum;
        }
        public double DivideTwoDoubles(double num1, double num2)
        {
            Sum = num1 / num2;
            acceptStringForPrintSum.Invoke($"{num1}/{num2} = ");
            return Sum;
        }
        public double HisurTwoDoubles(double num1, double num2)
        {
            Sum = num1 - num2;
            acceptStringForPrintSum.Invoke($"{num1}-{num2} = ");
            return Sum;
        }
    }
}
