using Core.Maybe.Json;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Core.Maybe.NTests.Json
{
	public class MaybeConverterSpecification
	{
		[Test]
		public void CanSerialize()
		{
			var settings = new JsonSerializerSettings();
			settings.Converters.Add(new MaybeConverter());
			var json = JsonConvert.SerializeObject(new MyClass("Test".ToMaybeObject()), settings);

			
			Assert.AreEqual("{\"Name\":\"Test\"}", json);
		}
		
		[Test]
		public void CanDeSerialize()
		{
			var settings = new JsonSerializerSettings();
			settings.Converters.Add(new MaybeConverter());
			var obj = JsonConvert.DeserializeObject<MyClass>("{\"Name\":\"Test\"}", settings);

			
			Assert.AreEqual("Test".ToMaybeObject(), obj!.Name);
		}
		
			
		[Test]
		public void CanDealWithContainer()
		{
			var settings = new JsonSerializerSettings();
			settings.Converters.Add(new MaybeConverter());
			var obj = JsonConvert.DeserializeObject<MyContainer>(
				JsonConvert.SerializeObject(new MyContainer(new MyClass("Test".ToMaybeObject())), settings), 
				settings
			);

      Assert.AreEqual("Test".ToMaybeObject(), obj.Something.Name);
		}
	}

	internal class MyClass
	{
		public MyClass(Maybe<string> name)
		{
			Name = name;
		}

		public Maybe<string> Name { get; }
	}
	
	internal class MyContainer
	{
		public MyClass Something { get; }

		public MyContainer(MyClass something)
		{
			Something = something;
		}
	}
}