using CollectionViewFilteringUI.Utils;
using CollectionViewFilteringUI.ViewModels;
using DevExpress.Maui.Core;
using DevExpress.Maui.Editors;

namespace CollectionViewFilteringUI {
    public partial class MainPage : ContentPage {
        public MainPage() {
            InitializeComponent();
            BindingContext = new FilteringUIViewModel();
        }
        EnumToDescriptionConverter EnumToDescriptionConverter { get; } = new EnumToDescriptionConverter();


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