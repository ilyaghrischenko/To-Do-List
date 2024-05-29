using DataBase;
using DataBase.Models;
using System.Windows;
using System.Windows.Controls;

namespace ApplicationWPF.Windows
{
    public partial class TaskListWindow : Window
    {
        private readonly User _user;

        public TaskListWindow()
        {
            InitializeComponent();
        }
        public TaskListWindow(User user)
        {
            InitializeComponent();
            _user = user;
            LoadAllTasks();
        }

        private async void TasksList_AutoGeneratingColumn(object sender, System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "Id" || e.PropertyName == "User" || e.PropertyName == "IsCompleted")
            {
                e.Cancel = true;
            }
        }
        private async System.Threading.Tasks.Task LoadAllTasks()
        => TasksList.ItemsSource = _user.Tasks;
        private async void TasksList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CompleteCheckBox.IsEnabled = true;
            CompleteCheckBox.IsChecked = ((TasksList.SelectedItem as DataBase.Models.Task).IsCompleted) ? true : false;
        }

        private async void AllButton_Click(object sender, RoutedEventArgs e)
        {
            CompleteCheckBox.Visibility = Visibility.Visible;
            AllButton.IsEnabled = false;
            CompletedButton.IsEnabled = true;
            ActiveButton.IsEnabled = true;
            await LoadAllTasks();
        }
        private async void CompletedButton_Click(object sender, RoutedEventArgs e)
        {
            CompleteCheckBox.Visibility = Visibility.Hidden;
            CompletedButton.IsEnabled = false;
            AllButton.IsEnabled = true;
            ActiveButton.IsEnabled = true;
            TasksList.ItemsSource = _user.Tasks.Where(x => x.IsCompleted).ToList();
        }
        private async void ActiveButton_Click(object sender, RoutedEventArgs e)
        {
            CompleteCheckBox.Visibility = Visibility.Visible;
            ActiveButton.IsEnabled = false;
            AllButton.IsEnabled = true;
            CompletedButton.IsEnabled = true;
            TasksList.ItemsSource = _user.Tasks.Where(x => !x.IsCompleted).ToList();
        }
        private async void AddButton_Click(object sender, RoutedEventArgs e)
        {
            //new AdditionPanels(_user).ShowDialog();
            //await LoadAllTasks();
        }

        private async void CompleteCheckBox_Click(object sender, RoutedEventArgs e)
        {
            var editedTask = TasksList.SelectedItem as DataBase.Models.Task;
            using ToDoListContext db = new();
            var findedTask = db.Tasks.First(x => x.Id == editedTask.Id);
            findedTask.IsCompleted = !findedTask.IsCompleted;
            await db.SaveChangesAsync();
        }
    }
}
