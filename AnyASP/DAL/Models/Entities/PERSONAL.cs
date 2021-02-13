	namespace AnyASP.Models
	{
		using System;
		using System.Collections.Generic;
		using System.ComponentModel.DataAnnotations;
		using System.ComponentModel.DataAnnotations.Schema;

		//[Table("Firebird.PERSONAL")]
    public  class PERSONAL
    {       
    

        [Key]
        public int PE_ID { get; set; }

        

        [StringLength(75)]
        public string PE_NAME { get; set; }
        public string REM { get; set; }
        public int PO_ID { get; set; }



    }
}
