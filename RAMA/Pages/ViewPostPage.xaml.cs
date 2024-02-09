using RAMA.Models;
using RAMA.ViewModels;

namespace RAMA.Pages;

public partial class ViewPostPage : ContentPage
{
	public ViewPostPage(object? data)
	{
		InitializeComponent();

		var postItem = data as Post;

		var viewModel = new ViewPostViewModel();


        if (postItem != null)
		{
			viewModel.Id = postItem.Id;
			viewModel.UserId = postItem.UserId;
			viewModel.Body = postItem.Body;
			viewModel.Title = postItem.Title;
		}


		BindingContext = viewModel;
	}
}