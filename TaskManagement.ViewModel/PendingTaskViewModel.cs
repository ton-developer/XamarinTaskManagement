using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskManagement.Models;
using Xamarin.Forms;

namespace TaskManagement.ViewModel
{
    public class PendingTaskViewModel : ViewModelBase
    {
        private TaskModel _taskModel;
        private string _info;

        public PendingTaskViewModel()
        {
            var tasklist = TaskModelList.GetList().Where(x => x.TaskState == TaskModel.State.Pending).ToList();
            ObservableCollectionTask = new ObservableCollection<TaskModel>();
            foreach(var task in tasklist)
            {
                ObservableCollectionTask.Add(task);                    
            }

            if (ObservableCollectionTask.Count == 0)
            {
                Info = "Currently there is no Tasks in this section.";
            }

            PendingTaskModel = new TaskModel();
            UpdateInfo = new Command<TaskModel>(SetInfo);
        }

        /// <summary>
        /// Gets the update information.
        /// </summary>
        /// <value>
        /// The update information.
        /// </value>
        public ICommand UpdateInfo { get; private set; }
        private ObservableCollection<TaskModel> _observableCollectionTask;
        public ObservableCollection<TaskModel> ObservableCollectionTask
        {
            get => _observableCollectionTask;
            set => SetProperty(ref _observableCollectionTask, value);
        }

        /// <summary>
        /// Gets or sets the person model.
        /// </summary>
        /// <value>
        /// The person model.
        /// </value>
        public TaskModel PendingTaskModel
        {
            get => _taskModel;
            set => SetProperty(ref _taskModel, value);
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

        private void SetInfo(TaskModel task)
        {
            var taskModel = TaskModelList.UpdateTask(task, TaskModel.State.OnGoing);
            Info = string.Format("Task with Id {0} moved to {1}",
                                 task.Id, task.TaskState.ToString());
            ObservableCollectionTask.Remove(task);
        }

    }
}
