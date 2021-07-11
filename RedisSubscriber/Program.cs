using System;
using StackExchange.Redis;

namespace RedisSubscriber
{
	// docker run -p 6379:6379 redis
	static class Program
	{
		private static void Main(string[] args)
		{
			var redis = ConnectionMultiplexer.Connect("localhost:6379");

			var sub = redis.GetSubscriber();


			sub.Subscribe("msg", (channel, message) =>
			{
				Console.WriteLine((string)message);
			});

			Console.ReadKey();
		}
	}
}