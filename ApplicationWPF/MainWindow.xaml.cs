using System.Windows;
using DataBase;
using DataBase.Models;
using ApplicationWPF.Windows;

namespace ApplicationWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LoginInput.Text)
               || string.IsNullOrWhiteSpace(PasswordInput.Password))
            {
                MessageBox.Show("You have not filled all fields");
                return;
            }

            User user = new(LoginInput.Text, PasswordInput.Password);
            LogInButton.IsEnabled = false;
            var users = await ToDoListHandle.GetUsersAsync();
            var findedUser = users.FirstOrDefault(x => x.ToString() == user.ToString());

            if (findedUser != null)
            {
                user = findedUser;
                MessageBox.Show("Logged in");
            }
            else
            {
                using ToDoListContext db = new();
                db.Users.Add(user);
                await db.SaveChangesAsync();
                MessageBox.Show("Registered");
            }
            TaskListWindow window = new(user);
            window.Show();
            Close();
        }
    }
}