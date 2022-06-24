class SpiceHound : Ninja
{

    public override bool IsFull
    {
        get { return calorieIntake >= 1200; }
    }
    public override void Consume(IConsumable item)
    {
        if (!IsFull)
        {
            calorieIntake += item.Calories;
            ConsumptionHistory.Add(item);
            item.GetInfo();
            if (item.IsSpicy)
            {
                calorieIntake -= 5;
            }
        }
        else
        {
            Console.WriteLine("Your ass is full");
        }
        // provide override for Consume

    }

}
