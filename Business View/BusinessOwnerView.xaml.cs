using Npgsql;
using System.Windows;
using System.Windows.Controls;
using UIPractive.BusinessDisplay;
using UIPractive.DB_Classes;

namespace UIPractive.Business_View
{
    /// <summary>
    /// Interaction logic for BusinessOwnerView.xaml
    /// </summary>
    public partial class BusinessOwnerView : UserControl
    {
        private NpgsqlConnection connection;
        public string currentUser = "uXjR2GhCAYhqxVr21aC4vQ";
        private TransactionManager mgr;
        private Business currBusiness;
        private string businessID = "";

        public BusinessOwnerView(NpgsqlConnection conn, TransactionManager mgr)
        {
            InitializeComponent();
            this.mgr = mgr;
            connection = conn;
        }

        private void getCurrentBusiness()
        {
            currBusiness = mgr.ExecuteBusinessQuery(businessID);
            //nameField.Text = currBusiness.Name;
            //addressField.Text = currBusiness.Address;

            //foreach (var i in currBusiness.Categories)
            //{
            //    ListBoxItem temp = new ListBoxItem();
            //    temp.Content = i;
            //    CategoriesListBox.Items.Add(temp);
            //}

            //foreach (var i in currBusiness.Attributes)
            //{
            //    ListBoxItem temp = new ListBoxItem();
            //    temp.Content = i;
            //    AttributesListBox.Items.Add(temp);
            //}
            //openField.Text = currBusiness.OpenTime;
            //closeField.Text = currBusiness.CloseTime;
        }

        private void AddCheckins()
        {
            var checkins = mgr.ExecuteLatestCheckin(businessID);
            foreach (var i in checkins)
            {
                CheckInDisplay temp = new CheckInDisplay(i);
                Checkinsstack.Children.Add(temp);

            }
        }

        private void SelectBusiness_Click(object sender, RoutedEventArgs e)
        {
            var selectBus = new SelectBusinessWindow();
            selectBus.AddManager(mgr);
            selectBus.ShowDialog();

            businessID = selectBus.BusinessID;
            if (!string.IsNullOrEmpty(businessID)) {
                reviewsDisplays.reviewStackPanel.Children.Clear();
                getCurrentBusiness();
            }
            busInfo.AddBusinessToDisplay(currBusiness);
            busname.nameTextBox.Text = currBusiness.Name;
            busname.addressTextBox.Text = currBusiness.Address;
            busname.cityTextBox.Text = currBusiness.City;
            busname.stateTextBox.Text = currBusiness.State;
            busname.zipcodeTextBox.Text = currBusiness.Zipcode;

            var reviewList = mgr.ExecuteBusinessReviewQuery(businessID);
            foreach(var i in reviewList)
            {
                var name = mgr.ExecuteNameQuery(i.UserID);
                reviewsDisplays.AddReview(i, name);
            }
            AddCheckins();
        }

        private void EditName_Click(object sender, RoutedEventArgs e)
        {
            System.Console.WriteLine("Edit Name Button");
        }

        private void EditAddress_Click(object sender, RoutedEventArgs e)
        {
            System.Console.WriteLine("EditAddress Button");
        }

        private void EditOpenTime_Click(object sender, RoutedEventArgs e)
        {
            System.Console.WriteLine("EditOpenTime Button");
        }

        private void EditCloseTime_Click(object sender, RoutedEventArgs e)
        {
            System.Console.WriteLine("EditCloseTime Button");
        }

        private void EditCoordinates_Click(object sender, RoutedEventArgs e)
        {
            System.Console.WriteLine("EditCoordinates Button");
        }

        private void AddCategory_Click(object sender, RoutedEventArgs e)
        {
            System.Console.WriteLine("AddCategory Button");
        }

        private void RemoveCategory_Click(object sender, RoutedEventArgs e)
        {
            System.Console.WriteLine("RemoveCategory Button");
        }

        private void AddAttribute_Click(object sender, RoutedEventArgs e)
        {
            System.Console.WriteLine("AddAttribute Button");
        }

        private void RemoveAttribute_Click(object sender, RoutedEventArgs e)
        {
            System.Console.WriteLine("RemoveAttribut Button");
        }

    }
}
