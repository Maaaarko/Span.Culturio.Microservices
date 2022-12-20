namespace Span.Culturio.Core.Models.Subscriptions {
    public class CreateSubscriptionDto {
        public int UserId { get; set; }
        public int PackageId { get; set; }
        public string Name { get; set; }
    }
}
