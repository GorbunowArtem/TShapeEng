using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using M1._12.SpaghettiCodeFix.Models;

namespace M1._12.SpaghettiCodeFix
{
	public partial class Filter
	{
		private const string ALL = "*";
		private const string LIKE = "%";

		public async Task<IEnumerable<MessageData>> ApplyNormalFilters(
			IEnumerable<MessageData> messageData,
			CancellationToken cancellationToken)
		{
			var enabledMessageFilters = await _messageFilterService.GetEnabledMessageFilters(cancellationToken);

			foreach (var filter in enabledMessageFilters)
			{
				messageData = ApplyFilter(messageData, nameof(MessageData.Value), filter.DataValue);
				messageData = ApplyFilter(messageData, nameof(MessageData.Attribute), filter.Attribute);
				messageData = ApplyFilter(messageData, nameof(MessageData.Element), filter.Element);
			}

			return messageData;
		}

		private IEnumerable<MessageData> ApplyFilter(
			IEnumerable<MessageData> messageData,
			string propertyName,
			string filterElement)
		{
			if (filterElement.Contains(LIKE))
			{
				messageData = messageData.Where(d => A(d, propertyName).StartsWith(filterElement, StringComparison.OrdinalIgnoreCase));
			}
			else if (filterElement != ALL)
			{
				messageData = messageData.Where(d => d.GetType().GetProperty(propertyName)?.GetValue(d, null) is string value
					&& !value.StartsWith(filterElement, StringComparison.OrdinalIgnoreCase));
			}

			return messageData;
		}


		private string A(MessageData d, string propertyName)
		{
			return d.GetType().GetProperty(propertyName)?.GetValue(d, null) as string;
		}

		private static string RemoveLikeWildcard(string filter) =>
			filter.Trim('%');
	}
}