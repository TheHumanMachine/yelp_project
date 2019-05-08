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

namespace UIPractive
{
    /// <summary>
    /// Interaction logic for MainVeiwButtons.xaml
    /// </summary>
    public partial class MainVeiwButtons : UserControl
    {
        public Button businessButton;
        public Button userButton;
        public Button mapButton;
        public Button ownerButton;

        private Brush unselectedBtnColor;
        private Brush selectedBtnColor;

        private Image ownerBtnImage_selected;
        private Image ownerBtnImage_unselected;

        private Image mapBtnImage_selected;
        private Image mapBtnImage_unselected;

        private Image businessBtnImage_selected;
        private Image businessBtnImage_unselected;

        private Image userBtnImage_selected;
        private Image userBtnImage_unselected;

        public MainVeiwButtons()
        {
            InitializeComponent();
            var converter = new System.Windows.Media.BrushConverter();
            unselectedBtnColor = (Brush)converter.ConvertFromString("#3f3e45");
            selectedBtnColor = (Brush)converter.ConvertFromString("#bab0a3");
            
            businessBtnImage_unselected = SetImage("/Icons/business_unselected.png");
            businessBtnImage_selected = SetImage("/Icons/business_selected.png");

            userBtnImage_unselected = SetImage("/Icons/user_unselected.png");
            userBtnImage_selected = SetImage("/Icons/user_selected.png");

            mapBtnImage_unselected = SetImage("/Icons/map_unselected.png");
            mapBtnImage_selected = SetImage("/Icons/map_selected.png");

            ownerBtnImage_unselected = SetImage("/Icons/businessOwner_selected.png"); //Needs to be changed when icon is fixed
            ownerBtnImage_unselected.Width = 100;
            ownerBtnImage_unselected.Height = 100;
            ownerBtnImage_selected = SetImage("/Icons/businessOwner_selected.png");
            ownerBtnImage_selected.Width = 100;
            ownerBtnImage_selected.Height = 100;

            ownerButton = new Button
            {
                Background = unselectedBtnColor,
                BorderThickness = new Thickness(0),
                Content = ownerBtnImage_unselected,
                
            };

            ownerButton.Click += ownerView_Click;
            Grid.SetRow(ownerButton, 4);
            btnGrid.Children.Add(ownerButton);

            mapButton = new Button
            {
                Background = unselectedBtnColor,
                BorderThickness = new Thickness(0),
                Content = mapBtnImage_unselected
            };

            mapButton.Click += mapView_Click;
            Grid.SetRow(mapButton, 3);
            btnGrid.Children.Add(mapButton);

            businessButton = new Button
            {
                Background = unselectedBtnColor,
                BorderThickness = new Thickness(0),
                Content = businessBtnImage_unselected
            };

            businessButton.Click += businessView_Click;
            Grid.SetRow(businessButton, 2);
            btnGrid.Children.Add(businessButton);

            userButton = new Button
            {
                Background = selectedBtnColor,
                BorderThickness = new Thickness(0),
                Content = userBtnImage_selected
            };
        
            userButton.Click += userView_Click;
            Grid.SetRow(userButton, 1);
            btnGrid.Children.Add(userButton);
        }

        private Image SetImage(String path)
        {
            var image_bitmap = new BitmapImage(new Uri(path, UriKind.Relative));
            RenderOptions.SetBitmapScalingMode(image_bitmap, BitmapScalingMode.HighQuality);
            var tempImage = new Image
            {
                Source = image_bitmap,
                Width = 120,
                Height = 120,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center
            };

            return tempImage;
        }

        private void businessView_Click(object sender, RoutedEventArgs e)
        {
            businessButton.Background = selectedBtnColor;
            businessButton.Content = businessBtnImage_selected;

            mapButton.Background = unselectedBtnColor;
            mapButton.Content = mapBtnImage_unselected;

            ownerButton.Background = unselectedBtnColor;
            ownerButton.Content = ownerBtnImage_unselected;

            userButton.Background = unselectedBtnColor;
            userButton.Content = userBtnImage_unselected;
        }

        private void userView_Click(object sender, RoutedEventArgs e)
        {
            businessButton.Background = unselectedBtnColor;
            businessButton.Content = businessBtnImage_unselected;

            mapButton.Background = unselectedBtnColor;
            mapButton.Content = mapBtnImage_unselected;

            ownerButton.Background = unselectedBtnColor;
            ownerButton.Content = ownerBtnImage_unselected;

            userButton.Background = selectedBtnColor;
            userButton.Content = userBtnImage_selected;
        }

        private void mapView_Click(object sender, RoutedEventArgs e)
        {
            businessButton.Background = unselectedBtnColor;
            businessButton.Content = businessBtnImage_unselected;

            userButton.Background = unselectedBtnColor;
            userButton.Content = userBtnImage_unselected;

            mapButton.Background = selectedBtnColor;
            mapButton.Content = mapBtnImage_selected;

            ownerButton.Background = unselectedBtnColor;
            ownerButton.Content = ownerBtnImage_unselected;
        }

        private void ownerView_Click(object sender, RoutedEventArgs e)
        {
            businessButton.Background = unselectedBtnColor;
            businessButton.Content = businessBtnImage_unselected;

            userButton.Background = unselectedBtnColor;
            userButton.Content = userBtnImage_unselected;

            mapButton.Background = unselectedBtnColor;
            mapButton.Content = mapBtnImage_unselected;

            ownerButton.Background = selectedBtnColor;
            ownerButton.Content = ownerBtnImage_selected;
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
        }
    }
}

