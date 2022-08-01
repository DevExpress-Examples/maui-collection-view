namespace CollectionViewLoadMore {
    public partial class MainPage : ContentPage {

        public MainPage() {
            InitializeComponent();
            BindingContext = new ViewModel(new MailMessageRepository());
        }
    }
}