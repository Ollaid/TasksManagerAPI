using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.DAL.Model
{
    public class CrudProfil
    {
        public int CrudProfilIdentifier { get; set; }
        public string Label { get; set; }
        public DateTime TS { get; set; }
        public string State { get; set; }

    }
}
