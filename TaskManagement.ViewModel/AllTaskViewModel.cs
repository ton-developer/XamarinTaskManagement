using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Models;
using Xamarin.Forms;

namespace TaskManagement.ViewModel
{
    public class AllTaskViewModel : ViewModelBase
    {
        private TaskModel _taskModel;
        private string _info;

        public AllTaskViewModel()
        {
            var tasklist = TaskModelList.GetList().ToList();
            ObservableCollectionPendingTasks = new ObservableCollection<TaskModel>();
            ObservableCollectionOnGoingTasks = new ObservableCollection<TaskModel>();
            ObservableCollectionFinishedTasks = new ObservableCollection<TaskModel>();
            foreach (var task in tasklist)
            {
                switch (task.TaskState)
                {
                    case TaskModel.State.Pending: 
                        ObservableCollectionPendingTasks.Add(task);
                        break;
                    case TaskModel.State.OnGoing:
                        ObservableCollectionOnGoingTasks.Add(task);
                        break;
                    case TaskModel.State.Finished:
                        ObservableCollectionFinishedTasks.Add(task);
                        break;
                    default:
                        break;
                }
                
            }

        }

        private ObservableCollection<TaskModel> _observableCollectionPendingTask;
        public ObservableCollection<TaskModel> ObservableCollectionPendingTasks
        {
            get => _observableCollectionPendingTask;
            set => SetProperty(ref _observableCollectionPendingTask, value);
        }

        private ObservableCollection<TaskModel> _observableCollectionOnGoingTask;
        public ObservableCollection<TaskModel> ObservableCollectionOnGoingTasks
        {
            get => _observableCollectionOnGoingTask;
            set => SetProperty(ref _observableCollectionOnGoingTask, value);
        }

        private ObservableCollection<TaskModel> _observableCollectionFinishedTask;
        public ObservableCollection<TaskModel> ObservableCollectionFinishedTasks
        {
            get => _observableCollectionFinishedTask;
            set => SetProperty(ref _observableCollectionFinishedTask, value);
        }

        /// <summary>
        /// Gets or sets the information.
        /// </summary>
        /// <value>
        /// The information.
        /// </value>
        public string Info
        {
            get => _info;
            set => SetProperty(ref _info, value);
        }

    }
}
