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
        public static string logedUser;
        //Login login = new Login(context);
        public LoginWindow(DBCreator context)
        {            
            this.context = context;
            InitializeComponent();
            AddDefaultUser();
        }
        private void AddDefaultUser()
        {
            var a = context.UsersModel.ToList();
            foreach (var item in a)
            {
                if (item.Email.Equals("admin@admin.pl"))
                    return;
            }
            users.Id = Guid.NewGuid();
            users.Name = "admin";
            users.Email = "admin@admin.pl";
            users.Password = "admin";
            context.Add(users);
            context.SaveChanges();
        }
        public void CheckLogin()
        {
            //users.Email = textBoxLogin.Text;
            //users.Password = textBoxPasswd.Text;
            //login.Verify(textBoxLogin.Text,textBoxPasswd.Text);
            var a = context.UsersModel.ToList();
            foreach (var item in a)
            {
                if (item.Email.Equals(textBoxLogin.Text)&& item.Password.Equals(textBoxPasswd.Password))
                {
                    MainWindow mainWindow = new MainWindow(context);
                    logedUser = item.Email;
                    Close();
                    mainWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
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
