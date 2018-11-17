using DbManager.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace DbManager.DAL
{
    public class UnitOfWork<T,TContext> : IDisposable 
        where T : class, IBaseEntity 
        where TContext : SdkContext, new()
    {
        private TContext context = new TContext();
        private Repository<T> TempRepository;
        public Repository<T> Repository
        {
            get
            {
                TempRepository =  TempRepository ?? new Repository<T>(context);
                return TempRepository;
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}