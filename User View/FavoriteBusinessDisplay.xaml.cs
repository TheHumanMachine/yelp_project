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

namespace UIPractive.User_View
{
    /// <summary>
    /// Interaction logic for FavoriteBusinessDisplay.xaml
    /// This class controls what is listed in the UserMainView
    /// This houses all of the indiviual business "box"
    /// </summary>
    public partial class FavoriteBusinessDisplay : UserControl
    {
        private String SelectedBusiness ="";
        private TransactionManager mgr;
        public FavoriteBusinessDisplay()
        {
            InitializeComponent();
            //AddFavoriteBusinessDisplayBox();
        }

        public void AddManager(TransactionManager mgr)
        {
            this.mgr = mgr;
        }

        public void AddFavoriteBusinessDisplayBox(List<Business> businessList)
        {
            foreach(var i in businessList)
            {
                var busDisplay = new FavoriteBusinessDisplayBox(i);
                favoriteBusinessStackPanel.Children.Add(busDisplay);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(!String.IsNullOrEmpty(SelectedBusiness))
            {
                mgr.ExecuteDeleteFavoriteBusiness(SelectedBusiness);
            }
        }

        private void FavoriteBusinessStackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var uiElement = e.Source as FrameworkElement;
            if (uiElement != null)
            {
                var business = (FavoriteBusinessDisplayBox)uiElement;
                SelectedBusiness = business.Business_id;
                Console.WriteLine("The name is: " + business.nameTextBox.ToString());
            }
        }
    }
}
