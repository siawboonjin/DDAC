using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication3.Models
{
    public class editScheduleViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Departure")]
        public string departure { get; set; }
        [Required]
        [Display(Name = "Destination")]
        public string destination { get; set; }
        [Required]
        [Display(Name = "Weight")]
        public string weight { get; set; }
        [Required]
        [Display(Name = "Deliver Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public string deliver_date { get; set; }
        [Required]
        [Display(Name = "Ship ID")]
        public List<SelectListItem> listShipnum { get; set; }
        public string ship_num { get; set; }
        [Required]
        [Display(Name = "Status")]
        public string status { get; set; }
        public List<SelectListItem> listStatus { get; set; }
    }
}