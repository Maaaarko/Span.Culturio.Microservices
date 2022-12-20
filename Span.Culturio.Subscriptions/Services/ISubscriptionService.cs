using Span.Culturio.Core.Models.Packages;
using Span.Culturio.Core.Models.Subscriptions;
using Span.Culturio.Core.Models.Visits;

namespace Span.Culturio.Subscriptions.Services {
    public interface ISubscriptionService {
        Task<SubscriptionDto> CreateAsync(CreateSubscriptionDto createSubscriptionDto);
        Task<IEnumerable<SubscriptionDto>> GetAsync(int userId);
        Task<string> TrackVisit(TrackVisitDto trackVisitDto);
        Task<string> Activate(ActivateDto activateDto, int validDays);
        Task<string> CreateVisit(int subscriptionId, List<PackageItemDto> packageItemsDto);
        Task<SubscriptionDto> GetById(int subscriptionId);
    }
}
