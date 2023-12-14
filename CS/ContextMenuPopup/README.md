# CollectionView for .NET MAUI - Context Menu Actions in Popup

This example demonstrates how to implement context menu actions for [CollectionView](https://docs.devexpress.com/MAUI/DevExpress.Maui.CollectionView.DXCollectionView) items. To create a context menu, we used the [DXPopup Control](https://docs.devexpress.com/MAUI/DevExpress.Maui.Controls.DXPopup) that contains [Buttons](https://docs.devexpress.com/MAUI/DevExpress.Maui.Core.DXButton). These buttons can invoke different actions.  

<img src="https://user-images.githubusercontent.com/12169834/228216536-48240713-be2f-45e7-9dda-dbf843682500.png" width="30%"/>


Included controls and their properties:

* [DXPopup](https://docs.devexpress.com/MAUI/DevExpress.Maui.Controls.DXPopup): [Placement](https://docs.devexpress.com/MAUI/DevExpress.Maui.Controls.DXPopup.Placement), [IsOpen](https://docs.devexpress.com/MAUI/DevExpress.Maui.Controls.DXPopup.IsOpen)

* [DXButton](https://docs.devexpress.com/MAUI/DevExpress.Maui.Core.DXButton): [Content](https://docs.devexpress.com/MAUI/DevExpress.Maui.Core.DXBorder.Content), [Command](https://docs.devexpress.com/MAUI/DevExpress.Maui.Controls.SimpleButton.Command), [Icon](https://docs.devexpress.com/MAUI/DevExpress.Maui.Core.DXContentPresenter.Icon), [IconColor](https://docs.devexpress.com/MAUI/DevExpress.Maui.Core.DXContentPresenter.IconColor)


## Implementation Details


* To open or close [DXPopup](https://docs.devexpress.com/MAUI/DevExpress.Maui.Controls.DXPopup), use the [DXPopup.IsOpen](https://docs.devexpress.com/MAUI/DevExpress.Maui.Controls.DXPopup.IsOpen) property:

    ```xaml
    <dxco:DXPopup x:Name="actionsPopup" ...>
        <dx:DXStackLayout ...>
            <dx:DXButton .../>
            <dx:DXButton .../>
        </dx:DXStackLayout>
    </dxco:DXPopup>
    ```

    File to review: [MainPage.xaml](CS/MainPage.xaml)

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

    File to review: [MainViewModel.cs](CS/MainViewModel.cs)

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

    File to review: [MainPage.xaml.cs](CS/MainPage.xaml.cs)

* Use the [DXPopup.PlacementTarget](https://docs.devexpress.com/MAUI/DevExpress.Maui.Controls.DXPopup.PlacementTarget) property to define the popup alignment in relation to its parent element:

    ```xaml
    <dxco:DXPopup x:Name="actionsPopup" ...>
        <!--...-->
    </dxco:DXPopup>
    ```

    File to review: [MainPage.xaml](CS/MainPage.xaml)

    ```csharp
    public partial class MainPage : ContentPage {
        void ContactActionsClick(object sender, EventArgs e) {
            actionsPopup.PlacementTarget = (View)sender;
            // ...
        }
    }
    ```

    File to review: [MainPage.xaml.cs](CS/MainPage.xaml.cs)

* Use the [DXButton.Command](https://docs.devexpress.com/MAUI/DevExpress.Maui.Core.DXButtonBase.Command) property to define a button click command:

    ```xaml
    <dxco:DXPopup x:Name="actionsPopup" ...>
        <dx:DXStackLayout>
            <dx:DXButton Command="{Binding PopupActionCommand}" .../>
            <dx:DXButton Command="{Binding PopupActionCommand}" .../>
        </dx:DXStackLayout>
    </dxco:DXPopup>
    ```

    File to review: [MainPage.xaml](CS/MainPage.xaml)

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

    File to review: [MainViewModel.cs](CS/MainViewModel.cs)

* You can use the [DXButton.IconColor](https://docs.devexpress.com/MAUI/DevExpress.Maui.Core.DXContentPresenter.IconColor) property to change the color of the button [icon](https://docs.devexpress.com/MAUI/DevExpress.Maui.Core.DXContentPresenter.Icon):

    ```xaml
     <ContentPage.Resources>
        <Style TargetType="dx:DXButton" x:Key="popupButtonStyle">
            <Setter Property="IconColor" Value="{StaticResource Gray500}"/>
            <!-- ... -->
        </Style>
    </ContentPage.Resources>

    <dxco:DXPopup ...>
        <dx:DXStackLayout>
            <dx:DXButton Style="{StaticResource popupButtonStyle}" .../>
            <dx:DXButton Style="{StaticResource popupButtonStyle}" .../>
        <dx:DXStackLayout>
    </dxco:DXPopup>
    ```

    File to review: [MainPage.xaml](CS/MainPage.xaml)
    
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

    File to review: [MainPage.xaml.cs](CS/MainPage.xaml.cs)

## Files to Review

<!-- default file list -->
* [MainPage.xaml](CS/MainPage.xaml)
* [MainPage.xaml.cs](CS/MainPage.xaml.cs)
* [MainViewModel.cs](CS/MainViewModel.cs)
* [App.xaml](CS/App.xaml)
<!-- default file list end -->

## Documentation

* [Featured Scenario: Context Menu Actions in Popup](https://docs.devexpress.com/MAUI/404342)
* [Featured Scenarios](https://docs.devexpress.com/MAUI/404291)
* [DXButton](https://docs.devexpress.com/MAUI/DevExpress.Maui.Core.DXButton)
* [DXPopup](https://docs.devexpress.com/MAUI/DevExpress.Maui.Controls.DXPopup)

## More Examples

* [DevExpress Mobile UI for .NET MAUI](https://github.com/DevExpress-Examples/maui-demo-app/)
