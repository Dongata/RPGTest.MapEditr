using System.ComponentModel;

namespace RPGTest.MapEditr.Entities
{
    public abstract class BaseNotifier : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void Notify(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
