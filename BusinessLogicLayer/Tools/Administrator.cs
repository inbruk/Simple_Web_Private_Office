using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using DataAccessLayer;
using AutoMapper;

namespace BusinessLogicLayer.Tools
{
    public static class Administrator
    {
        private readonly static CRUD.User cUser = null;
        private readonly static CRUD.Account cAccount = null;
        private readonly static CRUD.Service cService = null;
        private readonly static CRUD.ServiceUsage cServiceUsage = null;

        private readonly static IMapper mapper = null;

        static Administrator()
        {
            cUser = new CRUD.User();
            cAccount = new CRUD.Account();
            cService = new CRUD.Service();
            cServiceUsage = new CRUD.ServiceUsage();

            var config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<prcServiceUsage_Result, DTO.ServiceUsageService>();
                    cfg.CreateMap<prcUserAccountServiceUsage_Result, DTO.UserAccountUserType>();
                }
            );
            mapper = config.CreateMapper();
        }

        public static DTO.User AdministratorGetById(Int32 Id)
        {
            DTO.User result = cUser.ReadOne(Id);

            if (result.Type != (int)DTO.UserTypeEnum.Administrator)
                throw new Exception("Нельзя грузить в профиль администратора обычного пользователя");

            return result;
        }

        public static void AdministratorUpdate(DTO.User item)
        {
            if (item.Type != (int)DTO.UserTypeEnum.Administrator)
                throw new Exception("Нельзя менять в профиле администратора данные обычного пользователя");

            cUser.UpdateOne(item);
        }

        public static List<DTO.UserAccountUserType> ServiceUsageGetByTypeId(DTO.UserTypeEnum userTypeId, bool onlyServicesUsedNow)
        {
            var ctx = Auxiliary.InternetUserAccountEntitiesHandler.Get();
            var listOfProxy = ctx.prcUserAccountServiceUsage( (Int32) userTypeId, onlyServicesUsedNow).ToList();

            List<DTO.UserAccountUserType> result =
                listOfProxy.Select(x => mapper.Map<prcUserAccountServiceUsage_Result, DTO.UserAccountUserType>(x)).ToList();

            return result;
        }

    }
}
