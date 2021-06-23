using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.DAL.Model
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

    public class Tasks : TasksBase
    {
        public List<SubTasks> SubTasks { get; set; } = new List<SubTasks>();

        public Tasks()
        {
            this.IsSubTask = false;
        }
    }

    public class SubTasks : TasksBase
    {
        public List<Tasks> Tasks { get; set; } = new List<Tasks>();
        public List<User> Users { get; set; } = new List<User>();

        public SubTasks()
        {
            this.IsSubTask = true;
        }
    }
}
