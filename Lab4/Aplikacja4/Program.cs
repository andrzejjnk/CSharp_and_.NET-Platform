using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization.Metadata;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Aplikacja4
{
    class Program
    {
        static void Main(string[] args)
        {
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
                            Console.WriteLine("Select a sub-task for Task1 (1 or 2):");
                            string subTaskInput = Console.ReadLine();
                            if (subTaskInput == "1")
                            {
                                Program.Task1_1();
                            }
                            else if (subTaskInput == "2")
                            {
                                Program.Task1_2();
                            }
                            else
                            {
                                Console.WriteLine("Invalid sub-task selection!");
                            }
                            break;
                        case 2:
                            Console.WriteLine("Select a sub-task for Task2 (2 or 3):");
                            string subTaskInput2 = Console.ReadLine();
                            if (subTaskInput2 == "2")
                            {
                                Program.Task2_2();
                            }
                            else if (subTaskInput2 == "3")
                            {
                                Program.Task2_3();
                            }
                            else
                            {
                                Console.WriteLine("Invalid sub-task selection!");
                            }
                            break;
                        case 3:
                            Program.Task3();
                            break;
                        case 4:
                            Program.Task4();
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
                            Program.Task8();
                            break;
                        default:
                            Console.WriteLine("Invalid task number. Please select from 1 to 8.");
                            break;

                    }
                }
                else
                {
                    Console.WriteLine("Inavlid input! Please enter a task number or 'exit' to quit.");
                }
            }
        }

            static void Task1_1()
        {
            Console.WriteLine("For int type value:");
            int value1 = 1;
            Console.WriteLine($"Before Fun1: value = {value1}");
            Fun1(in value1);
            Console.WriteLine($"After Fun1: value = {value1}");

            int value2 = 1;
            Console.WriteLine($"Before Fun2: value = {value2}");
            Fun2(out value2);
            Console.WriteLine($"After Fun2: value = {value2}");

            int value3 = 1;
            Console.WriteLine($"Before Fun3: value = {value3}");
            Fun3(ref value3);
            Console.WriteLine($"After Fun3: value = {value3}");

            int value4 = 1;
            Console.WriteLine($"Before Fun4: value = {value4}");
            Fun4(value4);
            Console.WriteLine($"After Fun4: value = {value4}");

            Console.WriteLine("================================");
            Console.WriteLine("For short type value:");
            //short value1_short = 1;
            //Console.WriteLine($"Before Fun1: value = {value1_short}");
            //Fun1(in value1_short); //CS1503	Argument „1”: nie można przekonwertować z „in short” na „in int”
            //Console.WriteLine($"After Fun1: value = {value1_short}");

            //short value2_short = 1;
            //Console.WriteLine($"Before Fun2: value = {value2_short}");
            //Fun2(out value2_short); //CS1503	Argument „1”: nie można przekonwertować z „out short” na „out int”
            //Console.WriteLine($"After Fun2: value = {value2_short}");

            //short value3_short = 1;
            //Console.WriteLine($"Before Fun3: value = {value3_short}");
            //Fun3(ref value3_short); //CS1503	Argument „1”: nie można przekonwertować z „ref short” na „ref int”
            //Console.WriteLine($"After Fun3: value = {value3_short}");

            short value4_short = 1;
            Console.WriteLine($"Before Fun4: value = {value4_short}");
            Fun4(value4_short);
            Console.WriteLine($"After Fun4: value = {value4_short}");

        }

        static void Fun1(in int i)
        {
            //i = 10; //Błąd(aktywny)  CS8331 Nie można przypisać do zmienna „i” lub użyć go jako prawej strony przypisania odwołania, ponieważ jest to zmienna tylko do odczytu.	

        }

        static void Fun2(out int i)
        {
            i = 10;
        }

        static void Fun3(ref int i)
        {
            i = 10;
        }

        static void Fun4(int i)
        {
            i = 10;
        }

        /* 
        CS0663	'Element „Program” nie może definiować przeciążonego elementu metoda, który różni się tylko modyfikatorami parametru „in” i „out”
        */
        //static void Fun2(in int i) 
        //{
        //    i = i + 1;
        //}

        static void Task1_2()
        {
            Point point = new Point(1, 1);
            Console.WriteLine($"Before calling Fun5: point={point}");
            Fun5(point);
            Console.WriteLine($"After calling Fun5: point={point}");
            Fun6(ref point);
            Console.WriteLine($"After calling Fun6: point={point}");
            point = null;
            Console.WriteLine($"After assignment null value: point={point}");
        }

        static void Fun5(Point p)
        {
            Point new_point = new Point(2, 2);
            p = new_point;
        }

        static void Fun6(ref Point p)
        {
            Point new_point = new Point(3, 3);
            p = new_point;
        }

        /* 
        Funkcja jest zadeklarowana jako unsafe, aby móc używać wskaźników, 
        w przeciwnym wypadku otrzymujemy błąd jak w podpunkcie 1.:
        CS0214	Wskaźniki i bufory o ustalonym rozmiarze mogą zostać użyte 
        tylko w kontekście słowa kluczowego „unsafe”
        Modyfikator unsafe jest niezbędny do operacji wskaźnikowych w C#.
        */
        unsafe static void Task2_2()
        {
            int p_val = 5;
            int q_val = 10;
            Console.WriteLine("Before swap:");
            int* p_ptr = &p_val;
            int* q_ptr = &q_val;
            Console.WriteLine($"p_val={p_val}");
            Console.WriteLine($"q_val={q_val}");
            Console.WriteLine($"*p_ptr={*p_ptr}");
            Console.WriteLine($"*q_ptr={*q_ptr}");

            swap(p_ptr, q_ptr);

            Console.WriteLine("After swap:");
            Console.WriteLine($"p_val={p_val}");
            Console.WriteLine($"q_val={q_val}");
            Console.WriteLine($"*p_ptr={*p_ptr}");
            Console.WriteLine($"*q_ptr={*q_ptr}");

        }
        
        static unsafe void swap(int * p, int * q)
        {
            int temp = *p;
            *p = *q;
            *q = temp;
        }

        static unsafe void Task2_3()
        {
            fixed (int* buffer = new int[1024])
            {
                for (int index = 0; index < 1024; index++)
                {
                    *(buffer + index) = index;
                }
                Console.WriteLine("Printing the first 10 elements in the buffer:");
                for(int index = 0; index < 10; index++)
                {
                    Console.WriteLine($"buffer[{index}]={buffer[index]}");
                }
            }
        }

        static void Task3()
        {
            int[] array = [ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 ];
            Console.WriteLine("Array elements: ");
            for (int index = 0; index < array.Length; index++)
            {
                Console.Write(array[index] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Enter a number: ");
            int value = int.Parse(Console.ReadLine());

            for (int index = array.Length - 1; index > 0; index--)
            {
                array[index] = array[index - 1];
            }
            array[0] = value;
            Console.WriteLine("Array elements: ");
            for (int index = 0; index < array.Length; index++)
            {
                Console.Write(array[index] + " ");
            }
            Console.WriteLine();
        }

        static void Task4()
        {
            int[] array = new int[5];
            Console.WriteLine("Enter 5 numbers: ");
            for (int index = 0; index < array.Length; index++)
            {
                array[index] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Array elements: ");
            for (int index = 0; index < array.Length; index++)
            {
                Console.Write(array[index] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Array elements in reverse order");
            for(int index = array.Length - 1; index >= 0; index--)
            {
                Console.Write(array[index] + " ");
            }
            Console.WriteLine();
        }

        static void Task5()
        {
            int[] array = [ 1, 1, 4, 3, 3 ];
            for (int index = 0; index < array.Length; index++)
            {
                Console.Write(array[index] + " ");
            }
            Console.WriteLine();
            Dictionary<int, int> occurences = new Dictionary<int, int>();

            foreach (int element in array)
            {
                if (occurences.ContainsKey(element))
                {
                    occurences[element]++;
                }
                else
                {
                    occurences[element] = 1;
                }
            }
            Console.WriteLine($"Duplications in array:");
            foreach(var pair in occurences)
            {
                Console.WriteLine($"Number {pair.Key} occurred {pair.Value} times");
            }
        }

        static void Task6()
        {
            int[,] matrix1 = new int[5, 5];
            int[,] matrix2 = new int[5, 5];
            int[,] sum = new int[5, 5];

            Console.WriteLine("First matrix: ");
            for (int row = 0; row < matrix1.GetLength(0); row++)
            {
                for (int col = 0; col < matrix1.GetLength(1); col++)
                {
                    matrix1[row, col] = 1;
                    Console.Write(matrix1[row, col] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Second matrix: ");
            for (int row = 0; row < matrix2.GetLength(0); row++)
            {
                for (int col = 0; col < matrix2.GetLength(1); col++)
                {
                    matrix2[row, col] = 2;
                    Console.Write(matrix2[row, col] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Sum matrix: ");
            if (matrix1.GetLength(0) == matrix2.GetLength(0) && matrix1.GetLength(1) == matrix2.GetLength(1))
            {
                for (int row = 0; row < matrix1.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix1.GetLength(1); col++)
                    {
                        sum[row, col] = matrix1[row, col] + matrix2[row, col];
                        Console.Write(sum[row, col] + " ");
                    }
                    Console.WriteLine();
                }
            }


        }

        static void Task7()
        {
            int[,] matrix = { { 1, 0, -1 }, { 0, 0, 1 }, { -1, -1, 0} };
            int determinant = 0;
            // Determinant will be calculated using Sarrus formula for 3x3 matrix
            determinant = matrix[0, 0] * (matrix[1, 1] * matrix[2, 2] - matrix[1, 2] * matrix[2, 1]) - matrix[0, 1] * (matrix[1, 0] * matrix[2, 2] - matrix[1, 2] * matrix[2, 0]) + matrix[0, 2] * (matrix[1, 0] * matrix[2, 1] - matrix[1, 1] * matrix[2, 0]);
            Console.WriteLine("Matrix: ");
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Matrix determinant: det={determinant}");
        }

        static void Task8()
        {
            /* Direct initialization of jagged array: */
            int[][] jagged_array1 = new int[5][];
            jagged_array1[0] = [1, 2, 3];
            jagged_array1[1] = [4, 5, 6, 7, 8, 9];
            jagged_array1[2] = [10, 11, 12, 13];
            jagged_array1[3] = [14, 15 ,16, 17, 18];
            jagged_array1[4] = [19, 20, 21];

            Console.WriteLine("Jagged array version 1: ");
            foreach (var row in jagged_array1)
            {
                foreach (var element in row)
                {
                    Console.Write(element + " ");
                }
                Console.WriteLine();
            }

            /* Initialization of jagged array using loops */
            int[][] jagged_array2 = new int[5][];
            jagged_array2[0] = new int[3];
            jagged_array2[1] = new int[6];
            jagged_array2[2] = new int[4];
            jagged_array2[3] = new int[5];
            jagged_array2[4] = new int[3];
            int value = 1;
            for (int row = 0; row < jagged_array2.Length; row++)
            {
                for (int col = 0; col < jagged_array2[row].Length; col++)
                {
                    jagged_array2[row][col] = value;
                    value++;
                }
            }

            Console.WriteLine("Jagged array version 2: ");
            foreach (var row in jagged_array2)
            {
                foreach (var element in row)
                {
                    Console.Write(element + " ");
                }
                Console.WriteLine();
            }

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

        // Overridden ToString method to more clearly print instance of class Point
        public override string ToString()
        {
            return $"Point(x={x}, y={y})";
        }
    }

    class TestPointer 
    {
        /*
        CS0227	Niebezpieczny kod może się pojawić tylko
        w przypadku kompilowania przy użyciu opcji /unsafe
        Powyższy błąd pojawil się po napisaniu fragmentu kodu,
        lecz Visual Studio pozwala na wyłączenie tego ostrzeżenia
        poprzez ustawienie flagi kompilatora
        */

        /* Po usunięciu słowa kluczowego unsafe otrzymuje bląd:
        CS0214	Wskaźniki i bufory o ustalonym rozmiarze mogą zostać 
        użyte tylko w kontekście słowa kluczowego „unsafe”
        Modyfikator unsafe jest niezbędny do operacji wskaźnikowych w C#.
        */
        public unsafe static void Main_2_1() 
        { 
            int[] list = { 10, 100, 200 }; 
            fixed (int* ptr = list) 
                for (int i = 0; i < 3; i++) 
                { 
                    Console.WriteLine("Adres [{0}]={1}", i, (int)(ptr + i)); 
                    Console.WriteLine("Wartość[{0}]={1}", i, *(ptr + i)); 
                } 
            Console.ReadKey(); 
        } 
    }
}
