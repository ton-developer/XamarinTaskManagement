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
    public class AddTaskViewModel : ViewModelBase
    {
        private TaskModel _taskModel;
        private string _info;

        public AddTaskViewModel()
        {
            TaskInfoModel = new TaskModel();
            UpdateInfo = new Command(SetInfo);
        }

        /// <summary>
        /// Gets the update information.
        /// </summary>
        /// <value>
        /// The update information.
        /// </value>
        public ICommand UpdateInfo { get; private set; }

        /// <summary>
        /// Gets or sets the person model.
        /// </summary>
        /// <value>
        /// The person model.
        /// </value>
        public TaskModel TaskInfoModel
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

        private void SetInfo()
        {
            if (String.IsNullOrEmpty(TaskInfoModel.Name))
            {
                Info = "Field Name is Required";                
            }
            else
            {
                var taskModel = TaskModelList.AddTask(TaskInfoModel);

                Info = string.Format("Task Id {0} create as {1}",
                                     taskModel.Id, taskModel.TaskState.ToString());

                TaskInfoModel = new TaskModel();
            } 
        }   
    }
}
