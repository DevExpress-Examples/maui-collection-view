using DevExpress.Maui.Core;
using DevExpress.Maui.DataForm;
using Contact = CrudOperations.Model.Contact;

namespace CrudOperations;

public partial class DetailInfoPage : ContentPage {
    DetailFormViewModel ViewModel => ((DetailFormViewModel)BindingContext);
    Contact Item => (Contact)ViewModel.Item;
    bool isDeleting;

    public DetailInfoPage() {
        InitializeComponent();
    }

    void DeleteItemClick(object sender, EventArgs e) {
        popup.IsOpen = true;
    }

    void DataFormView_ValidateProperty(object sender, DataFormPropertyValidationEventArgs e) {
        e.ErrorText = e.PropertyName;
        e.HasError = true;
    }

    void CancelDeleteClick(object sender, EventArgs e) {
        popup.IsOpen = false;
    }

    void DeleteConfirmedClick(object sender, EventArgs e) {
        if (isDeleting)
            return;
        isDeleting = true;

        try {
            if (!ViewModel.Delete())
                isDeleting = false;
        } catch (Exception ex) {
            isDeleting = false;
            DisplayAlert("Error", ex.Message, "OK");
        }
    }

    async void MessageClick(object sender, EventArgs e) {
        if (Sms.Default.IsComposeSupported) {
            string[] recipients = new[] { Item.HomePhone };
            var message = new SmsMessage(string.Empty, recipients);
            await Sms.Default.ComposeAsync(message);
        }
    }

    void CallClick(object sender, EventArgs e) {
        if (PhoneDialer.Default.IsSupported)
            PhoneDialer.Default.Open(Item.HomePhone);
    }

    async void MailClick(object sender, EventArgs e) {
        if (Email.Default.IsComposeSupported) {
            string[] recipients = new[] { Item.Email };

            var message = new EmailMessage {
                BodyFormat = EmailBodyFormat.PlainText,
                To = recipients.ToList()
            };

            await Email.Default.ComposeAsync(message);
        }
    }

    async void CopyPhoneClick(object sender, EventArgs e) {
        await Clipboard.Default.SetTextAsync(Item.HomePhone);
    }

    async void CopyEmailClick(object sender, EventArgs e) {
        await Clipboard.Default.SetTextAsync(Item.Email);
    }
}