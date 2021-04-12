using BlockBuster.Shared.Application.Bus.UseCase;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Testing.Application
{
    [TestFixture]
    public class AbstractRequestTesting
    {
        [Test]
        public void GetPageSizeAndNumberFromRequestUrlQuery()
        {
            var pageNumber = 3;
            var pageSize = 25;
            var number = "number";
            var size = "size";
            
            var query = new Mock<IQueryCollection>();
            query.SetupGet(q => q["page[number]"]).Returns(new StringValues(pageNumber.ToString()));
            query.SetupGet(q => q["page[size]"]).Returns(new StringValues(pageSize.ToString()));

            var abstractRequest = new AbstractRequest(query.Object);
            var pageProps = abstractRequest.Page();

            Assert.AreEqual(pageProps.Keys.Count, 2);
            Assert.IsTrue(pageProps.ContainsKey(number));
            Assert.IsTrue(pageProps.ContainsKey(size));
            Assert.AreEqual(pageProps[number], pageNumber);
            Assert.AreEqual(pageProps[size], pageSize);

        }
    }
}
