namespace AnyASP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

     

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
}
