using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PopupContextMenuActions {
    public class MainViewModel : BindableBase {
        ObservableCollection<ContactPerson> contacts;

        object placementTarget;
        bool isOpenPopup;
        public ObservableCollection<ContactPerson> Contacts {
            get => this.contacts;
            set {
                contacts = value;
                RaisePropertyChanged();
            }
        }

        public bool IsOpenPopup {
            get => this.isOpenPopup;
            set {
                isOpenPopup = value;
                RaisePropertyChanged();
            }
        }


        public object PlacementTarget {
            get => this.placementTarget;
            set {
                placementTarget = value;
                RaisePropertyChanged();
            }
        }
        public ICommand PopupActionCommand {
            get;
            set;
        }

        public MainViewModel() {
            PopupActionCommand = new Command<string>(PopupAction);
            Contacts = ContactDataGenerator.CreateContacts();
        }
        public async void PopupAction(string parameter) {
            await Application.Current.MainPage.DisplayAlert("Popup item is clicked", parameter, "OK");
        }
    }

    public class ContactPerson {
        public ContactPerson(string firstName, string lastName, string email) {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get => $"{FirstName} {LastName}"; }
        public string Email { get; set; }

        public string Initials {
            get {
                if (FirstName == null || LastName == null)
                    return "?";
                return FirstName.Substring(0, 1) + LastName.Substring(0, 1);
            }
        }
        Color categoryColor;
        public Color CategoryColor {
            get {
                if (categoryColor == null) {
                    categoryColor = ContactColors.GetRandomColor();
                }
                return categoryColor;
            }
        }
    }
    public class BindableBase : INotifyPropertyChanged {

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public static class ContactDataGenerator {
        public static ObservableCollection<ContactPerson> CreateContacts() {
            return new ObservableCollection<ContactPerson>() {
                new ContactPerson("John", "Doe", "john.doe@doeent.com"),
                new ContactPerson("Sam", "Hill", "sam.hill@hillcorp.com"),
                new ContactPerson("Karen", "Holmes", "karen.holves@holmesworld.com"),
                new ContactPerson("Bobbie", "Valentine", "bobbie.val@valetinehearts@com"),
                new ContactPerson("Jennie", "Valentine", "jennie.valentine@valetinehearts@com"),
                new ContactPerson("Albert", "Menendez", "albert.men@menendezdev.com"),
                new ContactPerson("Frank", "Frankson", "frank.frankson@franksonmedia.com"),
                new ContactPerson("Christa", "Christie", "christina.c@chod.com"),
                new ContactPerson("Jimmie", "Jones", "jimmie.jones@jandassoc.com"),
                new ContactPerson("Alfred", "Newman", "alfred.nm@newmansystems.com"),
                new ContactPerson("Benjamin", "Johnson", "ben.johnson@developmenthouse.com"),
                new ContactPerson("Alex", "James", "alex.james@jamessystems.com"),
                new ContactPerson("Beau", "Alessandro", "beau.a@aanda@com"),
                new ContactPerson("Mildred", "Johansson", "mildred.j@mildredsworld.com"),
                new ContactPerson("Henry", "McAllister", "henry.m@mcallistersys.com"),
                new ContactPerson("Aaron", "Mathewson", "michael.j@jeffersclinic.com"),
            };
        }
    }
    public class ContactColors {
        public static Color GetRandomColor() {
            return GetColor(new Random().Next(10));
        }
        public static Color GetColor(int colorNumber) {
            switch (colorNumber) {
                case 1: return Color.FromArgb("#f15558");
                case 2: return Color.FromArgb("#ff7c11");
                case 3: return Color.FromArgb("#ffbf22");
                case 4: return Color.FromArgb("#ff6e86");
                case 5: return Color.FromArgb("#9865b0");
                case 6: return Color.FromArgb("#756cfd");
                case 7: return Color.FromArgb("#0055d8");
                case 8: return Color.FromArgb("#01b0ee");
                case 9: return Color.FromArgb("#0097ad");
                case 0: return Color.FromArgb("#00c831");
                default: return Color.FromArgb("#949494");
            }
        }
    }
}
