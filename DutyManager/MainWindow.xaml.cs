using DutyManager.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
using Ubiety.Dns.Core;

namespace DutyManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Guid groupid;
        public static Guid groupidimportant;
        readonly DBCreator context;
        UsersModel users = new UsersModel();
        GroupsModel group = new GroupsModel();
        RolesModel rolesModel = new RolesModel();
        
        private bool selekt = true;
        
        public MainWindow(DBCreator context)
        {
            this.context = context;
            
            InitializeComponent();
            ShowGroups();
            ShowRoles();

            //GroupGrid.ItemsSource
        }
        public void ShowRoles()
        {
            //context.RolesModel.Add(new RolesModel
            //{
            //    Id = Guid.NewGuid(),
            //    Name = "Anna",
            //    Date = new DateTime(2020, 11, 22),
            //    Role = "Repo",
            //    GroupId = Guid.NewGuid()
            //});
            //context.SaveChanges();
            List<string> role = new List<string>();
            foreach (var item in context.RolesModel.ToList())
            {
                
                role.Add(item.Date + " , " + item.Name + " , "+ item.Role);
            }
            RolesListbox.ItemsSource = role;
        }
        private void ShowGroups()
        {
            List<string> test = new List<string>();
            foreach (var item in context.GroupModel.ToList())
            {
                test.Add(item.Name);
            }
            ListGroup.ItemsSource = test;
        }
        private void GroupAddButton_Click(object sender, RoutedEventArgs e)
        {           
            group.Id = Guid.NewGuid();
            //group.users.Email = LoginWindow.logedUser;
            //group.users.Id = context.UsersModel.SingleOrDefault(x=>x.Email == group.users.Email).Id;
            //group.users.Name = context.UsersModel.SingleOrDefault(x => x.Email == group.users.Email).Name;
            AddUsersTextBox.Text = LoginWindow.logedUser;
            group.users = LoginWindow.logedUser;
            group.Name = GroupNameTextBox.Text;
            context.GroupModel.Add(group);
            context.SaveChanges();
            ShowGroups();
        }
        public void usun(Guid id)
        {
            var item = context.GroupModel.SingleOrDefault(x=>x.Id == id);
            context.GroupModel.Remove(item);
            context.SaveChanges();
            selekt = false;
            ShowGroups();
        }
        private void DeleteGroupButton_Click(object sender, RoutedEventArgs e)
        {
            usun(groupid);
        }
        private void ListGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GroupNameTextBox.Visibility != Visibility.Visible)
            {
                GroupNameTextBox.Visibility = Visibility.Visible;
                AddUsersTextBox.Visibility = Visibility.Visible;
                AddGroup.Visibility = Visibility.Visible;
                AddMembers.Visibility = Visibility.Visible;
            }
            if (!selekt)
            {
                e.Handled = true;
                selekt = true;
                return;
            }
            GroupNameTextBox.Text = ListGroup.SelectedItem.ToString() != null ? ListGroup.SelectedItem.ToString() : "";
            groupid = context.GroupModel.SingleOrDefault(x =>x.Name == ListGroup.SelectedItem.ToString()).Id;
            groupidimportant = groupid;
        }
        private void EditGroupButton_Click(object sender, RoutedEventArgs e)
        {
            Edit();   
        }
        private void Edit()
        {
            group.users = AddUsersTextBox.Text;
            group.Name = GroupNameTextBox.Text;
            usun(groupid);
            context.GroupModel.Add(group);
            context.SaveChanges();
            selekt = false;
            ShowGroups();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            group.users = context.GroupModel.SingleOrDefault(x=>x.Id == groupid).users;
            group.Id = groupid;
            group.Name = GroupNameTextBox.Text;
            group.users += AddUsersTextBox.Text+",";
            //context.GroupModel.Update(group);
            usun(groupid);
            context.GroupModel.Add(group);
            context.SaveChanges();
            AddUsersTextBox.Text = "";
            selekt = false;
            ShowGroups();
        }
        private void testbutton_Click(object sender, RoutedEventArgs e)
        {
            GroupListWindow window = new GroupListWindow(context);
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RoleManagerWindow roleManagerWindow = new RoleManagerWindow(context);
            roleManagerWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            roleManagerWindow.Show();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ShowRoles();
        }
    }
}
