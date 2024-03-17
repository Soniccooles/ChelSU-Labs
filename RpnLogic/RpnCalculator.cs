﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace RpnLogic
{
    public abstract class Token
    {

    }

    class Number : Token
    {
        public float Value { get; }

        public Number(float value)
        {
            Value = value;
        }
        public override string ToString()
        {
            return "" + Value;
        }

    }

    class Operation : Token
    {
        public char Operator { get; }

        public Operation(char op)
        {
            Operator = op;
        }
        public override string ToString()
        {
            return "" + Operator;
        }
    }

    class Parenthesis : Token
    {
        public char ParenthesisType { get; }

        public Parenthesis(char type)
        {
            ParenthesisType = type;
        }
        public override string ToString()
        {
            return "" + ParenthesisType;
        }
    }

    public class RpnCalculator
    {
        public static float CalculateExpression(string userInput, string x)
        {
            string variable = x;
            float result = CalculateWithRPN(ToRPN(Parse(userInput, variable)));
            return result;
        }
        public static List<Token> Parse(string input, string variable)
        { 
            List<Token> tokenList = new List<Token>();
            string newInput = input.Replace("x", variable) + ' ';
            string number = "";
            for (int i = 0; i < newInput.Length;  i++)
            {
                if (char.IsDigit(newInput[i]) || newInput[i] == '.')
                {
                    number += newInput[i];
                    continue;
                }
                else if (!string.IsNullOrEmpty(number))
                {
                    tokenList.Add(new Number(float.Parse(number)));
                    number = "";
                }

                if (newInput[i] == '*' || newInput[i] == '/' || newInput[i] == '+' || newInput[i] == '-')
                {
                    tokenList.Add(new Operation(newInput[i]));
                    continue;
                }

                if (newInput[i] == '(' || newInput[i] == ')')
                {
                    tokenList.Add(new Parenthesis(newInput[i]));
                }
            }
            return tokenList;
        }

        public static List<Token> ToRPN(List<Token> input)
        {
            List<Token> result = new List<Token>();
            Stack<Token> stack = new Stack<Token>();

            foreach (var token in input)
            {
                if (token is Number)
                {
                    result.Add(token);
                }
                else if (token is Operation)
                {
                    while (stack.Count > 0 && stack.Peek() is Operation &&
                           GetPriority((stack.Peek() as Operation).Operator) >= GetPriority((token as Operation).Operator))
                    {
                        result.Add(stack.Pop());
                    }
                    stack.Push(token);
                }
                else if (token is Parenthesis)
                {
                    if ((token as Parenthesis).ParenthesisType == '(')
                    {
                        stack.Push(token);
                    }
                    else if ((token as Parenthesis).ParenthesisType == ')')
                    {
                        while (stack.Count > 0 && !(stack.Peek() is Parenthesis))
                        {
                            result.Add(stack.Pop());
                        }
                        stack.Pop();
                    }
                }
            }

            while (stack.Count > 0)
            {
                if (stack.Peek() is Parenthesis)
                {
                    throw new Exception("Invalid expression: mismatched parentheses");
                }

                result.Add(stack.Pop());
            }

            return result;
        }

        public static float CalculateWithRPN(List<Token> rpn)
        {
            Stack<float> stack = new Stack<float>();

            foreach (var token in rpn)
            {
                if (token is Number)
                {
                    stack.Push((token as Number).Value);
                }
                else if (token is Operation)
                {
                    float num2 = stack.Pop();
                    float num1 = stack.Pop();
                    char op = (token as Operation).Operator;
                    float intermediateResult = Calculate(op, num1, num2);
                    stack.Push(intermediateResult);
                }
            }
            return stack.Peek();
        }

        private static float Calculate(char op, float num1, float num2)
        {
            switch (op)
            {
                case '+': return num1 + num2;
                case '-': return num1 - num2;
                case '*': return num1 * num2;
                case '/': return num1 / num2;
                default: throw new Exception("Unknown operation");
            }
        }

        private static int GetPriority(char op)
        {
            if (op == '*' || op == '/')
                return 2;
            if (op == '+' || op == '-')
                return 1;
            return 0;
        }
    }
}