using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.ConstrainedExecution;

namespace Aplikacja13
{

    public struct authorParam
    {
        public string id;
        public double book;
        public int year;
    }

    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Choose a function to execute:");
                Console.WriteLine("1 - Task1");
                Console.WriteLine("2 - Task2");
                Console.WriteLine("3 - Task3");
                Console.WriteLine("4 - Task4");
                Console.WriteLine("6 - Task6");
                Console.WriteLine("0 - Exit");

                string input = Console.ReadLine();

                if (int.TryParse(input, out int choice))
                {
                    switch (choice)
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
                            Program program = new Program();
                            program.Task4();
                            break;
                        case 6:
                            Program.Task6();
                            break;
                        case 0:
                            Console.WriteLine("Exiting the program...");
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a function number.");
                }

                Console.WriteLine();
            }
        }

        static void Task1()
        {
            List<authorParam> mAuthors = new List<authorParam>();

            mAuthors.Add(new authorParam { id = "ID1", book = 7, year = 2014 });
            mAuthors.Add(new authorParam { id = "ID2", book = 5.5, year = 2024 });
            mAuthors.Add(new authorParam { id = "ID3", book = 9.2, year = 2022 });

            //mAuthors[1].year = 2020;
            authorParam temp = mAuthors[1];
            temp.year = 2020;
            mAuthors[1] = temp;

            foreach (var author in mAuthors)
            {
                Console.WriteLine($"id: {author.id}, book: {author.book}, year: {author.year}");
            }
        }

        static void Task2()
        {
            using (SomeDisposableClass someDisposableObject = new SomeDisposableClass())
            {
                someDisposableObject.DoTheJob();
            }
        }

        public class SomeDisposableClass : IDisposable
        {
            public void DoTheJob()
            {
                Console.WriteLine("DoTheJob");
            }

            public void Dispose()
            {
                Console.WriteLine("Releasing resources...");
            }
        }

        static void Task3()
        {
            List<string> values = new List<string> { "Ala ", "ma ", "kota ", "!" };
            string output = string.Empty;
            foreach (var value in values)
            {
                output += value;
            }

            Console.WriteLine($"Output: \"{output}\"");
        }

        static Point point1;
        //static Pen pen1;
        public void Task4()
        {
            //Console.WriteLine(pen1 == null);
            Console.WriteLine(point1 == null);
            Console.WriteLine($"Default value of Point is: {point1}");
        }

        static void Task6()
        {
            Car car = new Car();
            Track track;

            try
            {
                track = (Track)car;
                Console.WriteLine("Casting succeeded.");
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine("InvalidCastException: " + ex.Message);
            }

            track = car as Track;
            if (track != null)
            {
                Console.WriteLine("Casting succeeded using 'as'.");
            }
            else
            {
                Console.WriteLine("Casting failed using 'as' (null returned).");
            }
        }

        public class Car
        {
            public string Model { get; set; } = "Car Model";
        }
        public class Track : Car
        {
            public int Wheels { get; set; } = 6;
        }
    }
}
