public class Wizard : Human
{
    public Wizard(string name) : base(name)
    {
        Name = name;
        Strength = 3;
        Intelligence = 25;
        Dexterity = 3;
        Health = 50;
    }

    // Build Attack method
    public override int Attack(Human target)
    {
        int dmg = Intelligence * 5;
        target.Health -= dmg;
        Health += dmg;
        Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage! and healed for {dmg}");
        return target.Health;
    }
    public int Heal(Human target)
    {
        int heal = 10 * Intelligence;
        target.Health += heal;
        Console.WriteLine($"{Name} healed {target.Name} for {heal}");
        return target.Health;

    }
}