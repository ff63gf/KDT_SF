using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_BasicControl
{
    public class ViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<string> _items;
        public ObservableCollection<string> Items
        {  
            get { return _items; } 
            set 
            { 
                _items = value;
                OnPropertyChanged(nameof(Items));

            }
        }

        public ViewModel()
        {
            Items = new ObservableCollection<string>();
            Items.Add("Item 1");
            Items.Add("Item 2");
            Items.Add("Item 3");
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
