using System.Threading.Tasks;

namespace Converter
{
    public interface IConverter
    {
        Task<decimal> Convert(string firstCurrency, string secondCurrency, decimal value);
    }
}
