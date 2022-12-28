using MAUI_Tests.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI_Tests.Services
{
    public class TaskService
    {
        SaveService saveService = new SaveService();
        private ObservableCollection<TaskModel> tasks;
        public ObservableCollection<TaskModel> Tasks => tasks;

        public TaskService(SaveService saveService)
        {
            this.saveService = saveService;
            tasks = this.saveService.GetSavedTasks() ?? new ObservableCollection<TaskModel>();
        }
        public void Add(TaskModel task)
        {
            if (task != null)
            {
                tasks.Add(task);
                saveService.Save(tasks);
            }
        }
        public void Save() => saveService.Save(tasks);
       
    }
}
