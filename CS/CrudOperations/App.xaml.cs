
using Microsoft.EntityFrameworkCore;

namespace CrudOperations;

public partial class App : Application {
    public static string DbFileName = "contacts.db";
    public App() {
        InitializeComponent();
        CopyWorkingFilesToAppData(DbFileName).Wait();
        MainPage = new AppShell();
    }

    public async Task<string> CopyWorkingFilesToAppData(string fileName) {
        string targetFile = Path.Combine(FileSystem.Current.AppDataDirectory, fileName);
        if (File.Exists(targetFile))
            return targetFile;
        using Stream fileStream = await FileSystem.Current.OpenAppPackageFileAsync(fileName);
        using FileStream outputStream = File.OpenWrite(targetFile);
        fileStream.CopyTo(outputStream);
        return targetFile;
    }
}

