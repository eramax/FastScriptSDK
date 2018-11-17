using DbManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DbManager.DAL
{
    public class UnitOfWork<T,TContext> : IDisposable 
        where T : class, IBaseEntity 
        where TContext : DbxContext , new()
    {
        private TContext context = new TContext();
        private GenericRepository<T> TempRepository;
        public GenericRepository<T> Repository
        {
            get
            {
                TempRepository =  TempRepository ?? new GenericRepository<T>(context);
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