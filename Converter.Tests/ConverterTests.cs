using System.Threading.Tasks;
using Converter.Droid;
using NUnit.Framework;

namespace Converter.Tests
{
    public class ConverterTests
    {
        [Test]
        public async Task Run()
        {
            var firstCurrency = "RUB";
            var secondCurrency = "JPY";
            
            var converter = new AndroidConverter();
            var result = await converter.Convert(firstCurrency, secondCurrency, 5);

            Assert.AreNotEqual(result, 0d);
            Assert.AreNotEqual(result, 5d);
        }
    }
}
