class Buffet
{
    public List<IConsumable> Menu;
    public Buffet()
    {
        Menu = new List<IConsumable>()
        {
            new Food("chicken nuggies", 1000, false, false),
            new Food("chicken wings", 800, true, false),
            new Food("fried chicken", 1200, false, false),
            new Food("chicken kabobs", 1000, true, false),
            new Food("chicken", 1000, false, false),
            new Food("a chicken", 700, false, false),
            new Drink("whiskey", 400, false, false),
            new Drink("cosmo", 300, false, true),
            new Drink("gingerale", 350, false, true),
            new Drink("vodka martini", 500, false, false),
        };
    }
    public IConsumable Serve()
    {
        Random rand = new Random();
        return Menu[rand.Next(0, Menu.Count())];
    }
}
