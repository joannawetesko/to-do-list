using ToDoList.ViewModel;
using ToDoListApp3;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ToDoList
{
    public sealed partial class Login : Page
    {
        public Login()
        {
            this.InitializeComponent();
            DataContext = MainViewModel.Singleton();
            getViewModel().loadLocalSettings();

            RESTManager restManager = new RESTManager();
            restManager.getTasks(MainViewModel.OwnerId, getViewModel());
        }

        private MainViewModel getViewModel()
        {
            return DataContext as MainViewModel;
        }

        private void Task_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ToDoListBox.SelectedItem == null)
            {
                return;
            }
            else
            {
                getViewModel().CurrentTask = (ToDoTask)ToDoListBox.SelectedItem;
                Window.Current.Content = new DetailsPage();
            }
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            Window.Current.Content = new AddTask();
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            Window.Current.Content = new Login();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            getViewModel().removeLocalSettings();
            DataContext = null;
            Window.Current.Content = new MainPage();
        }

    }
}
