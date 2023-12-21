using System;
using System.Threading.Tasks;
using Threading.Models;

namespace Threading
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            CoffeePot.CoffeeSize size = CoffeePot.CoffeeSize.Medium;
            CoffeePot pot = new CoffeePot();
            CoffeeFilter filter = new CoffeeFilter();

            await pot.PutWater();
            await Task.WhenAll(pot.HeatWater(), filter.PrepareFilter(size)); // Here we have 2 parallel tasks
            await filter.ReceiveWater(size);
            await filter.Clean();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Program::The coffee is ready to be served");
        }
    }
}
