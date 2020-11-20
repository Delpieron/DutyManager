using DutyManager.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DutyManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        readonly DBCreator context;
        UsersModel users = new UsersModel();
        //Login login = new Login(context);
        public LoginWindow(DBCreator context)
        {            
            this.context = context;
            InitializeComponent();
        }
        public void CheckLogin()
        {
            //users.Email = textBoxLogin.Text;
            //users.Password = textBoxPasswd.Text;
            //login.Verify(textBoxLogin.Text,textBoxPasswd.Text);
            var a = context.UsersModel.ToList();
            foreach (var item in a)
            {
                if (item.Email.Equals(textBoxLogin.Text)&& item.Password.Equals(textBoxPasswd.Text))
                {
                    MainWindow mainWindow = new MainWindow(context);
                    Close();
                    mainWindow.Show();
                }
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            CheckLogin();
        }
    }
}
