﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
        [MaxLength(500)]
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [MaxLength(50)]
        [Required]
        public string Category { get; set; }
    }
}
