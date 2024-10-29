using System;
using System.Data;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;

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
            Program.Task7();
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
            for (int  index = 0; index < 100; index++)
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
        // TODO
    }
}
