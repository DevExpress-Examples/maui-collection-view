using System.Dynamic;

namespace PopupContextMenuActions {
    public partial class MainPage : ContentPage {
        public MainPage() {
            InitializeComponent();
        }

        void ContactActionsClick(object sender, EventArgs e) {
            actionsPopup.PlacementTarget = (View)sender;
            actionsPopup.IsOpen = !actionsPopup.IsOpen;
        }

        private void PopupItemClick(object sender, EventArgs e) {
            actionsPopup.IsOpen = false;
        }
    }
}