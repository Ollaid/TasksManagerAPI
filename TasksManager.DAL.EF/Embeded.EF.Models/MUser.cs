using System;
using System.Collections.Generic;
using TasksManager.DAL.EF.Models.EF;
using TasksManager.DAL.EF.CRUDManager;

namespace TasksManager.DAL.EF.Embeded.EF.Models
{
    public class MUser: ModelBase
    {
        public int UserIdentifier { get; set; }
        public string UserName { get; set; }
        public DateTime TS { get; set; }
        public string State { get; set; }
        public List<MCrudProfil> CrudProfils { get; set; } = new List<MCrudProfil>();

        public MUser()
        {

        }

        public MUser(User user)
        {
            try
            {
                this.UserIdentifier = user.UserId;
                this.UserName = user.UserName;
                this.TS = user.Ts;
                this.State = user.State;
                this._LoadCrudProfils(user, this.CrudProfils);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("MUser: {0}", ex.Message));
            }
        }

        private void _LoadCrudProfils(User user, List<MCrudProfil> result)
        {
            try
            {
                result = CrudManager.LoadCrudProfils(user, result);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("_LoadCrudProfils: {0}", ex.Message));
            }
        }

        public override object ToEntity()
        {
            User result = new();

            try
            {
                result.UserName = this.UserName;
                result.Ts = this.TS;
                result.State = this.State;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("MUser.ToEntity: {0}", ex.Message));
            }

            return result;
        }
    }
}
