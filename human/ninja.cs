public class Ninja : Human
{


    public Ninja(string name) : base(name)
    {
        Name = name;
        Strength = 3;
        Intelligence = 3;
        Dexterity = 175;
        Health = 100;
    }

    // Build Attack method
    public override int Attack(Human target)
    {
        int dmg = Dexterity * 5;
        Random rand = new Random();
        int x = rand.Next(1, 6);
        if (x == 5)
        {
            Console.WriteLine($"{Name} rolled a 5 so another 10 damage is hit on you!");
            dmg += 10;
        }
        target.Health -= dmg;
        Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
        return target.Health;
    }
    public int Steal(Human target)
    {
        int steal = 5;
        target.Health -= steal;
        Health += steal;
        Console.WriteLine($"{Name} stole {target.Name} for {steal} health!");
        return target.Health;
    }
}