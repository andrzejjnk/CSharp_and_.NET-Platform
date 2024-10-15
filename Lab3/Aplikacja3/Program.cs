using System;
using System.Reflection;
using System.Threading.Tasks;


namespace Aplikacja3
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("1 - Ćwiczenie 1 Typy wartości – struktury I");
            Console.WriteLine("2 - Ćwiczenie 2 Typy wartości – struktury II");
            Console.WriteLine("3 - Ćwiczenie 3 Typy wartości");
            Console.WriteLine("4 - Ćwiczenie 4 Tryb wyliczeniowy - Enum");
            Console.WriteLine("5 - Ćwiczenie 5 Znaki");
            Console.WriteLine("6 - Ćwiczenie 6 Typ String");
            Console.WriteLine("7 - Ćwiczenie 7 Przepełnienie");
            Console.WriteLine("8 - Ćwiczenie 8 Typy wartości i typy odwołań");
            Console.WriteLine("9 - Ćwiczenie 9 Prosty kalkulator");
            Console.WriteLine("10 - Ćwiczenie 10 Konwersja danych");
            Console.WriteLine("Type 'exit' to quit the program.\n");

            while (true)
            {
                Console.WriteLine("Select a task to run (1-10):");
                string input = Console.ReadLine();

                if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                if (int.TryParse(input, out int taskNumber))
                {
                    switch (taskNumber)
                    {
                        case 1:
                            Program.Task1();
                            break;
                        case 2:
                            Program.Task2();
                            break;
                        case 3:
                            Program.Task3();
                            break;
                        case 4:
                            Console.WriteLine("Select a sub-task for Task 4 (1 or 2):");
                            string subTaskInput = Console.ReadLine();
                            if (subTaskInput == "1")
                            {
                                Program.Task4_1();
                            }
                            else if (subTaskInput == "2")
                            {
                                Program.Task4_2();
                            }
                            else
                            {
                                Console.WriteLine("Invalid sub-task selection.");
                            }
                            break;
                        case 5:
                            Program.Task5();
                            break;
                        case 6:
                            Program.Task6();
                            break;
                        case 7:
                            Program.Task7();
                            break;
                        case 8:
                            Console.WriteLine("Select a sub-task for Task 8 (1 or 2):");
                            string subTask8Input = Console.ReadLine();
                            if (subTask8Input == "1")
                            {
                                Program.Task8_1();
                            }
                            else if (subTask8Input == "2")
                            {
                                Program.Task8_2();
                            }
                            else
                            {
                                Console.WriteLine("Invalid sub-task selection.");
                            }
                            break;
                        case 9:
                            Program.Task9();
                            break;
                        case 10:
                            Program.Task10();
                            break;
                        default:
                            Console.WriteLine("Invalid task number. Please select from 1 to 10.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a task number or 'exit' to quit.");
                }
            }
        }

        static void Task1()
        {
            Point2D[] points = new Point2D[5];

            for(int index = 0; index < 4; index++)
            {
                Console.WriteLine($"Enter coordinates for point {index + 1} (x, y)");
                string[] input = Console.ReadLine().Split();
                double x = double.Parse(input[0]);
                double y = double.Parse(input[1]);
                points[index] = new Point2D(x, y);
            }

            const double radius = 3.0;
            bool is_point_inside_circle = false;
            while (!is_point_inside_circle)
            {
                Console.WriteLine("Enter coordinates for the fifth point (x,y): ");
                string[] input = Console.ReadLine().Split();
                double x = double.Parse(input[0]);
                double y = double.Parse(input[1]);

                if (x < 0 || y < 0)
                {
                    Console.WriteLine("Negative coordinates cannot be entered");
                    break;
                }
                else
                {
                    /* Do Nothing */
                }

                Point2D point5 = new Point2D(x, y);
                points[points.Length - 1] = point5;

                for (int index = 0; index < 4; index++)
                { 
                    double distance = points[index].Dist(point5);
                    if (distance < radius)
                    {
                        Console.WriteLine($"Point is placed inside the circle with center in ({points[index].X}, {points[index].Y}) with radius={radius}");
                        is_point_inside_circle = true;
                        break;
                    }
                    else
                    {
                        /* Do Nothing */
                    }
                }

                if (!is_point_inside_circle)
                {
                    Console.WriteLine($"Point ({point5.X} {point5.Y}) is not placed into any circle!");
                    double MinDistance = double.MaxValue;
                    for (int index = 0; index < 4; index++)
                    {
                        double distance = points[index].Dist(point5);
                        if (distance < MinDistance)
                        {
                            MinDistance = distance;
                        }
                        else
                        {
                            /* Do Nothing */
                        }
                    }
                    Console.WriteLine($"The closest point distance to point5 is equal to {MinDistance}");
                }



            }

            Console.WriteLine("Coordinates of all points: ");
            for (int index = 0; (index < points.Length); index++)
            {
                points[index].Print2DPoint();
            }
            
        }

        static void Task2()
        {
            /* 
                a) While using private coordinates without constructor, it is needed to initialize all variables before use.
                b) The new operator uses a default constructor and initializes all fiels to default values (0).
                c) It is not possible to create a default constructor (without parameters) in a structure.
                d) Since C# version 10.0, it is possible to initialie fields of a structure during their declaration.
            */
            Point2D_ab point = new Point2D_ab();
            Console.WriteLine(point.ToString());
            point.Print2DPoint();

            Point2D_d point_d = new Point2D_d();
            point_d.Print2DPoint();
        }

        static void Task3()
        {
            int string_count = 0;
            int int_count = 0;
            int float_count = 0;
            int int_value = 0;
            float float_value = 0;

            while (true)
            {
                Console.WriteLine("=======================");
                Console.WriteLine($"Values entered={int_count+float_count+string_count}: Int count={int_count}, float count={float_count}, string count={string_count}");
                Console.WriteLine("=======================");

                Console.WriteLine("Enter int/float/string value or -1 to exit!");
                string input = Console.ReadLine();
                if ("-1" == input)
                {
                    Console.WriteLine("Exiting!");
                    break;
                }

                if (int.TryParse(input, out int_value))
                {
                    int_count++;
                }
                else if (float.TryParse(input, out float_value))
                {
                    float_count++;
                }
                else if (!string.IsNullOrEmpty(input))
                {
                    string_count++;
                }
                else
                {
                    /* Do Nothing */
                }
            }
        }

        static void Task4_1()
        {
            Console.WriteLine("Enter a number of a day in the week: ");
            string input = Console.ReadLine();

            if(int.TryParse(input, out int day) && day >= 1 && day <= 7)
            {
                Console.WriteLine($"{(Days)day}");
            }
            else
            {
                Console.WriteLine("Please enter a number between 1 and 7!");
            }
        }

        static void Task4_2()
        {
            Console.WriteLine("Enter a number: ");
            string input = Console.ReadLine();
            Range size = Range.Small;

            if (int.TryParse(input, out int number))
            {
                if (number < 10)
                {
                    size = Range.Small;
                }
                else if (number >= 10 && number < 100 )
                {
                    size = Range.Medium;
                }
                else if (number >= 100)
                {
                    size = Range.Big;
                }
                else
                {
                    /* Do Nothing */
                }
                Console.WriteLine($"input number = {number} is {size}");
            }
            else
            {
                /* Do Nothing */
            }
        }

        static void Task5()
        {
            Console.WriteLine("Enter a key: ");
            char input = Console.ReadKey().KeyChar;
            Console.WriteLine();

            if (IsVovel(input))
            {
                Console.WriteLine("Entered character is a vovel!");
            }
            else if (char.IsDigit(input))
            {
                Console.WriteLine("Entered character is a digit!");
            }
            else
            {
                Console.WriteLine("Entered character is another character!");
            }
        }

        static bool IsVovel(char c)
        {
            char lower_char = char.ToLower(c);
            if (lower_char == 'a' ||
                lower_char == 'ą' ||
                lower_char == 'e' ||
                lower_char == 'ę' ||
                lower_char == 'i' ||
                lower_char == 'o' ||
                lower_char == 'u' ||
                lower_char == 'y'
                )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void Task6()
        {
            Console.WriteLine("Enter a string: ");
            string input = Console.ReadLine();

            string output = string.Join(" ", input.ToCharArray());
            Console.WriteLine($"Input: {input},\noutput={output}");
        }

        static void Task7()
        {
            /* This code gives this error:
            Błąd (aktywny)	CS0220	Operacja przepełnia się w czasie kompilowania w trybie sprawdzonym	Aplikacja3	C:\Users\Andrzej\Desktop\9 semestr\C# i platforma .NET\Lab3\Aplikacja3\Program.cs	260	
            */
            // Console.WriteLine(int.MaxValue + 1); //Error during compilation

            // overflow during function execution
            try
            {
                checked
                {
                    int overflow = int.MaxValue;
                    Console.WriteLine($"before overflow++: {overflow}");
                    overflow++;
                    Console.WriteLine($"after: {overflow}");
                }
            }
            catch (OverflowException ex) 
            {
                Console.WriteLine($"{ex.Message}");
            }
        }

        static void Fun1(Point p)
        {
            p.x = 1;
            p.y = 2;
        }

        static void Fun2(Coords c)
        {
            c.x = 1;
            c.y = 2;
        }
        static void Task8_1()
        {
            Point p = new Point(5, 7);
            Coords c = new Coords(9, 3);

            Console.WriteLine("Before:");
            Console.WriteLine($"p=({p.x}, {p.y})");
            Console.WriteLine($"c=({c.x}, {c.y})");
            Fun1(p);
            Fun2(c);
            Console.WriteLine("After:");
            Console.WriteLine($"p=({p.x}, {p.y})");
            Console.WriteLine($"c=({c.x}, {c.y})");
            /* 
            When we pass Coords to the Fun2, a copy of the object is passed, so changes made in the Fun2 won't affect the original Coords object.
            In case of point being passed to the Fun1, a reference to the original object is passed, so changes made in the Fun1 wil affect on Point object.
            */

        }

        static void Task8_2()
        {
            Point p1 = new Point(3, 3);
            Point p2 = new Point(3, 3);
            Coords c1 = new Coords(3, 3);
            Coords c2 = new Coords(3, 3);
            /* a) */
            Console.WriteLine($"Cords Object.Equals(c1, c2): {Object.Equals(c1, c2)}");
            Console.WriteLine($"Points Object.Equals(p1, p2): {Object.Equals(p1, p2)}");
            /* b) */
            Console.WriteLine($"Coords c1.Equals(c2): {c1.Equals(c2)}");
            Console.WriteLine($"Coords c2.Equals(c1): {c2.Equals(c1)}");
            /* c) */
            Console.WriteLine($"Points p1.Equals(p2): {p1.Equals(p2)}");
            Console.WriteLine($"Points p2.Equals(p1): {p2.Equals(p1)}");
            /* d) */
            Console.WriteLine($"Cords Object.ReferenceEquals(c1, c2): {Object.ReferenceEquals(c1, c2)}");
            Console.WriteLine($"Cords Object.ReferenceEquals(c1, c1): {Object.ReferenceEquals(c1, c1)}");
            Console.WriteLine($"Cords Object.ReferenceEquals(c2, c2): {Object.ReferenceEquals(c2, c2)}");
            Console.WriteLine($"Points Object.ReferenceEquals(p1, p2): {Object.ReferenceEquals(p1, p2)}");
            Console.WriteLine($"Points Object.ReferenceEquals(p1, p1): {Object.ReferenceEquals(p1, p1)}");
            Console.WriteLine($"Points Object.ReferenceEquals(p2, p2): {Object.ReferenceEquals(p2, p2)}");
        }

        static void Task9()
        {
            Console.WriteLine("Enter a calculation (e.g. 12+2-3): ");
            Console.WriteLine("Allowed characters only 0-99, and '+' and '-'");
            string input = Console.ReadLine();
            int result = 0;
            int currentNumber = 0;
            char operation = '+';

            foreach (char c in input)
            {
                if (char.IsDigit(c))
                {
                    currentNumber = currentNumber * 10 + (c - '0');
                }
                else if (c == '+' || c == '-')
                {
                    if (currentNumber < 0 || currentNumber > 99)
                    {
                        Console.WriteLine("Error: 0-99 Numbers are only allowed!");
                        return;
                    }

                    if (operation == '+')
                    {
                        result += currentNumber;
                    }
                    else if (operation == '-')
                    {
                        result -= currentNumber;
                    }

                    currentNumber = 0;
                    operation = c;
                }
                else
                {
                    Console.WriteLine("Allowed characters only 0-99, and '+' and '-'");
                    return;
                }
            }

            if (currentNumber < 0 || currentNumber > 99)
            {
                Console.WriteLine("Error: 0-99 Numbers are only allowed!");
                return;
            }
            if (operation == '+')
            {
                result += currentNumber;
            }
            else if (operation == '-')
            {
                result -= currentNumber;
            }

            Console.WriteLine($"{input}={result}");
        }

        static void Task10()
        {
            /* Implicit conversion */
            /* int -> long */
            int int_var = 147;
            long long_var = int_var;
            Console.WriteLine($"Implicit Conversion: int {int_var} to long {long_var}");

            /* float -> double */
            float float_var = 14.70f;
            double double_var = float_var;
            Console.WriteLine($"Implicit Conversion: float {float_var} to double {double_var}");

            /* char -> int */
            char char_var = 'A';
            int int_var2 = char_var;
            Console.WriteLine($"Implicit Conversion: char '{char_var}' to int {int_var2} (ASCII value)");

            /* byte -> int */
            byte byte_var = 255;
            int int_var3 = byte_var;
            Console.WriteLine($"Implicit Conversion: byte {byte_var} to int {int_var3}");

            /* Explicit conversion */
            /* double -> int */
            double double_var_2 = 14.70;
            int int_var4 = (int)double_var_2;
            Console.WriteLine($"Explicit Conversion: double {double_var_2} to int {int_var4} (fractional part discarded)");

            /* long -> int */
            long long_var2 = 123456789;
            int int_var5 = (int)long_var2;
            Console.WriteLine($"Explicit Conversion: long {long_var2} to int {int_var5} (may lose data if value exceeds int range)");

            /* float -> int */
            float float_var2 = 12.99f;
            int int_var6 = (int)float_var2;
            Console.WriteLine($"Explicit Conversion: float {float_var2} to int {int_var6} (fractional part discarded)");

            /* string -> int */
            string string_var = "123";
            int int_var7 = int.Parse(string_var);
            Console.WriteLine($"Explicit Conversion: string '{string_var}' to int {int_var7}");
        }


    }

    public struct Point2D
    {
        public double X { get; private set; } = 0.0;
        public double Y { get; private set; } = 0.0;
        public Point2D(double x, double y)
        {
            X = x;
            Y = y;
        }

        public void Reset()
        {
            X = 0;
            Y = 0;
        }

        public void IncrX(double dx)
        {
            X += dx;
        }

        public void IncrY(double dy)
        {
            Y += dy;
        }

        public void Print2DPoint()
        {
            Console.WriteLine($"Point2D: X={X}, Y={Y}");
        }

        public double Dist(Point2D other)
        {
            double distance = 0.0;
            distance = Math.Sqrt(Math.Pow(X - other.X, 2) + Math.Pow(Y - other.Y, 2));
            return distance;
        }

    }

    public struct Point2D_ab
    {
        /* Private coordinates */
        private double X;
        private double Y;

        /* There is no constructor */

        public void Reset()
        {
            X = 0;
            Y = 0;
        }

        public void IncrX(double dx)
        {
            X += dx;
        }

        public void IncrY(double dy)
        {
            Y += dy;
        }

        public void Print2DPoint()
        {
            Console.WriteLine($"Point2D: X={X}, Y={Y}");
        }

        public double Dist(Point2D other)
        {
            double distance = 0.0;
            distance = Math.Sqrt(Math.Pow(X - other.X, 2) + Math.Pow(Y - other.Y, 2));
            return distance;
        }

    }

    public struct Point2D_c
    {
        /* Private coordinates */
        private double X;
        private double Y;

        /* There is constructor without parameters*/

        /* 
         Error:
        Błąd (aktywny)	CS0542	„Point2D_c”: nazwy składowych nie mogą być takie same jak nazwa zawierającego je typu	Aplikacja3	C:\Users\Andrzej\Desktop\9 semestr\C# i platforma .NET\Lab3\Aplikacja3\Program.cs	92	

        ale nie można definiować dodatkowego konstruktora bezparametrowego w strukturze.

        W strukturach w C#, domyślny konstruktor bezparametrowy (czyli ten, który ustawia wartości domyślne, takie jak 0 dla typów numerycznych) 
        jest automatycznie dostarczany przez kompilator i nie można go ręcznie definiować. 
        Stąd próba zdefiniowania takiego konstruktora prowadzi do błędu.
         */
        //public void Point2D_c()
        //{
        //} 

        public void Reset()
        {
            X = 0;
            Y = 0;
        }

        public void IncrX(double dx)
        {
            X += dx;
        }

        public void IncrY(double dy)
        {
            Y += dy;
        }

        public void Print2DPoint()
        {
            Console.WriteLine($"Point2D: X={X}, Y={Y}");
        }

        public double Dist(Point2D other)
        {
            double distance = 0.0;
            distance = Math.Sqrt(Math.Pow(X - other.X, 2) + Math.Pow(Y - other.Y, 2));
            return distance;
        }

    }

    public struct Point2D_d
    {
        /* Private coordinates */
        private double X = 5;
        private double Y = 7;

        public Point2D_d() { }

        public void Reset()
        {
            X = 0;
            Y = 0;
        }

        public void IncrX(double dx)
        {
            X += dx;
        }

        public void IncrY(double dy)
        {
            Y += dy;
        }

        public void Print2DPoint()
        {
            Console.WriteLine($"Point2D: X={X}, Y={Y}");
        }

        public double Dist(Point2D other)
        {
            double distance = 0.0;
            distance = Math.Sqrt(Math.Pow(X - other.X, 2) + Math.Pow(Y - other.Y, 2));
            return distance;
        }

    }

    enum Days
    {
        Monday = 1, 
        Tuesday,
        Wednesday,
        Thursday, 
        Friday, 
        Saturday, 
        Sunday
    }

    enum Range
    {
        Small, 
        Medium, 
        Big
    }

    public struct Coords
    {
        public int x, y;

        public Coords(int p1, int p2)
        {
            x = p1;
            y = p2;
        }
    }

    public class Point
    {
        public int x, y;

        public Point(int p1, int p2)
        {
            x = p1;
            y = p2;
        }
    }
}