Buffet buffet = new Buffet();
SpiceHound spice = new SpiceHound();
SweetTooth tooth = new SweetTooth();

while (!spice.IsFull)
{
    spice.Consume(buffet.Serve());
}
while (!tooth.IsFull)
{
    tooth.Consume(buffet.Serve());
}

if (spice.ConsumptionHistory.Count > tooth.ConsumptionHistory.Count)
{
    Console.WriteLine($"Spice in the winner and consumed {spice.ConsumptionHistory.Count} items");
}
else
{
    Console.WriteLine($"Tooth in the winner and consumed {tooth.ConsumptionHistory.Count} items");
}

