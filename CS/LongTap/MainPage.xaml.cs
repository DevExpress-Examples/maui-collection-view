using DevExpress.Data.Browsing.Design;
using DevExpress.Maui.CollectionView;
using System.Collections;
using DevExpress.Maui.Core;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

namespace CollectionViewLongTapExamp {
    public partial class MainPage : ContentPage {
        public MainPage() {
            InitializeComponent();
            TitleAreaColor = ThemeColor.Primary;
            //SetDefaultTitleColor();
        }

        public ThemeColor TitleAreaColor {
            get { return (ThemeColor)GetValue(TitleAreaColorProperty); }
            set { SetValue(TitleAreaColorProperty, value); }
        }

        public static readonly BindableProperty TitleAreaColorProperty = BindableProperty.Create("TitleAreaColor", typeof(ThemeColor), typeof(MainPage));

        private void DXCollectionView_LongPress(object sender, CollectionViewGestureEventArgs e) {
            EnableMultipleSelectionMode();
            collectionView.SelectedItems = new List<object>() { e.Item };
        }

        private void CollectionViewSelectionChanged(object sender, CollectionViewSelectionChangedEventArgs e) {
            int selectionCount = ((IList)collectionView.SelectedItems).Count;
            if (selectionCount == 0)
                DisableMultipleSelectionMode();
            else {
                selectionLabel.Text = selectionCount.ToString();
            }
        }
        void EnableMultipleSelectionMode() {
            collectionView.SelectionMode = SelectionMode.Multiple;
            defaultTitle.IsVisible = false;
            multipleSelectionPanel.IsVisible = true;
            HapticFeedback.Default.Perform(HapticFeedbackType.LongPress);
        }
        void DisableMultipleSelectionMode() {
            collectionView.SelectionMode = SelectionMode.None;
            defaultTitle.IsVisible = true;
            multipleSelectionPanel.IsVisible = false;
            //SetDefaultTitleColor();
        }

        private void SelectAllButtonClick(object sender, EventArgs e) {
            List<object> newSelectedItems = new List<object>();
            foreach (var item in (IList)collectionView.ItemsSource)
                newSelectedItems.Add(item);
            collectionView.SelectedItems = newSelectedItems;
        }

        private void CancelButtonClick(object sender, EventArgs e) {
            DisableMultipleSelectionMode();
        }
        //void SetDefaultTitleColor() {
        //    this.SetAppThemeColor(TitleAreaColorProperty, (Color)App.Current.Resources["Primary"], (Color)App.Current.Resources["Gray950"]);
        //}
    }
    public class SelectableItem : ContentView {
        public bool IsSelected {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }
        public static readonly BindableProperty IsSelectedProperty = BindableProperty.Create("IsSelected", typeof(bool), typeof(SelectableItem));
    }
    public class TitleViewFix : Grid {
        bool isMeasured;
        protected override Size MeasureOverride(double widthConstraint, double heightConstraint) {
            isMeasured = true;
            return base.MeasureOverride(widthConstraint, heightConstraint);
        }
        protected override Size ArrangeOverride(Rect bounds) {
            if(!isMeasured)
                Measure(bounds.Width, double.PositiveInfinity, MeasureFlags.None);
            if (bounds.Height == 0)
                bounds.Height = DesiredSize.Height + 12;
            return base.ArrangeOverride(bounds);
        }
    }
}
