using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace RPGTest.MapEditr.Components
{
    /// <summary>
    /// Interaction logic for SripteExplorer.xaml
    /// </summary>
    public partial class SripteExplorer : UserControl
    {
        private readonly App _app;

        public SripteExplorer()
        {
            InitializeComponent();
            _app = Application.Current as App;
            _app.PropertyChanged += OnListUpdated;
            Sprites = new List<SpriteView>();
            Load(_app.Sprites);
        }

        public List<SpriteView> Sprites { get; set; }
        
        public void Update()
        {
            Clean();
            Load(_app.Sprites);
        }

        private void OnListUpdated(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_app.Sprites))
            {
                Clean();
                Load(_app.Sprites);
            }
        }

        private void Load(ObservableCollection<Image> sprites)
        {
            foreach (var sprite in sprites)
            {
                var spriteView = new SpriteView(sprite);
                StackSprites.Children.Add(spriteView);
                Sprites.Add(spriteView);
            }

        }

        private void Clean()
        {
            StackSprites.Children.Clear();
            Sprites.Clear();
        }
    }
}
