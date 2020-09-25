using System.Collections.Generic;
using System.Windows;
using WorldPosts.Models;
using WorldPosts.Components;

namespace WorldPosts
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnLoadClick(object sender, RoutedEventArgs e)
        {
            LoadPostsButton.Visibility = Visibility.Hidden;

            var posts = new List<Post>
            {
                new Post() { Id = 15, UserId = 95, Title = "Hello", Body = "Hello everyone!" },
                new Post() { Id = 17, UserId = 77, Title = "Hi", Body = "Hi guys!" }
            };

            PostGridComponent.Posts = posts;

            PostGridComponent.Visibility = Visibility.Visible;
        }
    }
}
