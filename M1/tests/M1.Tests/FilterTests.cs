using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using M1._12.SpaghettiCodeFix;
using M1._12.SpaghettiCodeFix.Models;
using Moq;
using Xunit;

namespace M1.Tests
{
	public class FilterTests
	{
		private readonly Mock<IMessageFilterService> _msgFilterServiceStub;

		private readonly Fixture _fixture;

		public FilterTests()
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
		[InlineData("*", "%stAttri%", "*")]
		[InlineData("*", "%stAttri%", "TestValue")]
		[InlineData("*", "%stAttri%", "TestVal%")]
		[InlineData("TestElement", "*", "*")]
		[InlineData("TestElement", "*", "TestValue")]
		[InlineData("TestElement", "*", "TestVal%")]
		[InlineData("TestElement", "%stAttribute", "*")]
		[InlineData("TestElement", "%stAttribute", "TestValue")]
		[InlineData("TestElement", "%stAttribute", "TestVal%")]
		[InlineData("TestElement", "%stAttri%", "*")]
		[InlineData("TestElement", "%stAttri%", "TestValue")]
		[InlineData("TestElement", "testAttri%", "TestVal%")]
		[InlineData("%TestEle%", "*", "*")]
		[InlineData("%TestEle%", "*", "TestValue")]
		[InlineData("%TestEle%", "*", "TestVal%")]
		[InlineData("%TestEle%", "%stAttribute", "*")]
		[InlineData("%TestEle%", "%stAttribute", "TestValue")]
		[InlineData("%TestEle%", "%stAttribute", "TestVal%")]
		[InlineData("%TestEle%", "%stAttri%", "*")]
		[InlineData("%TestEle%", "%stAttri%", "TestValue")]
		[InlineData("%TestEle%", "%stAttri%", "TestVal%")]
		public async Task ShouldApplyValueFilteringForSmokerFilter(
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
					   
			var messagesList = new List<MessageData>
			{
				_fixture.Build<MessageData>()
					.With(md => md.Element, "TestELEment")
					.With(md => md.Attribute, "TESTAttribute")
					.With(md => md.Value, "testVALue")
					.Create()
			};

			var filter = new Filter(_msgFilterServiceStub.Object);

			await filter.ApplySmokerFilters(messagesList, default);

			messagesList.Should().BeEmpty();
		}

		[Theory]
		[InlineData("*", "*", "TestValue")]
		[InlineData("*", "*", "TestVal%")]
		[InlineData("*", "testAttribute", "*")]
		[InlineData("*", "testAttribute", "TestValue")]
		[InlineData("*", "testAttribute", "TestVal%")]
		[InlineData("*", "%stAttri%", "*")]
		[InlineData("*", "%stAttri%", "TestValue")]
		[InlineData("*", "%stAttri%", "TestVal%")]
		[InlineData("TestElement", "*", "*")]
		[InlineData("TestElement", "*", "TestValue")]
		[InlineData("TestElement", "*", "TestVal%")]
		[InlineData("TestElement", "%stAttribute", "*")]
		[InlineData("TestElement", "%stAttribute", "TestValue")]
		[InlineData("TestElement", "%stAttribute", "TestVal%")]
		[InlineData("TestElement", "%stAttri%", "*")]
		[InlineData("TestElement", "%stAttri%", "TestValue")]
		[InlineData("TestElement", "testAttri%", "TestVal%")]
		[InlineData("%TestEle%", "*", "*")]
		[InlineData("%TestEle%", "*", "TestValue")]
		[InlineData("%TestEle%", "*", "TestVal%")]
		[InlineData("%TestEle%", "%stAttribute", "*")]
		[InlineData("%TestEle%", "%stAttribute", "TestValue")]
		[InlineData("%TestEle%", "%stAttribute", "TestVal%")]
		[InlineData("%TestEle%", "%stAttri%", "*")]
		[InlineData("%TestEle%", "%stAttri%", "TestValue")]
		[InlineData("%TestEle%", "%stAttri%", "TestVal%")]
		public async Task ShouldApplyValueFilteringForNormalFilter(
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

			var messagesList = new List<MessageData>
			{
				_fixture.Build<MessageData>()
					.With(md => md.Element, "TestELEment")
					.With(md => md.Attribute, "TESTAttribute")
					.With(md => md.Value, "testVALue")
					.Create()
			};

			var filter = new Filter(_msgFilterServiceStub.Object);

			var messagesListResult = await filter.ApplyNormalFilters(messagesList, default);

			messagesListResult.Should().BeEmpty();
		}
	}
}