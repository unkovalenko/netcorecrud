using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;







namespace AnyASP.Models
{
    public class Catalog
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class CatalogComparer : IEqualityComparer<Catalog>
    {
        public bool Equals(Catalog x, Catalog y)
        {
            //First check if both object reference are equal then return true
            if (object.ReferenceEquals(x, y))
            {
                return true;
            }
            //If either one of the object refernce is null, return false
            if (object.ReferenceEquals(x, null) || object.ReferenceEquals(y, null))
            {
                return false;
            }
            //Comparing all the properties one by one
            return x.ID == y.ID && x.Name == y.Name;
        }
        public int GetHashCode(Catalog obj)
        {
            //If obj is null then return 0
            if (obj == null)
            {
                return 0;
            }
            //Get the ID hash code value
            int IDHashCode = obj.ID.GetHashCode();
            //Get the string HashCode Value
            //Check for null refernece exception
            int NameHashCode = obj.Name == null ? 0 : obj.Name.GetHashCode();
            return IDHashCode ^ NameHashCode;
        }
    }

   


    public class EControllerExt : IControllerExt
	{	
		private  IHostingEnvironment _enviroment;
		
		private IConfiguration _configuration { get; set; }
		
		//private AnyGridModel _model;
		
		public ISQLToolsRepository _sqlTools;
       
       
		public EControllerExt(IConfiguration configuration, IHostingEnvironment enviroment, 
			 ISQLToolsRepository sqltools)
		{
			_configuration = configuration;
			_enviroment = enviroment;

			
			_sqlTools = sqltools;
            
            
            _configuration = new ConfigurationBuilder()
                          .SetBasePath(Directory.GetCurrentDirectory())
                          .AddJsonFile("appsettings.json")
                          .Build();
		}
		public IHostingEnvironment Enviroment
		{
			get { return _enviroment; }
		}

		public IConfiguration Configuration
		{
			get
            {             
                return _configuration;
            }
		}

		
		public ISQLToolsRepository SQLTools
		{
			get	{return _sqlTools;}
		}
        
        public string PIB(int peid)
        {
            return SQLTools.GetString(String.Format("select pe_name from personal where pe_id={0}",peid));
        }
        private int GetOpenShiftID(int peid, DateTime date, int shift)
        {
            string dat = date.ToString(DateTimeManipulator.dtformatfb);
            return SQLTools.GetInt(string.Format("select t.ts_id from timesheet t where t.pe_id={0} and   t.ts_date='{1}' and  t.ts_shift={2} and not t.ts_start is null ",
               peid, dat, shift), 0);
        }
        
        public int GetIdFromCookies(string idName, HttpContext httpContext)
        {
            string sid = (httpContext.Request.Cookies[idName]);
            int id;
            if (Int32.TryParse(sid, out id))
            {
                id = Int32.Parse(sid);
                return id;
            }
            else
            {
                return Constants.IDUndefined;
            }
        }

    }

	public class ListToSelect
	{
		public int ID { get; set; }
		public int PRID { get; set; }
		public string NAME { get; set; }
		public string ISFREE { get; set; }
	}



    }

    

    



