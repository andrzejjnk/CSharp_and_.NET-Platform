﻿using System;
using System.Data;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace Aplikacja5
{
    class Program
    {
        static void Main(string[] args)
        {
            //Program.Task1(5);
            //Program.Task2();
            //Program.Task3();
            //Program.Task4();
            //Program.Task5();
            //Program.Task6();
            //Program.Task7();
            Program.Task8();
            //Program.Task9();
        }

        static void Task1(int height)
        {
            Console.WriteLine("For loop:");
            for (int row = 1; row <= height; row++)
            {
                for (int col = 1; col <= row; col++)
                {
                    Console.Write(col + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Triangle:");
            for (int row = 1; row <= height; row++)
            {
                for (int col = 1; col <= row; col++)
                {
                    Console.Write(row + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\nWhile loop:");
            int row2 = 1;
            while (row2 <= height)
            {
                int col2 = 1;
                while (col2 <= row2)
                {
                    Console.Write(col2 + " ");
                    col2++;
                }
                Console.WriteLine();
                row2++;
            }
            Console.WriteLine("Triangle:");
            int row2_t = 1;
            while (row2_t <= height)
            {
                int col2 = 1;
                while (col2 <= row2_t)
                {
                    Console.Write(row2_t + " ");
                    col2++;
                }
                Console.WriteLine();
                row2_t++;
            }

            Console.WriteLine("\nDo while loop:");
            int row3 = 1;
            do
            {
                int col3 = 1;
                do
                {
                    Console.Write(col3 + " ");
                    col3++;
                } while (col3 <= row3);
                Console.WriteLine();
                row3++;
            } while (row3 <= height);

            Console.WriteLine("Triangle:");
            int row3_t = 1;
            do
            {
                int col3 = 1;
                do
                {
                    Console.Write(row3_t + " ");
                    col3++;
                } while (col3 <= row3_t);
                Console.WriteLine();
                row3_t++;
            } while (row3_t <= height);
        }

        static void Task2()
        {
            Int32 i = 23;
            object o = i;
            i = 123;
            Console.WriteLine(i + ", " + (Int32)o); // Na ekran zostało wypisane 123, 23
            /* 
             * Na początku i=23, potem wartość "i" zostaje przypisana do
             * zmiennej typu object, czyli następuje boxing - zmiana wartości
             * typu Int32 na typ object. 23 zostaje zapakowane jako object zachowując
             * swoją wartość w osobnym obieckie w pamięci
             * następnie jest zmiana wartości i=123 - zmiana ta dotyczy
             * tylko zmiennej "i" bez zmiany obiektu "o", ponieważ jest 
             * to odzielny obiekt
             * Wypisanie do konsoli wartości (Int32)o wywołuje unboxing czyli
             * rozpakowuje oryginalną wartośc, która była przypisana do "o"
             * czyli 23.
            */

            //long j = (long)o;
            //Console.WriteLine($"j={j}");
            // bląd: InavlidCastException
            // Próba bezpośredniego rzutowania na long nie powiedzie się,
            // ponieważ kompilator nie może automatycznie przekonwertować
            // zapakowanego Int32 na long.
            // Aby uzyskać wartość long na podstawie o,
            // trzeba najpierw zrobić unboxing do Int32,
            // a następnie rzutowanie na long
            long j2 = (long)(Int32)o;
            Console.WriteLine($"j={j2}"); // j ma wartość 23
        }

        static void Task3()
        {
            int? nullableInt;
            // Wypisanie wartości niezainicjaliowanej
            // Console.WriteLine($"Wartość nullableInt={nullableInt}"); //CS0165 Użyto nieprzypisanej zmiennej lokalnej „nullableInt”

            //Wypisanie wartości przy użyciu GetValueOrDefault i HasValue
            // Console.WriteLine($"nullableInt.HasValue: {nullableInt.HasValue}"); //CS0165 Użyto nieprzypisanej zmiennej lokalnej „nullableInt”

            // Console.WriteLine($"nullableInt.GetValueOrDefault(0): {nullableInt.GetValueOrDefault(0)}"); //CS0165 Użyto nieprzypisanej zmiennej lokalnej „nullableInt”

            //Przypisanie wartości do nullableInt
            nullableInt = 4;

            //Ponowna próba wypisania wartości
            Console.WriteLine($"Wartość nullableInt po przypisaniu: {nullableInt}");
            Console.WriteLine($"nullableInt.HasValue: {nullableInt.HasValue}");
            Console.WriteLine($"nullableInt.GetValueOrDefault(0): {nullableInt.GetValueOrDefault(0)}");
        }

        static void Task4()
        {
            int? i = null;
            int j = 10;
            Console.WriteLine($"Porównanie '<': {i < j}"); // False
            Console.WriteLine($"Porównanie '<=': {i <= j}"); // False
            Console.WriteLine($"Porównanie '==': {i == j}"); // False
            Console.WriteLine($"Porównanie '>=': {i >= j}"); // False
            Console.WriteLine($"Porównanie '>': {i > j}"); // False
            /* 
             * Porównanie wartości zwykłej z null
             * zawsze da wynik False, chyba, że porównujemy
             * null z null to wtedy będzie True
             */
        }

        static void Task5()
        {
            puts("Hello from msvcrt.dll");

            int numFlushed = _flushall();
            Console.WriteLine($"Wyczyszczono {numFlushed} strumienie");

        }
        [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int puts(string s);

        [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int _flushall();

        static void Task6()
        {
            Stack<int> stack1 = new Stack<int>();
            Stack<int> stack2 = new Stack<int>();
            Stack<int> stack3 = new Stack<int>();

            Random rand1 = new Random();
            Random rand2 = new Random();
            for (int index = 0; index < 100; index++)
            {
                stack1.AddItem(rand1.Next(1, 101));
                stack2.AddItem(rand2.Next(1, 101));
            }
            Console.WriteLine($"Liczba elementów w stosie 1:");
            stack1.ShowTheNumberOfItems();
            Console.WriteLine($"Liczba elementów w stosie 2:");
            stack2.ShowTheNumberOfItems();

            HashSet<int> UniqueEvenNumbers = new HashSet<int>();
            foreach (int item in stack1.GetAllItems())
            {
                if (0 == item % 2 && UniqueEvenNumbers.Add(item))
                {
                    stack3.AddItem(item);
                }
            }

            foreach (int item in stack2.GetAllItems())
            {
                if (0 == item % 2 && UniqueEvenNumbers.Add(item))
                {
                    stack3.AddItem(item);
                }
            }

            Console.WriteLine("Unikalne wartości parzyste w stosie 3:");
            stack3.PrintAllItems();
            Console.WriteLine("Liczba elementów w stosie 3:");
            stack3.ShowTheNumberOfItems();
        }

        static void Task7()
        {
            Console.WriteLine("Matrix 1:");
            int[] initialValues = { 1, 2, 3, 4, 5, 6, 7, 8 };
            Matrix matrix1 = new Matrix(2, 3, initialValues);
            matrix1.PrintSize();
            matrix1.PrintMatrix();
            Console.WriteLine("Matrix 2:");
            int[] initialValues2 = { 1, 3, 5, 7 };
            Matrix matrix2 = new Matrix(3, 2, initialValues);
            matrix2.PrintSize();
            matrix2.PrintMatrix();

            Console.WriteLine("Result after addition of matrix1 and matrix2:");
            Matrix result = Matrix.AddMatrix(matrix1, matrix2);
            result.PrintMatrix();
            result.PrintSize();

        }

        static void Task8()
        {
            int[] initialValues1 = { 1, 2, 3, 4, 5, 6 };
            int[] initialValues2 = { 1, 1, 1, 2, 2, 2 };
            Matrix2D matrix1 = new Matrix2D(2, 3, initialValues1);
            Console.WriteLine("Matrix 1:");
            matrix1.PrintSize();
            matrix1.PrintMatrix2D();

            Matrix2D matrix2 = new Matrix2D(2, 3, initialValues2);
            Console.WriteLine("Matrix 2:");
            matrix2.PrintSize();
            matrix2.PrintMatrix2D();

            Console.WriteLine("Matrix addition:");
            Matrix2D AddResult = Matrix2D.AddMatrix(matrix1, matrix2);
            AddResult.PrintSize();
            AddResult.PrintMatrix2D();

            Console.WriteLine("Matrix subtraction:");
            Matrix2D SubtractResult = Matrix2D.SubtractMatrix(matrix1, matrix2);
            SubtractResult.PrintSize();
            SubtractResult.PrintMatrix2D();


        }

        static void Task9()
        {

        }
    }


    public class Stack<T> where T : IComparable<T>
    {
        private List<T> items = new List<T>();

        public void AddItem(T item)
        {
            items.Add(item);
        }

        public void DeleteItem()
        {
            if (items.Count == 0)
            {
                Console.WriteLine("Stos jest pusty, nie można usunąć elementu!");
            }
            else
            {
                items.RemoveAt(0);
            }
        }

        public void ShowTheNumberOfItems()
        {
            if (items.Count == 0)
            {
                Console.WriteLine("Stos jest pusty!");
            }
            else
            {
                Console.WriteLine($"Liczba elementów: {items.Count}");
            }
        }

        public void ShowMinItem()
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException("Stos jest pusty!");
            }
            else
            {
                Console.WriteLine($"Min item= {items.Min()}");
            }
        }

        public void ShowMaxItem()
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException("Stos jest pusty!");
            }
            else
            {
                Console.WriteLine($"Max item= {items.Max()}");
            }
        }

        public int FindAnItem(T item)
        {
            int index = items.IndexOf(item);
            if (index != -1)
            {
                return index + 1;
            }
            else
            {
                return -1;
            }
        }

        public void PrintAllItems()
        {
            if (items.Count > 0)
            {
                foreach (var item in items)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            else
            {
                Console.WriteLine("Stos jest pusty!");
            }
        }

        public void ClearAll()
        {
            items.Clear();
        }

        public IEnumerable<T> GetAllItems()
        {
            return items;
        }
    }

    public class Matrix
    {
        int[] _matrix;
        int c;
        int l;

        public Matrix(int rows, int columns)
        {
            l = rows;
            c = columns;
            _matrix = new int[l * c];
        }

        public Matrix(int rows, int columns, int[] initialValues)
        {
            l = rows;
            c = columns;
            _matrix = new int[l * c];

            for (int index = 0; index < _matrix.Length; index++)
            {
                _matrix[index] = index < initialValues.Length ? initialValues[index] : 0;
            }
        }

        public void PrintMatrix()
        {
            for (int i = 0; i < l; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    Console.Write(_matrix[i * c + j] + "\t");
                }
                Console.WriteLine();
            }
        }

        public void AddElem(int row, int column, int value)
        {
            if (row >= 0 && row < l && column >= 0 && column < c)
            {
                _matrix[row * c + column] = value;
            }
            else
            {
                throw new IndexOutOfRangeException("Wrong index of line of column.");
            }
        }

        public void PrintSize()
        {
            Console.WriteLine($"Matrix size: {l}x{c}");
        }

        public int[] GetMatrixCopy()
        {
            return (int[])_matrix.Clone();
        }

        public static Matrix AddMatrix(Matrix matrix1, Matrix matrix2)
        {
            int rows = Math.Max(matrix1.l, matrix2.l);
            int columns = Math.Max(matrix1.c, matrix2.c);
            Matrix result = new Matrix(rows, columns);


            for (int l = 0; l < rows; l++)
            {
                for (int c = 0; c < columns; c++)
                {
                    int value1 = (l < matrix1.l && c < matrix1.c) ? matrix1._matrix[l * matrix1.c + c] : 0;
                    int value2 = (l < matrix2.l && c < matrix2.c) ? matrix2._matrix[l * matrix2.c + c] : 0;

                    result.AddElem(l, c, value1 + value2);
                }
            }

            return result;
        }
    }

    public class Matrix2D
    {
        protected int[][] _matrix;
        int c;
        int l;

        public Matrix2D(int rows, int columns)
        {
            l = rows;
            c = columns;
            _matrix = new int[l][];

            for (int i = 0; i < l; i++)
            {
                _matrix[i] = new int[c];
            }
        }

        public Matrix2D(int rows, int columns, int[] initialValues)
        {
            l = rows;
            c = columns;
            _matrix = new int[l][];

            int index = 0;
            for (int i = 0; i < l; i++)
            {
                _matrix[i] = new int[c];
                for (int j = 0; j < c; j++)
                {
                    _matrix[i][j] = index < initialValues.Length ? initialValues[index++] : 0;
                }
            }
        }

        public void PrintMatrix2D()
        {
            for (int i = 0; i < l; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    Console.Write(_matrix[i][j] + "\t");
                }
                Console.WriteLine();
            }
        }

        public void PrintSize()
        {
            Console.WriteLine($"Matrix size: {l}x{c}");
        }

        public static Matrix2D AddMatrix(Matrix2D m1, Matrix2D m2)
        {
            int maxRows = Math.Max(m1.l, m2.l);
            int maxColumns = Math.Max(m1.c, m2.c);
            Matrix2D result = new Matrix2D(maxRows, maxColumns);

            for (int l = 0; l < maxRows; l++)
            {
                for (int c = 0; c < maxColumns; c++)
                {
                    int value1 = (l < m1.l && c < m1.c) ? m1._matrix[l][c] : 0;
                    int value2 = (l < m2.l && c < m2.c) ? m2._matrix[l][c] : 0;

                    result._matrix[l][c] = value1 + value2;
                }
            }

            return result;
        }

        public static Matrix2D SubtractMatrix(Matrix2D m1, Matrix2D m2)
        {
            int maxRows = Math.Max(m1.l, m2.l);
            int maxColumns = Math.Max(m1.c, m2.c);
            Matrix2D result = new Matrix2D(maxRows, maxColumns);

            for (int l = 0; l < maxRows; l++)
            {
                for (int c = 0; c < maxColumns; c++)
                {
                    int value1 = (l < m1.l && c < m1.c) ? m1._matrix[l][c] : 0;
                    int value2 = (l < m2.l && c < m2.c) ? m2._matrix[l][c] : 0;

                    result._matrix[l][c] = value1 - value2;
                }
            }

            return result;
        }
    }

    public class Book
    {
        string _title;
        string _author;
        double _price;
        readonly string _isbn;
        DateTime _date;

        public Book(string title, string author, double price, string isbn, DateTime date)
        {
            _title = title;
            _author = author;
            _price = price;
            _isbn = isbn;
            _date = date;
        }
    }
}
