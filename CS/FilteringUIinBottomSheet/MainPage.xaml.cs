using BottomSheetFilterUI.ViewModel;
using DevExpress.Maui.Controls;
using DevExpress.Maui.Core;
using DevExpress.Maui.Editors;
using Microsoft.Maui.Controls.Shapes;
using System.Collections.ObjectModel;
using System.Globalization;

namespace BottomSheetFilterUI {
    public partial class MainPage : ContentPage {
        public MainPage() {
            InitializeComponent();
            //tutorsCollection.FilteringContext.ResetFilterCommand
        }

        private void OnFilterChipGroupTap(object sender, ChipEventArgs e) {
            filterTabView.SelectedItemIndex = filterChipGroup.Chips.IndexOf(e.Chip);
            UpdateBottmSheetState(filterTabView.SelectedItemIndex);
        }

        private void OnCloseBottomSheetClicked(object sender, EventArgs e) {
            filterBottomSheet.State = BottomSheetState.Hidden;
        }

        private void FilterTabHeaderTapped(object sender, ItemHeaderTappedEventArgs e) {
            UpdateBottmSheetState(e.Index);
        }
        void UpdateBottmSheetState(int selectedIndex) {
            if (selectedIndex == 2)
                filterBottomSheet.State = BottomSheetState.FullExpanded;
            else
                filterBottomSheet.State = BottomSheetState.HalfExpanded;
        }
    }

    public class IsFilterEmptyConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if(value is FilterValueInfo filterInfo && filterInfo != null) {
                return filterInfo.Count == 0;
            }
            else if (value is int selectedFilterItems) {
                return selectedFilterItems == 0;
            }
            return true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}