using System;

namespace Aplikacja6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tasks 4 and 5 have no code to run, only implementation in classes is provided at the bottom of this file. ");
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
            ChristmasTree Tree = new ChristmasTree("Christmas Tree", 5);
            Console.WriteLine("Add baubles to the Christmas Tree:");
            // Add baubles
            Tree.Add("White", "Angel");
            Tree.Add("Gold", "Star");
            Tree.Add("Blue", "Ball");
            Tree.Add("Green", "Ball");
            Tree.Add("White", "Ball");
            Console.WriteLine("Get bauble color by specified index:");
            Console.WriteLine($"index = 4, bauble color={Tree[4]}");
            Console.WriteLine("Count baubles by specified color:");
            Console.WriteLine($"Number of white baubles: {Tree["White"]}");
            Console.WriteLine("Change bauble color of index=4:");
            Console.WriteLine($"Old color of bauble with index=4: {Tree[4]}");
            Tree[4, "Orange"] = "Orange";
            Console.WriteLine($"New color of bauble with index=4: {Tree[4]}");
            // bauble remove
            Console.WriteLine("Remove bauble with color=Gold");
            Console.WriteLine($"Number of gold baubles before removal: {Tree["Gold"]}");
            Tree.Remove(1);
            Console.WriteLine($"Number of gold baubles after removal: {Tree["Gold"]}");
        }

        static void Task2()
        {
            ChristmasTreeA TreeA = new ChristmasTreeA("Christmas Tree A", 5);
            TreeA.Add("White", "Angel");
            TreeA.Add("Gold", "Star");
            TreeA.Add("Blue", "Ball");
            TreeA.Add("Green", "Ball");
            TreeA.Add("White", "Ball");
            Console.WriteLine($"Bauble type of index=0: {TreeA[0]}"); 
            Console.WriteLine($"Bauble type of index=1: {TreeA[1]}");

            Console.WriteLine($"Bauble color of index=2: {TreeA.BaubleColor(2)}");
            Console.WriteLine($"Bauble color of index=4: {TreeA.BaubleColor(4)}");

            ChristmasTree TreeBase = (ChristmasTree)TreeA;
            Console.WriteLine($"Bauble type with index=1 (after type casting): {TreeBase[1]}");
        }

        static void Task3()
        {
            ChristmasTreeB TreeB = new ChristmasTreeB("Christmas Tree B", 5);
            TreeB.Add("White", "Angel");
            TreeB.Add("Gold", "Star");
            TreeB.Add("Blue", "Ball");
            TreeB.Add("Green", "Ball");
            TreeB.Add("White", "Ball");
            Console.WriteLine($"Bauble type of index=0: {TreeB[0]}");
            Console.WriteLine($"Bauble type of index=1: {TreeB[1]}");

            ChristmasTreeA TreeA = (ChristmasTreeA)TreeB;
            Console.WriteLine($"Bauble type with index=0 (after type casting): {TreeA[0]}");

        }
    }

    public class Tree
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Tree(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }

    public class Fir : Tree
    {
        protected internal List<Bauble> baubles;

        public Fir(string name, int age) : base(name, age)
        {
            baubles = new List<Bauble>();
        }

        public class Bauble
        {
            public string Color { get; set; }
            public string Type { get; set; }

            public Bauble(string color, string type) 
            {
                Color = color;
                Type = type;
            }
        }

        public void Add(string color, string type)
        {
            baubles.Add(new Bauble(color, type));
        }

        public void Remove(int index)
        {
            if (index >= 0 && index < baubles.Count)
            {
                baubles.RemoveAt(index);
            }
            else
            {
                Console.WriteLine("Invalid index!");
            }
        }

        // Indekser 1
        public virtual string this[int index]
        {
            get
            {
                if (index >= 0 && index < baubles.Count)
                {
                    return baubles[index].Color;
                }
                return "Invalid index!";
            }
        }

        // Indekser 2
        public int this[string color]
        {
            get
            {
                int counter = 0;
                foreach (var bauble in baubles)
                {
                    if(bauble.Color == color)
                    {
                        counter++;
                    }
                }
                return counter;
            }
        }

        //Indekser 3
        public string this[int index, string color]
        {
            set
            {
                if (index >= 0 && index < baubles.Count)
                {
                    baubles[index].Color = color;
                }
                else
                {
                    Console.WriteLine("Invalid index!");
                }
            }
        }
    }

    public class ChristmasTree : Fir
    {
        public ChristmasTree(string name, int age) : base(name, age) { }
    }

    public class ChristmasTreeA : ChristmasTree
    {
        public ChristmasTreeA(string name, int age) : base(name, age) { }

        public override string this[int index]
        {
            get
            {
                if (index >= 0 && index < baubles.Count)
                {
                    return baubles[index].Type;
                }
                return "Invalid index!";
            }
        }

        public string BaubleColor(int index)
        {
            return base[index];
        }
    }

    public class ChristmasTreeB : ChristmasTreeA
    {
        public ChristmasTreeB(string name, int age) : base(name, age) { }

        public new string this[int index]
        {
            get
            {
                if (index >= 0 && index < baubles.Count)
                {
                    return $"{baubles[index].Color}_{baubles[index].Type}";
                }
                return "Invalid index!";
            }
        }
    }
    // Definition of the ChristmasTreeC class as sealed, prevents further inheritance
    public sealed class ChristmasTreeC : ChristmasTreeB
    {
        public ChristmasTreeC(string name, int age) : base(name, age) { }

    }

    public abstract class Home
    {
        // This abstract method have to be overriden in derived classes
        public abstract int Price();
    }

}
