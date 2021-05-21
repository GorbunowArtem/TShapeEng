using System;
using System.Threading.Tasks;
using M2._4.AsyncAndAwait;

namespace M2
{
	class Program
	{
		static async Task Main(string[] args)
		{
			var a = new AsyncAndAwaitExample(null);

			var result = await a.GetAllItems();
		}
	}
}