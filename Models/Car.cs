using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarDealershipApplication.Models
{
    public abstract class Car
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Picture { get; set; }

        public string Type { get; set; }

        [Required]
        [MaxLength(500, ErrorMessage = "Brief descriptions must be under 500 characters.")]
        public string BriefDescription { get; set; }

        public string FullDescription { get; set; }

    }
}