using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarDealershipApplication.Models
{
    public class RollsRoyce : Car
    {

        [Required]
        public int GasMileage { get; set; }
    }
}