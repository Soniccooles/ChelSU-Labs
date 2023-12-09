namespace AnotherCalculator
{
    internal class Calculator
    {
        public static void Main(string[] args)
        {
            string result;
            Console.WriteLine("Enter the number that indicates the operation you need. NS - Numeral System."
                + "\n" + "1 - Convert from any NS to any other"
                + "\n" + "2 - Addition, subtraction, multiplication of numbers in the specified NS"
                + "\n" + "3 - Convert an integer number to the Roman NS");
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
        public static string Transfer()
        {
            string alphabet = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMN";
            Console.WriteLine("Enter the number, its NS and the NS to which you want to translate this number separated by a space." +
"\n Available NS: from 2 to 50. NS - Numeral System.");

            string input = Console.ReadLine();
            string[] newInput = input.Split(" "); // разделил ввод на 3 строки и записал их в массив
            if (newInput.Length != 3) 
            {
                return "Вы ввели не 3 значения. ";
            }
            if (!int.TryParse(newInput[2], out int result))
            {
                return "The number system to be converted to is incorrectly entered.";
            }
            bool isCorrect = CheckSystem(newInput[0], newInput[1]);
            if (isCorrect) // Если число и система корректны, то просто переводим число из его СС в десятичную. А из десятичной в нужную
            {
                char[] digits = new char[newInput[0].Length];
                for (int i = 0; i < newInput[0].Length; i++)
                {
                    digits[i] = newInput[0][i];
                }
                int j = 0;
                int decimalNumber = 0;
                for (int index = digits.Length - 1; index >= 0; index--)
                {
                    Console.WriteLine($"{alphabet.IndexOf(digits[index])}" + " умножить на " + $"{Math.Pow(Convert.ToInt32(newInput[1]), j)}");
                    int temp = (int) (alphabet.IndexOf(digits[index]) * Math.Pow(Convert.ToInt32(newInput[1]), j));
                    decimalNumber += temp;
                    j++;
                }
                if (newInput[2] == "10")
                {
                    return Convert.ToString(decimalNumber);
                }
                else
                {
                    string numInOtherNS = "";
                    while (decimalNumber > 0) 
                    {
                        int secondSS = Convert.ToInt32(newInput[2]);
                        int ostatok = decimalNumber % secondSS;
                        decimalNumber = decimalNumber / secondSS;
                        numInOtherNS += ostatok;
                    }
                    string temp = "";
                    for (int i = numInOtherNS.Length-1; i >= 0; i--)
                    {
                        temp += numInOtherNS[i];
                    }
                    return temp;
                }
            }
            else
            {
                return ("Incorrect input. Number " + $"{newInput[0]}" + " cannot be written to " + $"{newInput[1]}" + " NS");
            }
        }

        public static string Operate()
        {
            Console.WriteLine("Enter two numbers in one NS");
            string input = Console.ReadLine();
            string[] newInput = input.Split(" ");
            if (newInput .Length != 4)
            {
                return "Incorrect Input";
            }
            if (!int.TryParse(newInput[3], out int result))
            {
                return "The number system to be converted to is incorrectly entered.";
            }
            bool firstCheck = CheckSystem(newInput[0], newInput[1]);
            bool secondCheck = CheckSystem(newInput[2], newInput[3]);
            if ((firstCheck && secondCheck) && (newInput[1] == newInput[3]))
            {
                return "Correct.";
            }
            return "Incorrect input.";
        }
        public static string RomanTransfer()
        {
            Console.WriteLine("Enter the integer you want to convert to Roman NS");
            string input = Console.ReadLine();
            return "Incorrect input.";
        }
        public static bool CheckSystem(string num, string numeralSystem)
        {
            if (!int.TryParse(numeralSystem, out int ok))
            {
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
            return false;   
        }
    }
}