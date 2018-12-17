using Newtonsoft.Json;
using RPGTest.MapEditr.Entities;
using System.Windows.Controls;

namespace RPGTest.MapEditr.Components
{
    /// <summary>
    /// Interaction logic for TileView.xaml
    /// </summary>
    [JsonConverter(typeof(TileJsonConverter))]
    public partial class TileView : UserControl
    {
        private Image _image;

        public TileView()
        {
            InitializeComponent();
        }

        public int X { get; set; }

        public int Y { get; set; }

        public Image Image
        {
            get => _image;
            set
            {
                GrdContent.Children.Clear();

                GrdContent.Children.Add(new Image() { Source = value?.Source ?? new Image().Source});
                _image = value;
            }
        }
    }
}
