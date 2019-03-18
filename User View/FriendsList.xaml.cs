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
    /// Interaction logic for FriendsList.xaml
    /// </summary>
    public partial class FriendsList : UserControl
    {
        public FriendsList()
        {
            InitializeComponent();
        }

        public void AddFriendBox(FriendDisplayBox nFriend)
        {
            friendStackPanel.Children.Add(nFriend);
        }

        public void Clear()
        {
            friendStackPanel.Children.Clear();
        }
    }
}
