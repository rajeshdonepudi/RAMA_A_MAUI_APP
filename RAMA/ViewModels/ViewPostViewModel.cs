namespace RAMA.ViewModels
{
    public class ViewPostViewModel : BindableObject
    {
        public static readonly BindableProperty UserIdProperty =
        BindableProperty.Create(nameof(UserId), typeof(int), typeof(ViewPostViewModel), default(int));

        public int UserId
        {
            get { return (int)GetValue(UserIdProperty); }
            set { SetValue(UserIdProperty, value); }
        }

        public static readonly BindableProperty IdProperty =
            BindableProperty.Create(nameof(Id), typeof(int), typeof(ViewPostViewModel), default(int));

        public int Id
        {
            get { return (int)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }

        public static readonly BindableProperty TitleProperty =
            BindableProperty.Create(nameof(Title), typeof(string), typeof(ViewPostViewModel), string.Empty);

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly BindableProperty BodyProperty =
            BindableProperty.Create(nameof(Body), typeof(string), typeof(ViewPostViewModel), string.Empty);

        public string Body
        {
            get { return (string)GetValue(BodyProperty); }
            set { SetValue(BodyProperty, value); }
        }
    }
}
