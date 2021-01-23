using System;
using Verivox.Domain.Common;
using Verivox.Model;

namespace Verivox.Domain
{
    public class ProductB: ITariffCalculator
    {
        public ProductModel CalculateTariff(ProductModel product, int consumptionPerYear)
        {
            double resultTariff = VerivoxConstants.ProductB.BaseTariff;
            if(consumptionPerYear > VerivoxConstants.ProductB.FlatUsagePolicy)
            {
                resultTariff += (consumptionPerYear - VerivoxConstants.ProductB.FlatUsagePolicy) * VerivoxConstants.ProductB.CostPerkWh;
            }
            return new ProductModel(product.Title, resultTariff);
        }
    }
}
