﻿using CommunityToolkit.Maui;
using DevExpress.Maui;
using DevExpress.Maui.Core;
using Microsoft.Maui;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Compatibility.Hosting;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;

namespace CollectionViewLongTapExamp {
    public static class MauiProgram {
        public static MauiApp CreateMauiApp() {
            ThemeManager.UseAndroidSystemColor = false;
            ThemeManager.Theme = new Theme(ThemeSeedColor.Purple);
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseDevExpress(useLocalization: true)
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("univia-pro-regular.ttf", "Univia-Pro");
                    fonts.AddFont("roboto-bold.ttf", "Roboto-Bold");
                    fonts.AddFont("roboto-regular.ttf", "Roboto");
                });

            return builder.Build();
        }
    }
}