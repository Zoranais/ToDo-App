﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUI_Tests.Model;
using MAUI_Tests.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MAUI_Tests.ViewModel
{
    public partial class MainViewModel : ObservableObject 
    {
        TaskService taskService;
        public MainViewModel(TaskService taskService)
        {
            this.taskService = taskService;
            Items = taskService.Tasks;
        }
        [ObservableProperty]
        ObservableCollection<TaskModel> items;
        [ObservableProperty]
        private TaskModel task;
        [ObservableProperty]
        private string name;
        [RelayCommand]
        async void Add()
        {
            await Shell.Current.GoToAsync($"{nameof(CreatePage)}");
            //if (string.IsNullOrEmpty(Name))
            //    return;
            //Items.Add(new TaskModel());
            //Name = string.Empty;
        }
        [RelayCommand]
        void Delete(TaskModel s)
        {
            if (Items.Contains(s))
            {
                Items.Remove(s);
            }
        }
        [RelayCommand]
        async Task Edit(TaskModel s)
        {
            var navigationParameter = new Dictionary<string, object>
            {
                {$"{nameof(TaskModel)}", s }
            };
            await Shell.Current.GoToAsync($"{nameof(DetailPage)}", navigationParameter);
        }
        [RelayCommand]
        void Check(TaskModel s)
        {
            s.IsCompleted = !s.IsCompleted;
            taskService.Save();
        }
    }
}