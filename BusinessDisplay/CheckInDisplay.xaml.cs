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

namespace UIPractive.BusinessDisplay
{
    /// <summary>
    /// Interaction logic for CheckInDisplay.xaml
    /// </summary>
    public partial class CheckInDisplay : UserControl
    {
        public CheckInDisplay(CheckIn temp)
        {
            InitializeComponent();
            dayTextbox.Text = temp.Day;
            countTextbox.Text = temp.Count;
            timeTextbox.Text = temp.Time;
        }
    }
}
