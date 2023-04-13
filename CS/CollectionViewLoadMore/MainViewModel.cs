using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;

namespace InfiniteScrollingExample {
    public class MainViewModel : ViewModelBase {
        int lastLoadedIndex = 0;
        int loadBatchSize = 5;
        int sourceSize = 0;
        bool isLoading;
        public List<BlogPost> Blogs { get; set; }
        public ICommand LoadMoreCommand { get; set; }
        public ICommand ShareCommand { get; set; }
        public ICommand OpenBlogCommand { get; set; }
        public bool IsLoading {
            get => isLoading;
            set {
                isLoading = value;
                RaisePropertyChanged();
            }
        }
        public MainViewModel() {
            Blogs = new List<BlogPost>();
            sourceSize = DataStorage.GetTotalCount();
            LoadBatch();
            LoadMoreCommand = new Command(LoadMore, CanLoadMore);
            ShareCommand = new Command<BlogPost>(ShareBlog);
            OpenBlogCommand = new Command<BlogPost>(OpenBlog);
        }
        public async void LoadBatch() {
            IEnumerable<BlogPost> newBlogsBatch = null;
            IsLoading = true;
            await Task.Run(() =>
            {
                Thread.Sleep(1000);
                newBlogsBatch = DataStorage.GetBlogs(lastLoadedIndex, loadBatchSize);
            });
            Blogs.AddRange(newBlogsBatch);
            IsLoading = false;
        }
        public void LoadMore() {
            LoadBatch();
            lastLoadedIndex += loadBatchSize;
        }
        public bool CanLoadMore() {
            return Blogs.Count < sourceSize;
        }
        public async void ShareBlog(BlogPost blog) {
            await Share.Default.RequestAsync(new ShareTextRequest {
                Text = blog.Url,
                Title = "Share the Blog With your Friends"
            });
        }
        public async void OpenBlog(BlogPost blog) {
            try {
                await Browser.Default.OpenAsync(new Uri(blog.Url), BrowserLaunchMode.SystemPreferred);
            }
            catch (Exception) {
                await App.Current.MainPage.DisplayAlert("Error", "Couldn't open the URL", "OK");
            }
        }
    }
    public class BlogPost {
        public BlogPost(int id, string title, string authorName, DateTime publicationDate, string imagePath, string url) {
            Id = id;
            Title = title;
            AuthorName = authorName;
            PublicationDate = publicationDate;
            ImagePath = imagePath;
            Url = url;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public DateTime PublicationDate { get; set; }
        public string ImagePath { get; set; }
        public string Url { get; set; }
        public string AvatarPath => AuthorName?.ToLower()+".jpg";

    }

    public static class DataStorage {
        static DataStorage() {
            allBlogs = CreateBlogs();
        }

