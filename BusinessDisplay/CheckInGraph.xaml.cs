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
using System.Windows.Shapes;

namespace UIPractive.BusinessDisplay
{
    /// <summary>
    /// Interaction logic for CheckInGraph.xaml
    /// </summary>
    public partial class CheckInGraph : Window
    {
        TransactionManager mgr;
        String business_id = "";

        public CheckInGraph(TransactionManager mgr, String business_id)
        {
            InitializeComponent();
            this.mgr = mgr;
            this.business_id = business_id;
            PopulateColumns();
        }

        public void PopulateColumns()
        {
            List<KeyValuePair<String, int>> chartData = mgr.ExecuteCheckIn(business_id);

            checkInChart.DataContext = chartData;
        }


    }
}
