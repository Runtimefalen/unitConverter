using System;
namespace Units
{
    public class UnitsExtensions
    {
        static void Main()
        {
            Dictionary <(string, char),(string, double)> coefficient = new Dictionary<(string, char),(string, double)>()
            {
                { ("km",'*'),("miles", 1.609344) },
                { ("c",'+'),("fahrenheit degree", 273.15) },
                { ("l",'*'),("galons", 0.264172) }
            };

            Console.WriteLine("Enter values: ");
            var userInput = Console.ReadLine();

            var inputArr = SplitValue(userInput);

            var valueInput = inputArr.Item1;
            var keyInput = inputArr.Item2;
            
            foreach (var unit in coefficient)
            {
                if (unit.Key.Item1 == keyInput)
                {
                    var operatorMath = unit.Key.Item2;
                    var resultVal = Foo(operatorMath, unit.Value.Item2, valueInput);
                   
                    Console.WriteLine($"{valueInput} {keyInput} is {resultVal} {unit.Value.Item1}");
                }
            }
        }

        public static double Foo(char operatorM, double valueUnitI2, double valueInput)
        {
            var result = 0.0;
            switch (operatorM)
            {
                case '+':
                    result = valueUnitI2 + valueInput;
                    break;
                case '-':
                    result = valueUnitI2 - valueInput;
                    break;
                case '*':
                    result = valueUnitI2 * valueInput;
                    break;
                case '/':
                    result = valueUnitI2 / valueInput;
                    break;
            }
            return result;
        }
        public static (double, string) SplitValue(string w)
        {
            string[] inputArray = w.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            var value = Double.Parse(inputArray[0]);
            var key = inputArray[1];
            return (value, key);
        }
    }
}
