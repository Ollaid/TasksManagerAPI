using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksManager.DAL.EF.Embeded.EF.Models
{
    public abstract class ModelBase
    {
        public abstract Object ToEntity();
    }

    interface IModelBase
    {
        Object ToEntity();
    }
}
