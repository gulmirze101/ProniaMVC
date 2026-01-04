using Pronia.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace Pronia.Models
{
    public class ServiceFeature:BaseEntity
    {
    
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        [Required]
        public string IconPath { get; set; } = null!;
    }
}
