using Npgsql;
using System.Windows;
using UIPractive.Business_View;
using UIPractive.Map_View;
using UIPractive.User_View;

namespace UIPractive
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string connString = "Host=localhost;Username=postgres;Password=1111111;Database=yelp";
        private NpgsqlConnection connection;
        TransactionManager Tmgr;

        private UserMainView userView;
        private BusinessMainView businessView;
        private MapView mapView;
        private BusinessOwnerView businessOwnerView;

        private MainVeiwButtons mainViewButtons;

        public MainWindow()
        {
            InitializeComponent();
            ConnectToDatabase();
            Tmgr = new TransactionManager(connection);

            userView = new UserMainView(connection, Tmgr);
            businessView = new BusinessMainView(connection);
            mapView = new MapView(connection, Tmgr);
            businessOwnerView = new BusinessOwnerView(connection, Tmgr);

            businessView.Attri.AddMap(mapView);

            Tmgr.CurrentUser = userView.currentUser;
            businessView.Attri.AddManager(Tmgr);
            businessView.container.AddManager(Tmgr);
            mainViewButtons = new MainVeiwButtons();

            mainViewButtons.ownerButton.Click += SetOwnerView;
            mainViewButtons.mapButton.Click += SetMapView;
            mainViewButtons.businessButton.Click += SetBusinessView;
            mainViewButtons.userButton.Click += SetUserView;
            buttons.Children.Add(mainViewButtons);
            view.Children.Add(userView);
        }
        
        private void ConnectToDatabase()
        {
            connection = new NpgsqlConnection(connString);
            connection.Open();
        }

        private void SetUserView(object sender, RoutedEventArgs e)
        {
            view.Children.Clear();
            view.Children.Add(userView);
        }

        private void SetBusinessView(object sender, RoutedEventArgs e)
        {
            view.Children.Clear();
            view.Children.Add(businessView);
            businessView.Attri.PopulateStates();
        }

        private void SetOwnerView(object sender, RoutedEventArgs e)
        {
            view.Children.Clear();
            view.Children.Add(businessOwnerView);
        }

        private void SetMapView(object sender, RoutedEventArgs e)
        {
            view.Children.Clear();
            view.Children.Add(mapView);
        }
    }
}
