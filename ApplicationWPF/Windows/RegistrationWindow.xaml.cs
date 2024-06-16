using DataBase;
using DataBase.Models;
using System.Windows;

namespace ApplicationWPF.Windows
{
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private async void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LoginInput.Text)
               || string.IsNullOrWhiteSpace(PasswordInput.Password)
               || string.IsNullOrWhiteSpace(ConfirmPasswordInput.Password))
            {
                MessageBox.Show("You have not filled all fields");
                return;
            }
            if (PasswordInput.Password != ConfirmPasswordInput.Password)
            {
                MessageBox.Show("You did not re-enter your password correctly");
                ConfirmPasswordInput.Clear();
                return;
            }
            var users = await ToDoListHandle.GetUsersAsync();
            var findedUser = users.FirstOrDefault(x => x.Login == LoginInput.Text);
            if (findedUser != null)
            {
                MessageBox.Show("This login already exist");
                LoginInput.Clear();
                return;
            }

            SignUpButton.IsEnabled = false;
            using ToDoListContext db = new();
            User user = new(LoginInput.Text, PasswordInput.Password);
            db.Users.Add(user);
            await db.SaveChangesAsync();
            Close();
        }
        private async void LogIn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new();
            window.Show();
            Close();
        }
    }
}
