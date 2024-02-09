using RAMA.Models;
using RAMA.ViewModels;

namespace RAMA.Pages;

public partial class ViewPostsPage : ContentPage
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ViewPostsPageViewModel _viewModel;

    public ViewPostsPage(IHttpClientFactory httpClientFactory)
    {
        InitializeComponent();

        _httpClientFactory = httpClientFactory;

        _viewModel = new ViewPostsPageViewModel(_httpClientFactory);

        BindingContext = _viewModel;

    }

    protected async override void OnAppearing()
    {
        await _viewModel.UpdatePosts();
    }
    public async void OnPullToRefreshRefreshing(object sender, EventArgs args)
    {
        _viewModel.IsRefreshing = true;
        await _viewModel.UpdatePosts();
        _viewModel.IsRefreshing = false;
    }

    public void OnPullToRefreshRefreshed(object sender, EventArgs args)
    {
    }

    private async void postsList_ItemTapped(object sender, Syncfusion.Maui.ListView.ItemTappedEventArgs e)
    {
        if(e.DataItem is not null)
        {
            var post = e.DataItem as Post;

            await Navigation.PushAsync(new ViewPostPage(post));
        }
    }
}