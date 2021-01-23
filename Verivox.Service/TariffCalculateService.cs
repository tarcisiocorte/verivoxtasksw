using System;
using System.Collections.Generic;
using Verivox.Domain;
using Verivox.Model;

namespace Verivox.Service
{
    public class TariffCalculateService: ITariffCalculateService
    {
        private readonly ITariffCalculator tariffCalculatorProductA;
        private readonly ITariffCalculator tariffCalculatorProductB;

        public TariffCalculateService(ITariffCalculator productA, ITariffCalculator productB)
        {
            this.tariffCalculatorProductA = productA;
            this.tariffCalculatorProductB = productB;
        }
        public List<ProductModel> GetList(int consumptionPerYear)
        {
            List<ProductModel> list = new List<ProductModel>();
            ProductModel productA = new ProductModel("Basic electricity tariff");
            ProductModel productB = new ProductModel("Packaged tariff");
            productA = this.tariffCalculatorProductA.CalculateTariff(productA, consumptionPerYear);
            productB = this.tariffCalculatorProductB.CalculateTariff(productB, consumptionPerYear);

            list.Add(productA);
            list.Add(productB);

            list.Sort((a, b) => a.AnnualTariff.CompareTo(b.AnnualTariff));
            return list;
        }
    }
}
