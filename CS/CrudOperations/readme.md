# CollectionView for .NET MAUI - Incorporate CRUD Operations

This project shows how to bind our [.NET MAUI CollectionView](https://docs.devexpress.com/MAUI/403324/collection-view/index) control to a SQLite database and implement CRUD operations (create, read, update, delete). These operations allow you to post changes that users make in the CollectionView to the database. The database is included in the project and contains the *Contacts* table with pre-defined records.

![DevExpress CollectionView for MAUI - CRUD demo app](Images/results.png)

## Implementation Details

### Connect to the Database

Follow the steps below to obtain data from the SQLite database and display it in the [CollectionView](https://docs.devexpress.com/MAUI/403324/collection-view/index):

1. Reference the [Microsoft.EntityFrameworkCore.Sqlite](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Sqlite/) NuGet package.
   
2. Define the *Contact* class:
    
    ```
    public class Contact { 
        public string FirstName { 
            get; 
            set; 
        }        
        public string LastName { 
            get; 
            set; 
        } 
        //... 
    } 
    ```

3. Define a [DXContext](https://learn.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.dbcontext?view=efcore-7.0) descendant class to use it as the database context:
   
    ```cs
    public class ContactsContext : DbContext { 
        public DbSet<Model.Contact> Contacts { get; set; } 
        public ContactsContext() { 
            //Initiates SQLite on iOS 
            SQLitePCL.Batteries_V2.Init(); 
            this.Database.EnsureCreated(); 
        } 
        //Sets up the location of the SQLite database on the physical device 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { 
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, App.DbFileName); 
            optionsBuilder.UseSqlite($"Filename={dbPath}"); 
            base.OnConfiguring(optionsBuilder); 
        } 
    } 
    ```

4. Copy the [Contacts.db](/CS/CrudOperations/Resources/Raw/contacts.db) database file from the application bundle to the application's data folder on the device. This is required since Android/iOS applications have no access to the application's bundle files due to security reasons. To work with these files, you should copy them to the *Cache* or *AppDataDirectory* (used in this example) folder. 

    ```cs
    CopyWorkingFilesToAppData(DbFileName).Wait(); 

    //...
    public async Task<string> CopyWorkingFilesToAppData(string fileName) { 
        string targetFile = Path.Combine(FileSystem.Current.AppDataDirectory, fileName); 
        if (File.Exists(targetFile)) 
            return targetFile; 
        using Stream fileStream = await FileSystem.Current.OpenAppPackageFileAsync(fileName); 
        using FileStream outputStream = File.OpenWrite(targetFile); 
        fileStream.CopyTo(outputStream); 
        return targetFile; 
    } 
    ```

5. Load data from the database and pass it to the *Contacts* collection:

    ```cs
    async void LoadData() {
        IsRefreshing = true;
        using ContactsContext context = new ContactsContext();
        await context.Contacts.LoadAsync();
        Contacts = new ObservableCollection<Model.Contact>(context.Contacts);
        Companies = new ObservableCollection<string>(Contacts.Select(c => c.Company));
        IsRefreshing = false;
    }
    ```

6. Bind the [CollectionView](https://docs.devexpress.com/MAUI/403324/collection-view/index) control to the *Contacts* collection:

    ```xml
    <dxcv:DXCollectionView ItemsSource="{Binding Contacts}" ...>
    ```

### Bind ViewModel to Create, Read, and Update Views

Bind UI controls on detail views to appropriate data properties and commands. 

The [CollectionView](https://docs.devexpress.com/MAUI/403324/collection-view/index) control passes the view model to next-level views: new item form, edit form, and detail view. This view model contains commands and item properties. The following code snippet binds the item's *FirstName* property to [Label.Text](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.label.text?view=net-maui-7.0):
  
```xml
<Label Text="{Binding Item.FirstName}" .../>
```

The following code snippet binds a [ToolbarItem](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.toolbaritem?view=net-maui-7.0) control to *EditCommand*:

```xml
<ToolbarItem Command="{Binding EditCommand}" .../>
```


### Invoke Read and Create Views

* Call the *ShowDetailForm* command to display the detail view:

   ```xml
   <dxco:SimpleButton Command="{Binding Source={x:Reference collectionView}, Path=Commands.ShowDetailForm}" .../>
   ```

* Place a [SimpleButton](https://docs.devexpress.com/MAUI/DevExpress.Maui.Controls.SimpleButton) control above the [CollectionView](https://docs.devexpress.com/MAUI/403324/collection-view/index) control in the Grid panel to implement a Floating Action Button (FAB). Users can click this button to add a new item to the collection.

    ```xml
    <Grid>
        <dxcv:DXCollectionView>
            ...
        </dxcv:DXCollectionView>
        <dxco:SimpleButton Command="{Binding Source={x:Reference collectionView}, Path=Commands.ShowDetailNewItemForm}" Text="+" VerticalOptions="End" HorizontalOptions="End" ... />
    </Grid>
    ```

### Customize Create, Read, and Update Views

* To replace auto-generated CRUD Views, specify [DetailFormTemplate](https://docs.devexpress.com/MAUI/DevExpress.Maui.CollectionView.DXCollectionView.DetailFormTemplate), [DetailEditFormTemplate](https://docs.devexpress.com/MAUI/DevExpress.Maui.CollectionView.DXCollectionView.DetailEditFormTemplate), and [DetailNewItemFormTemplate](https://docs.devexpress.com/MAUI/DevExpress.Maui.CollectionView.DXCollectionView.DetailNewItemFormTemplate) properties:

    ```xml
    <dxcv:DXCollectionView ...
                            DetailFormTemplate="{DataTemplate local:DetailInfoPage}"
                            DetailEditFormTemplate="{DataTemplate local:ContactEditingPage}"
                            DetailNewItemFormTemplate="{DataTemplate local:ContactEditingPage}">
    ```

    **Files to Review:**

    * [DetailInfoPage.xaml](/CS/CrudOperations/DetailInfoPage.xaml)
    * [ContactEditingPage.xaml](/CS/CrudOperations/ContactEditingPage.xaml)

* Use the [DataFormView](https://docs.devexpress.com/MAUI/DevExpress.Maui.DataForm.DataFormView) control to build the edit view. The view's editors post their changes when you call the [Commit](https://docs.devexpress.com/MAUI/DevExpress.Maui.DataForm.DataFormView.Commit) method. This allows you to discard changes if the user goes back and cancels the edit operation.

### Validate User Input

Handle the [DataFormView.ValidateProperty](https://docs.devexpress.com/MAUI/DevExpress.Maui.DataForm.DataFormView.ValidateProperty) event to validate user input on the editor's level:
  
```cs
void dataForm_ValidateProperty(object sender, DataFormPropertyValidationEventArgs e) {
    if (e.PropertyName == "Email" && e.NewValue != null) {
        MailAddress res;
        if (!MailAddress.TryCreate((string)e.NewValue, out res)) {
            e.HasError = true;
            e.ErrorText = "Invalid email";
        }
    }
}
```

You can also apply validation attributes the data object. The [DataFormView](https://docs.devexpress.com/MAUI/DevExpress.Maui.DataForm.DataFormView) control validates its editors accordingly. The following code sample marks the *FirstName* property with the [Required](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.requiredattribute?view=net-7.0) attribute (the marked property cannot be empty):

```cs
public class Contact : BindableBase {
[Required(ErrorMessage = "First Name cannot be empty")]
public string FirstName {
    get;
    set;
}
```

### Additional Information: Handle a Remote Database Connection Error

The changed data may not be saved to the database due to a connection error or another database constraint. To handle these errors, subscribe to the [DXCollectionView.ValidateAndSave](https://docs.devexpress.com/MAUI/DevExpress.Maui.CollectionView.DXCollectionView.ValidateAndSave?p=netframework) event. This event uses the *unit of work* pattern that creates a `DBContext` for each database operation (edit, add, or delete):

```cs
async void ValidateAndSave(ValidateItemEventArgs e) {
    ContactsContext context;
    var changedContact = (Model.Contact)e.Item;
    if (e.DataChangeType == DataChangeType.Edit) {
        context = (ContactsContext)e.Context;
    }
    else
        context = new ContactsContext();
    try {
        if (e.DataChangeType == DataChangeType.Add) {
            context.Contacts.Add(changedContact);
        }
        else if (e.DataChangeType == DataChangeType.Edit) {
            context.Contacts.Update(changedContact);
        }
        else if (e.DataChangeType == DataChangeType.Delete) {
            var issue = new Model.Contact() { ID = changedContact.ID };
            context.Entry(issue).State = EntityState.Deleted;
        }
        context.SaveChanges();
    }
    catch (Exception ex) {
        e.IsValid = false;
        await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
    }
}
```

In the code snippet above, the *edit* operation uses the *ContactsContext* [DBContext](https://learn.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.dbcontext?view=efcore-7.0) that is created when item editing starts:

```cs
void CreateDetailFormViewModel(CreateDetailFormViewModelEventArgs e) {
    if (e.DetailFormType == DetailFormType.Edit) {
        ContactsContext contactsContext = new ContactsContext();
        Model.Contact editedContact = (Model.Contact)contactsContext.Find(typeof(Model.Contact), ((Model.Contact)e.Item).ID);
        e.Result = new DetailEditFormViewModel(editedContact, isNew: false, context: contactsContext);
    }
}
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
