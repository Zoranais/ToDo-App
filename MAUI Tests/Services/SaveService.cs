using MAUI_Tests.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MAUI_Tests.Services
{
    public class SaveService
    {
        public async void Save(ObservableCollection<TaskModel> tasks)
        {
            var path = Path.Combine(FileSystem.Current.AppDataDirectory, "savedtasks.json");
            await File.WriteAllTextAsync(path, JsonSerializer.Serialize(tasks));
        }
        public ObservableCollection<TaskModel> GetSavedTasks()
        {
            var result = new ObservableCollection<TaskModel>();
            var path = Path.Combine(FileSystem.Current.AppDataDirectory, "savedtasks.json");
            if (File.Exists(path))
            {
                return JsonSerializer.Deserialize<ObservableCollection<TaskModel>>(File.ReadAllText(path));
            }
            return new ObservableCollection<TaskModel>();
        }
    }
}
