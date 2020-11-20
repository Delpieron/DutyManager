using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace DutyManager.DataBases
{
    public class dbOperations
    {
        readonly DBCreator context;
        UsersModel userParamList = new UsersModel();
        public dbOperations(DBCreator context)
        {
            this.context = context;
        }
        private void Update(object s, RoutedEventArgs e)
        {
            context.Update(userParamList);
            context.SaveChanges();
        }
        private void Delete(object s, RoutedEventArgs e)
        {
            var productToDelete = (s as FrameworkElement).DataContext as UsersModel;
            context.UsersModel.Remove(productToDelete);
            context.SaveChanges();
        }
        private void Add(object sender, RoutedEventArgs e)
        {
            context.UsersModel.Add(userParamList);
            context.SaveChanges();
        }
        public void Get(string context)
        {
            //return context.UsersModel.ToList();
        }
    }
}
