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
        private Guid groupid;
        readonly DBCreator context;
        UsersModel users = new UsersModel();
        GroupsModel group = new GroupsModel();
        private bool selekt = true;

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
          
            group.Id = Guid.NewGuid();
            group.Name = GroupNameTextBox.Text;
            context.GroupModel.Add(group);
            context.SaveChanges();
            ShowGroups();
        }

        private void DeleteGroupButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ListGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!selekt)
            {
                e.Handled = true;
                return;
            }
            GroupNameTextBox.Text = ListGroup.SelectedItem.ToString() == null ? ListGroup.SelectedItem.ToString() : "";
            groupid = context.GroupModel.SingleOrDefault(x =>x.Name == ListGroup.SelectedItem.ToString()).Id;
        }
        //public List<GroupsModel> Updatetest(Guid id)
        //{
        //    List<GroupsModel> lista = new List<GroupsModel>();
        //    lista.Add();
        //    context.GroupModel.si
        //    return lista;
        //}
        private void EditGroupButton_Click(object sender, RoutedEventArgs e)
        {
            context.GroupModel.SingleOrDefault(x => x.Id == groupid).Name = GroupNameTextBox.Text;

            //Update(groupid);
            //group.Name = GroupNameTextBox.Text;
            context.GroupModel.Update(context.GroupModel.SingleOrDefault(x => x.Id == groupid));
            context.SaveChanges();
            selekt = false;
            ShowGroups();


        }

        private void ListGroup_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
