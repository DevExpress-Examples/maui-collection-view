using DevExpress.Maui.Core;
using DevExpress.Maui.Core.Internal;
using FilterChips.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilterChips.ViewModel {
    public class MainViewModel : BindableBase {
        string filter;
        public ObservableCollection<Invoice> Invoices {
            get;
            set;
        }
        public ObservableCollection<FilterItem> PredefinedFilters {
            get;
            set;
        }
        public BindingList<FilterItem> SelectedFilters {
            get;
            set;
        }
        public string Filter {
            get {
                return filter;
            }
            set {
                filter = value;
                RaisePropertiesChanged();
            }
        }
        public MainViewModel() {
            Invoices = new ObservableCollection<Invoice>() {
                new Invoice(){ ID = 40202, Company="Around the Horn", CreatedDate = DateTime.Now.AddDays(-2), Price = 930, IsDraft = true },
                new Invoice(){ ID = 50305, Company="Vins et alcools Chevalier", CreatedDate = DateTime.Now.AddDays(-5), Price = 120 },
                new Invoice(){ ID = 10000, Company="Hanari Carnes", CreatedDate = DateTime.Now.AddDays(-10), Price = 1230 },
                new Invoice(){ ID = 73901, Company="Michelson Systems", CreatedDate = DateTime.Now.AddDays(-20), Price = 2500 },
                new Invoice(){ ID = 10360, Company="Ford Consulting", CreatedDate = DateTime.Now.AddDays(-33), Price = 146.5m },
                new Invoice(){ ID = 20070, Company="Blauer See Delikatessen", CreatedDate = DateTime.Now.AddDays(-20), Price = 952 },
                new Invoice(){ ID = 12090, Company="Antonio Moreno Taquería", CreatedDate = DateTime.Now, Price = 1120 , IsDraft = true},
                new Invoice(){ ID = 41505, Company="Ana Trujillo Emparedados", CreatedDate = DateTime.Now.AddDays(-4), Price = 3560 },
                new Invoice(){ ID = 10023, Company="Mickeys World of Fun", CreatedDate = DateTime.Now.AddDays(-6), Price = 4832.5m },
                new Invoice(){ ID = 30000, Company="Mathewson Design", CreatedDate = DateTime.Now.AddDays(-11), Price = 1704 },
                new Invoice(){ ID = 67099, Company="Jeffers Clinic", CreatedDate = DateTime.Now.AddDays(-23), Price = 356 },
                new Invoice(){ ID = 33317, Company="McAllister Systems", CreatedDate = DateTime.Now.AddDays(-9), Price = 470 , IsDraft = true},
                new Invoice(){ ID = 77743, Company="Mildreds World", CreatedDate = DateTime.Now, Price = 984 },
                new Invoice(){ ID = 20173, Company="Alessandro & Associates", CreatedDate = DateTime.Now.AddDays(-25), Price = 1001 },
                new Invoice(){ ID = 10249, Company="James Systems", CreatedDate = DateTime.Now.AddDays(-15), Price = 1084 },
                new Invoice(){ ID = 20407, Company="United Package", CreatedDate = DateTime.Now.AddDays(-6), Price = 1502.5m },
                new Invoice(){ ID = 16058, Company="Development House", CreatedDate = DateTime.Now.AddDays(-1), Price = 1991, IsDraft = true },
                new Invoice(){ ID = 56013, Company="Newman Systems", CreatedDate = DateTime.Now.AddDays(-3), Price = 3200 },
                new Invoice(){ ID = 16090, Company="Jones & Assoc", CreatedDate = DateTime.Now.AddDays(-4), Price = 1400 },
                new Invoice(){ ID = 19342, Company="Christies House of Design", CreatedDate = DateTime.Now.AddDays(-1), Price = 1850 },
                new Invoice(){ ID = 53003, Company="Frankson Media", CreatedDate = DateTime.Now.AddDays(-2), Price = 4930 },
                new Invoice(){ ID = 72040, Company="Menedez Development", CreatedDate = DateTime.Now, Price = 7500},
                new Invoice(){ ID = 12340, Company="Valentine Hearts", CreatedDate = DateTime.Now.AddDays(-7), Price = 2300 },
                new Invoice(){ ID = 94207, Company="Holmes World", CreatedDate = DateTime.Now.AddDays(-12), Price = 5239 },
                new Invoice(){ ID = 18050, Company="Hill Corporation", CreatedDate = DateTime.Now.AddDays(-5), Price = 1102 },
                new Invoice(){ ID = 19303, Company="Doe Enterprises", CreatedDate = DateTime.Now.AddDays(-1), Price = 4650 , IsDraft = true},
            };
            SelectedFilters = new BindingList<FilterItem>();
            PredefinedFilters = new ObservableCollection<FilterItem>() {
                new FilterItem(){ DisplayText= "Today", Filter = "IsOutlookIntervalToday([CreatedDate])" },
                new FilterItem(){ DisplayText= "Last Week", Filter = "IsThisWeek([CreatedDate])" },
                new FilterItem(){ DisplayText= "Drafts", Filter = "[IsDraft] == True" },
                new FilterItem(){ DisplayText= "< $1000", Filter = "[Price] < 1000" },
                new FilterItem(){ DisplayText= "> $4000", Filter = "[Price] > 4000" },
            };
            SelectedFilters.ListChanged += SelectedFiltersChanged;
        }

        private void SelectedFiltersChanged(object sender, ListChangedEventArgs e) {
            if (SelectedFilters.Count > 0)
                Filter = String.Join(" AND ", SelectedFilters.Select(f => f.Filter));
            else
                Filter = string.Empty;
        }
    }

    public class FilterItem {
        public string DisplayText { get; set; }
        public string Filter { get; set; }
    }
}
