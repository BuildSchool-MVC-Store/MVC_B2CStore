namespace OSLibrary.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Orders
    {

        [Key]
        public int Order_ID { get; set; }

        public DateTime Order_Date { get; set; }
        public DateTime Shipping_Date { get; set; }

        [Required]
        [StringLength(50)]
        public string Account { get; set; }

        [Required]
        [StringLength(10)]
        public string Pay { get; set; }

        [StringLength(10)]
        public string Transport { get; set; }

        public int Order_Check { get; set; }

        [Column(TypeName = "money")]
        public decimal? Total { get; set; }

        [Column(TypeName = "money")]
        public decimal? TranMoney { get; set; }
    }
}
