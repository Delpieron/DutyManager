using DutyManager.Models;
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

namespace DutyManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly DBCreator context;
        UsersModel users = new UsersModel();
        GroupsModel group = new GroupsModel();

        public MainWindow(DBCreator context)
        {
            this.context = context;

            InitializeComponent();
            ShowGroups();
            
            //GroupGrid.ItemsSource
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
            //foreach (var item in context.GroupModel.ToList())
            //{
            //    item.Id = Guid.NewGuid();
            //    item.Name = "test1";


            //}
            group.Id = Guid.NewGuid();
            group.Name = "test1";
            context.GroupModel.Add(group);
            context.SaveChanges();
        }
    }
}
