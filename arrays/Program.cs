// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

string[] myCars = new string[] { "Mazda Miata", "Ford Model T", "Dodge Challenger", "Nissan 300zx" };
// The 'Length' property tells us how many values are in the Array (4 in our example here). 
// We can use this to determine where the loop ends: Length-1 is the index of the last value. 
for (int idx = 0; idx < myCars.Length; idx++)
{
    Console.WriteLine($"I own a {myCars[idx]}");
}

// OR THIS

string[] myCars2 = new string[] { "Mazda Miata", "Ford Model T", "Dodge Challenger", "Nissan 300zx" };
foreach (string car in myCars)
{
    // We no longer need the index, because variable 'car' already represents each indexed value
    Console.WriteLine($"I own a {car}");
}

