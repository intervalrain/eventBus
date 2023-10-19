using System;
namespace eventBus
{
	public interface IEventHandler<TEventData> : IEventHandler where TEventData : IEventData
	{
		Type GetEventType();
		void FireEvent(TEventData @event);
	}
}

