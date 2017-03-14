using FSL.XF3.Services;
using Xamarin.Forms;

namespace FSL.XF3
{
    public partial class MainPage : ContentPage
    {
        private readonly CustomersApiClient _customerApiClient;

        public MainPage()
        {
            InitializeComponent();
            _customerApiClient = new CustomersApiClient(); // You can use Dependency Injection
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var result = await _customerApiClient.GetAllCustomers();
            if (result.Success)
            {
                lvCustomers.ItemsSource = result.Data;
            }
        }
    }
}
