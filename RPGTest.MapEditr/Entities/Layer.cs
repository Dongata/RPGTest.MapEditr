using RPGTest.MapEditr.Components;
using System.Collections.Generic;

namespace RPGTest.MapEditr.Entities
{
    public class Layer : BaseNotifier
    {
        private List<TileView> _tiles;

        public Layer()
        {
            Tiles = new List<TileView>();
        }

        public List<TileView> Tiles
        {
            get => _tiles;
            set
            {
                _tiles = value;
                Notify(nameof(Tiles));
            }
        }
    }
}
