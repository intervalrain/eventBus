using System;
using System.Collections.Concurrent;
using System.Reflection;

namespace eventBus
{
	public class EventBus<TEventHandler> where TEventHandler : IEventHandler
	{
		public static EventBus<TEventHandler> Default => new EventBus<TEventHandler>();
		private readonly ConcurrentDictionary<Type, List<Type>> _eventAndHandlerMapping;

		public EventBus()
		{
			_eventAndHandlerMapping = new ConcurrentDictionary<Type, List<Type>>();
			MapEventToHandler();
		}

		private void MapEventToHandler()
		{
			Assembly? assembly = Assembly.GetEntryAssembly();
			if (assembly == null) return;

			foreach (var type in assembly.GetTypes())
			{
				if (typeof(IEventHandler).IsAssignableFrom(type))
				{
					Type? handlerInterface = type.GetInterface("IEventHandler`1");
					if (handlerInterface == null) continue;
					MethodInfo? methodInfo = type.GetMethod("GetEventType");
					

                    if (methodInfo != null)
					{
						object? obj = Activator.CreateInstance(type);
                        Type? eventDataType = (Type?)methodInfo.Invoke(obj, new object[] {});
						Type? eventDataInterface = handlerInterface.GetGenericArguments()[0];
						if (eventDataType == null || eventDataInterface == null) continue;
						if (eventDataInterface.IsAssignableFrom(eventDataType))
						{
							if (_eventAndHandlerMapping.ContainsKey(eventDataType))
							{
								List<Type> handlerTypes = _eventAndHandlerMapping[eventDataType];
								handlerTypes.Add(type);
								_eventAndHandlerMapping[eventDataType] = handlerTypes;
							}
							else
							{
								var handlerTypes = new List<Type> { type };
								_eventAndHandlerMapping[eventDataType] = handlerTypes;
							}
						}
					}
				}
			}
		}
	}
}

