using System;
namespace eventBus
{
	public interface IEventData
	{
		DateTime EventTime { get; set; }
		object EventSource { get; set; }
	}
}

