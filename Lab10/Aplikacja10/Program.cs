using System;
using System.Threading;

class Program
{
    // Semaphore to control when the trunk can be drawn
    static SemaphoreSlim semaphore = new SemaphoreSlim(0, 1);

    static void Main(string[] args)
    {
        // Create threads for drawing decorations and the trunk
        Thread decorationsThread = new Thread(DrawDecorations);
        Thread trunkThread = new Thread(DrawTrunk);

        // Start both threads
        decorationsThread.Start();
        trunkThread.Start();

        // Wait for both threads to complete
        decorationsThread.Join();
        trunkThread.Join();
    }

    // Drawing the decorated tree
    static void DrawDecorations()
    {
        Console.Clear();
        int height = 20;
        Random random = new Random();

        for (int i = 0; i < height; i++)
        {
            Thread.Sleep(100);

            int spaces = height - i - 1;
            int elements = 2 * i + 1;

            lock (Console.Out) // Synchronize console access
            {
                Console.Write(new string(' ', spaces));
            }

            // Draw decorations
            for (int j = 0; j < elements; j++)
            {
                char[] decorations = { '*', 'o', '.', '+', '^', '~' };
                char symbol = decorations[random.Next(decorations.Length)];

                lock (Console.Out)
                {
                    Console.Write(symbol);
                }
            }

            lock (Console.Out)
            {
                Console.WriteLine();
            }
        }

        // Release the semaphore to signal that the trunk can be drawn
        semaphore.Release();
    }

    // Drawing the trunk of the tree
    static void DrawTrunk()
    {
        // Wait for the semaphore signal before starting to draw the trunk
        semaphore.Wait();

        int height = 20;
        int trunkWidth = height / 4;
        int trunkHeight = 3;
        int trunkSpaces = height - trunkWidth / 2 - 1;

        for (int i = 0; i < trunkHeight; i++)
        {
            Thread.Sleep(100);

            lock (Console.Out)
            {
                Console.Write(new string(' ', trunkSpaces));
                Console.WriteLine(new string('|', trunkWidth));
            }
        }
    }
}
