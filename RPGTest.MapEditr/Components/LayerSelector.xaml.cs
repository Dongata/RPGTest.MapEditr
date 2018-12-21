using System.Windows;
using System.Windows.Controls;

namespace RPGTest.MapEditr.Components
{
    /// <summary>
    /// Interaction logic for LayerSelector.xaml
    /// </summary>
    public partial class LayerSelector : UserControl
    {
        private readonly App _app;

        public LayerSelector()
        {
            InitializeComponent();
            _app = Application.Current as App;
        }


        private void GroundLayerChecked(object sender, RoutedEventArgs e)
        {
            if (_app != null)
            {
                if (_app.SelectedLayer != "Ground")
                {
                    _app.SelectedLayer = "Ground";
                }
            }
        }

        private void MiddleLayerChecked(object sender, RoutedEventArgs e)
        {
            if (_app != null)
            {
                if (_app.SelectedLayer != "Middle")
                {
                    _app.SelectedLayer = "Middle";
                }
            }
        }

        private void TopLayerChecked(object sender, RoutedEventArgs e)
        {
            if (_app != null)
            {
                if (_app.SelectedLayer != "Top")
                {
                    _app.SelectedLayer = "Top";
                }
            }
        }
    }
}
