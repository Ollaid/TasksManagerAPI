using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.DAL.Model
{
    public class DbElements
    {
        public List<Tasks> Tasks { get; set; } = new List<Tasks>();
        public List<User> Users { get; set; } = new List<User>();
    }
}
