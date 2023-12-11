
using System.Globalization;
using System.Runtime.InteropServices.Marshalling;

namespace AnotherCalculator
{
    internal class Calculator
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                string result;
                Console.WriteLine("Введите число, обозначающее нужную вам операцию. СС - Система счисления."
                + "\n" + "1 - Преобразование из любой СС в любую другую"
                + "\n" + "2 - Сложение, вычитание, умножение чисел в указанной СС"
                + "\n" + "3 - Преобразовать целое число в римскую цифру СС");
                string firstInput = Console.ReadLine().Replace(" ", "");
                result = "Incorrect input. Enter 1, 2 or 3";
                if (firstInput == "1")
                {
                    result = Transfer();
                }
                if (firstInput == "2")
                {
                    result = Operate();
                }
                if (firstInput == "3")
                {
                    result = RomanTransfer();
                }
                Console.WriteLine(result);
            }
        }
        public static string Transfer() // Метод для перевода из любой СС в любую
        {
            string alphabet = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMN";
            Console.WriteLine("Введите число, это NS, и NS, в которое вы хотите перевести это число, разделенное пробелом." +
            "\n Доступные NS: от 2 до 50. NS - Система счисления.");

            string input = Console.ReadLine();
            string[] newInput = input.Split(" "); // разделил ввод на 3 строки и записал их в массив
            if (newInput.Length != 3)
            {
                return "Вы ввели не 3 значения. ";
            }
            if (!int.TryParse(newInput[2], out int result))
            {
                return "Система счисления должна состоять из цифр.";
            }
            bool isCorrect = CheckSystem(newInput[0], newInput[1]);
            if (isCorrect) // Если число и система корректны, то просто переводим число из его СС в десятичную. А из десятичной в нужную
            {
                if (newInput[1] == newInput[2])
                {
                    return newInput[0];
                }
                char[] digits = new char[newInput[0].Length];
                for (int i = 0; i < newInput[0].Length; i++)
                {
                    digits[i] = newInput[0][i];
                }
                int[] order = new int[digits.Length];

                int k = digits.Length - 1;
                for (int i = 0; i < digits.Length; i++)
                {
                    order[i] = k;
                    k--;
                }
                int j = 0;
                int decimalNumber = 0;
                string forUser = "0";
                if (newInput[1] != "10")
                {
                    Console.WriteLine("Так как " + newInput[0] + " не находится в десятичной СС, мы его переведем туда");
                    Console.WriteLine("Перевод в десятичную осуществляется так: " + "\n" +
                    "Берем цифру, а затем умножаем на СС из которой переводим в степени " +
                    "индекса этого числа и после нахождения всех произведений делаем сложение.");
                    Console.WriteLine("индексы цифр: " + string.Join(" ", order) + "\n" + "сами цифры:   " + string.Join(" ", digits));
                    for (int index = digits.Length - 1; index >= 0; index--)
                    {
                        
                        int temp = (int)(alphabet.IndexOf(digits[index]) * Math.Pow(Convert.ToInt32(newInput[1]), j));
                        Console.WriteLine($"{alphabet.IndexOf(digits[index])}" + "*" + $"{Convert.ToInt32(newInput[1])}" + "^" + j + " = " + $"{temp}");
                        decimalNumber += temp;
                        forUser += "+";
                        forUser += $"{temp}";
                        j++;
                    }
                    Console.WriteLine(forUser + " = " + decimalNumber);
                }
                if (newInput[1] == "10")
                {
                    decimalNumber = Convert.ToInt32(newInput[0]);
                }

                if (newInput[2] == "10")
                {
                    Console.WriteLine("Результат является десятичной записью исходного числа.");
                    return Convert.ToString(decimalNumber);
                }
                else
                {
                    Console.WriteLine("Сейчас мы переведем из десятичной в " + $"{newInput[2]}" + " CC" + "\n" + "Десятичное число: " + $"{decimalNumber}" + "\n"
                        + "Чтобы перевести из десятичной СС, нужно десятичное число делить на СС, в которую нужно перевести. "
                        + "То есть делить " + $"{decimalNumber}" + " на " + $"{newInput[2]}");
                    string numInOtherNS = "";
                    Console.WriteLine("Когда число станет меньше делителя, записываем результат в виде обратной последовательности остатков");
                    while (decimalNumber > 0)
                    {
                        int secondSS = Convert.ToInt32(newInput[2]);
                        int ostatok = decimalNumber % secondSS;
                        Console.WriteLine("Целая часть числа " + $"{decimalNumber} = " + $"{decimalNumber}/{secondSS}"
                            + " = " + decimalNumber/secondSS);
                        Console.WriteLine("остаток: " + $"{ostatok}");
                        decimalNumber = decimalNumber / secondSS;
                        numInOtherNS += ostatok;
                    }
                    Console.WriteLine("Запишем остатки в обратном порядке");
                    string temp = "";
                    for (int i = numInOtherNS.Length - 1; i >= 0; i--)
                    {
                        temp += numInOtherNS[i];
                    }
                    return "Ответ " + temp;
                }
            }
            else
            {
                return ("Попробуйте снова");
            }
        }
        public static string RomanTransfer() // Общий метод перевода римской
        {
            Dictionary<string, int> Roman = new Dictionary<string, int>
            {
                { "|M|", 1000000 }, { "|CM|", 900000 }, { "|D|", 500000 }, { "|CD|", 400000 }, { "|C|", 100000 },
                { "|XC|", 90000 }, { "|L|", 50000 }, { "|XL|", 40000 }, { "|X|", 10000 }, { "|IX|", 9000 }, { "|V|", 5000 },
                { "|IV|", 4000}, { "M", 1000 }, { "CM", 900 }, { "D", 500 }, { "CD", 400 }, { "C", 100 },
                { "XC", 90 }, { "L", 50 }, { "XL", 40 }, { "X", 10 }, { "IX", 9 }, { "V", 5 }, { "IV", 4 }, { "I", 1 }
            };
            Console.WriteLine("Введите целое число или число в римской СС.");
            string input = Console.ReadLine();
            string[] newInput = input.Split(' ');
            if (input.Length == 0)
            {
                return "Неверный ввод. Вы ничего не ввели!";
            }
            if (newInput.Length == 1)
            {
                if (int.TryParse(newInput[0], out int result))
                {
                    return ToRoman(result);
                }
                
                else
                {
                    bool isValid = IsRomanNumeralValid(newInput[0]); // Отправляем ввод на проверку правильности
                    if (isValid)
                    {
                        return FromRoman(newInput[0]);
                    }
                    else
                    {
                        return "Неверный ввод. Соблюдайте правила написания римского числа!";
                    }
                }
            }

            return "Неверный ввод. Введите римское число или число в десятичной системе и ничего более!";
        }
        public static bool IsRomanNumeralValid(string input) // Проверка римского числа по правилам написания
        {
            // Проверка на корректность символов
            foreach (char c in input)
            {
                if (!"IVXLCDM".Contains(c))
                {
                    return false;
                }
            }

            // Проверка на корректное расположение символов
            for (int i = 0; i < input.Length - 3; i++)
            {
                if (input[i] == input[i + 1] && input[i] == input[i + 2] && input[i] == input[i + 3])
                {
                    // Более трех одинаковых символов подряд
                    return false;
                }
            }

            return true;
        }
        public static string ToRoman(int input)
        {
            if (input < 1)
            {
                return "Неверный ввод. Число должно быть больше 1!";
            }

            Dictionary<int, string> Roman = new Dictionary<int, string>
            {
                { 1000000, "|M|" }, { 900000, "|CM|" }, { 500000, "|D|" }, { 400000, "|CD|" }, { 100000, "|C|" },
                { 90000, "|XC|" }, { 50000, "|L|" }, { 40000, "|XL|" }, { 10000, "|X|" }, { 9000, "|IX|" }, { 5000, "|V|" },
                { 4000, "|IV|" }, { 1000, "M" }, { 900, "CM" }, { 500, "D" }, { 400, "CD" }, { 100, "C" },
                { 90, "XC" }, { 50, "L" }, { 40, "XL" }, { 10, "X" }, { 9, "IX" }, { 5, "V" }, { 4, "IV" }, { 1, "I" }
            };

            string romanNumber = "";

            while (input > 0)
            {
                foreach (var keyAndValue in Roman)
                {
                    int value = keyAndValue.Key;
                    string symbol = keyAndValue.Value;

                    if (input >= value)
                    {
                        Console.WriteLine("Так как " + input + " >= " + value + $", то мы записываем рискую цифру {symbol} в результат," +
                            $" а из {input} вычитаем десятичноен значение цифры {symbol}, которое равно {value}");
                        romanNumber += symbol;
                        input -= value;
                        Console.WriteLine("Исходное число: " + romanNumber);
                        break;
                    }
                }
            }

            return romanNumber;
        }
        public static string FromRoman(string input)
        {
            Dictionary<char, int> Roman = new Dictionary<char, int>
            {
                {'M', 1000}, {'D', 500}, {'C', 100}, {'L', 50}, {'X', 10}, {'V', 5}, {'I', 1}
            };

            int result = 0;
            int prevValue = 0;

            for (int i = input.Length - 1; i >= 0; i--)
            {
                int value = Roman[input[i]];

                if (value < prevValue)
                {
                    Console.WriteLine("Так как " + value + " < " + prevValue + $", то мы вычитаем из исходного числа {value}");
                    result -= value;
                    Console.WriteLine("Исходное число: " + result);
                }
                else
                {
                    Console.WriteLine("Так как " + value + " >= " + prevValue + $", то мы прибавляем к нашему исходному числу {value}");
                    result += value;
                    Console.WriteLine("Исходное число: " + result);
                }

                prevValue = value;
            }

            return Convert.ToString(result);
        }
        public static bool CheckSystem(string num, string numeralSystem) // Проверка числа и его СС
        {
            if (!int.TryParse(numeralSystem, out int ok)) 
            {
                return false;
            }
            if (Convert.ToInt32(numeralSystem) > 50 || Convert.ToInt32(numeralSystem) < 2)
            {
                Console.WriteLine("Диапазон СС от 2 до 50. " +  numeralSystem + " неверная СС!");
                return false;
            }


            int maxNum = 0;
            string alphabet = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMN";
            foreach (char c in num)
            {
                if (alphabet.Contains(c)) // если в алфавите есть символ из 1-го числа
                {
                    int temp = alphabet.IndexOf(c) + 1;
                    if (temp > maxNum)
                    {
                        maxNum = temp;
                    }
                }
                else
                {
                    return false;
                }
            }
            if (maxNum <= Convert.ToInt32(numeralSystem))
            {
                return true;
            }
            Console.WriteLine("Неверная СС у числа.");
            return false;
        }
        public static string Operate()
        {
            Console.WriteLine("Введите два числа в одной СС");
            string input = Console.ReadLine();
            string[] newInput = input.Split(" ");
            if (newInput.Length != 4)
            {
                return $"Введите 4 числа, а не {newInput.Length}";
            }
            if (!int.TryParse(newInput[3], out int result))
            {
                return "Система должна быть числом, а не цифрой.";
            }
            bool firstCheck = CheckSystem(newInput[0], newInput[1]);
            bool secondCheck = CheckSystem(newInput[2], newInput[3]);
            if ((firstCheck && secondCheck) && (newInput[1] == newInput[3]))
            {
                int decimalFirstNumber = Convert.ToInt32(newInput[0], Convert.ToInt32(newInput[1]));
                int decimalSecondNumber = Convert.ToInt32(newInput[2], Convert.ToInt32(newInput[3]));
                return Convert.ToString(decimalFirstNumber + decimalSecondNumber);
            }
            return "Неверный ввод.";
        }
    }
}