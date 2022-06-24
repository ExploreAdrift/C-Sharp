List<object> types = new List<object>();

types.Add(7);
types.Add(28);
types.Add(-1);
types.Add(true);
types.Add("chair");

int sum = 0;

foreach (var type in types)
{
    Console.WriteLine(type);

    if (type is int)
    {
        sum += (int)type;
    }
}

Console.WriteLine(sum);