using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AppSDK.interfaces;
using DbManager.DAL;
using DbManager.Models;
namespace AppSDK.Api
{
    public class SdkApiController<T, TContext> : ApiController , IGetNew<ApiController> 
        where T : class, IBaseEntity, new()
        where TContext : SdkContext, new()
    {
        private UnitOfWork<T, TContext> unitOfWork = new UnitOfWork<T, TContext>();
        // GET api/<controller>
        public IEnumerable<T> Get()
        {
            var models = unitOfWork.Repository.Get(i => i.DeletedDate == null);
            return models.ToList();
        }

        // GET api/<controller>/5
        public T Get(int id)
        {
            if (id < 0)
            {
                return null;
            }
            T model = unitOfWork.Repository.GetByID(id);
            if (model == null)
            {
                return null;
            }
            return model;
        }

        // POST api/<controller>
        public T Post([FromBody]T model)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Repository.Insert(model);
                unitOfWork.Save();
            }
            return model;
        }

        // PUT api/<controller>/5
        public T Put(int id, [FromBody]T model)
        {
            if (ModelState.IsValid)
            {
                model.Id = id;
                unitOfWork.Repository.Update(model);
                unitOfWork.Save();
            }
            return model;
        }

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            T model = unitOfWork.Repository.GetByID(id);
            if (model == null) return false;
            unitOfWork.Repository.Delete(id);
            unitOfWork.Save();
            return true;
        }

        public ApiController GetNew()
        {
            return new SdkApiController<T,TContext>();
        }

        object IGetNew.GetNew()
        {
            return new SdkApiController<T, TContext>();
        }
    }
}
