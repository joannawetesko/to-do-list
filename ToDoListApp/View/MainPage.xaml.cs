using ToDoList.ViewModel;
using ToDoListApp3.View;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.ApplicationModel.Resources;

namespace ToDoList
{
    public sealed partial class MainPage : Page
    {
      
        public MainPage()
        {
            this.InitializeComponent();
            DataContext = MainViewModel.Singleton();
            TextBoxControl.UsernameTextBox.Text = getViewModel().loadLocalSettings();

            if (TextBoxControl.UsernameTextBox.Text != "")
            {
                Window.Current.Content = new Login();
            }
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxControl.UsernameTextBox.Text != "")
            {
                getViewModel().saveLocalSettings(TextBoxControl.UsernameTextBox.Text);
                Window.Current.Content = new Login();
            }
            else
            {
                var rl = new ResourceLoader();
                MessageDialog error = new MessageDialog(rl.GetString("ErrorText"));
                error.ShowAsync();
            }
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            Window.Current.Content = new AboutPage();
        }

        private MainViewModel getViewModel()
        {
            return DataContext as MainViewModel;
        }

    }
}
