namespace AnyASP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using AnyASP.DAL;

     

    // [Table("Firebird.USERS")]
    public partial class USERS
    {
       
        [Key]

        public int US_ID { get; set; }

        public int PE_ID { get; set; }

        [StringLength(8)]
        public string US_NAME { get; set; }

        [StringLength(1)]
        public string US_ENABLED { get; set; }

        [Required]
        [StringLength(1)]
        public string DEL { get; set; }

        [StringLength(5)]
        public string US_PREFIX { get; set; }

        [StringLength(1)]
        public string US_ADMIN { get; set; }

        [StringLength(1)]
        public string US_CATALOG { get; set; }

        [StringLength(32)]
        public string US_CRNAME { get; set; }

        [StringLength(32)]
        public string US_CRPW { get; set; }

        public short? US_LEVEL { get; set; }

        [StringLength(32)]
        public string US_PW { get; set; }

        [StringLength(32)]
        public string US_ROLE { get; set; }

    }

    // класс модель для отображения полей  сджоинные из нескольких таблиц 
    public class UserExtensionData : IViewExtensionData<USERS>
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
        public USERS GetEntity()
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
}
