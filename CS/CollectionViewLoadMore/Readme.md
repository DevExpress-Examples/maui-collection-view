# CollectionView for .NET MAUI - Infinite Scrolling

This example demonstrates how to implement infinite scrolling in [CollectionView](https://docs.devexpress.com/MAUI/403324/collection-view).

<img width="30%" src="https://user-images.githubusercontent.com/12169834/230103799-e52c384f-3efe-4428-b663-35756da1fe59.png"/>

## Implementation Details

* Set the [IsLoadMoreEnabled](https://docs.devexpress.com/MAUI/DevExpress.Maui.CollectionView.DXCollectionView.IsLoadMoreEnabled) to `true` to enable infinite scrolling in CollectionView.
* Bind the [DXCollectionView.LoadMoreCommand](https://docs.devexpress.com/MAUI/DevExpress.Maui.CollectionView.DXCollectionView.LoadMoreCommand) property to a view model's command that loads new items. CollectionView automatically invokes this command when a user scrolls content to the last loaded item.
* Set the [LoadMoreCommand](https://docs.devexpress.com/MAUI/DevExpress.Maui.CollectionView.DXCollectionView.LoadMoreCommand)'s **CanExecute** property to `false` to disable infinite when the scroll position reaches the last record in CollectionView.
* You can set the [IsRefreshing](https://docs.devexpress.com/MAUI/DevExpress.Maui.CollectionView.DXCollectionView.IsRefreshing) to `true` to display a wait indicator while CollectionView is loading a new portion of data. Once the load operation is complete, set [IsRefreshing](https://docs.devexpress.com/MAUI/DevExpress.Maui.CollectionView.DXCollectionView.IsRefreshing) to `false` to update displayed data.
* To load only the next portion of data, you can store a number of displayed rows and pass it to the [Skip](https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.skip) method. Then, pass the number of rows that you want to display in CollectionView to the [Take](https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.take) method.
  
    ```
    allBlogs.Skip(startIndex).Take(batchSize);
    ```

    File to look at: [MainViewModel.cs](MainViewModel.cs)

* Call the [Browser.OpenAsync](https://learn.microsoft.com/en-us/dotnet/maui/platform-integration/appmodel/open-browser?view=net-maui-7.0&tabs=android#open-the-browser) and [Share.RequestAsync](https://learn.microsoft.com/en-us/dotnet/maui/platform-integration/data/share?view=net-maui-7.0&tabs=android#share-text-and-links) methods to open a blog post in a browser and display the native share dialog.


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
