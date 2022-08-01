namespace CollectionViewPullToRefresh {
    public partial class MainPage : ContentPage {
        int count = 0;

        public MainPage() {
            InitializeComponent();
            BindingContext = new ViewModel(new MailMessageRepository());
        }
    }
}