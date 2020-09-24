using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ABCFOODCATERING.Models
{
    [Table("ORDERTABLE")]
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        public string FoodDescription { get; set; }
        public string DeliveryAddress { get; set; }
        public string DeliveryDate { get; set; }
        public string DeliveryTime { get; set; }
        public string EmailAddress { get; set; }
        public string ContactNumber { get; set; }
        public string OrderStatus { get; set; }
    }
}