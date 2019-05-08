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

namespace UIPractive.Business_View
{
    /// <summary>
    /// Interaction logic for SelectBusinessWindow.xaml
    /// </summary>
    public partial class SelectBusinessWindow : Window
    {
        private string businessID = "";
        private TransactionManager mgr;

        public SelectBusinessWindow()
        {
            InitializeComponent();
        }

        public void AddManager(TransactionManager mgr)
        {
            this.mgr = mgr;
        }

        private void SetBusinessID_Click(object sender, RoutedEventArgs e)
        {
            //businessID = businessIDTextBox.Text;
            this.Close();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            // Search for username 
            var busList = mgr.ExecuteBusinessSearchQuery(searchBox.Text);
            foreach (var user in busList)
            {
                searchList.Items.Add(user);
            }
        }

        public string BusinessID { get => businessID; }

        private void SetBusiness_Click(object sender, RoutedEventArgs e)
        {
            var item = searchList.SelectedItem;
            if (item != null)
            {
                businessID = item.ToString();
            }
            this.Close();
        }
    }
}
