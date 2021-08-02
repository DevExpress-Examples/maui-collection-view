using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Controls.Xaml;
using DevExpress.Maui.CollectionView;

[assembly: XamlCompilationAttribute(XamlCompilationOptions.Compile)]

namespace CollectionViewExample
{
	public class Startup : IStartup
	{
		public void Configure(IAppHostBuilder appBuilder)
		{
			appBuilder
				.ConfigureMauiHandlers((_, handlers) => handlers.AddHandler<IDXCollectionView, DXCollectionViewHandler>())
				.UseMauiApp<App>()
				.ConfigureFonts(fonts => 
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				});
		}
	}
}