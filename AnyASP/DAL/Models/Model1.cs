namespace AnyASP.Models
{

	using Microsoft.EntityFrameworkCore;
	using Microsoft.Extensions.Configuration;
	using System.Collections.Generic;
	using System.IO;
    



    public class Model1 : DbContext
	{
        public virtual DbSet<USERS> USERS { get; set; }
        public virtual DbSet<PERSONAL> PERSONAL { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		 {
			var Configuration = new ConfigurationBuilder()
							.SetBasePath(Directory.GetCurrentDirectory())
							.AddJsonFile("appsettings.json")
							.Build();

			optionsBuilder.UseFirebird(Configuration["ConnectionString"]);
		}
	}
	

}
 
    


