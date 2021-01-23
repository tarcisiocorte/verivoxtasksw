using System;
using Verivox.Domain.Common;
using Verivox.Model;

namespace Verivox.Domain
{
    public class ProductA : ITariffCalculator
    {
        public ProductModel CalculateTariff(ProductModel product,int consumptionPerYear)
        {
            var resultTariff = VerivoxConstants.ProductA.TariffPerYar
                            + (consumptionPerYear * VerivoxConstants.ProductA.CostPerkWh);

            return new ProductModel(product.Title, resultTariff);
        }
    }
}
