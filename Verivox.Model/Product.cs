using System;

namespace Verivox.Model
{
    public class ProductModel
    {
        public string Title { get; private set; }
        public double AnnualTariff { get; private set; }

        public ProductModel(string title)
        {
            this.Title = title;
        }

        public ProductModel(string title, double annualTariff)
        {
            this.Title = title;
            this.AnnualTariff = annualTariff;
        }
    }
}
