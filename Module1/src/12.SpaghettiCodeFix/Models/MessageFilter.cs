namespace Module1._12.SpaghettiCodeFix.Models
{
	public class MessageFilter
	{
		public int MessageSchemaId { get; set; }

		public string MessageSchema { get; set; }

		public int ProcessOrder { get; set; }

		public string Description { get; set; }

		public string Element { get; set; }

		public string Attribute { get; set; }

		public string DataValue { get; set; }

		public bool Enabled { get; set; }
	}
}