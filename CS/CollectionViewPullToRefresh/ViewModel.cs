using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CollectionViewPullToRefresh {
    public class ViewModel : INotifyPropertyChanged {
        readonly MailMessageRepository repository;

        public ViewModel(MailMessageRepository repository) {
            this.repository = repository;
            ItemSource = GetSortedMessages(this.repository);
            PullToRefreshCommand = new Command(ExecutePullToRefreshCommand);
        }

        IList<MailData> itemSource;
        public IList<MailData> ItemSource {
            get { return itemSource; }
            set {
                if (itemSource != value) {
                    itemSource = value;
                    OnPropertyChanged("ItemSource");
                }
            }
        }

        bool isRefreshing = false;
        public bool IsRefreshing {
            get { return isRefreshing; }
            set {
                if (isRefreshing != value) {
                    isRefreshing = value;
                    OnPropertyChanged("IsRefreshing");
                }
            }
        }

        ICommand pullToRefreshCommand = null;
        public ICommand PullToRefreshCommand {
            get { return pullToRefreshCommand; }
            set {
                if (pullToRefreshCommand != value) {
                    pullToRefreshCommand = value;
                    OnPropertyChanged("PullToRefreshCommand");
                }
            }
        }

        void ExecutePullToRefreshCommand() {
            Task.Run(() => {
                Thread.Sleep(1000);
                this.repository.GenerateMessages();
                ItemSource = GetSortedMessages(this.repository);
                IsRefreshing = false;
            });
        }

        IList<MailData> GetSortedMessages(MailMessageRepository repository) {
            return repository.MailMessages.OrderByDescending(x => x.MailTime).ToList();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
