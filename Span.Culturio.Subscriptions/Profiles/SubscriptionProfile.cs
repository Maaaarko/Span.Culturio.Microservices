using AutoMapper;
using Span.Culturio.Core.Models.Subscriptions;
using Span.Culturio.Subscriptions.Data.Entities;

namespace Span.Culturio.Subscriptions.Profiles {
    public class SubscriptionProfile : Profile { 
        public SubscriptionProfile() {
            CreateMap<CreateSubscriptionDto, Subscription>();
            CreateMap<Subscription, SubscriptionDto>();
        }
    }
}
