using System.Net.Http;
using System.Threading.Tasks;

namespace M2._4.AsyncAndAwait
{
	public class AsyncAndAwaitExample
	{
		public async Task Search()
		{
			var client = new HttpClient();

			var response = await client.GetStringAsync("https://google.com")
				.ConfigureAwait(false);
			
			// do some extra...
		}
		
		
		public async Task<dynamic> GetAllItems()
		{
			return await _repository.GetAll();
		}

		private readonly IRepository _repository;

		public AsyncAndAwaitExample(IRepository repository)
		{
			_repository = repository;
		}
	}
	
	public interface IRepository
	{
		Task<dynamic> GetAll();
	}
}