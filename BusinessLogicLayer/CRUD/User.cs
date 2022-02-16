using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


using DataAccessLayer;
using BusinessLogicLayer.Auxiliary;

namespace BusinessLogicLayer.CRUD
{
    internal class User : CRUDWithMappingBase< DTO.User, tblUser, Int32 >
    {
        public User() : base() { }
        protected override Int32 GetLastCreatedId() { return _lastCreatedItem.Id; }
        protected override void InsertIdInDTO(DTO.User dtoItem, Int32 idValue) { dtoItem.Id = idValue; }
        // ------------------------------
        public DTO.User ReadOne(Int32 Id) { return this.ReadOne(x => x.Id == Id); }
        public DTO.User ReadOne(String login, String password) { return this.ReadOne(x => x.Login==login && x.Password==password); }
        public List<DTO.User> ReadSeveral(List<Int32> listOfIds) { return this.ReadSeveral(x => listOfIds.Contains(x.Id)); }
        public void UpdateOne(DTO.User lib) { this.UpdateOne(lib, x => x.Id == lib.Id); }
        public void DeleteOne(DTO.User lib) { this.DeleteOne(lib.Id); }
        public void DeleteOne(Int32 Id) { this.DeleteOne(x => x.Id == Id); }
        public void DeleteSeveral(List<Int32> listOfIds) { this.DeleteSeveral(x => listOfIds.Contains(x.Id)); }
    }
}
