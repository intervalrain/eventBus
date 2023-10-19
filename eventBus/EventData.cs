using System;
namespace eventBus
{
	public class EventData : IEventData
	{
		public DateTime EventTime { get; set; }
		public object EventSource { get; set; }

		public EventData()
		{
			EventTime = DateTime.Now;
		}
	}
}

