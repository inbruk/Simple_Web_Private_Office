using System;
using System.Collections.Generic;

using DataAccessLayer;
using BusinessLogicLayer.Auxiliary;

namespace BusinessLogicLayer.CRUD
{
    internal class UserType : CRUDWithMappingBase<DTO.UserType, tblUserType, Int32>
    {
        public UserType() : base() { }
        protected override Int32 GetLastCreatedId() { return _lastCreatedItem.Id; }
        protected override void InsertIdInDTO(DTO.UserType dtoItem, Int32 idValue) { dtoItem.Id = idValue; }
        // ------------------------------
        public DTO.UserType ReadOne(Int32 Id) { return this.ReadOne(x => x.Id == Id); }
        public List<DTO.UserType> ReadSeveral(List<Int32> listOfIds) { return this.ReadSeveral(x => listOfIds.Contains(x.Id)); }
        public void UpdateOne(DTO.UserType lib) { this.UpdateOne(lib, x => x.Id == lib.Id); }
        public void DeleteOne(DTO.UserType lib) { this.DeleteOne(lib.Id); }
        public void DeleteOne(Int32 Id) { this.DeleteOne(x => x.Id == Id); }
        public void DeleteSeveral(List<Int32> listOfIds) { this.DeleteSeveral(x => listOfIds.Contains(x.Id)); }
    }
}
