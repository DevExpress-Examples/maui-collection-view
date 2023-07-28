using System.Diagnostics;

namespace CollectionViewFilteringUI;

public partial class TabHeaderControl : ContentView
{
    public static readonly BindableProperty IconPathProperty = BindableProperty.Create("IconPath", typeof(string), typeof(TabHeaderControl));
    public static readonly BindableProperty CaptionProperty = BindableProperty.Create("Caption", typeof(string), typeof(TabHeaderControl));
    public static readonly BindableProperty IsSelectedProperty = BindableProperty.Create("IsSelected", typeof(bool), typeof(TabHeaderControl));
    public string IconPath {
		get { return (string)GetValue(IconPathProperty); }
		set { SetValue(IconPathProperty, value); }
	}
    public string Caption {
		get { return (string)GetValue(CaptionProperty); }
		set { SetValue(CaptionProperty, value); }
	}
	public bool IsSelected {
		get { return (bool)GetValue(IsSelectedProperty); }
		set { SetValue(IsSelectedProperty, value); }
	}
	public TabHeaderControl()
	{
		InitializeComponent();
	}
}