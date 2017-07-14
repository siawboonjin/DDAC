using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class addShipViewModel
    {
        [Required]
        [Display(Name = "Ship ID")]
        public string ship_id { get; set; }
        [Required]
        [Display(Name = "Ship Number")]
        public string ship_num { get; set; }
        [Required]
        [Display(Name = "Ship Name")]
        public string ship_name { get; set; }
    }
}