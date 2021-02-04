using System;
using Microsoft.EntityFrameworkCore;
using AnyASP.Models;

namespace AnyASP.DAL
{
    public abstract class UnitOfWork : IDisposable
    {
        protected DbContext context = new Model1();
        protected Model1 model = new Model1();
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