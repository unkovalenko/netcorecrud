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
  
    // класс модель . Для логина и аутентифиткации
    public class UserAccountData
    {
        public string name { get; set; }
        public string role { get; set; }
        public string FIO { get; set; }// из таблицы персонал
        public int PE_ID { get; set; }
    }
    public class UsersAccount
	{
		public Model1 context;
		public IConfiguration Configuration { get; }
		public UsersAccount(IConfiguration configuration, Model1 _context)
		{
			context = _context;
			Configuration = configuration;
		}
		
		// список всех пользователей 
		public List<UserAccountData> GetUsers()
		{
            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                string sql = string.Format("select us_name,us_role,pe_id,pe_name from getwebuser({0},{1})", "none", "none");

                command.CommandText = sql;
                context.Database.OpenConnection();
                List<UserAccountData> lstuser = new List<UserAccountData>();
                using (var result = command.ExecuteReader())
                {

                    if (result.HasRows)
                    {

                        while (result.Read())
                        {
                            lstuser.Add(new UserAccountData
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


        public UserAccountData GetUser(string username)
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
                List<UserAccountData> lstuser = new List<UserAccountData>();
                using (var result = command.ExecuteReader())
                {

                    if (result.HasRows)
                    {

                        while (result.Read())
                        {
                            lstuser.Add(new UserAccountData
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
        public UserAccountData GetUser(string username, string userpasword)
        {
            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                string sql = string.Format("select us_name,us_role,pe_id,pe_name from getwebuser('{0}','{1}')", username, userpasword);

                command.CommandText = sql;
                context.Database.OpenConnection();
                List<UserAccountData> lstuser = new List<UserAccountData>();
                using (var result = command.ExecuteReader())
                {

                    if (result.HasRows)
                    {

                        while (result.Read())
                        {
                            lstuser.Add(new UserAccountData
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