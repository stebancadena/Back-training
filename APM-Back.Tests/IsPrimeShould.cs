using APM_Back.Services;
using Xunit;

namespace APM_Back.Tests.Services
{
    public class IsPrimeShould
    {
        private readonly PrimeService _primeService;

        public IsPrimeShould()
        {
            _primeService = new PrimeService();
        }

        //[Theory]
        //[InlineData(-1)]
        //[InlineData(0)]
        //[InlineData(1)]
        //public void TestLessThan2(int value)
        //{
        //    bool result = _primeService.IsPrime(value);

        //    Assert.False(result, $"{value} should not be prime");
        //}

        //[Theory]
        //[InlineData(2)]
        //[InlineData(3)]
        //[InlineData(5)]
        //[InlineData(7)]
        //[InlineData(127)]
        //public void TestNumbersTrue(int value)
        //{
        //    bool result = _primeService.IsPrime(value);

        //    Assert.True(result, $"{value} should be prime");
        //}

        //[Theory]
        //[InlineData(4)]
        //[InlineData(6)]
        //[InlineData(8)]
        //[InlineData(9)]
        //[InlineData(119)]
        //public void TestNumbersFalse(int value)
        //{
        //    bool result = _primeService.IsPrime(value);

        //    Assert.False(result, $"{value} should not be prime");
        //}
    }
}
