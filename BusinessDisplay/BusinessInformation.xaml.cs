using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace UIPractive
{
    /// <summary>
    /// Interaction logic for BusinessInformation.xaml
    /// </summary>
    public partial class BusinessInformation : UserControl
    {

        public BusinessInformation()
        {
            InitializeComponent();
        }

        public string BusinessName
        {
            get { return nameTextBox.Text; }
            set
            {
                if (value != nameTextBox.Text)
                {
                    nameTextBox.Text = value;
                }
            }
        }

        public string Address {
            get { return addressTextBox.Text; }
            set
            {
                if (value != addressTextBox.Text)
                {
                    addressTextBox.Text = value;
                }
            }
        }

        public string City
        {
            get { return cityTextBox.Text; }
            set
            {
                if (value != cityTextBox.Text)
                {
                    cityTextBox.Text = value;
                }
            }
        }

        public string State
        {
            get { return stateTextBox.Text; }
            set
            {
                if (value != stateTextBox.Text)
                {
                    stateTextBox.Text = value;
                }
            }
        }

        public string Zipcode
        {
            get { return zipcodeTextBox.Text; }
            set
            {
                if (value != zipcodeTextBox.Text)
                {
                    zipcodeTextBox.Text = value;
                }
            }
        }
    }
}
