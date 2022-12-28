using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI_Tests.Model
{
    public partial class TaskModel : ObservableObject
    {
        //    public string Header { get; set; }
        //    public string Body { get; set; }
        //    public bool isCompleted { get; set; }
        //    public bool isTimeLimited { get; set; }
        //    public DateTime endTime { get; set; }
        [ObservableProperty]
        string header;
        [ObservableProperty]
        string body;
        [ObservableProperty]
        bool isCompleted;
        [ObservableProperty]
        bool isTimeLimited;
        [ObservableProperty]
        DateTime endTime;
        public TaskModel()
        {
            EndTime= DateTime.Now;
        }
    }
}
