using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSLibrary.ViewModels
{
   public class BackStageOrdersModel
    {
        public int Order_ID { get; set; }
        public string Account { get; set; }
        public DateTime Order_Date { get; set; }
        public string Order_Check { get; set; }  
        public DateTime Shipment_Date { get; set; } //出貨
        public decimal? Total { get; set; }
        public string pay { get; set; } 
        public string Transport { get; set; } 


    }
}
