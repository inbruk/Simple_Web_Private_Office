using System;
using System.Collections.Generic;

using DataAccessLayer;
using BusinessLogicLayer.Auxiliary;

namespace BusinessLogicLayer.CRUD
{
    internal class ServiceUsage : CRUDWithMappingBase<DTO.ServiceUsage, tblServiceUsage, Int32>
    {
        public ServiceUsage() : base() { }
        protected override Int32 GetLastCreatedId() { return _lastCreatedItem.Id; }
        protected override void InsertIdInDTO(DTO.ServiceUsage dtoItem, Int32 idValue) { dtoItem.Id = idValue; }
        // ------------------------------
        public DTO.ServiceUsage ReadOne(Int32 Id) { return this.ReadOne(x => x.Id == Id); }
        public List<DTO.ServiceUsage> ReadSeveral(List<Int32> listOfIds) { return this.ReadSeveral(x => listOfIds.Contains(x.Id)); }
        public void UpdateOne(DTO.ServiceUsage lib) { this.UpdateOne(lib, x => x.Id == lib.Id); }
        public void DeleteOne(DTO.ServiceUsage lib) { this.DeleteOne(lib.Id); }
        public void DeleteOne(Int32 Id) { this.DeleteOne(x => x.Id == Id); }
        public void DeleteSeveral(List<Int32> listOfIds) { this.DeleteSeveral(x => listOfIds.Contains(x.Id)); }
    }
}
