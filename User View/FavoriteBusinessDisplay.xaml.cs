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

namespace UIPractive.User_View
{
    /// <summary>
    /// Interaction logic for FavoriteBusinessDisplay.xaml
    /// This class controls what is listed in the UserMainView
    /// This houses all of the indiviual business "box"
    /// </summary>
    public partial class FavoriteBusinessDisplay : UserControl
    {
       
        public FavoriteBusinessDisplay()
        {
            InitializeComponent();
            AddFavoriteBusinessDisplayBox();
        }

        private void AddFavoriteBusinessDisplayBox()
        {

        }
    }
}
