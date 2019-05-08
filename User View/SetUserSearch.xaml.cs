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
using System.Windows.Shapes;

namespace UIPractive.User_View
{
    /// <summary>
    /// Interaction logic for SetUserSearch.xaml
    /// </summary>
    public partial class SetUserSearch : Window
    {
        TransactionManager mgr;
        public String userID = "";
        public String userName = "";
        public SetUserSearch(TransactionManager mgr)
        {
            InitializeComponent();
            this.mgr = mgr;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Set user
            userID = searchList.SelectedItem.ToString();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Search for username 
            var userList = mgr.ExecuteUserQuery(userSearchTextBox.Text);
            userName = userSearchTextBox.Text;
            foreach (var user in userList)
            {
                searchList.Items.Add(user);
            }
        }
    }
}
