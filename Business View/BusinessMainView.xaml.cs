using Npgsql;
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

namespace UIPractive.Business_View
{
    /// <summary>
    /// Interaction logic for BusinessMainView.xaml
    /// </summary>
    public partial class BusinessMainView : UserControl
    {
        private NpgsqlConnection connection;

        public BusinessMainView(NpgsqlConnection conn)
        {
            InitializeComponent();
            connection = conn;
            Attri.AddContainer(container);
        }
    }
}
