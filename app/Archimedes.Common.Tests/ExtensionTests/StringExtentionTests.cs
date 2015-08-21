namespace Archimedes.Common.Tests.ExtensionTests
{
	using System;
	using System.Collections.Generic;

	using Extensions;

	using Xunit;

	public class StringExtentionTests
	{
		[Theory]
		[MemberData("TestData")]
		public void CanFormatWithObjects(string format, object obj, string expected)
		{
			Assert.Equal(expected, format.FormatWith(obj));
		}

		[Theory]
		[MemberData("BadData")]
		public void FormatWithObjectThrowsFormatExceptsWhereAppropriate(string format, object obj)
		{
			Assert.Throws<FormatException>(() => format.FormatWith(obj));
		}

		public static IEnumerable<object[]> TestData
		{
			get
			{
				var testData = new List<object[]>();

				testData.Add(new object[] { "Hello {name}", new { name = "World" }, "Hello World" });
				testData.Add(new object[] { "Hello {name} {name}", new { name = "World" }, "Hello World World" });

				// tests from Haacked
				testData.Add(new object[]{ "{foo} {foo} {bar}{baz}", new { foo = 123.45, bar = 42, baz = "hello" }, "123.45 123.45 42hello" });
				testData.Add(new object[] { "{{{{foo}}}}", new { foo = 123.45 }, "{{foo}}" });
				testData.Add(new object[] { "{{{{{foo}}}}}", new { foo = 123.45 }, "{{123.45}}" });
				testData.Add(new object[] { "{{{foo}}}", new { foo = 123.45 }, "{123.45}" });
				testData.Add(new object[] { "a b c", new { foo = 123.45 }, "a b c" });
				testData.Add(new object[] { "{foo:#.#}", new { foo = 123.45 }, "123.5" });
				testData.Add(new object[] { "{foo.bar:#.#}ms", new { foo = new { bar = 123.45 } }, "123.5ms" });
				testData.Add(new object[] { "{foo}}}bar", new { foo = 123.45 }, "123.45}bar" });
				testData.Add(new object[] { "{foo}}}}}bar", new { foo = 123.45 }, "123.45}}bar" });
				
				return testData.ToArray();
			}
		}

		public static IEnumerable<object[]> BadData
		{
			get
			{
				var testData = new List<object[]>();

				// tests from Haacked

				testData.Add(new object[] { "{bar}", new { foo = 123.45 } });
				testData.Add(new object[] { "{bar", new { foo = 123.45 } });
				testData.Add(new object[] { "{foo}}", new { foo = 123.45 } });
				testData.Add(new object[] { "{foo}}}}bar", new { foo = 123.45 } });
				testData.Add(new object[] { "{foo}}}}", new { foo = 123.45 } });
				//testData.Add(new object[] { "{foo}}}", new { foo = 123.45 } });
				// not a format exception, but an argument null exception
				// testData.Add(new object[] { null, 123 });


				return testData.ToArray();
			}
		}
	}
}