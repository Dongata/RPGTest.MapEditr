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

        private Grid groundGrid;
        private Grid middleGrid;
        private Grid topGrid;

        public GridView()
        {
            InitializeComponent();
            _app = Application.Current as App;
            _app.PropertyChanged += OnMapUpdated;
            groundGrid = new Grid();
            middleGrid= new Grid();
            topGrid= new Grid();

            ScrMain.Content = groundGrid;
        }

        private void RenderMap()
        {
            for (var x = 0; x < _map.Width; x++)
            {
                groundGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = size });
                middleGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = size });
                topGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = size });

                for (var y = 0; y < _map.Height; y++)
                {
                    groundGrid.RowDefinitions.Add(new RowDefinition() { Height = size });
                    middleGrid.RowDefinitions.Add(new RowDefinition() { Height = size });
                    topGrid.RowDefinitions.Add(new RowDefinition() { Height = size });

                    AddNewTile(groundGrid, _map.GroundLayer, x, y);
                    AddNewTile(middleGrid, _map.MiddleLayer, x, y);
                    AddNewTile(topGrid, _map.TopLayer, x, y);
                }
            }
        }

        private TileView AddNewTile(Grid grid, Layer layer, int x, int y)
        {
            var tile = layer.Tiles.Find(a => a.X == x && a.Y == y);

            if (tile == null)
            {
                tile = new TileView()
                {
                    Image = _app.EmptyImage,
                    X = x,
                    Y = y
                };

                layer.Tiles.Add(tile);
            }

            tile.MouseLeftButtonUp += Image_MouseLeftButtonUp;
            Grid.SetColumn(tile, y);
            Grid.SetRow(tile, x);
            grid.Children.Add(tile);

            return tile;
        }

        private void Image_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e) => _app.SelectedTile = (TileView)sender;

        private void OnMapUpdated(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(_app.SelectedLayer))
            {
                if(_app.SelectedLayer == "Top")
                {
                    ScrMain.Content = topGrid;
                }

                if (_app.SelectedLayer == "Ground")
                {
                    ScrMain.Content = groundGrid;
                }

                if (_app.SelectedLayer == "Middle")
                {
                    ScrMain.Content = middleGrid;
                }
            }

            if (e.PropertyName == nameof(_app.ActualMap))
            {
                if (_app.ActualMap == null)
                {
                    Grid.SetColumn(_lblNoMap, 0);
                    Grid.SetRow(_lblNoMap, 0);
                    groundGrid.Children.Add(_lblNoMap);
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
