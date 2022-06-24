public class Samurai : Human
{
    public Samurai(string name) : base(name)
    {
        Name = name;
        Strength = 3;
        Intelligence = 3;
        Dexterity = 3;
        Health = 200;
    }


    // Build Attack method
    public override int Attack(Human target)

    {
        base.Attack(target);
        if (target.Health < 50)
        {
            target.Health = 0;
            Console.WriteLine($"{Name} destroyed {target.Name}");
        }
        return target.Health;
    }
    public int Meditate()
    {
        Health = 200;
        Console.WriteLine($"{Name} meditates to full health");
        return Health;
    }
}