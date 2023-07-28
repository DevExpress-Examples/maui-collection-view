using CrudOperations.ViewModels;
using DevExpress.Maui.CollectionView;
using DevExpress.Maui.Controls;
using DevExpress.Maui.Core;
using DevExpress.Maui.Editors;
using Microsoft.EntityFrameworkCore;

namespace CrudOperations;

public partial class ContactsCRUDView : ContentPage {
    public ContactsCRUDView() {
        InitializeComponent();
        Localizer.StringLoader = new CustomStringLoader();
    }
}

public class CustomStringLoader : Localizer.IStringLoader { 
    public bool TryGetString(string key, out string value) {
        if (key == "CollectionViewStringId.GroupCaptionDisplayFormat") {
            value = "{1}";
            return true;
        }
        value = null;
        return false;
    }
}