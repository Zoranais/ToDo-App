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
            tasks = saveService.GetSavedTasks();
        }
        public void Add(TaskModel task)
        {
            if (task != null)
            {
                tasks.Add(task);
                Save();
            }
        }
        public void Remove(TaskModel task)
        {
            if (tasks.Contains(task))
            {
                tasks.Remove(task);
                Save();
            }
        }
        public void Save() => saveService.Save(tasks);
       
    }
}
