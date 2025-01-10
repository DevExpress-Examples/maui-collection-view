using DevExpress.Maui;
using DevExpress.Maui.Core;

namespace CollectionViewPullToRefresh {
    public static class MauiProgram {
        public static MauiApp CreateMauiApp() {
            ThemeManager.ApplyThemeToSystemBars = true;
            ThemeManager.Theme = new Theme(ThemeSeedColor.DeepSeaBlue);
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseDevExpress()
                .UseDevExpressCollectionView()
                .ConfigureFonts(fonts => {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddSingleton<ViewModel>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MailMessageRepository>();
            return builder.Build();
        }
    }
}