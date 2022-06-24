using linqeruption.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddHttpContextAccessor();

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        builder.Services.AddSession();

        var app = builder.Build();


        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
        }
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.UseSession();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");



        List<Eruption> eruptions = new List<Eruption>()
{
    new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
    new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
    new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
    new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
    new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
    new Eruption("Santorini", 46,"Greece", 367, "Shield Volcano"),
    new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
    new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
    new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
    new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
    new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
};
        // Example Query - Prints all Stratovolcano eruptions
        IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
        PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions.");
        // Execute Assignment Tasks here!

        IEnumerable<Eruption> firstChile = eruptions.Where(c => c.Location == "Chile");
        PrintEach(firstChile, "Chile eruptions");

        IEnumerable<Eruption> firstHawaii = eruptions.Where(h => h.Location == "Hawaiian Is");
        PrintEach(firstHawaii, "Hawaii eruptions");

        IEnumerable<Eruption> elevation = eruptions.Where(e => e.ElevationInMeters > 2000);
        PrintEach(elevation, "Eruptions high than 2000m");

        IEnumerable<Eruption> newZealand = eruptions.Where(c => c.Location == "New Zealand").OrderBy(l => l.Year > 1900);
        PrintEach(newZealand, "New Zealand eruptions over 1900!");

        IEnumerable<Eruption> zooZ = eruptions.Where(p => p.Volcano.StartsWith("z"));
        PrintEach(zooZ, "Volcanoes that start with the letter z");

        IEnumerable<Eruption> alpha = eruptions.OrderBy(p => p.Volcano);
        PrintEach(alpha, "Volcanoes in alphabetical name!");

        IEnumerable<Eruption> CE = eruptions.OrderBy(p => p.Volcano).Where(b => b.Year < 1000);
        PrintEach(CE, "Volcanoes that erupted before 1000 CE!");

        IEnumerable<Eruption> maxElevation = eruptions.Where(p => p.ElevationInMeters > 0);
        List<int> maxElev = new List<int>();

        foreach (Eruption one in maxElevation)
        {
            maxElev.Add(one.ElevationInMeters);
        }
        int newMax = maxElev.Max();

        Console.WriteLine(newMax);







        // var Elev = maxElev.Max(a => a.ElevationInMeters);
        // Console.WriteLine("The highest fucking one is: {0}", Elev);



        // Helper method to print each item in a List or IEnumerable.This should remain at the bottom of your class!
        static void PrintEach(IEnumerable<dynamic> items, string msg = "")
        {
            Console.WriteLine("\n" + msg);
            foreach (var item in items)
            {
                Console.WriteLine(item.ToString());
            }

        }

        app.Run();
    }
}