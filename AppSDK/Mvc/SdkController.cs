using System.Linq;
using System.Net;
using System.Web.Mvc;
using AppSDK.interfaces;
using DbManager.DAL;
using DbManager.Models;
namespace AppSDK.mvc
{
    public class SdkController<T, TContext> : Controller , IGetNew<Controller> 
        where T : class, IBaseEntity, new()
        where TContext : SdkContext, new()
    {
        private UnitOfWork<T, TContext> unitOfWork = new UnitOfWork<T, TContext>();
        // GET: model
        public ActionResult Index()
        {
            var models = unitOfWork.Repository.Get(i => i.DeletedDate == null);
            return View(models.ToList());
        }
        // GET: model/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T model = unitOfWork.Repository.GetByID(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
        // GET: model/Create
        public ActionResult Create()
        {
            return View(new T());
        }

        // POST: model/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(T model)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Repository.Insert(model);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: model/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T model = unitOfWork.Repository.GetByID(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
        // POST: model/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(T model)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Repository.Update(model);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        // GET: model/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T model = unitOfWork.Repository.GetByID(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
        // POST: model/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            T model = unitOfWork.Repository.GetByID(id);
            unitOfWork.Repository.Delete(id);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }

        public Controller GetNew()
        {
            return new SdkController<T, TContext>();
        }

        object IGetNew.GetNew()
        {
            return new SdkController<T, TContext>();
        }
    }
}
