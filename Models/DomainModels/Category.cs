﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyMovie.Models.DomainModels
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [DisplayName("Category Name")]
        public string CategoryName { get; set; }
        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage ="Display order must be between 1-100")]
        public int DisplayOrder { get; set; }
    }
}
