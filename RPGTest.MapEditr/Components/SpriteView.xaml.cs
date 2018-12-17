using System.Windows.Controls;

namespace RPGTest.MapEditr.Components
{
    /// <summary>
    /// Interaction logic for SpriteView.xaml
    /// </summary>
    public partial class SpriteView : UserControl
    {
        public SpriteView(Image sprite)
        {
            InitializeComponent();
            Sprite = sprite;
            DataContext = Sprite;
        }

        public Image Sprite { get; set; }
    }
}
