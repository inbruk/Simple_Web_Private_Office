using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using DataAccessLayer;

namespace BusinessLogicLayer.Tools
{
    public static class Login
    {
        private readonly static CRUD.User cUser = null;

        static Login()
        {
            cUser = new CRUD.User();
        }

        public static DTO.User LogIn(String login, String password)
        {
            DTO.User result = cUser.ReadOne(login, password);

            if (result.Blocked)
                throw new Exception("Нельзя входить в кабинет под заблокированным пользователем");

            return result;
        }
    }
}
