using System;
using System.Collections.Generic;

using DataAccessLayer;
using BusinessLogicLayer.Auxiliary;

namespace BusinessLogicLayer.CRUD
{
    internal class Account : CRUDWithMappingBase< DTO.Account, tblAccount, Int32 >
    {
        public Account() : base() { }
        protected override Int32 GetLastCreatedId() { return _lastCreatedItem.Id; }
        protected override void InsertIdInDTO( DTO.Account dtoItem, Int32 idValue ) { dtoItem.Id = idValue; }
    // ------------------------------
        public DTO.Account ReadOne(Int32 Id) { return this.ReadOne( x => x.Id == Id ); }
        public List<DTO.Account> ReadSeveral(List<Int32> listOfIds) { return this.ReadSeveral( x => listOfIds.Contains(x.Id)); }
        public void UpdateOne(DTO.Account lib) { this.UpdateOne(lib, x => x.Id == lib.Id); }
        public void DeleteOne(DTO.Account lib) { this.DeleteOne(lib.Id); }
        public void DeleteOne(Int32 Id) { this.DeleteOne(x => x.Id == Id); }
        public void DeleteSeveral(List<Int32> listOfIds) { this.DeleteSeveral( x => listOfIds.Contains(x.Id)); }
    }
}
