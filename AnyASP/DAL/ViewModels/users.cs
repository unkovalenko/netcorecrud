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
    public class Users_dal<TEntity, TVwEntity> : VwRepository<TEntity, TVwEntity> where TEntity : class where TVwEntity : class, new()
    {
        public Users_dal(DbContext context, IQueryable<TVwEntity> vwquery = null) : base(context, vwquery)
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
                      select new User
                      {
                          name = p.US_NAME,
                          role = p.US_ROLE,
                          FIO = e.PE_NAME
                      };
            return base.CreateQuery();
        }
    }



    // класс модель . Показывает  сджоинные из других сущностей- таблиц  поля
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
                //"select d.dt_id ,d.dtname,d.dt,d.dt_sizea,d.dt_sizeb,d.dt_tsizea,d.dt_tsizeb,d.dt_wght,d.triada,d.mix,d.dt_incount from DETAILTREETOREPORT({0}) d"
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