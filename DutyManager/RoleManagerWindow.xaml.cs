using DutyManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DutyManager
{
    /// <summary>
    /// Interaction logic for RoleManagerWindow.xaml
    /// </summary>
    public partial class RoleManagerWindow : Window
    {
        RolesModel roles = new RolesModel();
        GroupsModel groups = new GroupsModel();
        UsersModel users = new UsersModel();
        public RoleManagerWindow(DBCreator Context)
        {
            InitializeComponent();
            context = Context;
            ShowGroups();
            ShowRole();
            
        }

        public DBCreator context { get; }
        public void ShowRole()
        {
            List<string> role = new List<string>();
            foreach (var item in context.RolesModel.ToList())
            {

                role.Add(item.Date + " , " + item.Name + " , " + item.Role);
            }
            RoleListBox.ItemsSource = role;
        }
        List<string> test = new List<string>();
        private void ShowGroups()
        {
            //List<string> test = new List<string>();
            foreach (var item in context.GroupModel.ToList())
            {
                test.Add(item.Name);
            }
            GroupsListBox.ItemsSource = test;
        }
        public string name;
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            name = GroupsListBox.SelectedItem.ToString();
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            roles.Id = Guid.NewGuid();
            roles.Name = NameTextBox.Text;
            roles.Date = DataPickerText.SelectedDate.Value;
            roles.Role = RoleTextBox.Text;
            roles.GroupId = context.GroupModel.SingleOrDefault(x => x.Name == name).Id;
            context.Add(roles);
            context.SaveChanges();
            ShowRole();
        }
        public void usun(Guid id)
        {
            var item = context.RolesModel.SingleOrDefault(x => x.Id == id);
            context.RolesModel.Remove(item);
            context.SaveChanges();
        }
        public List<string> lol = new List<string>();
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            //roles.Name = context.GroupModel.SingleOrDefault(x => x.Name == name).Name;
            //roles.Id = context.RolesModel.SingleOrDefault(x => x.Name == namerole).Id;
            //var test2 = RoleListBox.SelectedItem.ToString();
            usun(roles.Id);
            context.Remove(roles);
            saveasync();
            RoleListBox.ItemsSource = test;
        }
        public async void saveasync()
        {
            await context.SaveChangesAsync();
        }
        //public string namerole;
        private void RoleListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var namerole = RoleListBox.SelectedItem.ToString();
        }
    }
}
