using System;
using System.Net;
using Xamarin.Forms;

namespace Converter.Pages
{
    public partial class StartPage : ContentPage
    {
        private const string FirstCurrency = "RUB";

        private const string SecondCurrency = "JPY";

        private const string ValidationErrorMessage = "Введенное значение должно быть числом";

        private const string ConnectionFailure = "Не удалось соединиться с сервисом. Проверьте подключение к интернету";

        public StartPage()
        {
            InitializeComponent();
        }

        public async void OnCalc(object o, EventArgs e)
        {
            decimal value;

            if (decimal.TryParse(EntryMoney.Text, out value) == false)
            {
                ValidationErrors.Text = ValidationErrorMessage;
                return;
            }
            ValidationErrors.Text = string.Empty;
            var converter = DependencyService.Get<IConverter>();

            try
            {
                var result = await converter.Convert(FirstCurrency, SecondCurrency, value);
                ResultMoney.Text = result.ToString();
            }
            catch (WebException ex)
            {
                ValidationErrors.Text = ConnectionFailure;
            }
        }
    }
}
