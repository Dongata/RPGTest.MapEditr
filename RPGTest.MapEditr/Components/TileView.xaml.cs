using Newtonsoft.Json;
using RPGTest.MapEditr.Entities;
using System.ComponentModel;
using System.Windows.Controls;

namespace RPGTest.MapEditr.Components
{
    /// <summary>
    /// Interaction logic for TileView.xaml
    /// </summary>
    [JsonConverter(typeof(TileJsonConverter))]
    public partial class TileView : UserControl, INotifyPropertyChanged
    {
        private Image _image;
        private bool _shouldCollide;

        public TileView()
        {
            InitializeComponent();
        }

        public int X { get; set; }

        public int Y { get; set; }

        public bool ShouldCollide
        {
            get => _shouldCollide;
            set
            {
                _shouldCollide = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ShouldCollide)));
            }
        }

        public Image Image
        {
            get => _image;
            set
            {
                GrdContent.Children.Clear();

                GrdContent.Children.Add(new Image() { Source = value?.Source ?? new Image().Source });
                _image = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
