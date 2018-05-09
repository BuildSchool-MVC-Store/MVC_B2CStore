namespace OSLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product_Image
    {
        [Key]
        public int Product_Image_ID { get; set; }

        public int Product_ID { get; set; }

        [Column(TypeName = "image")]
        public byte[] Pictrue { get; set; }

        [StringLength(5)]
        public string Product_Image_Only { get; set; }

        public virtual Products Products { get; set; }
    }
}
