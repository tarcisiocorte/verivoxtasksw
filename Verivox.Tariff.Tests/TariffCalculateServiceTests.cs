using Moq;
using System;
using Verivox.Domain;
using Verivox.Model;
using Verivox.Service;
using Xunit;
using FluentAssertions;


namespace Verivox.Tariff.Tests
{
    public class TariffCalculateServiceTests
    {
        private readonly ITariffCalculator _tariffCalculatorProductA;
        private readonly ITariffCalculator _tariffCalculatorProductB;
        private readonly ITariffCalculateService _tariffCalculateService;

        public TariffCalculateServiceTests()
        {
            _tariffCalculatorProductA = new ProductA();
            _tariffCalculatorProductB = new ProductB();
            _tariffCalculateService = new TariffCalculateService(_tariffCalculatorProductA, _tariffCalculatorProductB);
        }

        [Fact]
        public void ShouldCreateAnInstanceOfTariffCalculateService()
        {
            var service = new TariffCalculateService(new ProductA(), new ProductB());
            service.Should().NotBeNull();
        }

        [Theory]
        [InlineData(3500)]
        [InlineData(4500)]
        [InlineData(6000)]
        public void ShouldListProductsSortedByCosts(int consumptionPerYear)
        {
            var result = _tariffCalculateService.GetList(consumptionPerYear);
            result.Should().NotBeNull();
            result.Count.Should().Be(2);
            result[0].AnnualTariff.Should().BeLessThan(result[1].AnnualTariff);            
        }

        [Fact]
        public void ShouldListProductsWhenZeroConsumptionPerYearIsProvided()
        {
            var result = _tariffCalculateService.GetList(0);
            result.Should().NotBeNull();
            result.Count.Should().Be(2);
            result[0].AnnualTariff.Should().Be(60);
            result[1].AnnualTariff.Should().Be(800);
        }

        [Fact]        
        public void ShouldListProductsWhenValidParamIsProvided()
        {
            var result = _tariffCalculateService.GetList(9000);
            result.Should().NotBeNull();
            result.Count.Should().Be(2);
            result[0].AnnualTariff.Should().Be(2040);
            result[1].AnnualTariff.Should().Be(2300);
        }
    }
}
