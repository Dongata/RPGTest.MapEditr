using RPGTest.MapEditr.Components;
using RPGTest.MapEditr.Entities;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace RPGTest.MapEditr
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application, INotifyPropertyChanged
    {
        private Map _actualMap;
        private ObservableCollection<Image> _sprites;
        private TileView _selectedTile;
        private string _selectedLayer = "Ground";

        public App() : base()
        {
            EmptyImage = new Image()
            {
                Name = "Empty",
                Width = 32,
                Height = 32,
                Source = new BitmapImage(new Uri(Path.Combine(AppContext.BaseDirectory, "Resources", "Empty.png")))
            };
            Sprites = new ObservableCollection<Image>() { EmptyImage };
        }

        public string SelectedLayer
        {
            get => _selectedLayer;
            set
            {
                _selectedLayer = value;
                Notify(nameof(SelectedLayer));
            }
        }

        public Map ActualMap
        {
            get => _actualMap;
            set
            {
                _actualMap = value;
                Notify(nameof(ActualMap));
            }
        }

        public ObservableCollection<Image> Sprites
        {
            get => _sprites;
            set
            {
                _sprites = value;
                Notify(nameof(Sprites));
            }
        }

        public TileView SelectedTile
        {
            get => _selectedTile;
            set
            {
                _selectedTile = value;
                Notify(nameof(SelectedTile));
            }
        }

        public Image EmptyImage { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Notify(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
