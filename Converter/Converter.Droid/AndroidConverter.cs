using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Converter.Droid;
using Converter.Models.Json;
using Newtonsoft.Json;
using Xamarin.Forms;

[assembly: Dependency(typeof(AndroidConverter))]
namespace Converter.Droid
{
    public class AndroidConverter : IConverter
    {
        private const string Url = "http://api.fixer.io/latest?base="; 

        public async Task<decimal> Convert(string firstCurrency, string secondCurrency, decimal value)
        {
            var result = await GetRatesAsync(Url + firstCurrency);

            var secondValue = result.Fields.First(x => x.Key == secondCurrency).Value;

            return value * secondValue;
        }

        private async Task<JsonRates> GetRatesAsync(string url)
        {
            using (var clien = new WebClient {Encoding = Encoding.UTF8})
            {
                var raw = await clien.DownloadStringTaskAsync(url);
                var result = JsonConvert.DeserializeObject<JsonResponse>(raw);
                return result.Rates;
            }
        }
    }
}