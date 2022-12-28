using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUI_Tests.Model;
using MAUI_Tests.Services;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI_Tests.ViewModel
{
    public partial class CreateViewModel : ObservableObject
    {
        private TaskService ts;
        [ObservableProperty] 
        TaskModel taskModel;
        [ObservableProperty]
        string errorText;
        public CreateViewModel(TaskService ts)
        {
            taskModel = new TaskModel();
            this.ts = ts;
        }
        [RelayCommand]
        public async void Add()
        {
            ErrorText = string.Empty;
            if (string.IsNullOrWhiteSpace(taskModel.Header))
            {
                ErrorText+= " Header cannot be empty!";
                return;
            }
            ts.Add(taskModel);
            await Shell.Current.GoToAsync("..");
        }
        
    }
}
