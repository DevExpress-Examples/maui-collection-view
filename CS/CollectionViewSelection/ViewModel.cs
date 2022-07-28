using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CollectionViewSelection {
    public class Contact {
        string name;
        public string Name {
            get => this.name;
            set {
                this.name = value;
                if (Photo == null) {
                    string resourceName = value.Replace(" ", "").ToLower() + ".jpg";
                    Photo = ImageSource.FromFile(resourceName);
                }
            }
        }

        public Contact(string name, string phone) {
            Name = name;
            Phone = phone;
        }
        public ImageSource Photo { get; set; }
        public string Phone { get; set; }
    }

    public class ViewModel : INotifyPropertyChanged {
        public List<Contact> Contacts { get; }

        List<Contact> selectedContacts;
        public List<Contact> SelectedContacts {
            get { return selectedContacts; }
            set {
                if (selectedContacts != value) {
                    selectedContacts = value;
                }
            }
        }

        public ViewModel() {
            Contacts = new List<Contact>() {
                new Contact("Nancy Davolio", "(206) 555-9857"),
                new Contact("Andrew Fuller", "(206) 555-9482"),
                new Contact("Janet Leverling", "(206) 555-3412"),
                new Contact("Margaret Peacock", "(206) 555-8122"),
                new Contact("Steven Buchanan", "(71) 555-4848"),
                new Contact("Michael Suyama", "(71) 555-7773"),
                new Contact("Robert King", "(71) 555-5598"),
                new Contact("Laura Callahan", "(206) 555-1189"),
                new Contact("Anne Dodsworth", "(71) 555-4444"),
            };
            SelectedContacts = new List<Contact> { Contacts[1], Contacts[3] };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
