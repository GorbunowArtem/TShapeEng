using System;
using StackExchange.Redis;

namespace RedisPublisher
{
	static class Program
	{
		private static void Main(string[] args)
		{
			var redis = ConnectionMultiplexer.Connect("localhost:6379");

			var sub = redis.GetSubscriber();

			sub.Publish("msg",  new RedisValue("Message sent from Publisher"));
		}
	}
}