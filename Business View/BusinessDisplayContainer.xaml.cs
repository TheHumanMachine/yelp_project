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
using UIPractive.DB_Classes;

namespace UIPractive.Business_View
{
    /// <summary>
    /// Interaction logic for BusinessDisplayContainer.xaml
    /// </summary>
    public partial class BusinessDisplayContainer : UserControl
    {
        private TransactionManager mgr;
        private AttributeSelections attri;

        public BusinessDisplayContainer()
        {
            InitializeComponent();
        }

        public void AddManager(TransactionManager mgr)
        {
            this.mgr = mgr;
        }

        private void Favorite_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void CheckIn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ShowCheckIns_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ShowReviews_Click(object sender, RoutedEventArgs e)
        {

        }

        // called after zipcode is updated
        public void LoadBusinesses(object sender, RoutedEventArgs e)
        {
            // query for all businesses
            //var temp = (ListBox)sender;
            //var busList = mgr.ExecuteBusinessQuery(Convert.ToInt32(temp.SelectedItem), sortBox); // Get the list of business
            //AddBusinesses(busList);
        }

        public void ClearBusinesses()
        {
            searchResultsStackPanel.Children.Clear();
        }

        public void AddBusinesses(List<Business> businesses)
        {
            searchResultsStackPanel.Children.Clear();
            foreach (var t in businesses)
            {
                searchResultsStackPanel.Children.Add(new BusinessDisplayBox(t, mgr));
            }
        }


    }
}
