using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.DAL.Model
{
    public class User
    {
        public int UserIdentifier { get; set; }
        public string UserName { get; set; }
        public DateTime TS { get; set; }
        public string State { get; set; }
        public List<CrudProfil> CrudProfils { get; set; } = new List<CrudProfil>();
    }
}
