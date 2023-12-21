using System;
using System.Threading.Tasks;

namespace Threading.Models
{
    public class Pot
    {
        #region Enums
        public enum ContentState : ushort
        {
            Empty, Cold, Hot
        }
        #endregion

        #region Fields
        private ContentState waterState = ContentState.Empty;
        private uint quantity = 0;
        #endregion

        #region Properties
        public ContentState WaterState { get => waterState; }
        public uint Quantity { get => quantity; }
        public uint Capacity { get; }
        #endregion

        #region Constructors
        public Pot(uint capacity)
        {
            if (capacity < 0)
            {
                throw new InvalidOperationException("Invalid capacity");
            }
            Capacity = capacity;
        }
        #endregion

        #region Methods
        public async Task PutWater()
        {
            uint timeToComplete = await Task.FromResult(Capacity - Quantity);
            if (timeToComplete > 0)
            {
                for (uint i = 0; i < timeToComplete; i += 30)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Pot::Putting Water...");
                    await Task.Delay(500);
                }
                waterState = ContentState.Cold;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Pot::The pot is full of water...");
            quantity = Capacity;
        }
        public async Task HeatWater()
        {
            if (waterState == ContentState.Empty)
            {
                throw new InvalidOperationException("There is no hot water");
            }
            if (waterState == ContentState.Cold)
            {
                for (uint i = 0; i < quantity; i += 25)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Pot::Heating water...");
                    await Task.Delay(1000);
                }
                waterState = ContentState.Hot;
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Pot::The water is hot...");
        }
        public async Task ServeWater(uint dosage)
        {
            if (dosage == 0)
            {
                throw new InvalidOperationException("Invalid dosage");
            }
            if (waterState != ContentState.Hot || dosage > Quantity)
            {
                throw new InvalidOperationException("There is no enough hot water");
            }
            for (uint i = 0; i < dosage; i += 10)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Pot::Serving Water...");
                await Task.Delay(500);
            }
            quantity -= dosage;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Pot::The water was served...");
        }
        #endregion
    }
}
