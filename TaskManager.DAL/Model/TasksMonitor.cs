using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.DAL.Model
{
    public class TasksMonitor
    {
        public int TaskMonitorIdentifier { get; set; }
        public SubTasks SubTaskToMonitor { get; set; }
        public string State { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
