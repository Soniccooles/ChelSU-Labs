namespace RpnLogic
{
    abstract class Operation : Token
    {
        public abstract string Name { get; }
        public abstract int Priority { get; }
        public abstract int ArgsCount { get; }
        public abstract Number Execute(params Number[] numbers);
        public override string ToString()
        {
            return Name;
        }
    }
    class Plus : Operation
    {
        public override string Name => "+";
        public override int Priority => 1;
        public override int ArgsCount => 2;
        public override Number Execute(params Number[] numbers)
        {
            var num1 = numbers[0];
            var num2 = numbers[1];
            return num1 + num2;
        }
    }
    class Minus : Operation
    {
        public override string Name => "-";
        public override int Priority => 1;
        public override int ArgsCount => 2;
        public override Number Execute(params Number[] numbers)
        {
            var num1 = numbers[0];
            var num2 = numbers[1];
            return num1 - num2;
        }
    }
    class Divide : Operation
    {
        public override string Name => "/";
        public override int Priority => 2;
        public override int ArgsCount => 2;
        public override Number Execute(params Number[] numbers)
        {
            var num1 = numbers[0];
            var num2 = numbers[1];
            return num1 / num2;
        }
    }
    class Multiply : Operation
    {
        public override string Name => "*";
        public override int Priority => 2;
        public override int ArgsCount => 2;
        public override Number Execute(params Number[] numbers)
        {
            var num1 = numbers[0];
            var num2 = numbers[1];
            return num1 * num2;
        }
    }
    class Logarithm : Operation
    {
        public override string Name => "log";
        public override int Priority => 3;
        public override int ArgsCount => 2;
        public override Number Execute(params Number[] numbers)
        {
            Number num1 = numbers[0];
            Number num2 = numbers[1];
            return new Number(Math.Log(num1.Value, num2.Value).ToString());
        }
    }
    class Sin : Operation
    {
        public override string Name => "sin";
        public override int Priority => 4;
        public override int ArgsCount => 1;
        public override Number Execute(params Number[] numbers)
        {
            Number num1 = numbers[0];
            return new Number(Math.Sin(num1.Value).ToString());
        }
    }
    class Cos : Operation
    {
        public override string Name => "cos";
        public override int Priority => 4;
        public override int ArgsCount => 1;
        public override Number Execute(params Number[] numbers)
        {
            Number num1 = numbers[0];
            return new Number(Math.Cos(num1.Value).ToString());
        }
    }
    class Tg : Operation
    {
        public override string Name => "tan";
        public override int Priority => 4;
        public override int ArgsCount => 1;
        public override Number Execute(params Number[] numbers)
        {
            Number num1 = numbers[0];
            return new Number(Math.Tan(num1.Value).ToString());
        }
    }
    class Ctg : Operation
    {
        public override string Name => "ctg";
        public override int Priority => 4;
        public override int ArgsCount => 1;
        public override Number Execute(params Number[] numbers)
        {
            Number num1 = numbers[0];
            return new Number((1/Math.Tan(num1.Value)).ToString());
        }
    }
    class Exponentiation : Operation
    {
        public override string Name => "^";
        public override int Priority => 3;
        public override int ArgsCount => 2;
        public override Number Execute(params Number[] numbers)
        {
            Number num1 = numbers[0];
            Number num2 = numbers[1];
            return new Number(Math.Pow(num2.Value, num1.Value).ToString());
        }
    }
    class SquareRoot : Operation
    {
        public override string Name => "sqrt";
        public override int Priority => 3;
        public override int ArgsCount => 1;
        public override Number Execute(params Number[] numbers)
        {
            Number num1 = numbers[0];
            return new Number(Math.Sqrt(num1.Value).ToString());
        }
    }

    class Root : Operation
    {
        public override string Name => "rt";
        public override int Priority => 3;
        public override int ArgsCount => 2;
        public override Number Execute(params Number[] numbers)
        {
            Number num1 = numbers[0];
            Number num2 = numbers[1];
            return new Number(Math.Pow(num1.Value, 1/num2.Value).ToString());
        }
    }
    class LogarithmNatural : Operation
    {
        public override string Name => "ln";
        public override int Priority => 4;
        public override int ArgsCount => 1;
        public override Number Execute(params Number[] numbers)
        {
            Number num1 = numbers[0];
            return new Number(Math.Log(num1.Value).ToString());
        }
    }
}
