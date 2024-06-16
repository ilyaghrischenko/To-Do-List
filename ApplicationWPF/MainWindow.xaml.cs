using System.Windows;
using DataBase;
using DataBase.Models;
using ApplicationWPF.Windows;
using System.Net.NetworkInformation;

namespace ApplicationWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            if (!InternetConnectionCheck())
            {
                MessageBox.Show("Connect to the internet to use the application");
                Close();
            }
        }

        private bool InternetConnectionCheck()
        {
            try
            {
                using (Ping ping = new Ping())
                {
                    PingReply reply = ping.Send("8.8.8.8", 3000);
                    return reply.Status == IPStatus.Success;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        private async void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LoginInput.Text)
               || string.IsNullOrWhiteSpace(PasswordInput.Password))
            {
                MessageBox.Show("You have not filled all fields");
                return;
            }
            var users = await ToDoListHandle.GetUsersAsync();
            var findedUser = users.FirstOrDefault(x => x.Login == LoginInput.Text && x.Password == PasswordInput.Password);
            if (findedUser == null)
            {
                MessageBox.Show("Not found");
                LoginInput.Clear();
                PasswordInput.Clear();
                return;
            }

            LogInButton.IsEnabled = false;
            User user = findedUser;
            TaskListWindow window = new(user);
            window.Show();
            Close();
        }
        private async void SignUp_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow window = new();
            window.Show();
            Close();
        }
    }
}