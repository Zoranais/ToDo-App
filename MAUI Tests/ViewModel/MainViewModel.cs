using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUI_Tests.Model;
using MAUI_Tests.Services;
using MAUI_Tests.Themes;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MAUI_Tests.ViewModel
{
    public partial class MainViewModel : ObservableObject 
    {
        bool isDarkTheme = false;
        TaskService taskService;
        public MainViewModel(TaskService taskService, 
            SaveService sv)
        {
            this.taskService = taskService;
            Items = taskService.Tasks;
            //foreach (var item in sv.GetSavedTasks())
            //{
            //    Items.Add(item);
            //}
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
        }
        [RelayCommand]
        void Delete(TaskModel s)
        {
            taskService.Remove(s);
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
        [RelayCommand]
        void Theme()
        {
            var mergedDictionaries = Application.Current.Resources.MergedDictionaries;
            if (mergedDictionaries != null)
            {
                mergedDictionaries.Clear();
                if (isDarkTheme)
                {
                    mergedDictionaries.Add(new LightTheme());
                }
                else
                {
                    mergedDictionaries.Add(new DarkTheme());
                }
                isDarkTheme = !isDarkTheme;
            }
        }
    }
}
