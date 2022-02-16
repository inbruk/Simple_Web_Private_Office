using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

namespace BusinessLogicLayer.Auxiliary
{
    internal abstract class CRUDWithMappingBase<DTO, TBL, TID>
         where DTO : class
         where TBL : class
    {
        private readonly IMapper mapper = null;
        public CRUDWithMappingBase()
        {
            var config = new MapperConfiguration(
                cfg => 
                {
                    cfg.CreateMap<TBL, DTO>();
                    cfg.CreateMap<DTO, TBL>();
                }
            );

            mapper = config.CreateMapper();
        }

        protected TBL _lastCreatedItem = null;

        // получение значения автоинкрементного поля Id при создании одной записи 
        protected abstract TID GetLastCreatedId();

        // запись значения Id в DTO объект
        protected abstract void InsertIdInDTO(DTO dtoItem, TID idValue);

        protected List<DTO> ConvertTBL2DTO(List<TBL> listOfProxy)
        {
            List<DTO> result = new List<DTO>();
            foreach (TBL currProxy in listOfProxy)
            {
                DTO resDTO = mapper.Map<TBL, DTO>(currProxy);
                result.Add(resDTO);
            }
            return result;
        }

        public void Create(DTO newDTO)
        {
            _lastCreatedItem = mapper.Map<DTO, TBL>(newDTO);

            try
            {
                var ctx = InternetUserAccountEntitiesHandler.Get();
                ctx.Set<TBL>().Add(_lastCreatedItem);
                ctx.SaveChanges();
            }
            catch (DbEntityValidationException dbex)
            {
                var errs = dbex.EntityValidationErrors;
                throw dbex; // ловим для поиска ошибки при отладке, но прокидываем, чтобы не скрыть
            }

            TID lastCreatedId = GetLastCreatedId();
            InsertIdInDTO(newDTO, lastCreatedId);
        }

        public void CreateSeveral(List<DTO> newDTOList)
        {
            try
            {
                foreach (DTO currItem in newDTOList)
                {
                    Create(currItem);
                }
            }
            catch (DbEntityValidationException dbex)
            {
                var errs = dbex.EntityValidationErrors;
                throw dbex; // ловим для поиска ошибки при отладке, но прокидываем, чтобы не скрыть
            }
        }

        public void CreateSeveralFastWithoutIdsAquering(List<DTO> newDTOList)
        {
            try
            {
                var ctx = InternetUserAccountEntitiesHandler.Get();
                foreach (DTO currItem in newDTOList)
                {
                    _lastCreatedItem = mapper.Map<DTO, TBL>(currItem);
                    ctx.Set<TBL>().Add(_lastCreatedItem);
                }
                ctx.SaveChanges();
            }
            catch (DbEntityValidationException dbex)
            {
                var errs = dbex.EntityValidationErrors;
                throw dbex; // ловим для поиска ошибки при отладке, но прокидываем, чтобы не скрыть
            }
        }

        public List<DTO> ReadAll()
        {
            List<TBL> listOfProxy = InternetUserAccountEntitiesHandler.Get().Set<TBL>().ToList();
            List<DTO> result = ConvertTBL2DTO(listOfProxy);
            return result;
        }

        protected List<DTO> ReadSeveral(Expression<Func<TBL, bool>> predicate)
        {
            List<TBL> listOfProxy = InternetUserAccountEntitiesHandler.Get().
                     Set<TBL>().Where(predicate).ToList();

            List<DTO> result = ConvertTBL2DTO(listOfProxy);
            return result;
        }

        protected DTO ReadOne(Expression<Func<TBL, bool>> predicate)
        {
            TBL dataProxyObject = InternetUserAccountEntitiesHandler.Get().Set<TBL>().SingleOrDefault(predicate);

            DTO resDTO = mapper.Map<TBL, DTO>(dataProxyObject);
            return resDTO;
        }

        protected void UpdateOne(DTO upDTO, Expression<Func<TBL, bool>> predicate)
        {
            var ctx = InternetUserAccountEntitiesHandler.Get();

            TBL dataProxyObject = ctx.Set<TBL>().SingleOrDefault(predicate);
            mapper.Map<DTO, TBL>(upDTO, dataProxyObject);
            ctx.SaveChanges();
        }

        protected void DeleteOne(Expression<Func<TBL, bool>> predicate)
        {
            var ctx = InternetUserAccountEntitiesHandler.Get();
            TBL dataProxyObject = ctx.Set<TBL>().SingleOrDefault(predicate);
            ctx.Set<TBL>().Remove(dataProxyObject);
            ctx.SaveChanges();
        }
        protected void DeleteSeveral(Expression<Func<TBL, bool>> predicate)
        {
            var ctx = InternetUserAccountEntitiesHandler.Get();
            List<TBL> listOfProxy = ctx.Set<TBL>().Where(predicate).ToList();
            foreach (TBL currProxy in listOfProxy)
            {
                ctx.Set<TBL>().Remove(currProxy);
            }
            ctx.SaveChanges();
        }
    }
}
