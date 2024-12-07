using System.ComponentModel;

namespace MauiApp1
{
    public class AbacusRow : INotifyPropertyChanged
    {
        private int _value;
        private int _placeValue;

        // A Slider változása automatikusan frissíti a Label-t
        public int Value
        {
            get { return _value; }
            set
            {
                if (_value != value)
                {
                    _value = value;
                    OnPropertyChanged(nameof(Value));  // Frissíti a megfelelő PropertyChanged eseményt
                }
            }
        }

        public int PlaceValue
        {
            get { return _placeValue; }
            set
            {
                if (_placeValue != value)
                {
                    _placeValue = value;
                    OnPropertyChanged(nameof(PlaceValue));  // Frissíti a megfelelő PropertyChanged eseményt
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
