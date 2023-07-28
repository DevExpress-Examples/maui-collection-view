# Populate E-Forms in a PDF File

> NOTE
>
> This project requires PDF document processing functionality available in [DevExpress Office File API (Basic)](https://www.devexpress.com/buy). You can obtain this product as part of the following DevExpress subscriptions: Universal, DXperience, WinForms, WPF, and ASP.NET.

This example implements a view that opens a PDF File, obtains form fields, and allows you to populate them. Note that the sample application supports a limited set of PDF file form fields, but you can extend the functionality according to your needs. 

**Related Controls and Their Properties**: 

* [OfficeFileAPI](https://docs.devexpress.com/MAUI/404434): [PdfDocumentProcessor](https://docs.devexpress.com/MAUI/DevExpress.Pdf.PdfDocumentProcessor), [PdfFormFieldFacade](https://docs.devexpress.com/MAUI/DevExpress.Pdf.PdfFormFieldFacade)
* [ToolbarItems](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.toolbaritem)
* [DataFormView](https://docs.devexpress.com/MAUI/403640): [DataObject](https://docs.devexpress.com/MAUI/DevExpress.Maui.DataForm.DataFormView.DataObject), [IsAutoGenerationEnabled](https://docs.devexpress.com/MAUI/DevExpress.Maui.DataForm.DataFormView.IsAutoGenerationEnabled), [ValidateProperty](https://docs.devexpress.com/MAUI/DevExpress.Maui.DataForm.DataFormView.ValidateProperty)

## Implementation Details

* Call the [PdfDocumentProcessor.LoadDocument](https://docs.devexpress.com/OfficeFileAPI/DevExpress.Pdf.PdfDocumentProcessor.LoadDocument.overloads) method to load a PDF file. If you open a PDF file included in the project, first copy the file to the **AppData** folder.
* Call the [PdfAcroFormFacade.GetFields](https://docs.devexpress.com/OfficeFileAPI/DevExpress.Pdf.PdfAcroFormFacade.GetFields) method to obtain form fields from the PDF file.
    
    ```xml
    DocumentProcessor.DocumentFacade.AcroForm.GetFields();
    ```
* You can determine field type, value, and settings. To change a field value, assign the new value to the [PdfTextFormFieldFacade.Value](https://docs.devexpress.com/OfficeFileAPI/DevExpress.Pdf.PdfTextFormFieldFacade.Value) property. 
    
    ```xml
    ((PdfTextFormFieldFacade)field).Value = "newValue";
    ```
* The *EditPageViewModel.Properties* collection contains information about field editors used in the PDF file. The *DataFormPropertySourceBehavior.PropertiesSource* property is bound to this collection to populate the [DataFormView](https://docs.devexpress.com/MAUI/403640) control with editors. The *DataFormPropertySourceBehavior.ItemTemplate* property defines a template used to display [DataFormView](https://docs.devexpress.com/MAUI/403640) editors.
  
    ```xml
    <dxdf:DataFormView>
        <dxdf:DataFormView.Behaviors>
            <local:DataFormPropertySourceBehavior PropertiesSource="{Binding Properties}" ItemTemplate="{StaticResource formItemTemplateSelector}"/>
        </dxdf:DataFormView.Behaviors>
    </dxdf:DataFormView>
    ```
* Field values are stored in the *editedObject* dictionary (`Dictionary<string, object>`). This project creates an edit form with the help of a [DataFormView](https://docs.devexpress.com/MAUI/403640) control bound to this *editedObject* dictionary.
* The [ValidateProperty](https://docs.devexpress.com/MAUI/DevExpress.Maui.DataForm.DataFormView.ValidateProperty) event validates form fields.
    
    ```
    private void dataform_ValidateProperty(object sender, DataFormPropertyValidationEventArgs e) {
        DataFormItem dataFormItem = ((DataFormView)sender).Items.FirstOrDefault(item => item.FieldName == e.PropertyName);
        if (dataFormItem != null && ((EditedItemModel)dataFormItem.BindingContext).IsRequired && (e.NewValue == null || (e.NewValue is string strValue && string.IsNullOrEmpty(strValue)))) {
            e.HasError = true;
        }
    }
    ```

* The type of a DataFormView editor depends on the type of the corresponding PDF file field:
  
  | PDF field type | DataFormView editor |
  |-|-|
  | Text | [DataFormTextItem](https://docs.devexpress.com/MAUI/DevExpress.Maui.DataForm.DataFormTextItem) |
  | Date | [DataFormDateItem](https://docs.devexpress.com/MAUI/DevExpress.Maui.DataForm.DataFormDateItem) |
  | Masked Text | [DataFormMaskedItem](https://docs.devexpress.com/MAUI/DevExpress.Maui.DataForm.DataFormMaskedItem) |
  | ComboBox | [DataFormComboBoxItem](https://docs.devexpress.com/MAUI/DevExpress.Maui.DataForm.DataFormComboBoxItem) |
  | RadioGroup| [DataFormComboBoxItem](https://docs.devexpress.com/MAUI/DevExpress.Maui.DataForm.DataFormComboBoxItem) |

* When the [DataFormComboBoxItem](https://docs.devexpress.com/MAUI/DevExpress.Maui.DataForm.DataFormComboBoxItem) contains a small number of available items, it displays them in popup. Otherwise, the [DataFormComboBoxItem.PickerShowMode](https://docs.devexpress.com/MAUI/DevExpress.Maui.DataForm.DataFormComboBoxItem.PickerShowMode) property is set to [BottomSheet](https://docs.devexpress.com/MAUI/DevExpress.Maui.Editors.DropDownShowMode) and  displays the list of items in the [BottomSheet](https://docs.devexpress.com/MAUI/DevExpress.Maui.Controls.BottomSheet) control. 

* The [PdfDocumentProcessor.SaveDocument](https://docs.devexpress.com/OfficeFileAPI/DevExpress.Pdf.PdfDocumentProcessor.SaveDocument.overloads) method saves changes.