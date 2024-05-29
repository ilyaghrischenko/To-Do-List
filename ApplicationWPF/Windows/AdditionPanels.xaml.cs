using DataBase;
using DataBase.Models;
using System.Windows;
using System.Windows.Controls;

namespace ApplicationWPF.Windows
{
    public partial class AdditionPanels : Window
    {
        private User _user;
        private readonly ToDoListContext _context = new();
        public AdditionPanels(User user)
        {
            InitializeComponent();
            LoadData();
            _user = user;
        }

        private async System.Threading.Tasks.Task LoadData()
        {
            Categories_Box.ItemsSource = await ToDoListHandle.GetCategoriesAsync();
            Priorities_Box.ItemsSource = await ToDoListHandle.GetPrioritiesAsync();
        }
        private async System.Threading.Tasks.Task ChangeButtons(bool value)
        {
            AddNewTaskButton.IsEnabled = value;
            AddNewCategoryButton.IsEnabled = !value;
        }

        private async void AddNewTask_Click(object sender, RoutedEventArgs e)
        {
            await ChangeButtons(false);
            TaskAdd_Grid.Visibility = Visibility.Visible;
            CatAdd_Grid.Visibility = Visibility.Collapsed;
        }
        private async void AddTask_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Title_TextBox.Text) ||
                DatePicker == null || string.IsNullOrWhiteSpace(Hours_TextBox.Text) ||
                string.IsNullOrWhiteSpace(Minutes_TextBox.Text) ||
                Priorities_Box.SelectedItem == null)
            {
                MessageBox.Show("Fill all of the required fields!");
                return;
            }
            var selectedDate = DatePicker.SelectedDate.Value;

            if (!int.TryParse(Hours_TextBox.Text, out var hours) || !int.TryParse(Minutes_TextBox.Text, out var minutes) 
                || hours > 23 || hours < 0 || minutes > 59 || minutes < 0)
            {
                return;
            }            
            var dateTime = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, int.Parse(Hours_TextBox.Text), int.Parse(Minutes_TextBox.Text), 0);
            await _context.AddAsync(new DataBase.Models.Task(Title_TextBox.Text, dateTime, (Priority)Priorities_Box.SelectedItem, _user, (Category)Categories_Box.SelectedItem));
            await _context.SaveChangesAsync();
            MessageBox.Show("Task added!");
        }
        private async void AddNewCategory_Click(object sender, RoutedEventArgs e)
        {
            await ChangeButtons(true);
            TaskAdd_Grid.Visibility = Visibility.Collapsed;
            CatAdd_Grid.Visibility = Visibility.Visible;
        }

        private async void AddCategory_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CategoryName_TextBox.Text))
            {
                return;
            }

            _context.Add(new Category(CategoryName_TextBox.Text));
            _context.SaveChanges();
            MessageBox.Show("Category added!");
            LoadData();
        }
        private void BackToTasks_Click(object sender, RoutedEventArgs e)
        => Close();
    }
}
