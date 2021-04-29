using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using M1._12.SpaghettiCodeFix.Models;

namespace M1._12.SpaghettiCodeFix
{
	public interface IMessageFilterHandler
	{
		Task ApplySmokerFilters(List<MessageData> messageData, CancellationToken cancellationToken);
		
		Task<IEnumerable<MessageData>> ApplyNormalFilters(IEnumerable<MessageData> messageData, CancellationToken cancellationToken);
	}
}