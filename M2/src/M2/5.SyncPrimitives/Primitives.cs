using System;
using System.Collections.Generic;
using System.Threading;

namespace M2._5.SyncPrimitives
{
	public class Primitives
	{
		private readonly List<int> _syncList = new();

		public void MonitorPrimitive()
		{
			// Basic example
			Monitor.Enter(_syncList);

			try
			{
				_syncList.Add(1);
			}
			finally
			{
				Monitor.Exit(_syncList);
			}


			// Syntactic sugar
			lock (_syncList)
			{
				_syncList.Add(1);
			}

			// Safe usage to avoid leaked lock
			var lockTaken = false;
			
			try
			{
				Monitor.Enter(_syncList, ref lockTaken);
			}
			finally
			{
				if (lockTaken)
				{
					Monitor.Exit(_syncList);
				}
			}
		}

		// Mutex
		public void MutexPrimitive()
		{
			var mut = new Mutex(false,Guid.NewGuid().ToString());

			mut.WaitOne();
			// mut.WaitOne(1000);
			
			_syncList.Add(2);

			mut.ReleaseMutex();
		}
	}
}