﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessApp.Data.Models
{
    public class Exercise
    {
        [Key]
        public int? Id { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        [StringLength(500)]
        public string Name { get; set; }

        public ushort Order { get; set; }
    }
}
