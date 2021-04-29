using System;
using System.Collections.Generic;
using Module1._12.SpaghettiCodeFix.Models;

namespace Module1._12.SpaghettiCodeFix
{
	public partial class Filter : IMessageFilterHandler
	{
		public void ApplyFilters(List<LoadCamxMessageData> messageData)
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
								d.Value.StartsWith(RemoveLikeWildcard(filter.DataValue),
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
							messageData.RemoveAll(d => d.Attribute.StartsWith(RemoveLikeWildcard(filter.Attribute),
								StringComparison.OrdinalIgnoreCase));
						}
						else if (filter.DataValue.Contains(LIKE))
						{
							messageData.RemoveAll(d =>
								d.Attribute.StartsWith(RemoveLikeWildcard(filter.Attribute),
									StringComparison.OrdinalIgnoreCase)
								&& d.Value.StartsWith(RemoveLikeWildcard(filter.DataValue),
									StringComparison.OrdinalIgnoreCase));
						}
						else
						{
							messageData.RemoveAll(d =>
								d.Attribute.StartsWith(RemoveLikeWildcard(filter.Attribute),
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
								&& d.Value.StartsWith(RemoveLikeWildcard(filter.DataValue),
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
								d.Element.StartsWith(RemoveLikeWildcard(filter.Element),
									StringComparison.OrdinalIgnoreCase));
						}
						else if (filter.DataValue.Contains(LIKE))
						{
							messageData.RemoveAll(d =>
								d.Element.StartsWith(RemoveLikeWildcard(filter.Element),
									StringComparison.OrdinalIgnoreCase)
								&& d.Value.StartsWith(RemoveLikeWildcard(filter.DataValue),
									StringComparison.OrdinalIgnoreCase));
						}
						else
						{
							messageData.RemoveAll(d =>
								d.Element.StartsWith(RemoveLikeWildcard(filter.Element),
									StringComparison.OrdinalIgnoreCase)
								&& string.Equals(d.Value, filter.DataValue, StringComparison.OrdinalIgnoreCase));
						}
					}
					else if (filter.Attribute.Contains(LIKE))
					{
						if (filter.DataValue == ALL)
						{
							messageData.RemoveAll(d =>
								d.Element.StartsWith(RemoveLikeWildcard(filter.Element),
									StringComparison.OrdinalIgnoreCase)
								&& d.Attribute.StartsWith(RemoveLikeWildcard(filter.Attribute),
									StringComparison.OrdinalIgnoreCase));
						}
						else if (filter.DataValue.Contains(LIKE))
						{
							messageData.RemoveAll(d =>
								d.Element.StartsWith(RemoveLikeWildcard(filter.Element),
									StringComparison.OrdinalIgnoreCase)
								&& d.Attribute.StartsWith(RemoveLikeWildcard(filter.Attribute),
									StringComparison.OrdinalIgnoreCase)
								&& d.Value.StartsWith(RemoveLikeWildcard(filter.DataValue),
									StringComparison.OrdinalIgnoreCase));
						}
						else
						{
							messageData.RemoveAll(d =>
								d.Element.StartsWith(RemoveLikeWildcard(filter.Element),
									StringComparison.OrdinalIgnoreCase)
								&& d.Attribute.StartsWith(RemoveLikeWildcard(filter.Attribute),
									StringComparison.OrdinalIgnoreCase)
								&& string.Equals(d.Value, filter.DataValue, StringComparison.OrdinalIgnoreCase));
						}
					}
					else
					{
						if (filter.DataValue == ALL)
						{
							messageData.RemoveAll(d =>
								d.Element.StartsWith(RemoveLikeWildcard(filter.Element),
									StringComparison.OrdinalIgnoreCase)
								&& string.Equals(d.Attribute, filter.Attribute, StringComparison.OrdinalIgnoreCase));
						}
						else if (filter.DataValue.Contains(LIKE))
						{
							messageData.RemoveAll(d =>
								d.Element.StartsWith(RemoveLikeWildcard(filter.Element),
									StringComparison.OrdinalIgnoreCase)
								&& string.Equals(d.Attribute, filter.Attribute, StringComparison.OrdinalIgnoreCase)
								&& d.Value.StartsWith(RemoveLikeWildcard(filter.DataValue),
									StringComparison.OrdinalIgnoreCase));
						}
						else
						{
							messageData.RemoveAll(d =>
								d.Element.StartsWith(RemoveLikeWildcard(filter.Element),
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
								&& d.Value.StartsWith(RemoveLikeWildcard(filter.DataValue),
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
								&& d.Attribute.StartsWith(RemoveLikeWildcard(filter.Attribute),
									StringComparison.OrdinalIgnoreCase));
						}
						else if (filter.DataValue.Contains(LIKE))
						{
							messageData.RemoveAll(d =>
								string.Equals(d.Element, filter.Element, StringComparison.OrdinalIgnoreCase)
								&& d.Attribute.StartsWith(RemoveLikeWildcard(filter.Attribute),
									StringComparison.OrdinalIgnoreCase)
								&& d.Value.StartsWith(RemoveLikeWildcard(filter.DataValue),
									StringComparison.OrdinalIgnoreCase));
						}
						else
						{
							messageData.RemoveAll(d =>
								string.Equals(d.Element, filter.Element, StringComparison.OrdinalIgnoreCase)
								&& d.Attribute.StartsWith(RemoveLikeWildcard(filter.Attribute),
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
								&& d.Value.StartsWith(RemoveLikeWildcard(filter.DataValue),
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