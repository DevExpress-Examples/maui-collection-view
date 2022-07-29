using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CollectionViewSwipe {
    public class ViewModel {
        public List<Task> Data { get; }

        public ViewModel() {
            Data = new List<Task>() {
                new Task("Prepare Financial"),
                new Task("Prepare Marketing Plan"),
                new Task("QA Strategy Report"),
                new Task("Update Personnel Files"),
                new Task("Provide New Health Insurance Docs"),
                new Task("Choose between PPO and HMO Health Plan"),
                new Task("New Brochures"),
                new Task("Brochure Designs"),
                new Task("Brochure Design Review"),
                new Task("Create Sales Report"),
                new Task("Deliver R&D Plans"),
            };
        }
    }

    public class Task : INotifyPropertyChanged {
        public string Description { get; private set; }

        bool isTaskCompleted;
        public bool IsTaskCompleted {
            get => isTaskCompleted;
            set {
                isTaskCompleted = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsTaskCompleted)));
                UpdateState();
            }
        }

        Color itemColor;
        public Color ItemColor {
            get => itemColor;
            private set {
                itemColor = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ItemColor)));
            }
        }

        string actionText;
        public string ActionText {
            get => actionText;
            private set {
                actionText = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ActionText)));
            }
        }

        string actionIcon;
        public string ActionIcon {
            get => actionIcon;
            private set {
                actionIcon = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ActionIcon)));
            }
        }

        public ICommand ChangeStateCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        public Task(string description) {
            ChangeStateCommand = new Command(() => IsTaskCompleted = !IsTaskCompleted);
            Description = description;
            UpdateState();
        }

        void UpdateState() {
            ItemColor = IsTaskCompleted ? Color.FromArgb("#c6eccb") : Color.FromArgb("#e6e6e6");
            ActionText = IsTaskCompleted ? "To Do" : "Done";
            ActionIcon = IsTaskCompleted ? "uncompletetask" : "completetask";
        }
    }
}
