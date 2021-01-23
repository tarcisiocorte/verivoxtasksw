using System;
using System.Collections.Generic;
using System.Text;
using Verivox.Domain;
using Verivox.Model;
using Xunit;
using FluentAssertions;

namespace Verivox.Tariff.Tests
{   

    public class DomainTests
    {
        private readonly ITariffCalculator tariffCalculatorProductA;
        private readonly ITariffCalculator tariffCalculatorProductB;

        public DomainTests()
        {
            this.tariffCalculatorProductA = new ProductA();
            this.tariffCalculatorProductB = new ProductB();

        }
        
        [Fact]
        public void ShouldCalculateTariffWhenValidParamIsProvided()
        {
            ProductModel productA = new ProductModel("A");
            ProductModel productB = new ProductModel("B");

            var resultA = this.tariffCalculatorProductA.Calculate(productA, 9000);
            var resultB = this.tariffCalculatorProductB.Calculate(productB, 9000);

            resultA.Should().NotBeNull();
            resultA.Title.Should().Be("A");
            resultA.AnnualTariff.Should().Be(2040);

            resultB.Should().NotBeNull();
            resultB.Title.Should().Be("B");
            resultB.AnnualTariff.Should().Be(2300);
        }

        [Fact]
        public void ShouldCalculateMinimumTariffWhenZeroIsProvided()
        {
            ProductModel productA = new ProductModel("A");
            ProductModel productB = new ProductModel("B");

            var resultA = this.tariffCalculatorProductA.Calculate(productA, 0);
            var resultB = this.tariffCalculatorProductB.Calculate(productB, 0);

            resultA.Should().NotBeNull();
            resultA.Title.Should().Be("A");
            resultA.AnnualTariff.Should().Be(60);

            resultB.Should().NotBeNull();
            resultB.Title.Should().Be("B");
            resultB.AnnualTariff.Should().Be(800);
        }
    }
}
