﻿int[] arrays = { 1, 2, 3, 4, 5 };
int[] negative = { -3, -5, -7 };
int[] arraysNegative = { 1, 2, 3, 4, -8, -4, -3 };
int[] NumToStrings = { 1, 4, 7, 9 };



static void PrintNumbers()
{
    // Print all of the integers from 1 to 255.

    int i = 1;
    while (i < 256)
    {
        Console.WriteLine(i);
        i++;
    }
}
PrintNumbers();




static void PrintOdds()
{
    // Print all of the odd integers from 1 to 255.

    int i = 1;
    while (i < 256)
    {
        Console.WriteLine(i);
        i += 2;
    }
}
PrintOdds();



static void PrintSum()
{
    // Print all of the numbers from 0 to 255, 
    // but this time, also print the sum as you go. 
    // For example, your output should be something like this:

    // New number: 0 Sum: 0
    // New number: 1 Sum: 1
    // New number: 2 Sum: 3

    int i = 1;
    int sum = 0;
    while (i < 256)
    {
        sum += i;
        Console.WriteLine($"New Number {i} Sum:{sum}");
        i++;
    }
}
PrintSum();



static void LoopArray(int[] numbers)
{
    // Write a function that would iterate through each item of the given integer array and 
    // print each value to the console. 

    for (int i = 0; i < numbers.Length; i++)
    {
        Console.Write(numbers[i]);
    }
}
LoopArray(arrays);




static int FindMax(int[] numbers)
{
    // Write a function that takes an integer array and prints and returns the maximum value in the array. 
    // Your program should also work with a given array that has all negative numbers (e.g. [-3, -5, -7]), 
    // or even a mix of positive numbers, negative numbers and zero.

    int max = numbers[0];
    for (int i = 0; i < numbers.Length; i++)
    {
        if (numbers[i] > max)
            max = numbers[i];
    }
    return (max);
}
FindMax(arrays);




static void GetAverage(int[] numbers)
{
    // Write a function that takes an integer array and prints the AVERAGE of the values in the array.
    // For example, with an array [2, 10, 3], your program should write 5 to the console.

    int sum = 0;
    for (int i = 0; i < numbers.Length; i++)
    {
        sum += numbers[i];
    }
    int avg = sum / numbers.Length;
    Console.WriteLine(avg);
}
GetAverage(arrays);




static int[] OddArray()
{
    // Write a function that creates, and then returns, an array that contains all the odd numbers between 1 to 255. 
    // When the program is done, this array should have the values of [1, 3, 5, 7, ... 255].

    int[] allOdds = new int[256 / 2];
    for (int i = 1; i <= 255; i += 2)
    {
        allOdds[i / 2] = i;
    }
    return (allOdds);
}
OddArray();



static int GreaterThanY(int[] numbers, int y)
{
    // Write a function that takes an integer array, and a integer "y" and returns the number of array values 
    // That are greater than the "y" value. 
    // For example, if array = [1, 3, 5, 7] and y = 3. Your function should return 2 
    // (since there are two values in the array that are greater than 3).

    int oddArr = 0;
    foreach (int num in numbers)
    {
        if (num > y)
            oddArr++;
    }
    return oddArr;
}
GreaterThanY(arrays, 3);




static void SquareArrayValues(int[] numbers)
{
    // Write a function that takes an integer array "numbers", and then multiplies each value by itself.
    // For example, [1,5,10,-10] should become [1,25,100,100]

    for (int i = 0; i < numbers.Length; i++)
    {
        numbers[i] = numbers[i] * numbers[i];
    }
}
SquareArrayValues(arrays);




static void EliminateNegatives(int[] numbers)
{
    // Given an integer array "numbers", say [1, 5, 10, -2], create a function that replaces any negative number with the value of 0. 
    // When the program is done, "numbers" should have no negative values, say [1, 5, 10, 0].

    for (int i = 0; i < numbers.Length; i++)
    {
        if (numbers[i] < 0)
            numbers[i] = 0;
        else
            numbers[i] = numbers[i];
    }
}
EliminateNegatives(negative);




static void MinMaxAverage(int[] numbers)
{
    // Given an integer array, say [1, 5, 10, -2], create a function that prints the maximum number in the array, 
    // the minimum value in the array, and the average of the values in the array.

    int max = numbers[0];
    int min = numbers[0];

    for (int i = 0; i < numbers.Length; i++)
    {
        if (numbers[i] > max)
            max = numbers[i];

        if (numbers[i] < min)
            min = numbers[i];
    }

    int avg = (min + max) / 2;
}

MinMaxAverage(arrays);
MinMaxAverage(negative);




static void ShiftValues(int[] numbers)
{
    // Given an integer array, say [1, 5, 10, 7, -2], 
    // Write a function that shifts each number by one to the front and adds '0' to the end. 
    // For example, when the program is done, if the array [1, 5, 10, 7, -2] is passed to the function, 
    // it should become [5, 10, 7, -2, 0].
    for (int i = 0; i < numbers.Length - 1; i++)
    {
        numbers[i] = numbers[i + 1];
    }

    numbers[numbers.Length - 1] = 0;
}
ShiftValues(arraysNegative);




static object[] NumToString(int[] numbers)
{
    // Write a function that takes an integer array and returns an object array 
    // that replaces any negative number with the string 'Dojo'.
    // For example, if array "numbers" is initially [-1, -3, 2] 
    // your function should return an array with values ['Dojo', 'Dojo', 2].

    object[] objects = new object[numbers.Length];
    for (int i = 0; i < numbers.Length; i++)
    {
        if (numbers[i] < 0)
            objects[i] = "Dojo";
        else
            objects[i] = numbers[i];
    }
    return objects;
}

NumToString(NumToStrings);





