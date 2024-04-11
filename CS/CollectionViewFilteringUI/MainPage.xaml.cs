using CollectionViewFilteringUI.Utils;
using CollectionViewFilteringUI.ViewModels;
using DevExpress.Maui.Core;
using DevExpress.Maui.Editors;

namespace CollectionViewFilteringUI {
    public partial class MainPage : ContentPage {
        FilteringUIViewModel ViewModel { get; }
        EnumToDescriptionConverter EnumToDescriptionConverter { get; } = new EnumToDescriptionConverter();
        public MainPage() {
            InitializeComponent();
            ViewModel = new FilteringUIViewModel();
            BindingContext = ViewModel;
            UpdateColumnsCount();
            ON.OrientationChanged(this, OnOrientationChanged);
            OnOrientationChanged(this);
        }

        void OnOrientationChanged(ContentPage view) {
            UpdateColumnsCount();
        }

        void UpdateColumnsCount() {
            ViewModel.ColumnsCount = ON.Idiom<int>(ON.Orientation<int>(1, 2), ON.Orientation<int>(2, Height < 600 ? 2 : 4));
        }

        void OnCustomDisplayText(object sender, FilterElementCustomDisplayTextEventArgs e) {
            e.DisplayText = EnumToDescriptionConverter.Convert(e.Value).ToString();
        }
        void OnFilteringUIFormShowing(object sender, FilteringUIFormShowingEventArgs e) {
            if (e.Form is not ContentPage page)
                return;
            page.Title = "Filters";
        }
    }
}