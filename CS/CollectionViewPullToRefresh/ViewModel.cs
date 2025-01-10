using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DevExpress.Maui.Mvvm;

namespace CollectionViewPullToRefresh {
    public partial class ViewModel : DXObservableObject {
        readonly MailMessageRepository repository;

        public ViewModel(MailMessageRepository repository) {
            this.repository = repository;
            ItemSource = GetSortedMessages(repository);
        }

        [ObservableProperty]
        IList<MailData> itemSource;

        [ObservableProperty]
        bool isRefreshing = false;

        [RelayCommand]
        void PullToRefresh() {
            Task.Run(() => {
                Thread.Sleep(1000);
                repository.GenerateMessages();
                ItemSource = GetSortedMessages(repository);
                IsRefreshing = false;
            });
        }

        IList<MailData> GetSortedMessages(MailMessageRepository repository) {
            return repository.MailMessages.OrderByDescending(x => x.MailTime).ToList();
        }
    }
}
