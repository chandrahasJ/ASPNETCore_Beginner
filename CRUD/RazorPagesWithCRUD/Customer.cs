﻿using System.ComponentModel.DataAnnotations;

namespace RazorPagesWithCRUD
{
    public class Customer
    {
        public int Id { get; set; }
        [Required,StringLength(30)]
        public string Name { get; set; }
    }
}