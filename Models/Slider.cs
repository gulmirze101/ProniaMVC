using Microsoft.EntityFrameworkCore;
using Pronia.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace Pronia.Models
{
    public class Slider:BaseEntity
    {
        
        [MaxLength(20)]
        [MinLength(3)]

        public string Title { get; set; } = null!;

        public string? Description { get; set; } = null!;
        [Required]
        public string ImagePath { get; set; } = null!;

        [Range(0,100)]
        [Precision(5,2)]
        public decimal OfferPercentage { get; set; }

    }
}
