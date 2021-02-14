using System;
using System.Linq;
using AnyASP.Models;

namespace AnyASP.DAL
{   
    public  class EUnitOfWork : IDisposable
    {
        private Model1 _context = new Model1();
        private DBView<USERS, UserExtensionData> viewUsers;
        private DBTable<USERS> tblUsers;


        #region DATASET 

       

        public DBView<USERS, UserExtensionData> ViewUsers
        {
            get
            {
                if (this.viewUsers == null)
                {
                    this.viewUsers = new DBView<USERS, UserExtensionData>(this._context, from p in _context.USERS
                                                                                       join e in _context.PERSONAL on p.PE_ID equals e.PE_ID
                                                                                       select new UserExtensionData
                                                                                       {
                                                                                           US_NAME = p.US_NAME,
                                                                                           US_ADMIN = p.US_ADMIN,
                                                                                           US_CATALOG = p.US_CATALOG,
                                                                                           US_CRNAME = p.US_CRNAME,
                                                                                           US_CRPW = p.US_CRPW,
                                                                                           US_ENABLED = p.US_ENABLED,
                                                                                           US_ID = p.US_ID,
                                                                                           US_LEVEL = p.US_LEVEL,
                                                                                           US_PREFIX = p.US_PREFIX,
                                                                                           US_PW = p.US_PW,
                                                                                           US_ROLE = p.US_ROLE,
                                                                                           DEL = p.DEL,
                                                                                           PE_ID = p.PE_ID,
                                                                                           PE_NAME = e.PE_NAME,
                                                                                           PE_REM = e.REM,
                                                                                           PO_ID = e.PO_ID
                                                                                       });
                }
                return viewUsers;
            }
        }

        public IQueryable<UserExtensionData> ViewUsersPost(int postid)
        {           
                return ViewUsers.GetView(f => f.PO_ID == postid);         
        }

        public DBTable<USERS> TblUsers
        {
            get
            {
                if (this.tblUsers == null)
                {
                    this.tblUsers = new DBTable<USERS>(this._context);
                }
                return tblUsers;
            }
        }
        #endregion
        #region MANIPULATION
        public void Save()
        {
            _context.SaveChanges();
            
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
        #endregion
        #region DISPOSE
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
        #endregion
    }
}