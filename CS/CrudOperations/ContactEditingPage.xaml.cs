using System.Net.Mail;
using DevExpress.Maui.Core;
using DevExpress.Maui.DataForm;

namespace CrudOperations;

public partial class ContactEditingPage : ContentPage {
    DetailEditFormViewModel ViewModel => (DetailEditFormViewModel)BindingContext;

    public ContactEditingPage() {
        InitializeComponent();
    }

    void SaveItemClick(object sender, EventArgs e) {
        if (!dataForm.Validate())
            return;
        dataForm.Commit();
        ViewModel.Save();
    }


    void dataForm_ValidateProperty(object sender, DataFormPropertyValidationEventArgs e) {
        if (e.PropertyName == "Email" && e.NewValue != null) {
            MailAddress res;
            if (!MailAddress.TryCreate((string)e.NewValue, out res)) {
                e.HasError = true;
                e.ErrorText = "Invalid email";
            }
        }
    }
}