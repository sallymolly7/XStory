﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XStory.BL.Web.XStory;
using XStory.BL.Web.XStory.Contracts;
using XStory.DTO;

namespace XStory.XUnitTests.XStory
{
	[TestClass]
	public class AuthorTests
	{
		[TestMethod]
		public void GetAuthorPageTest_OK()
		{
			IServiceAuthor _serviceAuthor = new ServiceAuthor();

			Author author = new Author()
			{
				Id = "111900",
				Name = "Defalt",
				Avatar = "https://www.xstory-fr.com/forum/img/avatars/111900.jpg",
				Url = "auteur,111900,Defalt.html"
			};

			Task<Author> task = _serviceAuthor.GetAuthorPage(author);
			var result = task.Result;

			Assert.IsNotNull(result);
			Assert.IsNotNull(result.Id);
		}

		[TestMethod]
		public void GetAuthorPageTest_FullInfos_OK()
		{
			IServiceAuthor _serviceAuthor = new ServiceAuthor();

			Author author = new Author()
			{
				Id = "215478",
				Name = "Lolo069",
				Avatar = "https://www.xstory-fr.com/forum/img/avatars/215478.png",
				Url = "auteur,215478,Lolo069.html"
			};

			Task<Author> task = _serviceAuthor.GetAuthorPage(author);
			var result = task.Result;

			Assert.IsNotNull(result);
			Assert.IsNotNull(result.Id);
		}
	}
}
