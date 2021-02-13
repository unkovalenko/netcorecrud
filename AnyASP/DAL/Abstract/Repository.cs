using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;


namespace AnyASP.Models
{
	public interface IControllerExt
	{
		// дополнения необходимые для  контроллеров этого приложения
		IWebHostEnvironment Enviroment { get; }

		IConfiguration Configuration { get;  }

		//IWebUsers WebUsers { get;  }
		ISQLToolsRepository SQLTools { get;  }
       
      //  string PIB(int peid);// Get personal PE_NAME  by id

        int GetIdFromCookies(string idName,HttpContext httpContext);

    }

   
	







}
