using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using WorldPosts.Models;

namespace WorldPosts.Components
{
    /// <summary>
    /// Interaction logic for PostGrid.xaml
    /// </summary>
    public partial class PostGrid : UserControl
    {
        public static readonly DependencyProperty PostsViewModeProperty = DependencyProperty.Register(
            "PostsViewMode", typeof(ViewMode), typeof(PostGrid), new PropertyMetadata(ViewMode.OwnId)
        );

        public static readonly DependencyProperty PostsProperty = DependencyProperty.Register(
            "Posts", typeof(List<Post>), typeof(PostGrid), new PropertyMetadata(new List<Post>())
        );

        public ViewMode PostsViewMode
        {
            get { return (ViewMode)GetValue(PostsViewModeProperty); }
            private set { SetValue(PostsViewModeProperty, value); }
        }

        public List<Post> Posts
        {
            get { return (List<Post>)GetValue(PostsProperty); }
            set { SetValue(PostsProperty, value); }
        }

        public PostGrid()
        {
            InitializeComponent();
        }

        private void OnViewModeChange(object sender, RoutedEventArgs e)
        {
            if (PostsViewMode == ViewMode.OwnId)
            {
                PostsViewMode = ViewMode.UserId;

                return;
            }

            PostsViewMode = ViewMode.OwnId;
        }
    }
}
