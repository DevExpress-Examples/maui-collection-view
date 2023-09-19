using DevExpress.Maui.CollectionView;

namespace CollectionViewSwipe {
    public partial class MainPage : ContentPage {

        public MainPage() {
            InitializeComponent();
        }

        void SwipeItem_Tapped(System.Object sender, SwipeItemTapEventArgs e) {
            this.collectionView.DeleteItem(e.ItemHandle);
        }
    }
}