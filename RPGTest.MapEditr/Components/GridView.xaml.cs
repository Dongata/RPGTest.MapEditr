using RPGTest.MapEditr.Entities;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace RPGTest.MapEditr.Components
{
    /// <summary>
    /// Interaction logic for GridView.xaml
    /// </summary>
    public partial class GridView : UserControl
    {
        private Map _map;

        private readonly App _app;

        private static readonly Label _lblNoMap = new Label() { Content = "Please create a new map" };

        private GridLength size = new GridLength(32);

        public GridView()
        {
            InitializeComponent();
            _app = Application.Current as App;
            _app.PropertyChanged += OnMapUpdated;
        }

        private void RenderMap()
        {
            for(var x = 0; x < _map.Width; x++)
            {
                MainGrid.ColumnDefinitions.Add(new ColumnDefinition()
                {
                    Width = size
                });

                for(var y = 0; y < _map.Height; y++)
                {
                    var tile = _map.GroundLayer.Tiles.Find(a => a.X == x && a.Y == y);

                    if(tile == null)
                    {
                        tile = new TileView()
                        {
                            Image = _app.EmptyImage,
                            X = x,
                            Y = y
                        };

                        _map.GroundLayer.Tiles.Add(tile);
                    }

                    tile.MouseLeftButtonUp += Image_MouseLeftButtonUp;

                    MainGrid.RowDefinitions.Add(new RowDefinition() { Height = size });

                    Grid.SetColumn(tile, y);
                    Grid.SetRow(tile, x);
                    MainGrid.Children.Add(tile);
                }
            }
        }

        private void Image_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            _app.SelectedTile = (TileView)sender;      
        }

        private void OnMapUpdated(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_app.ActualMap))
            {
                if (_app.ActualMap == null)
                {
                    Grid.SetColumn(_lblNoMap, 0);
                    Grid.SetRow(_lblNoMap, 0);
                    MainGrid.Children.Add(_lblNoMap);
                }
                else
                {
                    _map = _app.ActualMap;
                    RenderMap();
                } 
            }
        }
    }
}
