using ToDoList;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ToDoListApp3.View
{
    public sealed partial class AboutPage : Page
    {
        public AboutPage()
        {
            this.InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Window.Current.Content = new MainPage();
        }
    }
}
