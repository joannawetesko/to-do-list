using ToDoList.ViewModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace ToDoList
{
    public sealed partial class TextBoxWithValidation : UserControl
    {
        public TextBoxWithValidation()
        {
            this.InitializeComponent();
            DataContext = MainViewModel.Singleton();
        }

        private void UsernameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (UsernameTextBox.Text == "")
            {
                SolidColorBrush invalidColor = new SolidColorBrush();
                invalidColor.Color = Windows.UI.Color.FromArgb(150, 255, 0, 0);
                UsernameTextBox.BorderBrush = invalidColor;
                UsernameTextBox.Background = invalidColor;
            }
            else
            {
                SolidColorBrush validColor = new SolidColorBrush();
                validColor.Color = Windows.UI.Color.FromArgb(150, 0, 255, 0);
                UsernameTextBox.BorderBrush = validColor;
                UsernameTextBox.Background = validColor;
            }
        }
    }
}
