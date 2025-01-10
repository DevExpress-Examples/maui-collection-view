using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DevExpress.Maui.Core;
using DevExpress.Maui.Mvvm;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CrudOperations.ViewModels
{
    public partial class ContactsCRUDViewModel : DXObservableObject
    {
        [ObservableProperty]
        string userSearchString;

        [ObservableProperty]
        string filterString;

        [ObservableProperty]
        ObservableCollection<Model.Contact> contacts;

        [ObservableProperty]
        ObservableCollection<string> companies;

        [ObservableProperty]
        bool isRefreshing;

        [RelayCommand]
        async Task LoadData()
        {
            IsRefreshing = true;
            using ContactsContext context = new ContactsContext();
            await context.Contacts.LoadAsync();
            Contacts = new ObservableCollection<Model.Contact>(context.Contacts);
            Companies = new ObservableCollection<string>(Contacts.Select(c => c.Company));
            IsRefreshing = false;
        }

        partial void OnUserSearchStringChanged(string oldValue, string newValue)
        {
            FilterString = $"Contains([FirstName], '{UserSearchString}') or Contains([LastName], '{UserSearchString}')";
        }

        [RelayCommand]
        void CreateDetailFormViewModel(CreateDetailFormViewModelEventArgs e)
        {
            if (e.DetailFormType == DetailFormType.Edit)
            {
                ContactsContext contactsContext = new ContactsContext();
                Model.Contact editedContact = (Model.Contact)contactsContext.Find(typeof(Model.Contact), ((Model.Contact)e.Item).ID);
                e.Result = new DetailEditFormViewModel(editedContact, isNew: false, context: contactsContext);
            }
        }

        [RelayCommand]
        async Task ValidateAndSave(ValidateItemEventArgs e)
        {
            ContactsContext context;
            var changedContact = (Model.Contact)e.Item;
            if (e.DataChangeType == DataChangeType.Edit)
            {
                context = (ContactsContext)e.Context;
            }
            else
                context = new ContactsContext();
            try
            {
                if (e.DataChangeType == DataChangeType.Add)
                {
                    context.Contacts.Add(changedContact);
                }
                else if (e.DataChangeType == DataChangeType.Edit)
                {
                    context.Contacts.Update(changedContact);
                }
                else if (e.DataChangeType == DataChangeType.Delete)
                {
                    var issue = new Model.Contact() { ID = changedContact.ID };
                    context.Entry(issue).State = EntityState.Deleted;
                }
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                e.IsValid = false;
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}