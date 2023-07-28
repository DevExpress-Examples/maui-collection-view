using DevExpress.Maui.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CrudOperations.ViewModels {
    public class ContactsCRUDViewModel : BindableBase {
        bool isRefreshing;
        string userSearchString;
        string filterString;
        ObservableCollection<Model.Contact> contacts;
        ObservableCollection<string> companies;

        public ICommand RefreshDataCommand { get; }
        public ICommand CreateDetailFormViewModelCommand { get; }
        public ICommand ValidateAndSaveCommand { get; }

        public ObservableCollection<Model.Contact> Contacts {
            get => contacts;
            set {
                contacts = value;
                RaisePropertiesChanged();
            }
        }
        public ObservableCollection<string> Companies {
            get => companies;
            set {
                companies = value;
                RaisePropertiesChanged();
            }
        }
        public bool IsRefreshing {
            get => isRefreshing;
            set {
                isRefreshing = value;
                RaisePropertiesChanged();
            }
        }
        public string UserSearchString {
            get => userSearchString;
            set {
                userSearchString = value;
                UpdateFilterString();
                RaisePropertiesChanged();
            }
        }
        public string FilterString {
            get => filterString;
            set {
                filterString = value;
                RaisePropertiesChanged();
            }
        }

        public ContactsCRUDViewModel() {
            LoadData();
            RefreshDataCommand = new Command(LoadData);
            CreateDetailFormViewModelCommand = new Command<CreateDetailFormViewModelEventArgs>(CreateDetailFormViewModel);
            ValidateAndSaveCommand = new Command<ValidateItemEventArgs>(ValidateAndSave);
        }

        async void LoadData() {
                IsRefreshing = true;
                using ContactsContext context = new ContactsContext();
                await context.Contacts.LoadAsync();
                Contacts = new ObservableCollection<Model.Contact>(context.Contacts);
                Companies = new ObservableCollection<string>(Contacts.Select(c => c.Company));
                IsRefreshing = false;
        }
        void UpdateFilterString() {
            FilterString = $"Contains([FirstName], '{UserSearchString}') or Contains([LastName], '{UserSearchString}')";
        }

        void CreateDetailFormViewModel(CreateDetailFormViewModelEventArgs e) {
            if (e.DetailFormType == DetailFormType.Edit) {
                ContactsContext contactsContext = new ContactsContext();
                Model.Contact editedContact = (Model.Contact)contactsContext.Find(typeof(Model.Contact), ((Model.Contact)e.Item).ID);
                e.Result = new DetailEditFormViewModel(editedContact, isNew: false, context: contactsContext);
            }
        }
        async void ValidateAndSave(ValidateItemEventArgs e) {
            ContactsContext context;
            var changedContact = (Model.Contact)e.Item;
            if (e.DataChangeType == DataChangeType.Edit) {
                context = (ContactsContext)e.Context;
            }
            else
                context = new ContactsContext();
            try {
                if (e.DataChangeType == DataChangeType.Add) {
                    context.Contacts.Add(changedContact);
                }
                else if (e.DataChangeType == DataChangeType.Edit) {
                    context.Contacts.Update(changedContact);
                }
                else if (e.DataChangeType == DataChangeType.Delete) {
                    var issue = new Model.Contact() { ID = changedContact.ID };
                    context.Entry(issue).State = EntityState.Deleted;
                }
                context.SaveChanges();
            }
            catch (Exception ex) {
                e.IsValid = false;
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}