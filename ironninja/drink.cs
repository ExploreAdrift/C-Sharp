class Drink : IConsumable
{
    public string Name { get; set; }
    public int Calories { get; set; }
    public bool IsSpicy { get; set; }
    public bool IsSweet { get; set; }

    // Implement a GetInfo Method
    // Add a constructor method

    public Drink(string name, int calories, bool isSpicy, bool isSweet)
    {
        Name = name;
        Calories = calories;
        IsSpicy = isSpicy;
        IsSweet = true;
    }

    public string GetInfo()
    {
        Console.WriteLine(" ");
        Console.WriteLine($"{Name} - Calories: {Calories}. Spicy?: {IsSpicy}, Sweet?: {IsSweet}");
        Console.WriteLine(" ");
        return $"{Name} (drink).  Calories: {Calories}.  Spicy?: {IsSpicy}, Sweet?: {IsSweet}";
    }
}