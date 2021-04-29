using System;
using System.Collections.Generic;
using System.Linq;
using Module1._12.SpaghettiCodeFix.Models;

namespace Module1._12.SpaghettiCodeFix
{
	public partial class Filter
	{
		public const string ALL = "*";
		public const string LIKE = "%";

		public void ApplyFilters(IEnumerable<LoadCamxMessageData> messageData)
		{
			var filters = new MessageFilter[]
			{
				new()
				{
					Element = ALL
				}
			};

			foreach (var filter in filters)
			{
				messageData = ApplyFilter(messageData, nameof(LoadCamxMessageData.Value), filter.DataValue);
				messageData = ApplyFilter(messageData, nameof(LoadCamxMessageData.Attribute), filter.Attribute);
				messageData = ApplyFilter(messageData, nameof(LoadCamxMessageData.Element), filter.Element);
			}
		}

		private IEnumerable<LoadCamxMessageData> ApplyFilter(IEnumerable<LoadCamxMessageData> messageData,
			string propertyName,
			string filterElement)
		{
			if (filterElement.Contains(LIKE))
			{
					messageData = messageData.Where(d => (d.GetType().GetProperty(propertyName).GetValue(d, null) as string)
						.StartsWith(filterElement, StringComparison.OrdinalIgnoreCase));
			}
			else if (filterElement != ALL)
			{
					messageData = messageData.Where(d => !string.Equals(
						d.GetType().GetProperty(propertyName).GetValue(d, null) as string,
						filterElement, StringComparison.OrdinalIgnoreCase));
			}

			return messageData;
		}


		
		private static string RemoveLikeWildcard(string filter)
		{
			return filter.Trim('%');
		}
	}
}