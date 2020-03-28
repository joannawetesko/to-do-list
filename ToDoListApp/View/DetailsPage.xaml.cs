using ToDoList;
using ToDoList.ViewModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


namespace ToDoListApp3
{
    public sealed partial class DetailsPage : Page
    {
        public DetailsPage()
        {
            this.InitializeComponent();
            DataContext = MainViewModel.Singleton();
        }

        private MainViewModel getViewModel()
        {
            return DataContext as MainViewModel;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            RESTManager restManager = new RESTManager();
            restManager.deleteTask(getViewModel().CurrentTask);
            Window.Current.Content = new Login();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            getViewModel().CurrentTask.Title = TaskTitleTextBox.Text;
            getViewModel().CurrentTask.Value = TaskValueTextBox.Text;

            RESTManager restManager = new RESTManager();
            restManager.updateTask(getViewModel().CurrentTask);
            Window.Current.Content = new Login();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Window.Current.Content = new Login();
        }
    }
}
