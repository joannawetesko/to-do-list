using System;
using System.Collections.ObjectModel;
using Windows.Storage;

namespace ToDoList.ViewModel
{
    public class MainViewModel : ViewModel
    {
        private static MainViewModel MVVMinstance { get; set; }

        public static string OwnerId { get { return ownerId; } set { ownerId = value; } }
        private static string ownerId { get; set; }

        public ObservableCollection<ToDoTask> TaskList
            { get { return taskList; } set { taskList = value; OnPropertyChanged("TaskList"); } }
        private ObservableCollection<ToDoTask> taskList;

        public ToDoTask CurrentTask
            { get { return currentTask; } set { currentTask = value; OnPropertyChanged("CurrentTask"); } }
        private ToDoTask currentTask { get; set; }

        public static MainViewModel Singleton()
        {
            if (MVVMinstance == null)
            {
                MVVMinstance = new MainViewModel();
            }
            return MVVMinstance;
        }

        //Local settings manager

        private ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
        private const string USERNAME_TAG = "Owner";


        public void saveLocalSettings(string username)
        {
            localSettings.Values[USERNAME_TAG] = username;
        }

        public string loadLocalSettings()
        {
            Object value = localSettings.Values[USERNAME_TAG];
            if (value == null)
                ownerId = "";
            else
                ownerId = value.ToString();

            return ownerId;
        }

        public void removeLocalSettings()
        {
            localSettings.Values.Remove(USERNAME_TAG);
            ownerId = "";
        }

    }
}
