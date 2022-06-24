internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        // for (int i = 1; i <= 255; i++)
        // {
        //     Console.WriteLine(i);
        // }
        for (int i = 1; i <= 100; i++)
        {
            bool byThreeOrFive = (i % 3 == 0 || i % 5 == 0);
            bool notThreeAndFive = !(i % 3 == 0 && i % 5 == 0);

            if (byThreeOrFive && notThreeAndFive)
            {
                Console.WriteLine(i);
            }
        }

    }
}