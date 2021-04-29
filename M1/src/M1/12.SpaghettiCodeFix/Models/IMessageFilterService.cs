using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace M1._12.SpaghettiCodeFix.Models
{
	public interface IMessageFilterService
	{
		Task<List<MessageFilter>> GetEnabledMessageFilters(
			CancellationToken cancellationToken = default (CancellationToken));
	}
}