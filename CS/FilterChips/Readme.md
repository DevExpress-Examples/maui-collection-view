# Chip Filters for a CollectionView

This example demonstrates how to add chips with predefined filters that you can apply to the [CollectionView](https://docs.devexpress.com/MAUI/403324) control.

**Related Controls and Their Properties**: 
* [FilterChipGroup](https://docs.devexpress.com/MAUI/DevExpress.Maui.Editors.FilterChipGroup): [ItemsSource](https://docs.devexpress.com/MAUI/DevExpress.Maui.Editors.ChipGroup.ItemsSource), [SelectedItems](https://docs.devexpress.com/MAUI/DevExpress.Maui.Editors.FilterChipGroup.SelectedItems), [DisplayMember](https://docs.devexpress.com/MAUI/DevExpress.Maui.Editors.ChipGroup.DisplayMember)
* [DXCollectionView](https://docs.devexpress.com/MAUI/403324): [ItemsSource](https://docs.devexpress.com/MAUI/DevExpress.Maui.CollectionView.DXCollectionView.ItemsSource), [FilterString](https://docs.devexpress.com/MAUI/DevExpress.Maui.CollectionView.DXCollectionView.FilterString), [ItemTemplate](https://docs.devexpress.com/MAUI/DevExpress.Maui.CollectionView.DXCollectionView.ItemTemplate)
* [StatusBarBehavior](https://learn.microsoft.com/en-us/dotnet/communitytoolkit/maui/behaviors/statusbar-behavior)

## Implementation Details

* This project uses the [FilterChipGroup](https://docs.devexpress.com/MAUI/DevExpress.Maui.Editors.FilterChipGroup) control to display chips with predefined filters. The [FilterChipGroup.ItemsSource](https://docs.devexpress.com/MAUI/DevExpress.Maui.Editors.ChipGroup.ItemsSource) property is bound to the *PredefinedFilters* collection. Each item in this collection contains a value and corresponding display text. The value is specified according to the [Criteria Language Syntax](https://docs.devexpress.com/CoreLibraries/4928/devexpress-data-library/criteria-language-syntax).

    ```xml
    <dxe:FilterChipGroup ItemsSource="{Binding PredefinedFilters}" SelectedItems="{Binding SelectedFilters, Mode=TwoWay}"
    ```

    ```csharp
    public class MainViewModel : BindableBase {
        string filter;
        public ObservableCollection<FilterItem> PredefinedFilters {
            get;
            set;
        }
        public BindingList<FilterItem> SelectedFilters {
            get;
            set;
        }
        public MainViewModel() {
            SelectedFilters = new BindingList<FilterItem>();
            PredefinedFilters = new ObservableCollection<FilterItem>() {
                new FilterItem(){ DisplayText= "Today", Filter = "IsOutlookIntervalToday([CreatedDate])" },
                new FilterItem(){ DisplayText= "Last Week", Filter = "IsThisWeek([CreatedDate])" },
                new FilterItem(){ DisplayText= "Drafts", Filter = "[IsDraft] == True" },
                new FilterItem(){ DisplayText= "< $1000", Filter = "[Price] < 1000" },
                new FilterItem(){ DisplayText= "> $4000", Filter = "[Price] > 4000" },
            };
    }
    ```

* The [FilterChipGroup.SelectedItems](https://docs.devexpress.com/MAUI/DevExpress.Maui.Editors.FilterChipGroup.SelectedItems) property returns a `BindingList`. You can handle the [BindingList.ListChanged](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.bindinglist-1.listchanged) event to update the filter condition. In the event handler, create the filter string and pass it to the [FilterString](https://docs.devexpress.com/MAUI/DevExpress.Maui.CollectionView.DXCollectionView.FilterString) property.

    ```xaml
    <dxcv:DXCollectionView FilterString="{Binding Filter, Mode=TwoWay}" ... 
    ```

    ```
    public class MainViewModel : BindableBase 
        string filter;
        public BindingList<FilterItem> SelectedFilters {
            get;
            set;
        }
        public string Filter {
            get {
                return filter;
            }
            set {
                filter = value;
                RaisePropertiesChanged();
            }
        }
        private void SelectedFiltersChanged(object sender, ListChangedEventArgs e) {
            if (SelectedFilters.Count > 0)
                Filter = String.Join(" AND ", SelectedFilters.Select(f => f.Filter));
            else
                Filter = string.Empty;
        }
    }
    ```

* The [FilterChipGroup](https://docs.devexpress.com/MAUI/DevExpress.Maui.Editors.FilterChipGroup) control's appearance settings are defined in application resources:

    ```
    <Style TargetType="dxe:FilterChipGroup">
        <Setter Property="ChipSelectedBackgroundColor" Value="{AppThemeBinding Light={StaticResource SecondaryContainer}, Dark={StaticResource SelectedChipBackgroundDark}}" />
        <Setter Property="ChipCheckIconColor" Value="{AppThemeBinding Light={StaticResource Gray600}, Dark={StaticResource SecondaryContainer}}" />
        <Setter Property="ChipTextColor" Value="{AppThemeBinding Light={StaticResource Gray600}, Dark=White}" />
        <Setter Property="ChipSelectedBorderColor" Value="{AppThemeBinding Light={StaticResource SelectedChipBorderLight}, Dark={StaticResource SelectedChipBorderDark}}" />
        <Setter Property="ChipBorderThickness" Value="2" />
        <Setter Property="ChipSelectedTextColor" Value="{AppThemeBinding Light={StaticResource Gray600}, Dark={StaticResource SecondaryContainer}}" />
        <Setter Property="ChipFontAttributes" Value="None" />
    </Style>
    ```
