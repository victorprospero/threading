using System;
using System.Threading.Tasks;

namespace Threading.Models
{
    public class CoffeeFilter
    {
        public async Task PrepareFilter(CoffeePot.CoffeeSize dosage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("CoffeeFilter::Putting paper...");
            await Task.Delay(4000);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("CoffeeFilter::Filter paper is ok...");
            await Task.Delay(1000);
            for (uint i = 0; i < (uint)dosage; i += 30)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("CoffeeFilter::Adding coffee powder...");
                await Task.Delay(1000);
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("CoffeeFilter::The filter is ready...");
        }

        public async Task ReceiveWater(CoffeePot.CoffeeSize dosage)
        {
            for (uint i = 0; i < (uint)dosage; i += 20)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("CoffeeFilter::Receiving Water...");
                await Task.Delay(1000);
            }
        }
        
        public async Task Clean()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("CoffeeFilter::Discarding paper...");
            await Task.Delay(5000);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("CoffeeFilter::The filter is clean...");
        }
    }
}
