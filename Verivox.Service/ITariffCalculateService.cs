using System;
using System.Collections.Generic;
using System.Text;
using Verivox.Domain;
using Verivox.Model;

namespace Verivox.Service
{
    public interface ITariffCalculateService
    {
        List<ProductModel> GetList(int consumptionPerYear);
    }
}
