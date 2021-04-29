using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Module1._12.SpaghettiCodeFix;
using Module1._12.SpaghettiCodeFix.Models;
using Moq;
using Ploeh.AutoFixture;
using Xunit;

namespace Module1.Tests
{
	public class UnitTest1
	{
		private readonly Mock<IMessageFilterService> _msgFilterServiceStub;

		private readonly Fixture _fixture;

		public UnitTest1()
		{
			_fixture = new Fixture();
			_msgFilterServiceStub = new Mock<IMessageFilterService>();
		}

		[Theory]
		[InlineData("*", "*", "TestValue")]
		[InlineData("*", "*", "TestVal%")]
		[InlineData("*", "testAttribute", "*")]
		[InlineData("*", "testAttribute", "TestValue")]
		[InlineData("*", "testAttribute", "TestVal%")]
		[InlineData("*", "testAttri%", "*")]
		[InlineData("*", "testAttri%", "TestValue")]
		[InlineData("*", "testAttri%", "TestVal%")]
		[InlineData("TestElement", "*", "*")]
		[InlineData("TestElement", "*", "TestValue")]
		[InlineData("TestElement", "*", "TestVal%")]
		[InlineData("TestElement", "testAttribute", "*")]
		[InlineData("TestElement", "testAttribute", "TestValue")]
		[InlineData("TestElement", "testAttribute", "TestVal%")]
		[InlineData("TestElement", "testAttri%", "*")]
		[InlineData("TestElement", "testAttri%", "TestValue")]
		[InlineData("TestElement", "testAttri%", "TestVal%")]
		[InlineData("TestEle%", "*", "*")]
		[InlineData("TestEle%", "*", "TestValue")]
		[InlineData("TestEle%", "*", "TestVal%")]
		[InlineData("TestEle%", "testAttribute", "*")]
		[InlineData("TestEle%", "testAttribute", "TestValue")]
		[InlineData("TestEle%", "testAttribute", "TestVal%")]
		[InlineData("TestEle%", "testAttri%", "*")]
		[InlineData("TestEle%", "testAttri%", "TestValue")]
		[InlineData("TestEle%", "testAttri%", "TestVal%")]
		public async Task ShouldApplyValueFilteringForDeleteMode(
			string element,
			string attribute,
			string value)
		{
			_msgFilterServiceStub.Setup(mf => mf.GetEnabledMessageFilters(CancellationToken.None))
				.ReturnsAsync(new List<MessageFilter>
				{
					_fixture.Build<MessageFilter>()
						.With(f => f.MessageSchemaId, 0)
						.With(f => f.Element, element)
						.With(f => f.Attribute, attribute)
						.With(f => f.DataValue, value)
						.Create()
				});

			var messagesList = new List<LoadCamxMessageData>
			{
				_fixture.Build<LoadCamxMessageData>()
					.With(md => md.Element, "TestELEment")
					.With(md => md.Attribute, "TESTAttribute")
					.With(md => md.Value, "testVALue")
					.Create()
			};

			var handler = new Filter();

			handler.ApplyFilters(messagesList);

			messagesList.Should().BeEmpty();
		}
	}
}