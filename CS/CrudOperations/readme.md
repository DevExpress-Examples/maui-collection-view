# CollectionView for .NET MAUI - Incorporate CRUD Operations

This “contact list” sample app illustrates the capabilities of the DevExpress CollectionView for .NET MAUI. The contact list's data source includes a few pre-defined records. You can edit existing contact information or add new contacts to the list. In this example, the same contact edit form is used for both usage scenarios.

Data Validation: Our .NET MAUI Data Editors ship with data validation support. Enter invalid values within the editors on the contact edit form to view how DevExpress .NET MAUI Editors validate user input.

![DevExpress CollectionView for MAUI - CRUD demo app](Images/results.png)

The following list contains key API members used in this example:

* `DetailFormTemplate` - Specifies a custom detail form – used to display source item information.
* `DetailEditFormTemplate` - Specifies a custom detail form – used to edit source item information.
* `DetailNewItemFormTemplate` - Specifies a custom detail form – used to add a new item to the source and edit its properties.
* `ValidateAndSave` - Occurs once a user saves changes in a detail form - allows you to validate input values.

```xaml
<dxcv:DXCollectionView x:Name="collectionView" ItemsSource="{Binding Contacts}" 
                       ...
                       DetailFormTemplate="{DataTemplate local:DetailInfoPage}"
                       DetailEditFormTemplate="{DataTemplate local:ContactEditingPage}"
                       DetailNewItemFormTemplate="{DataTemplate local:ContactEditingPage}">
    <!--...-->
    <dxcv:DXCollectionView.Behaviors>
        <toolkit:EventToCommandBehavior EventName="ValidateAndSave" Command="{Binding ValidateAndSaveCommand}" x:TypeArguments="core:ValidateItemEventArgs"/>
        <toolkit:EventToCommandBehavior EventName="CreateDetailFormViewModel" Command="{Binding CreateDetailFormViewModelCommand}" x:TypeArguments="core:CreateDetailFormViewModelEventArgs"/>
    </dxcv:DXCollectionView.Behaviors>
</dxcv:DXCollectionView>

```

## Files to Review

- [ContactsCRUDView.xaml](/CS/CrudOperations/ContactsCRUDView.xaml)
- [ContactsCRUDView.xaml.cs](/CS/CrudOperations/ContactsCRUDView.xaml.cs)
- [DetailInfoPage.xaml](/CS/CrudOperations/DetailInfoPage.xaml)
- [DetailInfoPage.xaml.cs](/CS/CrudOperations/DetailInfoPage.xaml.cs)
- [ContactEditingPage.xaml](/CS/CrudOperations/ContactEditingPage.xaml)
- [ContactEditingPage.xaml.cs](/CS/CrudOperations/ContactEditingPage.xaml.cs)


## Documentation

- [CRUD Operations in a Data-Bound Collection View for .NET MAUI](https://docs.devexpress.com/MAUI/404421/collection-view/crud/crud-overview)

## More Examples

- [DevExpress Mobile UI for .NET MAUI](https://github.com/DevExpress-Examples/maui-demo-app/)
