using System;
using TasksManager.DAL.EF.Models.EF;

namespace TasksManager.DAL.EF.Embeded.EF.Models
{
    public class MCrudProfil: ModelBase
    {
        public int CrudProfilIdentifier { get; set; }
        public string Label { get; set; }
        public DateTime TS { get; set; }
        public string State { get; set; }

        public MCrudProfil()
        {

        }

        public MCrudProfil(CrudProfil crudProfil)
        {
            try
            {
                this.CrudProfilIdentifier = crudProfil.ProfilId;
                this.Label = crudProfil.Label;
                this.TS = crudProfil.Ts;
                this.State = crudProfil.State;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("CRUDProfil: {0}", ex.Message));
            }
        }
        public override object ToEntity()
        {
            CrudProfil crudProfil = new();
            try
            {
                crudProfil.Label = this.Label;
                crudProfil.Ts = this.TS;
                crudProfil.State = this.State;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("CRUDProfil.ToEntity: {0}", ex.Message));
            }

            return crudProfil;
        }
    }
}
