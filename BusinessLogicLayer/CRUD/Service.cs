using System;
using System.Collections.Generic;

using DataAccessLayer;
using BusinessLogicLayer.Auxiliary;

namespace BusinessLogicLayer.CRUD
{
    internal class Service : CRUDWithMappingBase<DTO.Service, tblService, Int32>
    {
        public Service() : base() { }
        protected override Int32 GetLastCreatedId() { return _lastCreatedItem.Id; }
        protected override void InsertIdInDTO(DTO.Service dtoItem, Int32 idValue) { dtoItem.Id = idValue; }
        // ------------------------------
        public DTO.Service ReadOne(Int32 Id) { return this.ReadOne(x => x.Id == Id); }
        public List<DTO.Service> ReadSeveral(List<Int32> listOfIds) { return this.ReadSeveral(x => listOfIds.Contains(x.Id)); }
        public void UpdateOne(DTO.Service lib) { this.UpdateOne(lib, x => x.Id == lib.Id); }
        public void DeleteOne(DTO.Service lib) { this.DeleteOne(lib.Id); }
        public void DeleteOne(Int32 Id) { this.DeleteOne(x => x.Id == Id); }
        public void DeleteSeveral(List<Int32> listOfIds) { this.DeleteSeveral(x => listOfIds.Contains(x.Id)); }
    }
}
