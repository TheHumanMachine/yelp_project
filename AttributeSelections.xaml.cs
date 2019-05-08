using Microsoft.Maps.MapControl.WPF;
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
using UIPractive.Business_View;
using UIPractive.Map_View;

namespace UIPractive
{
    /// <summary>
    /// Interaction logic for AttributeSelections.xaml
    /// </summary>
    public partial class AttributeSelections : UserControl
    {
        private TransactionManager mgr;
        private BusinessDisplayContainer cont;
        private MapView map;

        public AttributeSelections()
        {
            InitializeComponent();
        }

        public void AddMap(MapView map)
        {
            this.map = map;
        }

        public void PopulateStates()
        {
            mgr.ExecuteStateQuery(stateBox);
        }

        private List<KeyValuePair<String, String>> GetAttributes()
        {
            var attriList = new List<KeyValuePair<String, String>>();
            if ((bool)CC_CBox.IsChecked)    { attriList.Add(new KeyValuePair<String, String>("BusinessAcceptsCreditCards", "True")); }
            if ((bool)reserve_CBox.IsChecked) { attriList.Add(new KeyValuePair<String, String>("RestaurantsReservations","True")); }
            if ((bool)wheelchair_CBox.IsChecked)  { attriList.Add(new KeyValuePair<String, String>("WheelchairAccessible", "True")); }
            if ((bool)outdoorSeating_CBox.IsChecked) { attriList.Add(new KeyValuePair<String, String>("OutdoorSeating", "True")); }
            if ((bool)goodForKids_CBox.IsChecked)    { attriList.Add(new KeyValuePair<String, String>("GoodForKids", "True")); }
            if ((bool)goodForGroups_CBox.IsChecked)  { attriList.Add(new KeyValuePair<String, String>("RestaurantsGoodForGroups", "True")); }
            if ((bool)takeOut_CBox.IsChecked)  { attriList.Add(new KeyValuePair<String, String>("RestaurantsTakeOut","True")); }
            if ((bool)freewifi_CBox.IsChecked) { attriList.Add(new KeyValuePair<String, String>("WiFi","free")); }
            if ((bool)parking_CBox.IsChecked)  { attriList.Add(new KeyValuePair<String, String>("BikeParking","True")); }

            if ((bool)breakfast_box.IsChecked) { attriList.Add(new KeyValuePair<String, String>("breakfact", "True")); }
            if ((bool)brunch_box.IsChecked) { attriList.Add(new KeyValuePair<String, String>("brunch", "True")); }
            if ((bool)lunch_box.IsChecked) { attriList.Add(new KeyValuePair<String, String>("lunch", "True")); }
            if ((bool)dinner_box.IsChecked) { attriList.Add(new KeyValuePair<String, String>("dinner", "True")); }
            if ((bool)dessert_box.IsChecked) { attriList.Add(new KeyValuePair<String, String>("dessert", "True")); }
            if ((bool)lateNight_box.IsChecked) { attriList.Add(new KeyValuePair<String, String>("latenight", "True")); }

            if ((bool)price1.IsChecked) { attriList.Add(new KeyValuePair<String, String>("RestaurantsPriceRange2", "1")); }
            if ((bool)price2.IsChecked) { attriList.Add(new KeyValuePair<String, String>("RestaurantsPriceRange2", "2")); }
            if ((bool)price3.IsChecked) { attriList.Add(new KeyValuePair<String, String>("RestaurantsPriceRange2", "3")); }
            if ((bool)price4.IsChecked) { attriList.Add(new KeyValuePair<String, String>("RestaurantsPriceRange2", "4")); }


            return attriList;
        }

        private String getSort()
        {
            String sort = "";
            String selectedSort = sortBox.SelectedIndex.ToString();

            if(selectedSort == "0") // Name(Default)
            {
                sort = "name";
            }else if (selectedSort == "1") // Rating
            {
                sort = "stars";
            }
            else if (selectedSort == "2") // Most Reviewed
            {
                sort = "review_count";
            }
            else if (selectedSort == "3") // Avereage Rating
            {
                sort = "review_rating";
            }
            else if (selectedSort == "4") // Check-ins
            {
                sort = "num_checkins";
            }else if(selectedSort == "5") // Nearest
            {
                sort = "distance";
            }

            return sort;
        }

        public void AddManager(TransactionManager mgr)
        {
            this.mgr = mgr;
        }

        private void stateBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(stateBox.SelectedItem != null)
            {
                cityBox.Items.Clear();
                zipcodeBox.Items.Clear();
                mgr.ExecuteCityQuery(stateBox.SelectedItem.ToString(), cityBox);
            }
        }

        private void cityBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (stateBox.SelectedItem != null && cityBox.SelectedItem != null)
            {
                zipcodeBox.Items.Clear();
                categoryBox.Items.Clear();
                mgr.ExecuteZipcodeQuery(stateBox.SelectedItem.ToString(), cityBox.SelectedItem.ToString(), zipcodeBox);
            }
        }

        private void zipcodeBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            categoryBox.Items.Clear();
            var ls = mgr.ExecuteCategoryQuery(Convert.ToInt32(zipcodeBox.SelectedItem));
            foreach (var i in ls)
            {
                categoryBox.Items.Add(i);
            }
        }

        public void AddContainer(BusinessDisplayContainer cont)
        {
            this.cont = cont;
        }

        private void categoryBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            cont.ClearBusinesses();
            if (categoryBox.SelectedItems.Count > 0)
            {
                var categoriesList = new List<String>();
                foreach (var i in categoryBox.SelectedItems)
                {
                    categoriesList.Add(i.ToString());
                }
                var busList = mgr.ExecuteCategoryBusinessQuery(Convert.ToInt32(zipcodeBox.SelectedItem), categoriesList, GetAttributes(), getSort()); // Get the list of business
                if(map != null) { map.plotBusiness(busList); }
                cont.AddBusinesses(busList);
            }
        }
    }
}
