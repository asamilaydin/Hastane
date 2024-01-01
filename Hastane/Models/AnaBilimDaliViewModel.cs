using System;
using System.ComponentModel.DataAnnotations;
using Hastane.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hastane.Models
{
    public class AnaBilimDaliViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public Guid Id { get; set; }


    }
}

