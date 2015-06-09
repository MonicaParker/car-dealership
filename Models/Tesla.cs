using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarDealershipApplication.Models
{
    public class Tesla : Car
    {
        [Required]
        public int Range { get; set; }

        [Required]
        public int ChargeTime { get; set; }
    }
}