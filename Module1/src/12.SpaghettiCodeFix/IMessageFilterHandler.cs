using System.Collections.Generic;
using System.Threading.Tasks;
using Module1._12.SpaghettiCodeFix.Models;

namespace Module1._12.SpaghettiCodeFix
{
	public interface IMessageFilterHandler
	{
		public void ApplyFilters(List<LoadCamxMessageData> messageData);
	}
}