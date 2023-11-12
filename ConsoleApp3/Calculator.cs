using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Dynamic;
using System.Globalization;
using System.Linq.Expressions;
using System.Numerics;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks.Dataflow;

namespace Programm1;

public class Programm
{
    public static void Main(string[] args)
    {
        while (true)
        {
            string input = Console.ReadLine().Replace(" ", "");
            Console.WriteLine(string.Join(' ', Calculate(ToRPN(Parse(input)))));
        }
    }
    public static List<object> Parse(string input)
    {
        List<object> list = new List<object>();
        string number = "";
        foreach (var element in input + ' ')
        {
            if (Char.IsDigit(element) && (element != '(' || element != ')') || (element == ','))
            {
                number += element;
            }

            else if (number != "")
            {
                list.Add(float.Parse(number));
                number = "";
            }

            if (element == '*' || element == '/' || element == '+' || element == '-' || element == '(' || element == ')')
            {
                list.Add(element);
                continue;
            }
        }
        return list;
    }
    public static List<object> ToRPN(List<object> newInput)
    {
        List<object> result = new List<object>();
        Stack<char> stack = new Stack<char>();
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
                if (stack.Peek() == '(')
                    stack.Pop();
            }
            if (Convert.ToChar(newInput[elem]) == '*' || Convert.ToChar(newInput[elem]) == '/')
            {
                stack.Push(Convert.ToChar(newInput[elem]));
            }
            if (Convert.ToChar(newInput[elem]) == '+' || Convert.ToChar(newInput[elem]) == '-')
            {
                if (stack.Count != 0)
                {
                    if (stack.Peek() == '*' || stack.Peek() == '/')
                    {
                        result.Add(stack.Pop());
                    }
                }
                stack.Push(Convert.ToChar(newInput[elem]));
            }
        }
        while (stack.Contains('+') || stack.Contains('-') || stack.Contains('*') || stack.Contains('/'))
        {
            result.Add(stack.Pop());
        }
        return result;
    }
    public static float Calculate(List<object> result)
    {
        int index = 0;
        float intermediateResult = 0;
        while (result.Count != 1)
        {
            for (int i = 0; i <= result.Count; i++)
            {
                if (Convert.ToString(result[i]) == "*" || Convert.ToString(result[i]) == "/" || Convert.ToString(result[i]) == "+" ||
                    Convert.ToString(result[i]) == "-")
                {
                    index = i;
                    break;
                }
            }
            float num1 = float.Parse(Convert.ToString(result[index - 2]));
            float num2 = float.Parse(Convert.ToString(result[index - 1]));
            char op = Convert.ToChar(result[index]);
            if (op == '*')
            {
                intermediateResult = num1 * num2;
                result.RemoveAt(index);
                result.RemoveAt(index - 1);
                result.RemoveAt(index - 2);
                result.Insert(index - 2, intermediateResult);
            }
            if (op == '/')
            {
                intermediateResult = num1 / num2;
                result.RemoveAt(index);
                result.RemoveAt(index - 1);
                result.RemoveAt(index - 2);
                result.Insert(index - 2, intermediateResult);
            }
            if (op == '+')
            {
                intermediateResult = num1 + num2;
                result.RemoveAt(index);
                result.RemoveAt(index - 1);
                result.RemoveAt(index - 2);
                result.Insert(index - 2, intermediateResult);
            }
            if (op == '-')
            {
                intermediateResult = num1 - num2;
                result.RemoveAt(index);
                result.RemoveAt(index - 1);
                result.RemoveAt(index - 2);
                result.Insert(index - 2, intermediateResult);
            }
            index -= 2;
        }
        float finalResult = (float) result[0];
        return finalResult;
    }
}