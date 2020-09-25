using System.Windows;
using WorldPosts.Services;

namespace WorldPosts
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PostProviderService postProvider = new PostProviderService();

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void OnLoadClick(object sender, RoutedEventArgs e)
        {
            StartLoading();

            PostGridComponent.Posts = await postProvider.GetPosts();

            StopLoading();
        }

        private void StartLoading()
        {
            LoadPostsButton.Visibility = Visibility.Hidden;
            ProgressBarComponent.Visibility = Visibility.Visible;
        }

        private void StopLoading()
        {
            ProgressBarComponent.Visibility = Visibility.Hidden;
            PostGridComponent.Visibility = Visibility.Visible;
        }
    }
}
