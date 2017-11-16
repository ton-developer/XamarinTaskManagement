using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Models
{
    public static class TaskModelList
    {
        public static List<TaskModel> taskModelList;

        public static List<TaskModel> GetList()
        {
            if (taskModelList == null)
            {
                taskModelList = new List<TaskModel>();
            }

            return taskModelList;
        }

        public static TaskModel AddTask(TaskModel taskModel)
        {
            var list = GetList();

            taskModel.Id = list.Count + 1;
            taskModel.TaskState = TaskModel.State.Pending;

            list.Add(taskModel);

            return taskModel;
        }

        public static TaskModel UpdateTask(TaskModel taskModel, TaskModel.State modelState)
        {
            var list = GetList();

            list.Where(x => x.Id == taskModel.Id).Select(c => { c.TaskState = modelState; return c; }).ToList();

            return list.First();
        }

        public static void RemoveTask(TaskModel task)
        {
            GetList().Remove(task);
        }
    }
}
