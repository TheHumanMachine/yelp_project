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
    /// Interaction logic for SetUserDisplay.xaml
    /// </summary>
    public partial class SetUserDisplay : UserControl
    {
        public String user;
        private TransactionManager mgr;
        public SetUserSearch search;
        private UserMainView umv;
        public SetUserDisplay(TransactionManager mgr, UserMainView umv)
        {
            InitializeComponent();
            this.umv = umv;
            this.mgr = mgr;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            search = new SetUserSearch(mgr);
            search.ShowDialog();
            umv.currentUser = search.userID;
            userIDTextBox.Text = search.userID;
            nameTextBox.Text = search.userName;
            umv.LoadUserInformation();
        }
    }
}
