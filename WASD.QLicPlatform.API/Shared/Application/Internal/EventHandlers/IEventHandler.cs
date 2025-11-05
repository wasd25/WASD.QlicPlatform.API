using Cortex.Mediator.Notifications;
using WASD.QLicPlatform.API.Shared.Domain.Model.Events;

namespace WASD.QLicPlatform.API.Shared.Application.Internal.EventHandlers;

public interface IEventHandler<in TEvent> : INotificationHandler<TEvent> where TEvent : IEvent
{
    
}