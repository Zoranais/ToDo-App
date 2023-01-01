using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUI_Tests.Model;
using MAUI_Tests.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI_Tests.ViewModel
{
    [QueryProperty($"{nameof(TaskModel)}", $"{nameof(TaskModel)}")]
    public partial class DetailViewModel : ObservableObject
    {
        [ObservableProperty]
        TaskModel taskModel;
        [ObservableProperty]
        TaskModel editTask = new TaskModel();
        TaskService ts;
        public DetailViewModel(TaskService ts)
        {
            this.ts = ts;
        }
        partial void OnTaskModelChanged(TaskModel value)
        {
            //editTask = new TaskModel()
            //{
            //    Header = TaskModel.Header,
            //    Body = TaskModel.Body ?? string.Empty,
            //    IsCompleted = TaskModel.IsCompleted,
            //    IsTimeLimited = TaskModel.IsTimeLimited,
            //    EndTime = TaskModel.EndTime
            //};
            EditTask.Header = TaskModel.Header;
            EditTask.Body = TaskModel.Body;
            EditTask.IsCompleted = TaskModel.IsCompleted;
            EditTask.EndTime = TaskModel.EndTime;
            EditTask.IsTimeLimited = TaskModel.IsTimeLimited;

        }
        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }
        
        [RelayCommand]
        async void Save()
        {
            if(!string.IsNullOrEmpty(EditTask.Header)) 
            { 
                TaskModel.Header = EditTask.Header;
                TaskModel.Body = EditTask.Body;
                TaskModel.IsCompleted = EditTask.IsCompleted;
                TaskModel.EndTime = EditTask.EndTime;
                TaskModel.IsTimeLimited = EditTask.IsTimeLimited;
                ts.Save();
                await Shell.Current.GoToAsync("..");
            }
        }
    }
}
