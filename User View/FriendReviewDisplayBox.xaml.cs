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
    /// Interaction logic for FriendReviewDisplayBox.xaml
    /// </summary>
    public partial class FriendReviewDisplayBox : UserControl
    {

        public FriendReviewDisplayBox(Review rev)
        {
            InitializeComponent();


        }


        public string UserName
        {
            get { return userNameTextBox.Text; }
            set
            {
                if (value != userNameTextBox.Text)
                {
                    userNameTextBox.Text = value;
                }
            }
        }

        public string Date
        {
            get { return postDateTextBox.Text; }
            set
            {
                if (value != postDateTextBox.Text)
                {
                    postDateTextBox.Text = value;
                }
            }
        }

      

    }
}
