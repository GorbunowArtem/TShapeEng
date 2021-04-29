using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using M1._12.SpaghettiCodeFix.Models;

namespace M1._12.SpaghettiCodeFix
{
	public partial class Filter : IMessageFilterHandler
	{
		private readonly IMessageFilterService _messageFilterService;

		public Filter(IMessageFilterService messageFilterService)
		{
			_messageFilterService = messageFilterService;
		}

		public async Task ApplySmokerFilters(List<MessageData> messageData, CancellationToken cancellationToken)
		{
			var enabledMessageFilters = await _messageFilterService.GetEnabledMessageFilters(cancellationToken);

			foreach (var filter in enabledMessageFilters)
			{
				if (filter.Element == ALL)
				{
					if (filter.Attribute == ALL)
					{
						if (filter.DataValue == ALL)
						{
							messageData.Clear();
						}
						else if (filter.DataValue.Contains(LIKE))
						{
							messageData.RemoveAll(d =>
								d.Value.Contains(RemoveLikeWildcard(filter.DataValue),
									StringComparison.OrdinalIgnoreCase));
						}
						else
						{
							messageData.RemoveAll(d =>
								string.Equals(d.Value, filter.DataValue, StringComparison.OrdinalIgnoreCase));
						}
					}
					else if (filter.Attribute.Contains(LIKE))
					{
						if (filter.DataValue == ALL)
						{
							messageData.RemoveAll(d => d.Attribute.Contains(RemoveLikeWildcard(filter.Attribute),
								StringComparison.OrdinalIgnoreCase));
						}
						else if (filter.DataValue.Contains(LIKE))
						{
							messageData.RemoveAll(d =>
								d.Attribute.Contains(RemoveLikeWildcard(filter.Attribute),
									StringComparison.OrdinalIgnoreCase)
								&& d.Value.Contains(RemoveLikeWildcard(filter.DataValue),
									StringComparison.OrdinalIgnoreCase));
						}
						else
						{
							messageData.RemoveAll(d =>
								d.Attribute.Contains(RemoveLikeWildcard(filter.Attribute),
									StringComparison.OrdinalIgnoreCase)
								&& string.Equals(d.Value, filter.DataValue, StringComparison.OrdinalIgnoreCase));
						}
					}
					else
					{
						if (filter.DataValue == ALL)
						{
							messageData.RemoveAll(d =>
								string.Equals(d.Attribute, filter.Attribute, StringComparison.OrdinalIgnoreCase));
						}
						else if (filter.DataValue.Contains(LIKE))
						{
							messageData.RemoveAll(d =>
								string.Equals(d.Attribute, filter.Attribute, StringComparison.OrdinalIgnoreCase)
								&& d.Value.Contains(RemoveLikeWildcard(filter.DataValue),
									StringComparison.OrdinalIgnoreCase));
						}
						else
						{
							messageData.RemoveAll(d =>
								string.Equals(d.Attribute, filter.Attribute, StringComparison.OrdinalIgnoreCase)
								&& string.Equals(d.Value, filter.DataValue, StringComparison.OrdinalIgnoreCase));
						}
					}
				}
				else if (filter.Element.Contains(LIKE))
				{
					if (filter.Attribute == ALL)
					{
						if (filter.DataValue == ALL)
						{
							messageData.RemoveAll(d =>
								d.Element.Contains(RemoveLikeWildcard(filter.Element),
									StringComparison.OrdinalIgnoreCase));
						}
						else if (filter.DataValue.Contains(LIKE))
						{
							messageData.RemoveAll(d =>
								d.Element.Contains(RemoveLikeWildcard(filter.Element),
									StringComparison.OrdinalIgnoreCase)
								&& d.Value.Contains(RemoveLikeWildcard(filter.DataValue),
									StringComparison.OrdinalIgnoreCase));
						}
						else
						{
							messageData.RemoveAll(d =>
								d.Element.Contains(RemoveLikeWildcard(filter.Element),
									StringComparison.OrdinalIgnoreCase)
								&& string.Equals(d.Value, filter.DataValue, StringComparison.OrdinalIgnoreCase));
						}
					}
					else if (filter.Attribute.Contains(LIKE))
					{
						if (filter.DataValue == ALL)
						{
							messageData.RemoveAll(d =>
								d.Element.Contains(RemoveLikeWildcard(filter.Element),
									StringComparison.OrdinalIgnoreCase)
								&& d.Attribute.Contains(RemoveLikeWildcard(filter.Attribute),
									StringComparison.OrdinalIgnoreCase));
						}
						else if (filter.DataValue.Contains(LIKE))
						{
							messageData.RemoveAll(d =>
								d.Element.Contains(RemoveLikeWildcard(filter.Element),
									StringComparison.OrdinalIgnoreCase)
								&& d.Attribute.Contains(RemoveLikeWildcard(filter.Attribute),
									StringComparison.OrdinalIgnoreCase)
								&& d.Value.Contains(RemoveLikeWildcard(filter.DataValue),
									StringComparison.OrdinalIgnoreCase));
						}
						else
						{
							messageData.RemoveAll(d =>
								d.Element.Contains(RemoveLikeWildcard(filter.Element),
									StringComparison.OrdinalIgnoreCase)
								&& d.Attribute.Contains(RemoveLikeWildcard(filter.Attribute),
									StringComparison.OrdinalIgnoreCase)
								&& string.Equals(d.Value, filter.DataValue, StringComparison.OrdinalIgnoreCase));
						}
					}
					else
					{
						if (filter.DataValue == ALL)
						{
							messageData.RemoveAll(d =>
								d.Element.Contains(RemoveLikeWildcard(filter.Element),
									StringComparison.OrdinalIgnoreCase)
								&& string.Equals(d.Attribute, filter.Attribute, StringComparison.OrdinalIgnoreCase));
						}
						else if (filter.DataValue.Contains(LIKE))
						{
							messageData.RemoveAll(d =>
								d.Element.Contains(RemoveLikeWildcard(filter.Element),
									StringComparison.OrdinalIgnoreCase)
								&& string.Equals(d.Attribute, filter.Attribute, StringComparison.OrdinalIgnoreCase)
								&& d.Value.Contains(RemoveLikeWildcard(filter.DataValue),
									StringComparison.OrdinalIgnoreCase));
						}
						else
						{
							messageData.RemoveAll(d =>
								d.Element.Contains(RemoveLikeWildcard(filter.Element),
									StringComparison.OrdinalIgnoreCase)
								&& string.Equals(d.Attribute, filter.Attribute, StringComparison.OrdinalIgnoreCase)
								&& string.Equals(d.Value, filter.DataValue, StringComparison.OrdinalIgnoreCase));
						}
					}
				}

				else
				{
					if (filter.Attribute == ALL)
					{
						if (filter.DataValue == ALL)
						{
							messageData.RemoveAll(d =>
								string.Equals(d.Element, filter.Element, StringComparison.OrdinalIgnoreCase));
						}
						else if (filter.DataValue.Contains(LIKE))
						{
							messageData.RemoveAll(d =>
								string.Equals(d.Element, filter.Element, StringComparison.OrdinalIgnoreCase)
								&& d.Value.Contains(RemoveLikeWildcard(filter.DataValue),
									StringComparison.OrdinalIgnoreCase));
						}
						else
						{
							messageData.RemoveAll(d =>
								string.Equals(d.Element, filter.Element, StringComparison.OrdinalIgnoreCase)
								&& string.Equals(d.Value, filter.DataValue, StringComparison.OrdinalIgnoreCase));
						}
					}
					else if (filter.Attribute.Contains(LIKE))
					{
						if (filter.DataValue == ALL)
						{
							messageData.RemoveAll(d =>
								string.Equals(d.Element, filter.Element, StringComparison.OrdinalIgnoreCase)
								&& d.Attribute.Contains(RemoveLikeWildcard(filter.Attribute),
									StringComparison.OrdinalIgnoreCase));
						}
						else if (filter.DataValue.Contains(LIKE))
						{
							messageData.RemoveAll(d =>
								string.Equals(d.Element, filter.Element, StringComparison.OrdinalIgnoreCase)
								&& d.Attribute.Contains(RemoveLikeWildcard(filter.Attribute),
									StringComparison.OrdinalIgnoreCase)
								&& d.Value.Contains(RemoveLikeWildcard(filter.DataValue),
									StringComparison.OrdinalIgnoreCase));
						}
						else
						{
							messageData.RemoveAll(d =>
								string.Equals(d.Element, filter.Element, StringComparison.OrdinalIgnoreCase)
								&& d.Attribute.Contains(RemoveLikeWildcard(filter.Attribute),
									StringComparison.OrdinalIgnoreCase)
								&& string.Equals(d.Value, filter.DataValue, StringComparison.OrdinalIgnoreCase));
						}
					}
					else
					{
						if (filter.DataValue == ALL)
						{
							messageData.RemoveAll(d =>
								string.Equals(d.Element, filter.Element, StringComparison.OrdinalIgnoreCase)
								&& string.Equals(d.Attribute, filter.Attribute, StringComparison.OrdinalIgnoreCase));
						}
						else if (filter.DataValue.Contains(LIKE))
						{
							messageData.RemoveAll(d =>
								string.Equals(d.Element, filter.Element, StringComparison.OrdinalIgnoreCase)
								&& string.Equals(d.Attribute, filter.Attribute, StringComparison.OrdinalIgnoreCase)
								&& d.Value.Contains(RemoveLikeWildcard(filter.DataValue),
									StringComparison.OrdinalIgnoreCase));
						}
						else
						{
							messageData.RemoveAll(d =>
								string.Equals(d.Element, filter.Element, StringComparison.OrdinalIgnoreCase)
								&& string.Equals(d.Attribute, filter.Attribute, StringComparison.OrdinalIgnoreCase)
								&& string.Equals(d.Value, filter.DataValue, StringComparison.OrdinalIgnoreCase));
						}
					}
				}
			}
		}
	}
}