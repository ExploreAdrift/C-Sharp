class SweetTooth : Ninja
{
    // provide override for IsFull (Full at 1500 Calories)
    public override bool IsFull
    {
        get { return calorieIntake >= 1500; }
    }
    public override void Consume(IConsumable item)
    {
        if (!IsFull)
        {
            calorieIntake += item.Calories;
            ConsumptionHistory.Add(item);
            item.GetInfo();
            if (item.IsSweet)
            {
                calorieIntake += 10;
            }
        }
        else
        {
            Console.WriteLine("Your ass is full");
        }
        // provide override for Consume

    }

}

