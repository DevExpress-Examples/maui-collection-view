using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DevExpress.Maui.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CollectionViewLongTapExamp
{
    public partial class MainViewModel : DXObservableObject
    {
        [ObservableProperty]
        ObservableCollection<EmailMessage> emailMessages;

        [ObservableProperty]
        List<object> selectedEmailMessages;

        [ObservableProperty]
        bool isMultipleSelectionEnabled;
     
        public MainViewModel()
        {
            EmailMessages = DataGenerator.CreateEmailMessages();
        }

        [RelayCommand]
        public void EnableMultipleSelection(object firstItemToSelect)
        {
            IsMultipleSelectionEnabled = true;
            SelectedEmailMessages = new List<object>() { firstItemToSelect };
        }
    }
}
