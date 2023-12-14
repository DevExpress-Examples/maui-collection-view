using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CollectionViewLongTapExamp {
    public class MainViewModel : BindableBase {
        bool isMultipleSelectionEnabled;
        List<object> selectedEmailMessages;
        public ObservableCollection<EmailMessage> EmailMessages {
            get;
            set;
        }
        public List<object> SelectedEmailMessages {
            get {
                return selectedEmailMessages;
            }
            set {
                selectedEmailMessages = value;
                RaisePropertyChanged();
            }
        }
        public bool IsMultipleSelectionEnabled {
            get {
                return isMultipleSelectionEnabled;
            }
            set{
                isMultipleSelectionEnabled = value;
                RaisePropertyChanged();
            }
        }
        public ICommand EnableMultipleSelectionCommand {
            get;
            set;
        }
        public ICommand DisableMultipleSelectionCommand {
            get;
            set;
        }
        public MainViewModel() {
            EmailMessages = DataGenerator.CreateEmailMessages();
            EnableMultipleSelectionCommand = new Command<object>(EnableMultipleSelection);
        }
        public void EnableMultipleSelection(object firstItemToSelect) {
            IsMultipleSelectionEnabled = true;
            SelectedEmailMessages = new List<object>() { firstItemToSelect };
        }
    }

    public class BindableBase : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged([CallerMemberName] string propertyName = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
