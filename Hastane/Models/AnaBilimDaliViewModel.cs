using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hastane.Models
{
    public class AnaBilimDaliViewModel
    {
        [Required]
        public string Name { get; set; }
        public List<SelectListItem> AnaBilimDallari { get; set; }
        public int SelectedAnaBilimDaliId { get; set; }

    }
}

