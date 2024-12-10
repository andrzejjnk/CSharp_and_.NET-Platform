using System;
using System.Security.Cryptography;
using System.Threading;

namespace Aplikacja11
{
    class ThreadExample
    {
        static void Main1()
        {
            Thread t = new Thread(Write1); // Uruchom inny wątek
            t.Start();

            // Główny wątek.
            for (int i = 0; i < 1000; i++) Console.Write("0");
        }

        static void Main2()
        {
            new Thread(Run).Start(); // Uruchom Run w innym wątku
            Run(); // Uruchom Run w głównym wątku
        }

        // Inny wątek
        static void Write1()
        {
            for (int i = 0; i < 1000; i++) Console.Write("1");
        }

        static void Run()
        {
            // Deklaracja i użycie zmiennej lokalnej - 'cycles'
            for (int cycles = 0; cycles < 5; cycles++) Console.Write('x');
        }
    }

    class ThreadTest
    {
        bool done;
        static void Main3()
        {
            ThreadTest tt = new ThreadTest();
            new Thread(tt.Run).Start();
            tt.Run();
        }

        // Zauważ, że Run jest teraz metodą instancji
        void Run()
        {
            if (!done)
            {
                done = true;
                Console.WriteLine("Done");
            }
        }
    }

    class ThreadExample_cw4
    {
        static bool done; // Pole statyczne
        static void Main4()
        {
            new Thread(Run).Start();
            Run();
        }
        static void Run()
        {
            // if (!done) { done = true; Console.WriteLine("Done"); }
            if (!done) { Console.WriteLine("Done"); done = true; }
        }
    }

    class ThreadExample_cw5
    {
        static bool done; // Pole statyczne
        static readonly object locker = new object();
        static void Main5()
        {
            new Thread(Run).Start();
            Run();
        }
        static void Run()
        {
            // exclusive lock
            lock (locker)
            {
                // if (!done) { done = true; Console.WriteLine("Done"); }
                if (!done) { Console.WriteLine("Done"); done = true; }
            }
        }
    }

    public class Program6
    {
        static void Main6()
        {
            Thread t = new Thread(Run);
            t.Start();
            // t.Join();
            Console.WriteLine("Thread t has ended!");
        }

        static void Run()
        {
            for (int i = 0; i < 777; i++) Console.Write("J");
        }
    }

    public class MatrixSum
    {
        static readonly object locker = new object();

        static void Main()
        {
            int[,] matrix1 = FillMatrixWithRandomValues(2, 2);
            int[,] matrix2 = FillMatrixWithRandomValues(2, 2);
            int[,] matrix3 = FillMatrixWithRandomValues(3, 3);
            int[,] matrix4 = FillMatrixWithRandomValues(3, 3);
            int[,] matrix5 = FillMatrixWithRandomValues(5, 5);

            Thread t1 = new Thread(() => CalculateSumOfMatrixElements(matrix1, 0));
            Thread t2 = new Thread(() => CalculateSumOfMatrixElements(matrix2, 1));
            Thread t3 = new Thread(() => CalculateSumOfMatrixElements(matrix3, 2));
            Thread t4 = new Thread(() => CalculateSumOfMatrixElements(matrix4, 3));
            Thread t5 = new Thread(() => CalculateSumOfMatrixElements(matrix5, 4));

            t1.Start();
            t2.Start();
            t3.Start(); 
            t4.Start();
            t5.Start();

            t1.Join();
            t2.Join();
            t3.Join();
            t4.Join();
            t5.Join();
        }

        static int[,] FillMatrixWithRandomValues(int rows, int cols)
        {
            int[,] matrix = new int[rows, cols];
            var random_var = new Random(Guid.NewGuid().GetHashCode()); // Osobny Random dla każdego wątku
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = random_var.Next(0, 9);
                }
            }
            return matrix;
        }

        static void CalculateSumOfMatrixElements(int[,] matrix, int index)
        {
            int sum = 0;
            lock (locker)
            {
                Console.WriteLine($"Matrix {index + 1}");
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        Console.Write(matrix[i, j] + " ");
                        sum += matrix[i, j];
                    }
                    Console.WriteLine();
                }
                Console.WriteLine($"Sum of Matrix_{index + 1}: {sum}");
            }
        }
    }

}
