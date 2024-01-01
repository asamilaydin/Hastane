using Hastane.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

public class RandevuAlViewModel
{
    [Required(ErrorMessage = "This place is required.")]
    public Guid SelectedAnaBilimDaliId { get; set; }
    [Required(ErrorMessage = "This place is required.")]
    public SelectList AnaBilimDallari { get; set; }
    [Required(ErrorMessage = "This place is required.")]
    public SelectList Poliklinikler { get; set; }
    [Required(ErrorMessage = "This place is required.")]
    public Guid SelectedPoliklinikId { get; set; }
    [Required(ErrorMessage = "This place is required.")]
    public SelectList Doktorlar { get; set; }
    [Required(ErrorMessage = "This place is required.")]
    public DateTime RandevuTarihi { get; set; }
    [Required(ErrorMessage = "This place is required.")]
    public Guid SelectedDoktorId { get; set; }
    [Required(ErrorMessage = "This place is required.")]
    public Guid UserId { get; set; }
   

}
