﻿using System;
using NUnit.Framework;

namespace Core.Maybe.NTests
{
	[TestFixture]
	public class MaybeNullableSpecification
	{
		[Test]
		public void ToNullableTest()
		{
			var nothing = Maybe<Guid>.Nothing;
			Assert.AreEqual(null, nothing.ToNullable());
		}
	}
}
