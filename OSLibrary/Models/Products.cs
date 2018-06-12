namespace OSLibrary.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Products
    {
        [Key]
        public int Product_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Product_Name { get; set; }

        [Column(TypeName = "money")]
        [Range(0,100000,ErrorMessage ="價錢必須大於0")]
        public decimal UnitPrice { get; set; }

        [Required]
        [StringLength(50)]
        public string CategoryName { get; set; }

        [Required]
        [StringLength(10)]
        public string Gender { get; set; }

        [StringLength(10)]
        public string Online { get; set; }

        public string Comments { get; set; }

    }
}
