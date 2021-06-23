using System;
using TasksManager.DAL.EF.Models.EF;

namespace TasksManager.DAL.EF.Embeded.EF.Models
{
    public class MTaskMonitor : ModelBase
    {
        public int TaskMonitorIdentifier { get; set; }
        public MSubTask SubTaskToMonitor { get; set; }
        public string State { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public MTaskMonitor()
        {

        }
        public MTaskMonitor(TasksMonitor tasksMonitor)
        {
            try
            {
                this.TaskMonitorIdentifier = tasksMonitor.TaskMonitorId;
                this.State = tasksMonitor.IsRunning ? "En cours" : "Arrêtée";
                this.StartDate = tasksMonitor.StartDate;
                this.EndDate = tasksMonitor.EndDate;
                this.SubTaskToMonitor = this._LoadMSubTaskToMonitor(tasksMonitor);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("MTaskMonitor: {0}", ex.Message));
            }
        }

        private MSubTask _LoadMSubTaskToMonitor(TasksMonitor tasksMonitor)
        {
            MSubTask subTaskToMonitor = new();
            try
            {
                //Todo 
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("_LoadMSubTask: {0}", ex.Message));
            }

            return subTaskToMonitor;
        }

        public override object ToEntity()
        {
            TasksMonitor result = new();

            try
            {
                //ToDo
                result.TaskId = this.SubTaskToMonitor.TaskIdentifier;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("MTaskMonitor.ToEntity: {0}", ex.Message));
            }

            return result;
        }
    }
}
