using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Html;


namespace AnyASP.Models
{
	public interface IControllerExt
	{
		// дополнения необходимые для  контроллеров этого приложения
		IHostingEnvironment Enviroment { get; }

		IConfiguration Configuration { get;  }

		//IWebUsers WebUsers { get;  }
		ISQLToolsRepository SQLTools { get;  }
       
        string PIB(int peid);// Get personal PE_NAME  by id

        int GetIdFromCookies(string idName,HttpContext httpContext);

    }

   
	







}
