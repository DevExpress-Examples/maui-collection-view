<!-- default badges list -->
Automatically generated badges
<!-- default badges end -->

# DevExpress CollectionView for .NET MAUI - Create a Filter UI Form 

This example shows how to implement a filtering form. In this form, users can specify filter rules applied to multiple data source fields. 

![DevExpress CollectionView for .NET MAUI - Filtering UI](Images/cv-filtering-ui-demo.png)

## Implementation Details

- Use the [TabView](https://docs.devexpress.com/MAUI/DevExpress.Maui.Controls.TabView) component to create a multi-tabbed view.

- Initialize the [DXCollectionView.FilteringUITemplate](https://docs.devexpress.com/MAUI/DevExpress.Maui.CollectionView.DXCollectionView.FilteringUITemplate) property with a DataTemplate that contains filter items. Filter items are separate controls within your application that automatically retrieve available values, format settings, and other information from the bound control – CollectionView. Once you specify `FilteringUITemplate`, filter items are automatically bound to the CollectionView.

- Bind the [ToolbarItem.Command](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.menuitem.command?view=net-maui-7.0#microsoft-maui-controls-menuitem-command) property to the [DXCollectionViewCommands.ShowFilteringUIForm](https://docs.devexpress.com/MAUI/DevExpress.Maui.CollectionView.DXCollectionViewCommands.ShowFilteringUIForm) property. The `ShowFilteringUIForm` returns the command that invokes the filter form the `FilteringUITemplate` defines. 

## Files to Review

- [MainPage.xaml](MainPage.xaml)

## Documentation

- [CollectionView - Create Filtering UI](https://docs.devexpress.com/MAUI/404126/collection-view/filter-sort-and-group-data#create-filtering-ui)

## More Examples

- [CollectionView - Incorporate CRUD Operations](https://github.com/DevExpress-Examples/maui-collection-view/tree/HEAD/CS/CrudOperations)
