using Microsoft.Win32;
using Newtonsoft.Json;
using RPGTest.MapEditr.Views;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace RPGTest.MapEditr
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private NewMap _newMapView;
        private AddImage _addImage;
        private readonly App _app;

        public MainWindow()
        {
            InitializeComponent();
            _newMapView = new NewMap();
            _addImage = new AddImage();
            _app = Application.Current as App;

            _newMapView.Closed += ActivateThis;
            _addImage.Closed += ActivateThis;
        }

        private void ActivateThis(object sender, EventArgs e)
        {
            IsEnabled = true;

            if(sender is AddImage)
            {
                SpriteExplorer.Update();
            }
        }

        private void MenuItemNew_Click(object sender, RoutedEventArgs e)
        {
            IsEnabled = false;
            _newMapView = new NewMap();
            _newMapView.Closed += ActivateThis;
            _newMapView.Show();
        }

        private void MenuItemAddImage_Click(object sender, RoutedEventArgs e)
        {
            IsEnabled = false;
            _addImage = new AddImage();
            _addImage.Closed += ActivateThis;
            _addImage.Show();
        }

        private void MenuItemSaveMap_Click(object sender, RoutedEventArgs e)
        {
            var openDialog = new SaveFileDialog();
            openDialog.FileName = _app.ActualMap.Name + ".json";
            openDialog.DefaultExt = ".json";
            openDialog.AddExtension = true;

            if (openDialog.ShowDialog() == true)
            {
                using (var file = File.Create(openDialog.FileName))
                {
                    using (var stringReader = new StreamWriter(file))
                    {
                        stringReader.Write(JsonConvert.SerializeObject(_app.ActualMap));
                    }
                }
            }
        }

        private void MenuItemOpenMap_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
