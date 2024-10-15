using System;
using System.Globalization;

namespace Aplikacja1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Uncomment only one line to run specified task.

            //Program.Task1();
            //Program.Task2();
            //Program.Task3();
            //Program.Task4();
            //Program.Task5();
            //Program.Task6();
            //Program.Task7();
            //Program.Task8();

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        static void Task1()
        {
            Console.WriteLine("Hello, World!");
            Console.ReadKey();
        }

        static void Task2()
        {
            // Print sum of two numbers
            int number1 = 1;
            int number2 = 2;
            Console.WriteLine($"Sum of two numbers: {number1 + number2}");

            // Print result of division of two numbers
            int number3 = 5;
            int number4 = 3;
            Console.WriteLine($"Sum of two numbers: {(double)number3 / number4}");

            // Arithmetic operations
            Console.WriteLine($"-1 + 4 * 6 = {-1 + 4 * 6}");
            Console.WriteLine($"(35 + 5) % 7 = {(35 + 5) % 7}");
            Console.WriteLine($"14 + -4 * 6/11 = {14 + -4 * 6 / 11}");
            Console.WriteLine($"2 + 15/6 * 1 - 7 % 2 = {2 + 15 / 6 * 1 - 7 % 2}");

        }

        static void Task3()
        {
            Console.WriteLine("Enter first number: ");
            int first_number = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter second number: ");
            int second_number = int.Parse(Console.ReadLine());

            Console.WriteLine($"Second number: {second_number}.\tFirst number: {first_number}.");
        }

        static void Task4()
        {
            Console.WriteLine("Enter first number: ");
            int first_number = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter second number: ");
            int second_number = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter third number: ");
            int third_number = int.Parse(Console.ReadLine());
            Console.WriteLine($"Product of three numbers in reverse order: {third_number} * {second_number} * {first_number} = {third_number * second_number * first_number}");
        }

        static void Task5()
        {
            Console.WriteLine("Enter number to print a rectangle: ");
            int number = int.Parse(Console.ReadLine());
            int width = 4;
            int height = 6;

            for (int h = 0; h < height; h++)
            {
                Console.WriteLine();
                for (int w = 0; w < width; w++)
                {
                    if (h == 0 || h == height - 1 || w == 0 || w == width - 1)
                    {
                        Console.Write(number);
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
            }
        }

        static void Task6()
        {
            int ii = 75400;
            double id = 7.54;

            string s = string.Format("Wartość int to {0}, a wartość double to {1}", ii, id);
            Console.WriteLine(s);

            string s2 = "Wartość int to " + ii.ToString() + ", a wartość double to " + id.ToString();
            Console.WriteLine(s2);

            string s3 = "Wartość int to " + ii + ", a wartość double to " + id;
            Console.WriteLine(s3);

            Console.WriteLine("=================");
            //format string with right alignment for a total width of 40 characters
            string format1 = "---{0,40}---";
            //format string with left alignment for a total width of 40 characters
            string format2 = "---{0,-40}---";
            Console.WriteLine(string.Format(format1, ii));
            Console.WriteLine(string.Format(format2, ii));
            Console.WriteLine(string.Format(format1, id));
            Console.WriteLine(string.Format(format2, id));

            Console.WriteLine("=================");
            int ii2 = 57300;
            double id2 = 5.73;
            //Currency format specifier
            Console.WriteLine($"int: {ii2:c}, double: {id2:c}");
            //Decimal format specifier
            Console.WriteLine($"int: {ii2:d}");
            //Exponential format specifier
            Console.WriteLine($"int: {ii2:e}, double: {id2:e}");
            //Fixed-point format specifier
            Console.WriteLine($"int: {ii2:f}, double: {id2:f}");
            //The 'o' specifier does not exist, so it's commented out
            //Console.WriteLine($"int: {ii2:o}, double: {id2:o}"); // This causes an error
            //Hexadecimal format specifier
            Console.WriteLine($"int: {ii2:x}");

            Console.WriteLine("=================");
            float flo = 220.022f;
            //float with exactly 5 decimal places, rounding if necessary
            Console.WriteLine($"Format: {{0.00000}} - Value: {flo:0.00000}");
            // pattern with square brackets 
            Console.WriteLine($"Format: {{[#].(#)(##)}} - Value: {flo:[#].(#)(##)}");
            //float with 1 decimal place, rounding if necessary
            Console.WriteLine($"Format: {{0.0}} - Value: {flo:0.0}");
            //float with a thousands separator and 0 decimal places
            Console.WriteLine($"Format: {{0,0}} - Value: {flo:0,0}");
            //float with a thousands separator
            Console.WriteLine($"Format: {{,.}} - Value: {flo:,.}");
            //float as a percentage
            Console.WriteLine($"Format: {{0%}} - Value: {flo:0%}");
            //float in scientific notation with one decimal place
            Console.WriteLine($"Format: {{0e+0}} - Value: {flo:0e+0}");

            Console.WriteLine("=================");
            double first = 123.4;
            double second = -1234;
            double third = 0;
            string format = "{0:#,##0.0;(#,##)Minus;Zero}";
            Console.WriteLine(string.Format(format, first));
            Console.WriteLine(string.Format(format, second));
            Console.WriteLine(string.Format(format, third));

            Console.WriteLine("=================");
            DateTime d = System.DateTime.Now;
            Console.WriteLine($"{d:d}");
            Console.WriteLine($"{d:D}");
            Console.WriteLine($"{d:t}");
            Console.WriteLine($"{d:T}");
            Console.WriteLine($"{d:f}");
            Console.WriteLine($"{d:F}");
            Console.WriteLine($"{d:g}");
            Console.WriteLine($"{d:G}");
            Console.WriteLine($"{d:M}");
            Console.WriteLine($"{d:r}");
            Console.WriteLine($"{d:s}");
            Console.WriteLine($"{d:u}");
            Console.WriteLine($"{d:U}");
            Console.WriteLine($"{d:Y}");
        }

        static void Task7()
        {
            Console.WriteLine("Enter temperature in Celsius degrees:");
            // CultureInfo.InvariantCulture to ensure that decimal separator is recognized
            double C = Double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            double K = C + 273;
            double F = C * 18 / 10 + 32;

            Console.WriteLine($"Kelvin: {K}\tFahrenheit: {F}");
        }

        static void Task8()
        {
            Console.WriteLine(((int.TryParse(Console.ReadLine(), out int first)) && (int.TryParse(Console.ReadLine(), out int second))) && ((first * second < 0)));
        }
    }
}