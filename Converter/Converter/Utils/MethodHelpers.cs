using System;

namespace Converter.Utils
{
    public static class MethodHelpers
    {
        /// <summary>
        /// В Mono x86 под андроид бага, которая проявляется только в эмуляторе.
        /// На реальном устройстве все работает. 
        /// Методы decimal.Parse() и Convert.ToDecimal() работают не правильно.
        /// Тоже самое с double.
        /// </summary>
        public static decimal Parse(string str)
        {
            decimal result;

            try
            {
                // Под Mono x86 точка не допускается и FormatException
                result = decimal.Parse(str);
            }
            catch (FormatException ex)
            {
                // Под Mono ARM точка допускается, а без точки - не корректный результат
                result = decimal.Parse(str.Replace(".",","));
            }
            return result;
        }
    }
}
