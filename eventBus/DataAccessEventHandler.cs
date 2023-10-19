using System;
namespace eventBus
{
	public class DataAccessEventHandler : RetrievalEventHandler
	{
		public override void FireEvent(EventData eventData)
		{
			DatabaseAccessEventData @event = eventData as DatabaseAccessEventData;
		}
        public override Type GetEventType()
        {
			return typeof(DatabaseAccessEventData);
        }
    }
}

