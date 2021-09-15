using FluentAssertions;
using Xunit;

namespace M2.Tests._1.CSharpClosure
{
	public class CSharpClosureTests
	{
		private readonly M2._1.CSharpClosure.CSharpClosure _sut;

		public CSharpClosureTests()
		{
			_sut = new M2._1.CSharpClosure.CSharpClosure();
		}
		
		[Fact]
		public void ShouldCaptureFreeVariable()
		{
			var result = _sut.StrangeIncrement(5);

			result.Should().Be(7);
		}

		[Fact]
		public void ShouldCaptureFreeVariableWithDoubleCall()
		{
			_sut.StrangeIncrement(1);
			var result = _sut.StrangeIncrement(7);

			result.Should().Be(10);
		}

		[Theory]
		[InlineData("")]
		[InlineData("    ")]
		[InlineData(null)]
		public void S(string s)
		{
			var result = string.IsNullOrWhiteSpace(s);

			result.Should().BeTrue();
		}
	}
}