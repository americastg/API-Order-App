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
            Console.WriteLine("EXECUÇÕES COM ORDEM SIMPLES");
            await SimpleOrderExample.RunAsync();
            Console.WriteLine();

            await Task.Delay(2000);

            Console.WriteLine("EXECUÇÕES COM SPREAD");
            await SpreadExample.RunAsync();
            Console.WriteLine();

            Console.WriteLine("Aperte qualquer tecla para encerrar");
            Console.ReadKey();
        }
    }
}