using System;
namespace eventBus
{
	public abstract class RetrievalEventHandler : IEventHandler<EventData>
	{
		public abstract void FireEvent(EventData eventData);
		public abstract Type GetEventType();
	}
}

