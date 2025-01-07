﻿using System.ComponentModel.DataAnnotations;

namespace MagicVilla_VillaApi.Models.Dto
{
    public class VillaDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string? Name { get; set; }

        public int sqft { get; set; }

        public int occupency { get; set; }

        public DateTime CreatedDate { get; set; }

        public string? ImageUrl { get; set; }
    }
}
