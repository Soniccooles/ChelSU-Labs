namespace RpnLogic
{
    class TokenCreator
    {
        public static List<Operation> _availableOperations = new List<Operation>()
        {
            new Plus(), new Minus(), new Divide(), new Multiply(), new Logarithm(), new Sin(), new Cos(), new Tg(), new Ctg(), new Exponentiation(), new Root(), new SquareRoot(), new LogarithmNatural()
        };
        public static Token Create(string str)
        {
            if (char.IsDigit(str.First()))
            {
                return new Number(str);
            }
            return CreateOperation(str);
        }
        public static Operation CreateOperation(string name)
        {
            return _availableOperations.FirstOrDefault(op => op.Name.Equals(name));
        }

    }
    public abstract class Token { }
    public class Number : Token
    {
        public float Value { get; }
        public Number (string str)
        {
            Value = (float.Parse(str));
        }
        public Number(float value)
        {
            Value = value;  
        }
        public static Number operator +(Number a, Number b)
        {
            return new Number(a.Value + b.Value);
        }
        public static Number operator -(Number a, Number b)
        {
            return new Number(a.Value - b.Value);
        }
        public static Number operator *(Number a, Number b)
        {
            return new Number(a.Value * b.Value);
        }
        public static Number operator /(Number a, Number b)
        {
            return new Number(a.Value / b.Value);
        }
        public override string ToString()
        {
            return "" + Value;
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
            float result = CalculateWithRPN(ToRPN(Parse(userInput, x)));
            return result;
        }
        public static List<Token> Parse(string input, string variable)
        {
            List<Token> tokenList = new List<Token>();

            input = (input.Replace("x", '(' + variable + ')').Replace("-(", "-1*(") + ' ').Replace(".", ",");
            string number = "";
            for (int i = 0; i < input.Length; i++)
            {
                
                if ((char.IsDigit(input[i]) || input[i] == ',')) 
                {
                    number += input[i];

                    continue;
                }
                else if (!string.IsNullOrEmpty(number))
                {
                    tokenList.Add(new Number(float.Parse(number)));
                    number = "";
                }
                if (!char.IsDigit(input[i]) && (i != input.Length-1) && input[i] != ';')
                {
                    string function = string.Empty;
                    if ((input[i] == '-' && i == 0 && char.IsDigit(input[i+1])) || (input[i] == '-' && input[i - 1] == '('))
                    {
                        number += input[i];
                        continue;
                    }
                    if (input[i] == '(' || input[i] == ')') 
                    {
                        tokenList.Add(new Parenthesis(input[i]));
                        continue;
                    }
                    string rest = string.Empty;
                    for (int j = i; j < input.Length; j++)
                    {
                        rest += input[j];
                    }
                    foreach (Operation op in TokenCreator._availableOperations)
                    {
                        if (op.Name == rest.Substring(0, op.Name.Length))
                        {
                            function += op.Name;
                            i += op.Name.Length - 1;
                            break;
                        }
                    }
                    tokenList.Add(TokenCreator.Create(function));
                    continue;
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
                           (stack.Peek() as Operation).Priority >= (token as Operation).Priority)
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
            Stack<Number> stack = new Stack<Number>();

            foreach (var token in rpn)
            {
                if (token is Number)
                {   
                    stack.Push((Number)token);
                }
                else if (token is Operation)
                {
                    Operation op = (token as Operation);
                    Number[] args = new Number[op.ArgsCount];
                    for (int i = 0; i < op.ArgsCount; i++)
                    {
                        args[i] = stack.Pop();
                    }
                    Number intermediateResult = op.Execute(args);
                    stack.Push(intermediateResult);
                }
            }
            return stack.Peek().Value;
        }
    }
}