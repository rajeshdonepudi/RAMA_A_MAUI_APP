using RAMA.Pages;

namespace RAMA
{
    public partial class MainPage : ContentPage
    {
        private readonly IHttpClientFactory httpClientFactory;

        public MainPage(IHttpClientFactory httpClientFactory)
        {
            InitializeComponent();

            this.httpClientFactory = httpClientFactory;
        }

        private async void viewPostsButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ViewPostsPage(httpClientFactory), true);
        }
    }
}
