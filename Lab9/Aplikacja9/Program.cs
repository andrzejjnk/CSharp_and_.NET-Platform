using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Aplikacja7
{
    public class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Select a task to run (1-3):");
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
                        default:
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Inavlid input! Please enter a task number or 'exit' to quit.");
                }
            }
        }

        static void Task1()
        {
            string[] slowa = new string[]
            {
                "Już północ", // 0 ^10
                "cień",       // 1 ^9
                "ponury",     // 2 ^8
                "pół",        // 3 ^7
                "świata",     // 4 ^6
                "okrywa",     // 5 ^5
                "A jeszcze",  // 6 ^4
                "serce",      // 7 ^3
                "zmysłom",    // 8 ^2
                "spoczynku nie daje" // 9 ^1
                                     // 10(słowa.Length) ^0
            };

            // 1
            Console.WriteLine($"{slowa[^1]}");

            // 2
            string[] sonet1 = slowa[2..6];
            foreach (var slowo in sonet1)
            {
                Console.Write($"< {slowo} >");
            }
            Console.WriteLine();

            // 3
            string[] sonet2 = slowa[^3..^0];
            foreach (var slowo in sonet2)
            {
                Console.Write($"{slowo} ");
            }
            Console.WriteLine();

            // 4
            // All elements of the array
            string[] sonet3 = slowa[..];
            Console.WriteLine("Sonet3:");
            foreach (var slowo in sonet3)
            {
                Console.Write($"{slowo} ");
            }
            Console.WriteLine();

            // First 5 elements
            string[] sonet4 = slowa[..5];
            Console.WriteLine("Sonet4:");
            foreach (var slowo in sonet4)
            {
                Console.Write($"{slowo} ");
            }
            Console.WriteLine();

            // Elements from index 7 to the end
            string[] sonet5 = slowa[7..];
            Console.WriteLine("Sonet5:");
            foreach (var slowo in sonet5)
            {
                Console.Write($"{slowo} ");
            }
            Console.WriteLine();

            // 5
            Index stri = ^5;
            Console.WriteLine(slowa[stri]);

            // 6
            Range fraza = 2..7;
            string[] tekst = slowa[fraza];
            foreach (var slowo in tekst)
            {
                Console.Write($" {slowo} ");
            }
            Console.WriteLine();
        }


        public static event Action OnDigit;
        public static event Action OnCharacter;

        static void Task2()
        {
            OnDigit -= DigitPressed;
            OnCharacter -= CharacterPressed;

            OnDigit += DigitPressed;
            OnCharacter += CharacterPressed;

            Console.WriteLine("Press a key. Press any non-alphanumeric key to exit.");
            while (true)
            {
                var key = Console.ReadKey(intercept: true);
                if (char.IsDigit(key.KeyChar))
                {
                    OnDigit?.Invoke();
                }
                else if (char.IsLetter(key.KeyChar))
                {
                    OnCharacter?.Invoke();
                }
                else
                {
                    Console.WriteLine("Non-alphanumeric character pressed.");
                    break;
                }
            }
        }

        static void DigitPressed()
        {
            Console.WriteLine("Naciśnięto cyfrę!");
        }

        static void CharacterPressed()
        {
            Console.WriteLine("Naciśnięto literę!");
        }

        static void Task3()
        {
            // Utworzenie obiektu DisposeObject
            DisposeObject disposableObject = new DisposeObject();

            // Zwolnienie zasobów
            disposableObject.Dispose();
            Console.WriteLine("Zwolniono zasoby obiektu DisposeObject.");
        }

        public class DisposeObject : IDisposable
        {
            protected bool disposed = false; // zabezpieczenie, aby nie wywoływać wielokrotnie
            private IntPtr handle; // niezarządzane zasoby
            private Component components; // zarządzane zasoby

            public DisposeObject()
            {
                // Alokacja pamięci niezarządzanej
                handle = Marshal.AllocHGlobal(1024);
                Console.WriteLine("Alokowano pamięć niezarządzaną.");

                // Utworzenie zarządzanego obiektu
                components = new Component();
                Console.WriteLine("Utworzono zarządzany obiekt.");
            }

            ~DisposeObject() //niedeterministyczny
            {
                Dispose(false);
            }

            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this); // zabezpieczenie przed powtórnym wywołaniem finalizatora
            }

            protected virtual void Dispose(bool disposing)
            {
                if (disposed)
                    return; // tylko jeden raz

                if (disposing)
                {
                    // zwolnienie zarządzanych zasobów (kod użytkownika)
                    components.Dispose();
                    Console.WriteLine("Zwolniono zarządzane zasoby.");
                }

                // zwolnienie niezarządzanych zasobów
                if (handle != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(handle);
                    Console.WriteLine("Zwolniono pamięć niezarządzaną.");
                }

                disposed = true;
            }
        }

    }
}
