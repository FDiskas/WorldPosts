using System.Windows;
using System.Windows.Controls;
using WorldPosts.Models;

namespace WorldPosts.Components
{
    /// <summary>
    /// Interaction logic for PostView.xaml
    /// </summary>
    public partial class PostView : UserControl
    {
        public static RoutedEvent ViewModeChangeEvent = EventManager.RegisterRoutedEvent(
            "ViewModeChange", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(PostView)
        );

        public static readonly DependencyProperty PostProperty = DependencyProperty.Register(
            "Post", typeof(Post), typeof(PostView), new PropertyMetadata(new Post(), new PropertyChangedCallback(OnDataChange))
        );

        public static readonly DependencyProperty ViewModeProperty = DependencyProperty.Register(
            "ViewMode", typeof(ViewMode), typeof(PostView), new PropertyMetadata(ViewMode.OwnId, new PropertyChangedCallback(OnDataChange))
        );

        public static readonly DependencyProperty VisibleIdProperty = DependencyProperty.Register(
            "VisibleId", typeof(string), typeof(PostView), new PropertyMetadata("")
        );

        public event RoutedEventHandler ViewModeChange
        {
            add { AddHandler(ViewModeChangeEvent, value); }
            remove { RemoveHandler(ViewModeChangeEvent, value); }
        }

        public Post Post
        {
            get { return (Post)GetValue(PostProperty); }
            set { SetValue(PostProperty, value); }
        }

        public ViewMode ViewMode
        {
            get { return (ViewMode)GetValue(ViewModeProperty); }
            set { SetValue(ViewModeProperty, value); }
        }

        public string VisibleId
        {
            get { return (string)GetValue(VisibleIdProperty); }
            protected set { SetValue(VisibleIdProperty, value); }
        }

        public PostView()
        {
            InitializeComponent();
        }

        private static void OnDataChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var postView = d as PostView;

            if (postView == null)
            {
                return;
            }

            var label = postView.ViewMode == ViewMode.OwnId ? Properties.Resources.IdLabel : Properties.Resources.UserIdLabel;
            var id = postView.ViewMode == ViewMode.OwnId ? postView.Post.Id : postView.Post.UserId;

            postView.VisibleId = string.Concat(label, ": ", id);
        }

        private void OnChangeViewModeClick(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(ViewModeChangeEvent));
        }
    }
}
