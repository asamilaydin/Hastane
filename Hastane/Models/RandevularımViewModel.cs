using Hastane.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

public class RandevularımViewModel
{
    
        public Guid Id { get; set; }
        public string AnabilimdaliName { get; set; }
        public string DoktorName { get; set; }
        public string PoliklinikName { get; set; }
        public DateTime RandevuDate { get; set; }
    


}
