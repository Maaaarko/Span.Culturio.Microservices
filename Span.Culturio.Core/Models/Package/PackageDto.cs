namespace Span.Culturio.Core.Models.Packages {
    public class PackageDto {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<PackageItemDto> CultureObjects { get; set; }
        public int ValidDays { get; set; }
    }
}
