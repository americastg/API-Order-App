using System;
using System.Threading.Tasks;
using Strategies.SimpleOrder;
using Strategies.Spread;

namespace RestApiApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await SimpleOrderExample.RunAsync();
            await SpreadExample.RunAsync();

            Console.WriteLine("Press any key to close");
            Console.ReadKey();
        }
    }
}