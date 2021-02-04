using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;




namespace AnyASP.DAL
{


    public class VwRepository<TEntity, TVwEntity> : GenericDBRepository<TEntity> where TEntity : class where TVwEntity : class
    {
        protected IQueryable vwQuery;
        public VwRepository(DbContext context, IQueryable vwquery=null) : base(context)
        {
            vwQuery = vwquery;
        }
        
        // need override this method in real class
        public virtual  IQueryable CreateQuery()
        {
            /*
             Model1 model = (Model1)context;
            vwQuery = from p in model.PERSONAL
                      join l in model.PARTS on p.PR_ID equals l.PR_ID
                      join a in model.POST on p.PO_ID equals a.PO_ID
                      select  new PERSONALVW //   !!!!!!!!!!!!!! PERSONALVW=<TVwEntity> !!!!!!!!!!!!!!!!
                      {
                          PR_ID = p.PR_ID.Value,
                          PE_ID = p.PE_ID,
                          PE_NAME = p.PE_NAME,
                          PE_REM = p.REM,
                          PO_NAME = a.PO_NAME,
                          PR_NAME = l.PR_NAME
                      };
             */

            return vwQuery;
        }

         public IQueryable<TVwEntity> GetView()
        {
            return (IQueryable<TVwEntity>)vwQuery;
        }


        public virtual IQueryable<TVwEntity> GetView(
           Expression<Func<TVwEntity, bool>> filter = null,
           Func<IQueryable<TVwEntity>, IOrderedQueryable<TVwEntity>> orderBy = null,
           string includeProperties = "")
        {
            IQueryable<TVwEntity> query = (IQueryable < TVwEntity > )vwQuery;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }
            else
            {
                return query;
            }
        }



    }
}