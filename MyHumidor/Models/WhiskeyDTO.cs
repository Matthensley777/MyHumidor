using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyHumidor.Models
{
    public class WhiskeyDTO
    {
        public int WhiskeyID { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public int UserID { get; set; }
    }
}