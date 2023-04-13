# CollectionView for .NET MAUI - Infinite Scrolling

This example shows how to implement a [CollectionView](https://docs.devexpress.com/MAUI/403324/collection-view) infinite scrolling.

<img width="50%" src="https://user-images.githubusercontent.com/12169834/223110944-4904bf34-da91-4685-9656-fb7e09905d42.png"/>

## Implementation Details

* Set the [IsLoadMoreEnabled](https://docs.devexpress.com/MAUI/DevExpress.Maui.CollectionView.DXCollectionView.IsLoadMoreEnabled) to `true` to enable the CollectionView infinite scrolling.
* Bind the [DXCollectionView.LoadMoreCommand](https://docs.devexpress.com/MAUI/DevExpress.Maui.CollectionView.DXCollectionView.LoadMoreCommand) property to a view model's command that loads new items in the command's Execute method. CollectionView automatically invokes this command when a user scrolls to the end.
* Set the [LoadMoreCommand](https://docs.devexpress.com/MAUI/DevExpress.Maui.CollectionView.DXCollectionView.LoadMoreCommand)'s **CanExecute** property to `false` to disable infinite scrolling when you scrolled down to the end of CollectionView's data.
* While loading a new portion of data, you can set the [IsRefreshing](https://docs.devexpress.com/MAUI/DevExpress.Maui.CollectionView.DXCollectionView.IsRefreshing) property to `true` to display wait indicator. When the loading is over, set [IsRefreshing](https://docs.devexpress.com/MAUI/DevExpress.Maui.CollectionView.DXCollectionView.IsRefreshing) to `false` to automatically update the CollectionView's displayed data.
* To load only the next portion of data, you can store a number of displayed rows and pass it to the [Skip](https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.skip) method. Then, pass the number of rows that you want to display in CollectionView to the [Take](https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.take) method.
  
    ```
    allBlogs.Skip(startIndex).Take(batchSize);
    ```

    File to look at: [MainViewModel.cs](MainViewModel.cs)

* Call the [Browser.OpenAsync](https://learn.microsoft.com/en-us/dotnet/maui/platform-integration/appmodel/open-browser?view=net-maui-7.0&tabs=android#open-the-browser) and [Share.RequestAsync](https://learn.microsoft.com/en-us/dotnet/maui/platform-integration/data/share?view=net-maui-7.0&tabs=android#share-text-and-links) methods to open the blog post in browser and display the native share dialog.


## Files to Look At

* [MainPage.xaml](MainPage.xaml)
* [MainPage.xaml.cs](MainPage.xaml.cs)
* [MainViewModel.cs](MainViewModel.cs)
* [Styles.xaml](Resources/Styles/Styles.xaml)

## Documentation

* [Featured Scenario: Infinite Scrolling](https://docs.devexpress.com/MAUI/404358)
* [Featured Scenarios](https://docs.devexpress.com/MAUI/404291)
* [Infinite Scrolling in .NET MAUI CollectionView](https://docs.devexpress.com/MAUI/403331/collection-view/infinite-scrolling)

## More Examples

* [DevExpress Mobile UI for .NET MAUI](https://github.com/DevExpress-Examples/maui-demo-app/)