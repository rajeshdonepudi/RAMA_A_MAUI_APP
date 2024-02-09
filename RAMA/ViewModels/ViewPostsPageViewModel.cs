using Humanizer;
using RAMA.Models;
using System.Collections.ObjectModel;
using System.Net.Http.Json;

namespace RAMA.ViewModels
{
    public class ViewPostsPageViewModel
        : BindableObject
    {
        public static readonly BindableProperty IsRefreshingProperty =
            BindableProperty.Create(nameof(IsRefreshing), typeof(bool), typeof(ViewPostsPageViewModel), false);

        public bool IsRefreshing
        {
            get { return (bool)GetValue(IsRefreshingProperty); }
            set { SetValue(IsRefreshingProperty, value); }
        }

        public static readonly BindableProperty PostsProperty =
            BindableProperty.Create(nameof(Posts), typeof(ObservableCollection<Post>), typeof(ViewPostsPageViewModel), default(ObservableCollection<Post>));

        public ObservableCollection<Post> Posts
        {
            get { return (ObservableCollection<Post>)GetValue(PostsProperty); }
            set { SetValue(PostsProperty, value); }
        }

        private readonly IHttpClientFactory _httpClientFactory;
        public ViewPostsPageViewModel()
        {

        }
        public ViewPostsPageViewModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;

            Posts = new ObservableCollection<Post>();
        }

        public async Task UpdatePosts()
        {
            IsRefreshing = true;
            var posts = await GetPosts();
            Posts.Clear();
            foreach (var post in posts)
            {
                //post.Body = post.Body.Replace("\n", "").Truncate(50);
                //post.Title = post.Title.Replace("\n", "").Truncate(30);
                Posts.Add(post);
            }
            IsRefreshing = false;
        }

        private async Task<List<Post>> GetPosts()
        {
            var client = _httpClientFactory.CreateClient();
            var posts = await client.GetFromJsonAsync<List<Post>>("https://jsonplaceholder.typicode.com/posts");
            return posts ?? new List<Post>();
        }
    }
}