        public static IEnumerable<BlogPost> GetBlogs(int startIndex, int batchSize) {
            return allBlogs.Skip(startIndex).Take(batchSize);
        }
        public static int GetTotalCount() {
            return allBlogs.Count;
        }
        static List<BlogPost> allBlogs;
        static List<BlogPost> CreateBlogs() {
            return new List<BlogPost>() {
                new BlogPost(1, "DevExtreme Roadmap (Angular, React, Vue, jQuery)", "Vlada", new DateTime(2023,2,22), "devextreme_roadmap", "https://community.devexpress.com/blogs/javascript/archive/2023/02/22/devextreme-components-roadmap-2023-1.aspx"),
                new BlogPost(1, "Blazor Editors — Command Buttons", "Margarita", new DateTime(2023,2,22), "blazor_editors_buttons","https://community.devexpress.com/blogs/aspnet/archive/2023/02/22/Blazor-Editors-Command-Buttons-v22-2.aspx"),
                new BlogPost(1, "DevExpress Reports Roadmap (Survey Inside)", "Dmitry", new DateTime(2023,2,21), "reporting_roadmap", "https://community.devexpress.com/blogs/reporting/archive/2023/02/21/devexpress-reports-v23-1-june-2023-roadmap-survey-inside.aspx"),
                new BlogPost(1, "Announcing DevExpress Mobile UI for .NET MAUI", "Anthony", new DateTime(2023,2,21), "maui_release","https://community.devexpress.com/blogs/mobile/archive/2023/02/22/announcing-devexpress-mobile-ui-for-net-maui-v22-2.aspx"),
                new BlogPost(1, "Office File API & Office-Inspired UI Controls Roadmap (Survey Inside)", "Dmitry", new DateTime(2023,2,21), "office_roadmap","https://community.devexpress.com/blogs/office/archive/2023/02/21/office-file-api-office-inspired-ui-controls-v23-1-june-2023-roadmap-survey-inside.aspx"),
                new BlogPost(1, "DevExpress BI Dashboard Roadmap (Survey Inside)", "Dmitry", new DateTime(2023,2,21), "dashboard_roadmap","https://community.devexpress.com/blogs/analytics/archive/2023/02/21/devexpress-bi-dashboard-v23-1-june-2023-roadmap-survey-inside.aspx"),
                new BlogPost(1, "Reporting — Serial Shipping Container Code (SSCC-18): A Solution for Walmart's Packaging Needs", "Boris", new DateTime(2023,2,20), "reporting_serial_shipping","https://community.devexpress.com/blogs/reporting/archive/2023/02/20/reporting-serial-shipping-container-code-sscc-18-a-solution-for-walmart-39-s-packaging-needs.aspx"),
                new BlogPost(1, "DevExpress.Drawing Graphics Library — Update — Package Dependencies and Font Libraries", "Poline", new DateTime(2023,2,16), "devextreme__fonts","https://community.devexpress.com/blogs/news/archive/2023/02/16/devexpress-drawing-graphics-library-v22-2-4-update-package-dependencies-and-font-libraries.aspx"),
                new BlogPost(1, "DevExpress WinForms Roadmap", "Bogdan", new DateTime(2023,2,16), "winforms_roadmap","https://community.devexpress.com/blogs/winforms/archive/2023/02/16/devexpress-winforms-roadmap-23-1.aspx"),
                new BlogPost(1, "XAF Roadmap (Cross-Platform .NET App UI & Web API Service)", "Dennis", new DateTime(2023,2,9), "xaf_roadmap","https://community.devexpress.com/blogs/xaf/archive/2023/02/09/xaf-2023-1-roadmap-cross-platform-net-app-ui-and-web-api-service.aspx"),
                new BlogPost(1, "Blazor Reporting — Quick Start with New Project Templates", "Boris", new DateTime(2023,2,6), "blazor_reporting","https://community.devexpress.com/blogs/reporting/archive/2023/02/06/blazor-reporting-quick-start-with-new-project-templates.aspx"),
                new BlogPost(1, "Blazor Toolbar — Data Binding", "Elena", new DateTime(2023,2,1), "blazor_toolbar","https://community.devexpress.com/blogs/aspnet/archive/2023/02/01/Blazor-Toolbar-Data-Binding-_2800_v22.2_2900_.aspx"),
                new BlogPost(1, "9 Tips to Reduce WPF App Startup Time", "Andrey", new DateTime(2023,1,26), "wpf9tips","https://community.devexpress.com/blogs/wpf/archive/2023/01/26/9-tips-to-reduce-wpf-app-startup-time.aspx"),
                new BlogPost(1, ".NET MAUI Controls — Material Design 3", "Anthony", new DateTime(2023,1,25), "maui_md3","https://community.devexpress.com/blogs/mobile/archive/2023/01/25/net-maui-controls-v22-2-material-design-3.aspx"),
                new BlogPost(1, "Blazor Accordion — Single Selection", "Elena", new DateTime(2023,1,19), "blazor_accordion","https://community.devexpress.com/blogs/aspnet/archive/2023/01/19/blazor-accordion-single-selection-v22-2.aspx"),
                new BlogPost(1, ".NET MAUI — Hot Reload Support", "Kseniya", new DateTime(2023,1,17), "maui_hotreload","https://community.devexpress.com/blogs/mobile/archive/2023/01/17/net-maui-hot-reload-support.aspx"),
                new BlogPost(1, "Blazor Grid — Export Data to Excel", "Lana", new DateTime(2023,1,17), "blazor_excel_export","https://community.devexpress.com/blogs/aspnet/archive/2023/01/17/blazor-grid-export-data-to-excel-v22-2.aspx"),
                new BlogPost(1, "Blazor — New Window Component", "Margarita", new DateTime(2023,1,13), "blazor_window","https://community.devexpress.com/blogs/aspnet/archive/2023/01/13/blazor-new-window-component-v22-2.aspx"),
                new BlogPost(1, "DevExtreme Calendar for Angular, React, Vue and jQuery — Show Week Numbers", "Vlada", new DateTime(2023,1,12), "devextreme_calendar","https://community.devexpress.com/blogs/javascript/archive/2023/01/12/devextreme-calendar-angular-react-vue-jquery-show-week-numbers-v22-2.aspx"),
                new BlogPost(1, "WPF TreeList Control — Load Nodes Asynchronously", "Andrey", new DateTime(2023,1,11), "treelist_asynchronous_loading","https://community.devexpress.com/blogs/wpf/archive/2023/01/11/wpf-treelist-control-load-nodes-asynchronously-v22-2.aspx"),
                new BlogPost(1, "Blazor Grid — Integrated Editor Appearance", "Lana", new DateTime(2023,1,9), "blazor_integrated_editor","https://community.devexpress.com/blogs/reporting/archive/2023/02/06/blazor-reporting-quick-start-with-new-project-templates.aspx"),
                new BlogPost(1, ".NET MAUI — Your Feedback Counts", "Alex", new DateTime(2023,1,9), "maui_feedback","https://community.devexpress.com/blogs/mobile/archive/2023/01/09/maui.aspx"),
                new BlogPost(1, "Content Security Policy for BI Dashboard & Reporting — Say No To Unsafe JavaScript Evaluation!", "Margarita", new DateTime(2023,1,4), "dashboard_report_security","https://community.devexpress.com/blogs/reporting/archive/2023/01/09/content-security-policy-for-bi-dashboard-amp-reporting-say-no-to-unsafe-javascript-evaluation.aspx"),
                new BlogPost(1, "Blazor Grid — Search Box", "Lana", new DateTime(2023,1,4), "blazor_searchbox","https://community.devexpress.com/blogs/aspnet/archive/2023/01/04/blazor-grid-search-box-v22-2.aspx"),
                new BlogPost(1, "Blazor — Hybrid Support", "Margarita", new DateTime(2023,1,4), "blazor_hybrid","https://community.devexpress.com/blogs/aspnet/archive/2023/01/04/blazor-hybrid-support-v22.2.aspx"),
            };

        }
    }

    public class ViewModelBase : INotifyPropertyChanged {
        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
