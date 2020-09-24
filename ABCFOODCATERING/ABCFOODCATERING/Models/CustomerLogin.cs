﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ABCFOODCATERING.Models
{
    [Table("CUSTOMERLOGINTABLE")]
    public class CustomerLogin
    {
        [Key]
        public int CustomerID { get; set; }
        public string Password { get; set; }
    }
}