using DataBase.Models;
using System.Windows;

namespace ApplicationWPF.Windows
{
    public partial class TaskListWindow : Window
    {
        private User _user;

        public TaskListWindow()
        {
            InitializeComponent();
        }
        public TaskListWindow(User user)
        {
            InitializeComponent();
            _user = user;
        }
    }
}
