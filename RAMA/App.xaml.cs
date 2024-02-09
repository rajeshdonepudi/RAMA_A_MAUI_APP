namespace RAMA
{
    public partial class App : Application
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public App(IHttpClientFactory httpClientFactory)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzA3OTcxN0AzMjM0MmUzMDJlMzBBT0tqSjJTMFNrVVZpTk1xZDZoZjN1MDhGck9wUlBDUGh6NmNicGRHZ05JPQ==");

            InitializeComponent();

            _httpClientFactory = httpClientFactory;

            MainPage = new NavigationPage(new MainPage(_httpClientFactory));
        }
    }
}
