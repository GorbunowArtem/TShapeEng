using System;

namespace M2._1.CSharpClosure
{
	public class CSharpClosure
	{
		private readonly Func<int, int> _increment = GetAFunc();

		public int StrangeIncrement(int val) =>
			_increment(val);

		private static Func<int, int> GetAFunc()
		{
			var freeVariable = 1;
			
			return toAdd =>
			{
				freeVariable += 1;
				return toAdd + freeVariable;
			};
		}
	}
}