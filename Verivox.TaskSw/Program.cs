using System;
using System.Diagnostics.CodeAnalysis;
using Verivox.Domain;
using Verivox.Service;

namespace Verivox.TaskSw
{
    [ExcludeFromCodeCoverage]
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please, input the annual electric consumption.");
            string strConsumptionPerYear = Console.ReadLine();
            int.TryParse(strConsumptionPerYear, out var consuptionPerYear);

            ITariffCalculator productA = new ProductA();
            ITariffCalculator productB = new ProductB();

            TariffCalculateService service = new TariffCalculateService(productA, productB);
            var list = service.GetList(consuptionPerYear);

            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("See the two products sorted by annual tariff.");
            int count = 0;
            list.ForEach(x =>
            {
                count += 1;
                Console.WriteLine($"{count} - {x.Title}: {x.AnnualTariff} euros");
            });

            Console.ReadKey();
        }
    }
}
