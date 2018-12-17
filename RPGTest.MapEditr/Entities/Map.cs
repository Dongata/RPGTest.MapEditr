namespace RPGTest.MapEditr.Entities
{
    public class Map : BaseNotifier
    {
        private int _width;
        private int _height;
        private string _name;
        private Layer _groundLayer;
        private Layer _middleLayer;
        private Layer _topLayer;

        public Map(string name, int width, int height)
        {
            Name = name;
            Width = width;
            Height = height;
            GroundLayer = new Layer();
            MiddleLayer = new Layer();
            TopLayer = new Layer();
        }

        public int Width
        {
            get => _width;
            set
            {
                _width = value;
                Notify(nameof(Width));
            }
        }

        public int Height
        {
            get => _height;
            set
            {
                _height = value;
                Notify(nameof(Height));
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                Notify(nameof(Name));
            }
        }

        public Layer GroundLayer
        {
            get => _groundLayer;
            set
            {
                _groundLayer = value;
                Notify(nameof(GroundLayer));
            }
        }

        public Layer MiddleLayer
        {
            get => _middleLayer;
            set
            {
                _middleLayer = value;
                Notify(nameof(MiddleLayer));
            }
        }

        public Layer TopLayer
        {
            get => _topLayer;
            set
            {
                _topLayer = value;
                Notify(nameof(TopLayer));
            }
        }
    }
}
