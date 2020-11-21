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
    /// Logika interakcji dla klasy GroupListWindow.xaml
    /// </summary>
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
        private void ShowGroups()
        {
            List<string> test = new List<string>();

            var sum = context.GroupModel.SingleOrDefault(x => x.Id == guidid);
            var final = sum.users.Split(",");
            foreach (var item in final)
            {
                test.Add(item);
            }
            test.RemoveAt(test.Count - 1);
            //string lol = test.ToString();
            //var wynik = lol.Split(",");

            
            GroupUsersListBox.ItemsSource = test;
        }
    }
}
