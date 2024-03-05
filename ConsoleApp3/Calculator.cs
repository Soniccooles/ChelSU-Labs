using System;
using System.Collections.Generic;
using System.Linq;
using RpnLogic;

namespace CalculatorApp
{
    class ConsoleCalculator
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine().Replace(" ", "");
                List<Token> parsedInput = RpnCalculator.Parse(input);
                List<Token> rpn = RpnCalculator.ToRPN(parsedInput);
                float result = RpnCalculator.CalculateWithRPN(rpn);
                Console.WriteLine("Result: " + result);
            }
        }
    }
}