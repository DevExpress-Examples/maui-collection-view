<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/391921112/22.1.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T1018863)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# DevExpress Collection View for .NET MAUI

[DevExpress Mobile UI](https://www.devexpress.com/maui/) allows you to use a .NET cross-platform UI toolkit and C# to build native apps for iOS and Android.

![DevExpress Mobile UI for .NET MAUI](./Images/maui.png)

The **DevExpress Mobile UI for Xamarin.Forms and .NET MAUI** is free of charge. To learn more about our offer and to reserve your copy, visit [Free DevExpress Mobile UI for Xamarin.Forms and .NET MAUI](https://www.devexpress.com/xamarin-free).

## Requirements

Please register the DevExpress NuGet Gallery in Visual Studio to restore the NuGet packages used in this solution. See the following topic for more information: [Get Started with DevExpress Mobile UI for .NET MAUI](https://docs.devexpress.com/MAUI/403249/get-started).

## Documentation

- [Data Grid](https://docs.devexpress.com/MAUI/403255/data-grid/data-grid)
- [Charts](https://docs.devexpress.com/MAUI/403300/charts/charts)
- [Data Form](https://docs.devexpress.com/MAUI/403640/data-form)
- [Navigation](https://docs.devexpress.com/MAUI/403297/navigation/index)
- [Data Editors](https://docs.devexpress.com/MAUI/403427/editors/index)
- [Collection View](https://docs.devexpress.com/MAUI/403324/collection-view/index)

## More Examples

* [Stocks App](https://github.com/DevExpress-Examples/maui-stocks-mini)
* [Data Grid](https://github.com/DevExpress-Examples/maui-data-grid-get-started)
* [Data Form](https://github.com/DevExpress-Examples/maui-data-form-get-started)
* [Data Editors](https://github.com/DevExpress-Examples/maui-editors-get-started)
* [Pie Chart](https://github.com/DevExpress-Examples/maui-pie-chart-get-started)
* [Scatter Chart](https://github.com/DevExpress-Examples/maui-scatter-chart-get-started)
* [Tab View](https://github.com/DevExpress-Examples/maui-tab-view-get-started)

## What's in This Repository

The [DXCollectionView](https://docs.devexpress.com/MAUI/DevExpress.Maui.CollectionView.DXCollectionView) component uses a template to display a collection of data items in a vertical or horizontal list. The component features include the following:

- Templates for Data Items and Group Headers
- Data Sorting, Filtering, and Grouping
- Vertical and Horizontal Scrolling
- Drag-and-Drop Editing
- Pull-to-Refresh
- Infinite Scrolling
- Swipe Gestures
- Multiple Item Selection
- Themes

An example in this repository allows you to get started with the Collection View component and explore its basic functionality. It demonstrates how to bind the view to a data source, apply an item template, sort, and group data items.

![Collection View](Images/step-4.png) ![Collection View](Images/step-4-ios.png)

### Files to Look At

<!-- default file list -->
* [MauiProgram.cs](./CS/CollectionViewExample/MauiProgram.cs)
* [MainPage.xaml](./CS/CollectionViewExample/MainPage.xaml)
* [ViewModel.cs](./CS/CollectionViewExample/ViewModel.cs)
<!-- default file list end -->

## How to Run This Application

1. Install Visual Studio 2022 and the latest .NET MAUI version. See the following topic on docs.microsoft.com for more information: [.NET MAUI Installation](https://docs.microsoft.com/en-gb/dotnet/maui/get-started/installation).
1. Register [your personal NuGet feed](https://nuget.devexpress.com/) in Visual Studio.
    > If you are an active [DevExpress Universal](https://www.devexpress.com/subscriptions/universal.xml) customer, DevExpress Controls for .NET MAUI are available in your [personal NuGet feed](https://nuget.devexpress.com/).

## How to Reproduce This Application

The following step-by-step tutorial details how to reproduce this application.

### Create a New Project

1. In Visual Studio 2022, create a new .NET MAUI project. Name it *CollectionViewExample*.
    > If the wizard does not propose a template for .NET MAUI projects, you can call the following command in a CLI to create a new .NET MAUI project:
    > ```
    > dotnet new maui -n CollectionViewExample
    > ```
1. Install the **DevExpress.Maui.CollectionView** package from [your personal NuGet feed](https://nuget.devexpress.com/).

> DevExpress Collection View for .NET MAUI supports iOS and Android. The project should only contain these platforms.

### Add a Collection View to the Main Page

In the *MauiProgram.cs* file, call the `UseDevExpress` method to [register handlers](https://docs.microsoft.com/en-us/dotnet/maui/fundamentals/app-startup#register-handlers) for the [DXCollectionView](https://docs.devexpress.com/MAUI/DevExpress.Maui.CollectionView.DXCollectionView) and other DevExpress controls.

```cs
using Microsoft.Maui;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using DevExpress.Maui.CollectionView;

namespace CollectionViewExample {
    public static class MauiProgram {
        public static MauiApp CreateMauiApp() {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseDevExpress()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });
            return builder.Build();
        }
    }
}
```

Do the following in the *MainPage.xaml* file:

1. Define the **dxcv** XAML namespace that refers to the **DevExpress.Maui.CollectionView** CLR namespace.
1. Remove the default content and add an instance of the [DXCollectionView](https://docs.devexpress.com/MAUI/DevExpress.Maui.CollectionView.DXCollectionView) class to the page. Remove the default content's event handlers in the code-behind. We recommend that you remove the default styles (fonts, colors, and other settings) in the *App.xaml* file.

```xaml
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:dxcv="clr-namespace:DevExpress.Maui.CollectionView;assembly=DevExpress.Maui.CollectionView"
             x:Class="CollectionViewExample.MainPage"
             BackgroundColor="{DynamicResource PageBackgroundColor}">
    <dxcv:DXCollectionView/>
</ContentPage>
```

### Populate the View with Data

Create the **ViewModel** and **Contact** classes as shown below. The **ViewModel** class exposes the **Data** property that provides access to the data source. Items in this collection are **Contact** objects that expose the **Name**, **Photo**, and **Phone** properties.

```cs
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CollectionViewExample {
    public class Contact {
        string name;
        public string Name {
            get => this.name;
            set {
                this.name = value;
                if (Photo == null) {
                    string resourceName = value.Replace(" ", "").ToLower() + ".jpg";
                    Photo = ImageSource.FromFile(resourceName);
                }
            }
        }

        public Contact(string name, string phone) {
            Name = name;
            Phone = phone;
        }
        public ImageSource Photo { get; set; }
        public string Phone { get; set; }
    }

    public class ViewModel : INotifyPropertyChanged {
        public List<Contact> Data { get; }
        public ViewModel() {
            Data = new List<Contact>() {
                new Contact("Nancy Davolio", "(206) 555-9857"),
                new Contact("Andrew Fuller", "(206) 555-9482"),
                new Contact("Janet Leverling", "(206) 555-3412"),
                new Contact("Margaret Peacock", "(206) 555-8122"),
                new Contact("Steven Buchanan", "(71) 555-4848"),
                new Contact("Michael Suyama", "(71) 555-7773"),
                new Contact("Robert King", "(71) 555-5598"),
                new Contact("Laura Callahan", "(206) 555-1189"),
                new Contact("Anne Dodsworth", "(71) 555-4444"),
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
```

Do the following in the *MainPage.xaml* file:

1. Define the **local** XML namespace that refers to the **CollectionViewExample** CLR namespace.
1. Assign a **ViewModel** instance to the **ContentPage.BindingContext** property.
1. Bind the [DXCollectionView.ItemsSource](https://docs.devexpress.com/MAUI/DevExpress.Maui.CollectionView.DXCollectionView.ItemsSource) property to the view model's **Data** property.
1. Use the [DisplayMember](https://docs.devexpress.com/MAUI/DevExpress.Maui.CollectionView.DXCollectionView.DisplayMember) property to specify the data field that contains item captions. The [DisplayFormat](https://docs.devexpress.com/MAUI/DevExpress.Maui.CollectionView.DXCollectionView.DisplayFormat) allows you to format captions.

```xaml
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:dxcv="clr-namespace:DevExpress.Maui.CollectionView;assembly=DevExpress.Maui.CollectionView"
             xmlns:local="clr-namespace:CollectionViewExample"
             x:Class="CollectionViewExample.MainPage"
             BackgroundColor="{DynamicResource PageBackgroundColor}">
    <ContentPage.BindingContext>
        <local:ViewModel/>
    </ContentPage.BindingContext>
    <dxcv:DXCollectionView ItemsSource="{Binding Data}"/>
</ContentPage>
```

### Create an Item Template

The [DXCollectionView](https://docs.devexpress.com/MAUI/DevExpress.Maui.CollectionView.DXCollectionView) supports *item templates*. These templates allow you to specify how each item appears in the view. Make the following changes in the *MainPage.xaml* file to define an item template:

1. Assign a **DataTemplate** to the [DXCollectionView.ItemTemplate](https://docs.devexpress.com/MAUI/DevExpress.Maui.CollectionView.DXCollectionView.ItemTemplate) property.
1. Populate the template with controls and bind them to data source fields as the markup below demonstrates.

```xaml
<dxcv:DXCollectionView ItemsSource="{Binding Data}">
        <!--Define the item template.-->
        <dxcv:DXCollectionView.ItemTemplate>
            <DataTemplate>
                <Grid Padding="10, 8, 18, 7">
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="50"/>
                        <ColumnDefinition Width="*"/>
                    </Grid.ColumnDefinitions>
                    <Grid Margin="0" Padding="0" ColumnSpacing="0" RowSpacing="0">
                        <Image Source="{Binding Photo}" VerticalOptions="Center"
                                    HorizontalOptions="Center" WidthRequest="48" HeightRequest="48">
                            <Image.Clip>
                                <EllipseGeometry RadiusX="24" RadiusY="24" Center="24, 24" />
                            </Image.Clip>
                        </Image>
                        <Ellipse Margin="0"
                                 Fill="Transparent"
                                 Stroke="LightGray" 
                                 StrokeThickness="1"
                                 HeightRequest="50"
                                 WidthRequest="50"
                                 VerticalOptions="Center"
                                 HorizontalOptions="Center">
                        </Ellipse>
                    </Grid>
                    <StackLayout Grid.Column="1"
                             Padding="18,1,18,7"
                             Orientation="Vertical">
                        <Label Text="{Binding Name}"
                           Margin="0,2"
                           TextColor="#55575c"/>
                        <Label Text="{Binding Phone}"
                               TextColor="#959aa0"/>
                    </StackLayout>
                </Grid>
            </DataTemplate>
        </dxcv:DXCollectionView.ItemTemplate>
        
        <!--Specify margins.-->
        <dxcv:DXCollectionView.Margin>
            <x:OnIdiom Phone="16,0,0,0" Tablet="71,0,0,0"/>
        </dxcv:DXCollectionView.Margin>
</dxcv:DXCollectionView>
```

Do the following to add contact photos to the solution:
1. Download this repository.
1. Copy images from the */CollectionViewExample/Resources/Images* folder in the downloaded repository to the same folder in your project.

Run the application. The Collection View now displays a photo, name, and phone number for each contact.

![Collection View - Item Template](Images/step-2.png) ![Collection View - Item Template](Images/step-2-ios.png)

### Sort Data Items

Make the following changes in the *MainPage.xaml* file to sort data items:

1. Create a [SortDescription](https://docs.devexpress.com/MAUI/DevExpress.Maui.CollectionView.SortDescription) object, and specify its [FieldName](https://docs.devexpress.com/MAUI/DevExpress.Maui.CollectionView.SortDescriptionBase.FieldName) and [SortOrder](https://docs.devexpress.com/MAUI/DevExpress.Maui.CollectionView.SortDescriptionBase.SortOrder) properties.
1. Add this object to the [DXCollectionView.SortDescriptions](https://docs.devexpress.com/MAUI/DevExpress.Maui.CollectionView.DXCollectionView.SortDescriptions) collection.

```xaml
<dxcv:DXCollectionView ItemsSource="{Binding Data}">
        <!-- Define ItemTemplate here.-->

        <!--Sort items.-->
        <dxcv:DXCollectionView.SortDescriptions>
            <dxcv:SortDescription FieldName="Name" SortOrder="Descending"/>
        </dxcv:DXCollectionView.SortDescriptions>
</dxcv:DXCollectionView>
```

Run the application. Contacts are now sorted by first name in descending order.

![Collection View - Sort Data Items](Images/step-3.png) ![Collection View - Sort Data Items](Images/step-3-ios.png)

You can also sort list items by multiple data fields. To do this, create a [SortDescription](https://docs.devexpress.com/MAUI/DevExpress.Maui.CollectionView.SortDescription) object for each field that should be sorted. The order of these objects in the [DXCollectionView.SortDescriptions](https://docs.devexpress.com/MAUI/DevExpress.Maui.CollectionView.DXCollectionView.SortDescriptions) collection defines the sort order in the view.

### Group Data Items

Make the following changes in the *MainPage.xaml* file to group data items:

1. Assign a [GroupDescription](https://docs.devexpress.com/MAUI/DevExpress.Maui.CollectionView.GroupDescription) object to the [DXCollectionView.GroupDescription](https://docs.devexpress.com/MAUI/DevExpress.Maui.CollectionView.DXCollectionView.GroupDescription) property. Set the [GroupDescription.FieldName](https://docs.devexpress.com/MAUI/DevExpress.Maui.CollectionView.SortDescriptionBase.FieldName) property to **Name** and [GroupDescription.GroupInterval](https://docs.devexpress.com/MAUI/DevExpress.Maui.CollectionView.GroupDescription.GroupInterval) to [Alphabetical](https://docs.devexpress.com/MobileControls/DevExpress.Data.ColumnGroupInterval).
1. Use the [DXCollectionView.GroupHeaderTemplate](https://docs.devexpress.com/MAUI/DevExpress.Maui.CollectionView.DXCollectionView.GroupHeaderTemplate) property to specify group header appearance.

```xaml
<dxcv:DXCollectionView ItemsSource="{Binding Data}">
        <!-- Define ItemTemplate here.-->

        <!--Group items.-->
        <dxcv:DXCollectionView.GroupDescription>
            <dxcv:GroupDescription FieldName="Name" GroupInterval="Alphabetical"/>
        </dxcv:DXCollectionView.GroupDescription>

        <!--Define the group header template.-->
        <dxcv:DXCollectionView.GroupHeaderTemplate>
            <DataTemplate>
                <StackLayout Margin="2, 0, 18, 10">
                    <Label FontFamily="Roboto-Medium"
                       Margin="0,20,0,1"
                       TextColor="#55575c"
                       Text="{Binding Value}"/>
                    <BoxView BackgroundColor="#ebebeb" 
                         HeightRequest="1"/>
                </StackLayout>
            </DataTemplate>
        </dxcv:DXCollectionView.GroupHeaderTemplate>
</dxcv:DXCollectionView>
```

Run the application. Contacts whose first name begins with the same letter are now arranged into groups. Each group is identified by a header. Users can tap group headers to expand or collapse groups.

![Collection View - Group Data Items](Images/step-4.png) ![Collection View - Group Data Items](Images/step-4-ios.png)
