using System;
using Microsoft.EntityFrameworkCore;
using AnyASP.Models;

namespace AnyASP.DAL
{

    public interface IUnitOfWork:IDisposable
    {
        void BeginTransaction();
        void SaveChanges();
        bool Commit();
        void Rollback();
        DbContext Context();
    }
    public  class EUnitOfWork : IUnitOfWork
    {
        private DbContext _context;
        public DbContext Context() 
        {
             return _context;           
        }
        public EUnitOfWork()
        {
            _context = new Model1();
        }

        protected Model1 model = new Model1();
        public void Save()
        {
            _context.SaveChanges();
            
        }

        public void Discard()
        {
            //_context.Database.;

        }

        public void BeginTransaction()
        {
            _context.Database.BeginTransaction();
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        public bool Commit()
        {
            try
            {
                _context.Database.CommitTransaction();
                return true;

            }
            catch 
            {
                return false;
            }
        }
        public void Rollback()
        {
            _context.Database.RollbackTransaction();
        }



        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
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