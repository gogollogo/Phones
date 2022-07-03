﻿using System.ComponentModel.DataAnnotations;

namespace Phones.Entities
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
