using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace RPGTest.MapEditr.Components
{
    /// <summary>
    /// Interaction logic for TileProperties.xaml
    /// </summary>
    public partial class TileProperties : UserControl
    {
        private readonly App _app;

        public TileProperties()
        {
            InitializeComponent();
            _app = Application.Current as App;
            _app.PropertyChanged += OnAppPropertyChanged;
            CmbImage.ItemsSource = _app.Sprites;
        }

        private void OnAppPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_app.SelectedTile))
            {
                DataContext = _app.SelectedTile;
                CmbImage.SelectedItem = CmbImage.ItemsSource.Cast<Image>().FirstOrDefault(a => a.Source == _app.SelectedTile.Image?.Source);
                UpdateLayout();
            }
            else if (e.PropertyName == nameof(_app.Sprites))
            {
                CmbImage.ItemsSource = _app.Sprites;
                CmbImage.UpdateLayout();
            }
        }

        private void CmbImage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //_app.SelectedTile.Image 
        }
    }
}
