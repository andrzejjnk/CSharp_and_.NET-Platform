using System;
using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            Auto car1 = new Auto
            {
                VehicleType = "Hatchback",
                Brand = "Toyota",
                EngineCapacity = 1.4,
                SeatCount = 5,
                VIN = "1J8FF47W67D577623",
                RegistrationNumber = "KR 6FE6F",
                YearOfProduction = 2016,
                Color = "Black",
                InsurancePolicyNumber = "POL123456",
                OwnerName = "Jan Kowalski",
                Address = "Cracow, Mickiewicza 30",
                PESEL = "98072091239",
                DrivingLicenseNumber = "PL756320",
                DrivingLicenseIssueDate = new DateTime(2018, 3, 13),
                PurchaseYear = 2018,
                PenaltyPoints = 2
            };

            Auto car2 = new Auto
            {
                VehicleType = "SUV",
                Brand = "Mercedes",
                EngineCapacity = 3.0,
                SeatCount = 5,
                VIN = "3GCPCRECXEG434636",
                RegistrationNumber = "KR M890F",
                YearOfProduction = 2022,
                Color = "White",
                InsurancePolicyNumber = "POL789012",
                OwnerName = "Krzysztof Nowak",
                Address = "Krakow, Tokarskiego 8",
                PESEL = "91040543835",
                DrivingLicenseNumber = "CD987654",
                DrivingLicenseIssueDate = new DateTime(2011, 6, 6),
                PurchaseYear = 2022,
                PenaltyPoints = 0
            };

            Auto car3 = new Auto
            {
                VehicleType = "Sedan",
                Brand = "BMW",
                EngineCapacity = 2.0,
                SeatCount = 5,
                VIN = "JTHCK262672062351",
                RegistrationNumber = "KR 17NBP",
                YearOfProduction = 2004,
                Color = "Black",
                InsurancePolicyNumber = "PL083261",
                OwnerName = "Anna Brown",
                Address = "Krakow, 7 Dluga St",
                PESEL = "01263024983",
                DrivingLicenseNumber = "CD055423",
                DrivingLicenseIssueDate = new DateTime(2020, 1, 26),
                PurchaseYear = 2021,
                PenaltyPoints = 8
            };

            List<ICepikData> cepikList = new List<ICepikData> { car1, car2, car3 };
            List<IStatData> statList = new List<IStatData> { car1, car2, car3 };
            List<IPoliceData> policeList = new List<IPoliceData> { car1, car2, car3 };

            Console.WriteLine("CEPIK Data:");
            foreach (var car in cepikList)
            {
                Console.WriteLine($"Type: {car.VehicleType}, Brand: {car.Brand}, VIN: {car.VIN}, " +
                    $"Registration Number: {car.RegistrationNumber}, Year of Production: {car.YearOfProduction}, " +
                    $"Color: {car.Color}, Insurance Policy Number: {car.InsurancePolicyNumber}, " +
                    $"Owner Name: {car.OwnerName}, Address: {car.Address}, PESEL: {car.PESEL}, " +
                    $"Driving License Number: {car.DrivingLicenseNumber}, License Issue Date: {car.DrivingLicenseIssueDate.ToShortDateString()}, " +
                    $"Purchase Year: {car.PurchaseYear}\n");
            }

            Console.WriteLine("==========================");
            Console.WriteLine("\nStatistical Data:");
            foreach (var car in statList)
            {
                Console.WriteLine($"Type: {car.VehicleType}, Brand: {car.Brand}, Engine Capacity: {car.EngineCapacity}, " +
                    $"Seat Count: {car.SeatCount}, VIN: {car.VIN}, Year of Production: {car.YearOfProduction}, " +
                    $"Color: {car.Color}\n");
            }
            Console.WriteLine("==========================");
            Console.WriteLine("\nPolice Data:");
            foreach (var car in policeList)
            {
                Console.WriteLine($"Type: {car.VehicleType}, Brand: {car.Brand}, Engine Capacity: {car.EngineCapacity}, " +
                    $"Seat Count: {car.SeatCount}, VIN: {car.VIN}, Registration Number: {car.RegistrationNumber}, " +
                    $"Year of Production: {car.YearOfProduction}, Color: {car.Color}, Insurance Policy Number: {car.InsurancePolicyNumber}, " +
                    $"Owner Name: {car.OwnerName}, Address: {car.Address}, PESEL: {car.PESEL}, " +
                    $"Driving License Number: {car.DrivingLicenseNumber}, License Issue Date: {car.DrivingLicenseIssueDate.ToShortDateString()}, " +
                    $"Purchase Year: {car.PurchaseYear}, Penalty Points: {car.PenaltyPoints}\n");
            }
        }

        static void Task2()
        {
            Point p1 = new Point(1, 2);
            Point p2 = new Point(3, 3);
            Console.WriteLine($"Points: p1={p1}, p2={p2}");
            Console.WriteLine($"Operator +: p1 + p2 = {p1 + p2}");
            Console.WriteLine($"Operator true and false for points: p1={(p1 ? "true" : "false")}, p2={(p2 ? "true" : "false")}");
            Console.WriteLine($"Operator ==: p1 == p2 = {p1 == p2}");
            Console.WriteLine($"Operator <: p1 < p2 = {p1 < p2}");
            Console.WriteLine($"Operator <=: p1 <= p2 = {p1 <= p2}");
            Console.WriteLine($"Operator >: p1 > p2 = {p1 > p2}");
            Console.WriteLine($"Operator >=: p1 >= p2 = {p1 >= p2}");
            Console.WriteLine($"Operator ++, before: {p1}, after ++: {p1++}");
            Console.WriteLine($"Operator --, before: {p1}, after --: {p1--}");
            Point p = 5;
            Console.WriteLine($"Point p = 5: {p}");
            Console.WriteLine($"Sum of point={p2} coordinates: {(int)p2}");
            Console.WriteLine($"Operator +=: p1 += p2, result: {p1 += p2}");

        }

        static void Task3() 
        {
            Operations operations = new Operations();
            DelegateOperations add = operations.Add;
            DelegateOperations subtract = operations.Subtract;
            DelegateOperations multiply = operations.Multiply;
            DelegateOperations divide = operations.Divide;
            add(2, 3);
            subtract(7, 4);
            multiply(2, 3);
            divide(8, 2);
        }
    }

    public interface ICepikData
    {
        string VehicleType { get; set; }
        string Brand { get; set; }
        double EngineCapacity { get; set; }
        int SeatCount { get; set; }
        string VIN { get; set; }
        string RegistrationNumber { get; set; }
        int YearOfProduction { get; set; }
        string Color { get; set; }
        string InsurancePolicyNumber { get; set; }
        string OwnerName { get; set; }
        string Address { get; set; }
        string PESEL { get; set; }
        string DrivingLicenseNumber { get; set; }
        DateTime DrivingLicenseIssueDate { get; set; }
        int PurchaseYear { get; set; }
    }

    public interface IStatData
    {
        string VehicleType { get; set; }
        string Brand { get; set; }
        double EngineCapacity { get; set; }
        int SeatCount { get; set; }
        string VIN { get; set; }
        int YearOfProduction { get; set; }
        string Color { get; set; }
    }

    public interface IPoliceData
    {
        string VehicleType { get; set; }
        string Brand { get; set; }
        double EngineCapacity { get; set; }
        int SeatCount { get; set; }
        string VIN { get; set; }
        string RegistrationNumber { get; set; }
        int YearOfProduction { get; set; }
        string Color { get; set; }
        string InsurancePolicyNumber { get; set; }
        string OwnerName { get; set; }
        string Address { get; set; }
        string PESEL { get; set; }
        string DrivingLicenseNumber { get; set; }
        DateTime DrivingLicenseIssueDate { get; set; }
        int PurchaseYear { get; set; }
        int PenaltyPoints { get; set; }
    }

    public class Auto : ICepikData, IStatData, IPoliceData
    {
        public string VehicleType { get; set; }
        public string Brand { get; set; }
        public double EngineCapacity { get; set; }
        public int SeatCount { get; set; }
        public string VIN { get; set; }
        public string RegistrationNumber { get; set; }
        public int YearOfProduction { get; set; }
        public string Color { get; set; }
        public string InsurancePolicyNumber { get; set; }
        public string OwnerName { get; set; }
        public string Address { get; set; }
        public string PESEL { get; set; }
        public string DrivingLicenseNumber { get; set; }
        public DateTime DrivingLicenseIssueDate { get; set; }
        public int PurchaseYear { get; set; }
        public int PenaltyPoints { get; set; }
    }

    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Point operator +(Point p1, Point p2)
        {
            return new Point(p1.X + p2.X, p1.Y + p2.Y);
        }

        public static bool operator true(Point p)
        {
            return p.X != 0 || p.Y != 0;
        }

        public static bool operator false(Point p) 
        { 
            return p.X == 0 && p.Y == 0;
        }
        // In order to use the operator ==, the != operator must also be defined
        public static bool operator ==(Point p1, Point p2)
        {
            return p1.X == p2.X && p1.Y == p2.Y;
        }

        public static bool operator !=(Point p1, Point p2) 
        { 
            return !(p1 == p2);
        }

        // In order to use the operator <, the > operator must also be defined
        public static bool operator <(Point p1, Point p2)
        {
            return p1.X < p2.X && p1.Y < p2.Y;
        }

        public static bool operator >(Point p1, Point p2)
        {
            return p1.X > p2.X && p1.Y > p2.Y;
        }

        // In order to use the operator <=, the >= operator must also be defined
        public static bool operator <=(Point p1, Point p2) 
        {
            return p1.X <= p2.X && p1.Y <= p2.Y;
        }

        public static bool operator >=(Point p1, Point p2)
        { 
            return p1.X >= p2.X && p1.Y >= p2.Y;
        }

        public static Point operator ++(Point p)
        {
            return new Point(p.X++, p.Y++);
        }

        public static Point operator --(Point p) 
        {
            return new Point(p.X--, p.Y--);
        }

        public static implicit operator Point(int X_value)
        {
            return new Point(X_value, 0);
        }

        public static explicit operator int(Point p) 
        {
            return p.X + p.Y;
        }

        //CS0111 Typ „Point” już definiuje składową o nazwie „op_Addition” z tymi samymi typami parametrów
        //CS1020 Oczekiwano operatora binarnego z możliwością przeciążenia	
        // += operator cannot be overloaded, because it is overloaded by defining operator + by default
        //public static Point operator +=(Point p1, Point p2)
        //{
        //    p1.X += p2.X;
        //    p1.Y += p2.Y;
        //    return p1;
        //}

        public override string ToString()
        {
            return $"Point({X}, {Y})";
        }

        // A user-defined equality or inequality operator implies that, we also want to override the Equals method
        public override bool Equals(object obj)
        {
            if (obj is Point other)
            {
                return this == other;
            }
            return false;
        }

        // A user-defined equality or inequality operator implies that, we also want to override the GetHashCode function.
        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }
    }


    public delegate void DelegateOperations(int x, int y);
    
    public class Operations
    {
        public void Add(int x, int y)
        {
            Console.WriteLine($"Add: {x} + {y} = {x + y}");
        }

        public void Subtract(int x, int y)
        {
            Console.WriteLine($"Subtract: {x} - {y} = {x - y}");
        }

        public void Multiply(int x, int y)
        {
            Console.WriteLine($"Multiply: {x} * {y} = {x * y}");
        }

        public void Divide(int x, int y)
        {
            try
            {
                Console.WriteLine($"Divide: {x} / {y} = {x / y}");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine($"Division of {y} by zero.");
            }
        }
    }
}
