namespace Pronia.ViewModels.ProductViewModels
{
    public class ProductGetVM
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }

        public string CategoryName { get; set; } = null!;

        public string MainImagePath { get; set; } = null!;
        public string? HoverImagePath { get; set; }
        public List<string> TagNames { get; set; } = [];
        public List<string> ImagePaths { get; set; } = [];
    }

}
