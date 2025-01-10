using DevExpress.Maui.Core;
using DevExpress.Maui.DataForm;
using DevExpress.Maui.Mvvm;
using Contact = CrudOperations.Model.Contact;

namespace CrudOperations;

public partial class DetailInfoPage : ContentPage {
    DetailFormViewModel ViewModel => ((DetailFormViewModel)BindingContext);
    Contact Item => (Contact)ViewModel.Item;
    bool isDeleting;
    IDXPopupService popupService;

    public DetailInfoPage() {
        InitializeComponent();
        popupService = IPlatformApplication.Current.Services.GetRequiredService<IDXPopupService>();
    }

    async void DeleteItemClick(object sender, EventArgs e) {
        var dialogRes = await popupService.ShowAlert(
            settings: new DXPopupSettings()
            {
                Title = $"Confirm Deletion",
                Message = $"Are you sure you want to remove {Item.FullName} from the database?",
                TitleIcon = "delete",
                VerticalAlignment = DXPopupVerticalAlignment.Center,
                AllowScrim = true,
                CloseOnScrimTap = true,
                BindingContext = this
            },
            ok: "Yes",
            cancel: "No");
        if (dialogRes)
        {
            if (isDeleting)
                return;
            isDeleting = true;
            try
            {
                if (!await ViewModel.DeleteAsync())
                    isDeleting = false;
            }
            catch (Exception ex)
            {
                isDeleting = false;
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }

    void DataFormView_ValidateProperty(object sender, DataFormPropertyValidationEventArgs e) {
        e.ErrorText = e.PropertyName;
        e.HasError = true;
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