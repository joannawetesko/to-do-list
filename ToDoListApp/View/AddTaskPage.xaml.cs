using System;
using ToDoList.ViewModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ToDoList
{
    public sealed partial class AddTask : Page
    {
        public AddTask()
        {
            this.InitializeComponent();
            DataContext = MainViewModel.Singleton();
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            RESTManager restManager = new RESTManager();
            ToDoTask newTask = new ToDoTask { Id = 0, Title = NewTaskTitleTextBox.Text, Value = NewTaskValueTextBox.Text, OwnerId = MainViewModel.OwnerId, CreatedAt = DateTime.Now.ToString() };
            restManager.postTask(newTask);

            Window.Current.Content = new Login();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Window.Current.Content = new Login();
        }

        private MainViewModel getViewModel()
        {
            return DataContext as MainViewModel;
        }
    }
}
