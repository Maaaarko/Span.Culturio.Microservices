using Span.Culturio.Core.Models.Packages;

namespace Span.Culturio.Subscriptions.Services {
    public interface IPackageService {
        Task<PackageDto> GetPackage(int packageId);
    }
}
