using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DevExpress.Maui.Core;
using DevExpress.Maui.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CollectionViewSwipe
{
    public partial class ViewModel : DXObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Task> data;

        public ViewModel()
        {
            Data = new ObservableCollection<Task>() {
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

        [RelayCommand]
        void DeleteTask(Task taskToDelete)
        {
            Data.Remove(taskToDelete);
        }
    }

    public partial class Task : DXObservableObject
    {
        [ObservableProperty]
        bool isTaskCompleted;

        [ObservableProperty]
        string description;

        [ObservableProperty]
        Color itemColor;

        [ObservableProperty]
        string actionText;

        [ObservableProperty]
        string actionIcon;

        partial void OnIsTaskCompletedChanged(bool oldValue, bool newValue)
         => UpdateState();

        [RelayCommand]
        void ChangeState() => IsTaskCompleted = !IsTaskCompleted;

        public Task(string description)
        {
            Description = description;
            UpdateState();
        }

        void UpdateState()
        {
            ItemColor = IsTaskCompleted ? Color.FromArgb("#c6eccb") : Color.FromArgb("#e6e6e6");
            ActionText = IsTaskCompleted ? "To Do" : "Done";
            ActionIcon = IsTaskCompleted ? "uncompletetask" : "completetask";
        }
    }
}
