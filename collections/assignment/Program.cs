// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

int[] arrayOfInts = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
Console.WriteLine(arrayOfInts[0]);    // The first number lives at index 0.
Console.WriteLine(arrayOfInts[1]);    // The second number lives at index 1.
Console.WriteLine(arrayOfInts[2]);    // The third number lives at index 2.
Console.WriteLine(arrayOfInts[3]);    // The fourth number lives at index 3.
Console.WriteLine(arrayOfInts[4]);    // The fifth and final number lives at index 4.
Console.WriteLine(arrayOfInts[5]);    // The fourth number lives at index 3.
Console.WriteLine(arrayOfInts[6]);    // The fifth and final number lives at index 4.
Console.WriteLine(arrayOfInts[7]);    // The fourth number lives at index 3.
Console.WriteLine(arrayOfInts[8]);    // The fifth and final number lives at index 4.

string[] myNames = new string[] { "Tim", "Martin", "Nikki", "Sara" };
// The 'Length' property tells us how many values are in the Array (4 in our example here). 
// We can use this to determine where the loop ends: Length-1 is the index of the last value. 
for (int idx = 0; idx < myNames.Length; idx++)
{
    Console.WriteLine($"{myNames[idx]}");
}

bool[] arrayOfBool = { true, false };
Console.WriteLine(arrayOfBool[0]);
Console.WriteLine(arrayOfBool[1]);
Console.WriteLine(arrayOfBool[0]);
Console.WriteLine(arrayOfBool[1]);
Console.WriteLine(arrayOfBool[0]);
Console.WriteLine(arrayOfBool[1]);
Console.WriteLine(arrayOfBool[0]);
Console.WriteLine(arrayOfBool[1]);
Console.WriteLine(arrayOfBool[0]);
Console.WriteLine(arrayOfBool[1]);



// //Initializing an empty list of Motorcycle Manufacturers
// List<string> iceCream = new List<string>();
// //Use the Add function in a similar fashion to push
// iceCream.Add("Vanilla");
// iceCream.Add("Chocolate");
// iceCream.Add("Peach");
// iceCream.Add("Rocky Road");
// iceCream.Add("Mint");

// OR

List<string> flavors = new List<string>(){
    "green bean",
    "chocolate chip cookie dough",
    "dulce de leche",
    "mango habanero",
    "lobster"
};

Console.WriteLine(flavors.Count);

Console.WriteLine(flavors[2]);
flavors.RemoveAt(2);

Console.WriteLine(flavors.Count);

foreach (string flavor in flavors)
{
    Console.WriteLine(flavor);
}

//Accessing a generic list value is the same as you would an array
// Console.WriteLine(iceCream[2]); //Prints "ice cream at 2 index"
// Console.WriteLine($"We currently know of {iceCream.Count} kinds.");

//Using our array of motorcycle manufacturers from before
//we can easily loop through the list of them with a C-style for loop
//this time, however, Count is the attribute for a number of items.
// for (var idx = 0; idx < iceCream.Count; idx++)
// {
//     Console.WriteLine("-" + iceCream[idx]);
// }
// // Insert a new item between a specific index
iceCream.Insert(2, "Candy");
//Removal from Generic List
//Remove is a lot like Javascript array pop, but searches for a specified value
//In this case we are removing all manufacturers located in Japan
iceCream.Remove("Mint");
iceCream.Remove("Candy");
iceCream.RemoveAt(0); //RemoveAt has no return value however
//The updated list can then be iterated through using a foreach loop
Console.WriteLine("List of Non-Japanese Manufacturers:");
foreach (string ice in iceCream)
{
    Console.WriteLine("-" + ice);
}

Dictionary<string, string> profile = new Dictionary<string, string>();
//Almost all the methods that exists with Lists are the same with Dictionaries
profile.Add("Name", "Nick");
profile.Add("Language", "French");
profile.Add("Location", "Iceland");
Console.WriteLine("Instructor Profile");
Console.WriteLine("Name - " + profile["Name"]);
Console.WriteLine("From - " + profile["Location"]);
Console.WriteLine("Favorite Language - " + profile["Language"]);











