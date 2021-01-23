using System;
using System.Collections.Generic;
using System.Text;
using Verivox.Model;

namespace Verivox.Domain
{
    public interface ITariffCalculator
    {
        ProductModel Calculate(ProductModel product,int consumptionPerYear);
    }
}
