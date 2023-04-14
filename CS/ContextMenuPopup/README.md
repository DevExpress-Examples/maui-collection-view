<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/626815528/22.2.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T1159596)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
## CollectionView for .NET MAUI - Context Menu Actions in Popup

This example demonstrates how to implement context menu actions for [CollectionView](https://docs.devexpress.com/MAUI/DevExpress.Maui.CollectionView.DXCollectionView) items. To create a context menu, we used the [DXPopup Control](https://docs.devexpress.com/MAUI/DevExpress.Maui.Controls.DXPopup) that contains [SimpleButtons](https://docs.devexpress.com/MAUI/DevExpress.Maui.Controls.SimpleButton). These buttons can invoke different actions.  

<img src="https://user-images.githubusercontent.com/12169834/228216536-48240713-be2f-45e7-9dda-dbf843682500.png" width="30%"/>


Included controls and their properties:

* [DXPopup](https://docs.devexpress.com/MAUI/DevExpress.Maui.Controls.DXPopup): [Placement](https://docs.devexpress.com/MAUI/DevExpress.Maui.Controls.DXPopup.Placement), [IsOpen](https://docs.devexpress.com/MAUI/DevExpress.Maui.Controls.DXPopup.IsOpen)

* [SimpleButton](https://docs.devexpress.com/MAUI/DevExpress.Maui.Controls.SimpleButton): [Content](https://docs.devexpress.com/MAUI/DevExpress.Maui.Controls.SimpleButton.Content), [Command](https://docs.devexpress.com/MAUI/DevExpress.Maui.Controls.SimpleButton.Command), [Icon](https://docs.devexpress.com/MAUI/DevExpress.Maui.Controls.SimpleButton.Icon), [IconColor](https://docs.devexpress.com/MAUI/DevExpress.Maui.Controls.SimpleButton.IconColor)


## Implementation Details


* To open or close [DXPopup](https://docs.devexpress.com/MAUI/DevExpress.Maui.Controls.DXPopup), use the [DXPopup.IsOpen](https://docs.devexpress.com/MAUI/DevExpress.Maui.Controls.DXPopup.IsOpen) property:

    ```xaml
    <dxco:DXPopup x:Name="actionsPopup" ...>
        <StackLayout>
            <dxco:SimpleButton .../>
            <dxco:SimpleButton .../>
        </StackLayout>
    </dxco:DXPopup>
    ```

    File to Look At: [MainPage.xaml](CS/MainPage.xaml)

    ```csharp
    public class MainViewModel : BindableBase {
        bool isOpenPopup;
        public bool IsOpenPopup {
            get => this.isOpenPopup;
            set {
                isOpenPopup = value;
                RaisePropertyChanged();
            }
        }
    }
    ```

    File to Look At: [MainViewModel.cs](CS/MainViewModel.cs)

    ```csharp
    public partial class MainPage : ContentPage {
        void ContactActionsClick(object sender, EventArgs e) {
            // ...
            actionsPopup.IsOpen = !actionsPopup.IsOpen;
        }
        private void PopupItemClick(object sender, EventArgs e) {
            actionsPopup.IsOpen = false;
        }
    }
    ```

    File to Look At: [MainPage.xaml.cs](CS/MainPage.xaml.cs)

* Use the [DXPopup.PlacementTarget](https://docs.devexpress.com/MAUI/DevExpress.Maui.Controls.DXPopup.PlacementTarget) property to define the popup alignment in relation to its parent element:

    ```xaml
    <dxco:DXPopup x:Name="actionsPopup" ...>
        <StackLayout>
            <dxco:SimpleButton .../>
            <dxco:SimpleButton .../>
        </StackLayout>
    </dxco:DXPopup>
    ```

    File to Look At: [MainPage.xaml](CS/MainPage.xaml)

    ```csharp
    public partial class MainPage : ContentPage {
        void ContactActionsClick(object sender, EventArgs e) {
            actionsPopup.PlacementTarget = (View)sender;
            // ...
        }
    }
    ```

    File to Look At: [MainPage.xaml.cs](CS/MainPage.xaml.cs)

* Use the [SimpleButton.Command](https://docs.devexpress.com/MAUI/DevExpress.Maui.Controls.SimpleButton.Command) property to define a button click command:

    ```xaml
    <dxco:DXPopup x:Name="actionsPopup" ...>
        <StackLayout>
            <dxco:SimpleButton .../>
            <dxco:SimpleButton .../>
        </StackLayout>
    </dxco:DXPopup>
    ```

    File to Look At: [MainPage.xaml](CS/MainPage.xaml)

    ```csharp
    public class MainViewModel : BindableBase {
        bool isOpenPopup;

        public bool IsOpenPopup {
            get => this.isOpenPopup;
            set {
                isOpenPopup = value;
                RaisePropertyChanged();
            }
        }

        public ICommand PopupActionCommand {
            get;
            set;
        }

        public MainViewModel() {
            PopupActionCommand = new Command<string>(PopupAction);
            // ...
        }
        public async void PopupAction(string parameter) {
            await Application.Current.MainPage.DisplayAlert("Popup Item Click", parameter, "OK");
        }
    }
    ```

    File to Look At: [MainViewModel.cs](CS/MainViewModel.cs)

* You can use the [SimpleButton.IconColor](https://docs.devexpress.com/MAUI/DevExpress.Maui.Controls.SimpleButton.IconColor) property to change the color of the button [icon](https://docs.devexpress.com/MAUI/DevExpress.Maui.Controls.SimpleButton.Icon):

    ```xaml
     <ContentPage.Resources>
        <Style TargetType="dxco:SimpleButton" x:Key="popupButtonStyle">
            <Setter Property="IconColor" Value="{StaticResource Gray500}"/>
            <!-- ... -->
        </Style>
    </ContentPage.Resources>

    <dxco:DXPopup ...>
        <StackLayout>
            <dxco:SimpleButton Style="{StaticResource popupButtonStyle}" .../>
            <dxco:SimpleButton Style="{StaticResource popupButtonStyle}" .../>
        </StackLayout>
    </dxco:DXPopup>
    ```

    File to Look At: [MainPage.xaml](CS/MainPage.xaml)
    
    ```csharp
    public partial class MainPage : ContentPage {
        void ContactActionsClick(object sender, EventArgs e) {
            // ...
            actionsPopup.IsOpen = !actionsPopup.IsOpen;
        }
        private void PopupItemClick(object sender, EventArgs e) {
            actionsPopup.IsOpen = false;
        }
    }
    ```

    File to Look At: [MainPage.xaml.cs](CS/MainPage.xaml.cs)

## Files to Look At

<!-- default file list -->
* [MainPage.xaml](CS/MainPage.xaml)
* [MainPage.xaml.cs](CS/MainPage.xaml.cs)
* [MainViewModel.cs](CS/MainViewModel.cs)
* [App.xaml](CS/App.xaml)
<!-- default file list end -->

## Documentation

* [Featured Scenario: Context Menu Actions in Popup](https://docs.devexpress.com/MAUI/404342)
* [Featured Scenarios](https://docs.devexpress.com/MAUI/404291)
* [SimpleButton.Content](https://docs.devexpress.com/MAUI/DevExpress.Maui.Controls.SimpleButton.Content)
* [DXPopup](https://docs.devexpress.com/MAUI/DevExpress.Maui.Controls.DXPopup)

## More Examples

* [DevExpress Mobile UI for .NET MAUI](https://github.com/DevExpress-Examples/maui-demo-app/)
