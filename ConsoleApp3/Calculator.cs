using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Dynamic;
using System.Globalization;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks.Dataflow;

namespace Programm1;

public class Programm // Класс программ qqqeqeqeq
{
    public static void Main(string[] args) //Функция главная
    {
        while (true)
        {
            string input = Console.ReadLine().Replace(" ", "");
            // Console.WriteLine(string.Join(' ', WriteOperands(input)));
            // Console.WriteLine(string.Join(' ', WriteNumbers(input)));
            // Console.WriteLine(WriteResult(input));
            Console.WriteLine(string.Join(' ', ToRPN(Parse(input))));
        }
    }
    public static List<object> Parse(string input)
    {

        List<object> list = new List<object>();
        string number = "";
        foreach (var element in input + ' ')
        {
            if (Char.IsDigit(element))
            {
                number += element;
            }

            else
            {
                list.Add(float.Parse(number));
                number = "";
            }

            if (element == '*' || element == '/' || element == '+' || element == '-' || element == '(' || element == ')')
            {
                list.Add(element);
            }
        }
        return list;
    }
    public static List<object> ToRPN(List<object> newInput)
    {
        int token1 = 0;
        int token2 = 0;
        string number = "";
        List<object> result = new List<object>();
        Stack<char> stack = new Stack<char>();
        Console.WriteLine(string.Join(',', newInput));
        for (int elem = 0; elem < newInput.Count; elem++)
        {
            if (newInput[elem] is float)
            {
                result.Add(newInput[elem]);
                continue;
            }
            if (Convert.ToChar(newInput[elem]) == '(')
            {
                stack.Push(Convert.ToChar(newInput[elem]));
            }
            if (Convert.ToChar(newInput[elem]) == ')')
            {
                while (stack.Peek() != '(')
                {
                    result.Add(stack.Pop());
                }
            }
            if (Convert.ToChar(newInput[elem]) == '*' || Convert.ToChar(newInput[elem]) == '/')
            {
                stack.Push(Convert.ToChar(newInput[elem]));
            }
            if (Convert.ToChar(newInput[elem]) == '+' || Convert.ToChar(newInput[elem]) == '-')
            {
                stack.Push(Convert.ToChar(elem));
            }
        }
        Console.WriteLine(string.Join(',', stack));
        return result;
    }
    public static float Calculate(List<object> resulte)
    {
        float nichego = 1;
        return nichego;
    }
}