using System.Threading.Tasks;

namespace Threading.Models
{
    public class CoffeePot : Pot
    {
        public enum CoffeeSize : uint
        {
            Small = 50,
            Medium = 100,
            Big = 200
        }
        public CoffeePot() : base(500) { }

        public async Task ServeWater(CoffeeSize dosage)
        {
            await base.ServeWater((uint)dosage);
        }
    }
}
