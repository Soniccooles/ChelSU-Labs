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
            Console.WriteLine("Введите выражение");
            while (true)
            {
                
                string input = Console.ReadLine().Replace(" ", "");
               List<Token> parsedInput = RpnCalculator.Parse(input, "");
                List<Token> rpn = RpnCalculator.ToRPN(parsedInput);
                float result = RpnCalculator.CalculateWithRPN(rpn);
                Console.WriteLine("Результат: " + result);
            }
        }
    }
}