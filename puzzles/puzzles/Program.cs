static void RandomArray()
{
    int[] numArray = new int[10];
    int min = 25;
    int max = 5;

    Random rand = new Random();
    for (int i = 0; i < numArray.Length; i++)
    {


        numArray[i] = rand.Next(5, 26);
        Console.WriteLine(numArray[i]);

        if (numArray[i] < min)
            min = numArray[i];

        if (numArray[i] > max)
            max = numArray[i];

    }

    Console.WriteLine($"The minimum is: {min}");
    Console.WriteLine($"The maximum is: {max}");

    int sum = numArray.Sum();
    Console.WriteLine($"The sum is: {sum}");

    // shuffle numbers in a list
    List<int> numbers = new List<int>(){
    1,2,3,4,5,6,7,8,9
    };
    List<int> shuffledNumbers = new List<int>();

    Random rand2 = new Random();
    while (numbers.Count > 0)
    {
        int randIndex = rand2.Next(0, numbers.Count);
        shuffledNumbers.Add(numbers[randIndex]);
        numbers.RemoveAt(randIndex);
    }

    foreach (int num in shuffledNumbers)
    {
        Console.WriteLine(num);
    }




}
RandomArray();




// static void TossCoin()
// {


//     Console.WriteLine("Tossing a Coin!");

//     Random CoinGen = new Random();
//     int CoinResult = CoinGen.Next(1, 3);
//     if (CoinResult == 1)
//     {
//         Console.WriteLine("Heads");
//     }

//     if (CoinResult == 2)
//     {
//         Console.WriteLine("Tails");
//     }

// }
// TossCoin();