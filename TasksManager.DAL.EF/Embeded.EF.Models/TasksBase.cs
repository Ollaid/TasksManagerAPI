using System;
using System.Collections.Generic;
using TasksManager.DAL.EF.Models.EF;
using TasksManager.DAL.EF.CRUDManager;

namespace TasksManager.DAL.EF.Embeded.EF.Models
{
    public abstract class TasksBase
    {
        public int TaskIdentifier { get; set; }
        public string Label { get; set; }
        public string Role { get; set; }
        public bool IsSubTask { get; set; }
        public DateTime TS { get; set; }
        public string State { get; set; }
    }
    public class MTask: TasksBase, IModelBase
    {
        public List<MSubTask> SubTasks { get; set; } = new List<MSubTask>();

        public MTask()
        {

        }
        public MTask(Tasks tasks)
        {
            this.TaskIdentifier = tasks.TaskId;
            this.Label = tasks.Label;
            this.Role = tasks.Role;
            this.TS = tasks.Ts;
            this.IsSubTask = false;
            this._LoadSubtasks(tasks, this.SubTasks);
        }

        private void _LoadSubtasks(Tasks tasks, List<MSubTask> result)
        {
            try
            {
                result = CrudManager.LoadSubTasks(tasks, result);

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("_LoadSubtasks: {0}", ex.Message));
            }
        }

        public object ToEntity()
        {
            Tasks result = new();
            try
            {
                result.Label = this.Label;
                result.Role = this.Role;
                result.IsSubTask = false;
                result.Ts = this.TS;
                result.State = this.State;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("MTask.ToEntity: {0}", ex.Message));
            }

            return result;
        }
    }

    public class MSubTask : TasksBase, IModelBase
    {
        public List<MTask> Tasks { get; set; } = new List<MTask>();
        public List<MUser> Users { get; set; } = new List<MUser>();

        public MSubTask()
        {
        }
        public MSubTask(Tasks tasks)
        {
            this.TaskIdentifier = tasks.TaskId;
            this.Label = tasks.Label;
            this.Role = tasks.Role;
            this.TS = tasks.Ts;
            this.IsSubTask = true;
            this._LoadTasks(tasks, this.Tasks);
            //Todo load Users
        }

        private void _LoadTasks(Tasks tasks, List<MTask> result)
        {
            try
            {
                result = CrudManager.LoadTasks(tasks, result);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("_LoadTasks: {0}", ex.Message));
            }
        }

        public object ToEntity()
        {
            Tasks result = new();

            try
            {
                result.Label = this.Label;
                result.Role = this.Role;
                result.IsSubTask = true;
                result.Ts = this.TS;
                result.State = this.State;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("MSubTask.ToEntity: {0}", ex.Message));
            }

            return result;
        }
    }
}
