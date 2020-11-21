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
    public partial class GroupListWindow : Window
    {
        public Guid guidid;
        GroupsModel group = new GroupsModel();
        public GroupListWindow(DBCreator context)
        {
           guidid = MainWindow.groupidimportant;
            InitializeComponent();
            this.context = context;
            ShowGroups();
        }
        readonly DBCreator context;
        public List<string> test = new List<string>();
        private void ShowGroups()
        {
            var sum = context.GroupModel.SingleOrDefault(x => x.Id == guidid);
            var final = sum.users.Split(",");
            foreach (var item in final)
            {
                test.Add(item);
            }
            test.RemoveAt(test.Count - 1);
            GroupUsersListBox.ItemsSource = test;
        }
        public void usun(Guid id)
        {
            var item = context.GroupModel.SingleOrDefault(x => x.Id == id);
            context.GroupModel.Remove(item);
            context.SaveChanges();
        }
        private void GroupUsersListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
        private void addbutton_Click(object sender, RoutedEventArgs e)
        {
            Add();
        }
        private void Add()
        {
            List<string> users = new List<string>();
            group.users = context.GroupModel.SingleOrDefault(x => x.Id == guidid).users;
            group.users += addEmailTextBox.Text + ",";
            group.Id = guidid;
            group.Name = context.GroupModel.SingleOrDefault(x => x.Id == guidid).Name;
            usun(guidid);
            context.GroupModel.Add(group);
            context.SaveChanges();
            GroupUsersListBox.ItemsSource = test;
            GroupListWindow window = new GroupListWindow(context);
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.Show();
            this.Close();    
        }
        public List<string> lol = new List<string>();
        private void deletebutton_Click(object sender, RoutedEventArgs e)
        {
            group.Name = context.GroupModel.SingleOrDefault(x => x.Id == guidid).Name;
            group.Id = context.GroupModel.SingleOrDefault(x => x.Id == guidid).Id;
            var test2 = GroupUsersListBox.SelectedItem.ToString();
            for (int i = 0; i < test.Count; i++)
            {
                if (test[i].Equals(test2))
                {
                    test.RemoveAt(i);
                }
            }
            foreach (var item in test)
            {
                group.users += item + ",";
                lol.Add(item);
            }
            usun(guidid);
            context.Add(group);
            saveasync();
            GroupUsersListBox.ItemsSource = lol;
        }

        public async void saveasync()
        {
            await context.SaveChangesAsync();
        }
    }
}
