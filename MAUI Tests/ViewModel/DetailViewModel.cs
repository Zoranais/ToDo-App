using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUI_Tests.Model;
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
        string text;
        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }
        [RelayCommand]
        void Save()
        {
            if (!string.IsNullOrEmpty(text))
            {
                TaskModel.Header = Text;
                return;
            }
        }
    }
}
