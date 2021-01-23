using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Verivox.Domain.Common
{
    [ExcludeFromCodeCoverage]
    public class VerivoxConstants
    {        
        public class ProductA 
        {
            public const int TarifePerMonth = 5;            
            public const int MonthsPerYear = 12;
            public const double CostPerkWh = 0.22;
            public const int TariffPerYar = TarifePerMonth * MonthsPerYear;
        }

        public class ProductB
        {
            public const int BaseTariff = 800;
            public const int FlatUsagePolicy = 4000;
            public const double CostPerkWh = 0.3;
        }
    }
}
