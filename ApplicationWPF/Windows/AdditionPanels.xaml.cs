using DataBase.Models;
using System.Windows;

namespace ApplicationWPF.Windows
{
    public partial class AdditionPanels : Window
    {
        private User _user;

        public AdditionPanels()
        {
            InitializeComponent();
        }
        public AdditionPanels(User user)
        {
            InitializeComponent();
            _user = user;
        }
    }
}
