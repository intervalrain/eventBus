using System;
using System.Data;
namespace eventBus
{
	public sealed class DatabaseAccessEventData : EventData
	{
		public string DataCombinationClass { get; set; }
		public string ParameterType { get; set; }
		public string LoadLevel { get; set; }
		public string DataQuery { get; set; }
		public DataTable Model { get; set; }

		public DatabaseAccessEventData()
			: base()
		{
			DataCombinationClass = string.Empty;
			ParameterType = string.Empty;
			LoadLevel = string.Empty;
			DataQuery = string.Empty;
			Model = new DataTable("Test");
		}
	}
}

