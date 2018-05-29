﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyHumidor.Models
{
    public class CigarDTO
    {
        public int CigarID { get; set; }
        public string Brand { get; set; }
        public string Series { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public DateTime DatePurchased { get; set; }
        public int UserID { get; set; }
    }
}