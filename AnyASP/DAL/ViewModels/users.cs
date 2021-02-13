using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;


using Microsoft.EntityFrameworkCore;
using AnyASP.DAL;


namespace AnyASP.Models
{
    public class Users_dal<TEntity, TVwEntity> : DBView<TEntity, TVwEntity> where TEntity : class where TVwEntity : class, new()
    {
        public Users_dal(IUnitOfWork UnitOfWork, IQueryable<TVwEntity> vwquery = null) : base(UnitOfWork, vwquery)
        {
            if (vwQuery == null)
            {
                CreateQuery();
            }
        }

        public override IQueryable CreateQuery()
        {
            Model1 model = (Model1)context;
            vwQuery = from p in model.USERS
                      join e in model.PERSONAL on p.PE_ID equals e.PE_ID
                      select new UserBigData
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
                      };
            return base.CreateQuery();
        }
    }



    // класс модель . Показывает  сджоинные из других сущностей- таблиц  поля
    public class UserBigData: IViewData<USERS> 
    {
        public int US_ID { get; set; }
        public int PE_ID { get; set; }
        public string US_NAME { get; set; }
        public string US_ENABLED { get; set; }
        public string DEL { get; set; }
        public string US_PREFIX { get; set; }
        public string US_ADMIN { get; set; }
        public string US_CATALOG { get; set; }
        public string US_CRNAME { get; set; }
        public string US_CRPW { get; set; }
        public short? US_LEVEL { get; set; }
        public string US_PW { get; set; }
        public string US_ROLE { get; set; }
        public string PE_NAME { get; set; }
		public string PE_REM { get; set; }		
        public int PO_ID { get; set; }
        public USERS Get()
        {
            return new USERS() 
            { 
              US_ADMIN = this.US_ADMIN,
              US_CATALOG = this.US_CATALOG,
              US_ID = this.US_ID,
              US_NAME = this.US_NAME,
              PE_ID = this.PE_ID,
              US_PW = this.US_PW,
              US_CRNAME = this.US_CRNAME,
              DEL = this.DEL
            };

        }
	}


    // класс модель . Для логина и аутентифиткации
    public class User
    {
        public string name { get; set; }
        public string role { get; set; }
        public string FIO { get; set; }// из таблицы персонал
        public int PE_ID { get; set; }
    }
    public class EWebUsers
	{
		public Model1 context;
		public IConfiguration Configuration { get; }
		public EWebUsers(IConfiguration configuration, Model1 _context)
		{
			context = _context;
			Configuration = configuration;
		}
		
		// список всех пользователей 
		public List<User> GetUsers()
		{
            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                string sql = string.Format("select us_name,us_role,pe_id,pe_name from getwebuser({0},{1})", "none", "none");

                command.CommandText = sql;
                context.Database.OpenConnection();
                List<User> lstuser = new List<User>();
                using (var result = command.ExecuteReader())
                {

                    if (result.HasRows)
                    {

                        while (result.Read())
                        {
                            lstuser.Add(new User
                            {
                                name = Convert.ToString(result["US_NAME"]),
                                role = Convert.ToString(result["US_ROLE"])
                               // PE_ID = 
                                
                            });
                        }
                    }
                    result.Close();
                    command.ExecuteReader().Close();
                }
                return lstuser;
            }
		}


        public User GetUser(string username)
        {
            if ((username == null)||(username==""))
			{
				return null;
			}
       
            using (var command = context.Database.GetDbConnection().CreateCommand())
            {

                string sql = string.Format("select us_name,us_role,pe_id,pe_name from getwebuser('{0}')", username);

                command.CommandText = sql;
                context.Database.OpenConnection();
                List<User> lstuser = new List<User>();
                using (var result = command.ExecuteReader())
                {

                    if (result.HasRows)
                    {

                        while (result.Read())
                        {
                            lstuser.Add(new User
                            {
                                name = Convert.ToString(result["US_NAME"]),
                                role = Convert.ToString(result["US_ROLE"]),
                                PE_ID = Convert.ToInt32(result["PE_ID"]),
                                FIO = Convert.ToString(result["PE_NAME"])
                            });
                        }
                    }
                    result.Close();
                    command.ExecuteReader().Close();
                }
                return lstuser.First();

            }
        }


        // пользователь по укзанному имени и паролю
        public User GetUser(string username, string userpasword)
        {
            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                string sql = string.Format("select us_name,us_role,pe_id,pe_name from getwebuser('{0}','{1}')", username, userpasword);

                command.CommandText = sql;
                context.Database.OpenConnection();
                List<User> lstuser = new List<User>();
                using (var result = command.ExecuteReader())
                {

                    if (result.HasRows)
                    {

                        while (result.Read())
                        {
                            lstuser.Add(new User
                            {
                                name = Convert.ToString(result["US_NAME"]),
                                role = Convert.ToString(result["US_ROLE"]),
                                PE_ID = Convert.ToInt32(result["PE_ID"]),
                                FIO = Convert.ToString(result["PE_NAME"])
                            });
                        }
                    }
                    result.Close();
                    command.ExecuteReader().Close();
                }
                if (lstuser.Count() == 0)
                {
                    return null;
                }
                return lstuser.First();
            }
        }

		public bool checkRole(HttpContext httpContext, string _role)
		{
			if (httpContext.User.Identity.Name != null)
			{
				return (GetUser(httpContext.User.Identity.Name).role == _role);
			}
			else
				return false;
		}


	}
}