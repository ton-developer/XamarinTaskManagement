using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Models;

namespace TaskManagement.ViewModel
{
    public class TaskViewModel : ViewModelBase
    {
        private ObservableCollection<TaskModel> _observableCollectionTask;

        /// <summary>
        /// Gets or sets the task of the observable collection.
        /// </summary>
        /// <value>
        /// The  of the observable collection.
        /// </value>
        public ObservableCollection<TaskModel> ObservableCollectionTask
        {
            get => _observableCollectionTask;
            set => SetProperty(ref _observableCollectionTask, value);
        }
    }
}
