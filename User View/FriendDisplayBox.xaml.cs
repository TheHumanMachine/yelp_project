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
    /// Interaction logic for FriendDisplayBox.xaml
    /// </summary>
    public partial class FriendDisplayBox : UserControl
    {
        public FriendDisplayBox(User nUser)
        {
            InitializeComponent();
            userNameTextBox.Text = nUser.Name;
            joinedTextBox.Text  = nUser.YelpSince.ToShortDateString();
            funnyTextBox.Text   = nUser.Funny.ToString();
            coolTextBox.Text    = nUser.Cool.ToString();
            usefulTextBox.Text  = nUser.Useful.ToString();
            starTextBox.Text    = nUser.AverageStars.ToString();
        }
    }
}
