namespace Pronia.ViewModels.ServiceFeatureViewModels
{
    public class ServiceFeatureCreateVM
    {
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        [Required]
        public IFormFile Icon { get; set; } = null!;
    }

}
