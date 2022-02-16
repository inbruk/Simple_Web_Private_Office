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
    public static class User
    {
        private readonly static CRUD.User cUser = null;
        private readonly static CRUD.Account cAccount = null;
        private readonly static CRUD.Service cService = null;
        private readonly static CRUD.ServiceUsage cServiceUsage = null;

        private readonly static IMapper mapper = null;

        static User()
        {
            cUser = new CRUD.User();
            cAccount = new CRUD.Account();
            cService = new CRUD.Service();
            cServiceUsage = new CRUD.ServiceUsage();

            var config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<prcServiceUsage_Result, DTO.ServiceUsageService>();
                }
            );
            mapper = config.CreateMapper();
        }

        public static DTO.User UserGetById(Int32 Id)
        {
            return cUser.ReadOne(Id);
        }

        public static void UserUpdate(DTO.User item)
        {
            cUser.UpdateOne(item);
        }

        public static DTO.Account AccountGetByUserId(Int32 userId)
        {
            Int32? accountId = cUser.ReadOne(userId).Account;
            if (accountId == null) return null;
            return cAccount.ReadOne( (Int32)accountId );
        }

        public static void AccountUpdate(DTO.Account item)
        {
            cAccount.UpdateOne(item);
        }

        public static List<DTO.ServiceUsageService> ServiceUsageGetByUserId(Int32 userId, bool onlyServicesUsedNow)
        {
            var ctx = Auxiliary.InternetUserAccountEntitiesHandler.Get();
            var listOfProxy = ctx.prcServiceUsage(userId, onlyServicesUsedNow).ToList();

            List<DTO.ServiceUsageService> result = 
                listOfProxy.Select( x => mapper.Map<prcServiceUsage_Result, DTO.ServiceUsageService>(x) ).ToList();

            return result;
        }

        public static bool BuyService(Int32 userId, Int32 servId, DateTime startDT, int monthCount )
        {
            var ctx = Auxiliary.InternetUserAccountEntitiesHandler.Get();
            bool IsServiceNowPurchasedAlready = true;

            if( IsServiceNowPurchasedAlready )
            {
                return false; // нельзя заказывать услугу, если такая же уже куплена и сейчас активна
            }
            else
            {
                DateTime endDT = startDT.AddMonths(monthCount);

                DTO.Service currServ = cService.ReadOne(servId);
                int total = currServ.Price * monthCount;

                DTO.ServiceUsage servUse = 
                    new DTO.ServiceUsage()
                    {
                        User = userId,
                        Service = servId,
                        BeginUsage = startDT,
                        EndUsage = endDT,
                        TotalPayment = total
                    };

                cServiceUsage.Create(servUse);

                return true; // успешный заказ услуги
            }
        }
    }
}
