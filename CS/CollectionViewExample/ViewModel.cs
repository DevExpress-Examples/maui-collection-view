using CommunityToolkit.Mvvm.ComponentModel;
using DevExpress.Maui.Mvvm;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CollectionViewExample
{
    public partial class ViewModel : DXObservableObject
    {
        [ObservableProperty]
        List<Contact> data;
        public ViewModel()
        {
            Data = new List<Contact>() {
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
        }
    }

    public class Contact
    {
        public Contact(string name, string phone)
        {
            Name = name;
            Phone = phone;
        }

        string name;
        public string Name
        {
            get => name;
            set
            {
                name = value;
                if (Photo == null)
                {
                    string resourceName = value.Replace(" ", "").ToLower() + ".jpg";
                    Photo = ImageSource.FromFile(resourceName);
                }
            }
        }
        public ImageSource Photo { get; set; }
        public string Phone { get; set; }
    }


}