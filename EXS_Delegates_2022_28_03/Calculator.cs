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
        public double Sum { get; set; }

        public Calculator(string? sign = "")
        {
            OnGetResult += AddTwoDoubles;
            OnGetResult += DivideTwoDoubles;
            OnGetResult += MultiplyTwoDoubles;
            OnGetResult += HisurTwoDoubles;

            switch (sign)
            {
                case "+":
                    {
                        OnGetResult = AddTwoDoubles;
                        break;
                    }
                case "-":
                    {
                        OnGetResult = HisurTwoDoubles;
                        break;
                    }
                case "*":
                    {
                        OnGetResult = MultiplyTwoDoubles;
                        break;
                    }
                case "/":
                    {
                        OnGetResult = DivideTwoDoubles;
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
            PrintSum($"{num1}+{num2} =");
            return Sum;
        }
        public double MultiplyTwoDoubles(double num1, double num2)
        {
            Sum = num1 * num2;
            PrintSum($"{num1}*{num2} =");
            return Sum;
        }
        public double DivideTwoDoubles(double num1, double num2)
        {
            Sum = num1 / num2;
            PrintSum($"{num1}/{num2} =");
            return Sum;
        }
        public double HisurTwoDoubles(double num1, double num2)
        {
            Sum = num1 - num2;
            PrintSum($"{num1}-{num2} =");
            return Sum;
        }
    }
}
