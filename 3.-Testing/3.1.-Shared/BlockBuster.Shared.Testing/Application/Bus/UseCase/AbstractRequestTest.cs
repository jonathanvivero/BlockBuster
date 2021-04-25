using BlockBuster.Shared.Application.Bus.UseCase;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Moq;
using NUnit.Framework;

namespace BlockBuster.Shared.Testing.Application.Bus.UseCase
{
    public class Tests
    {
        const string size = "size";
        const string number = "number";

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetPageSizeAndNumberFromRequestUrlQuery()
        {
            var pageNumber = 3;
            var pageSize = 25;

            var query = new Mock<IQueryCollection>();
            query.SetupGet(q => q["page[number]"]).Returns(new StringValues(pageNumber.ToString()));
            query.SetupGet(q => q["page[size]"]).Returns(new StringValues(pageSize.ToString()));

            var abstractRequest = new AbstractRequest(query.Object);
            var pageProps = abstractRequest.Page;

            Assert.AreEqual(pageProps.Keys.Count, 2);
            Assert.IsTrue(pageProps.ContainsKey(number));
            Assert.IsTrue(pageProps.ContainsKey(size));
            Assert.AreEqual(pageProps[number], pageNumber);
            Assert.AreEqual(pageProps[size], pageSize);
            Assert.Pass();
        }

        [Test]
        public void GetPageSizeOnlyFromRequestUrlQuery()
        {
            var pageSize = 25;
            var pageNumber = 1;
            
            var query = new Mock<IQueryCollection>();
            query.SetupGet(q => q["page[size]"]).Returns(new StringValues(pageSize.ToString()));

            var abstractRequest = new AbstractRequest(query.Object);
            var pageProps = abstractRequest.Page;

            Assert.AreEqual(pageProps.Keys.Count, 2);
            Assert.IsTrue(pageProps.ContainsKey(number));
            Assert.IsTrue(pageProps.ContainsKey(size));
            Assert.AreEqual(pageProps[number], pageNumber);
            Assert.AreEqual(pageProps[size], pageSize);
            Assert.Pass();
        }

        [Test]
        public void GetPageNumberOnlyFromRequestUrlQuery()
        {
            var pageSize = 1;
            var pageNumber = 3;

            var query = new Mock<IQueryCollection>();
            query.SetupGet(q => q["page[number]"]).Returns(new StringValues(pageNumber.ToString()));

            var abstractRequest = new AbstractRequest(query.Object);
            var pageProps = abstractRequest.Page;

            Assert.AreEqual(pageProps.Keys.Count, 2);
            Assert.IsTrue(pageProps.ContainsKey(number));
            Assert.IsTrue(pageProps.ContainsKey(size));
            Assert.AreEqual(pageProps[number], pageNumber);
            Assert.AreEqual(pageProps[size], pageSize);
            Assert.Pass();
        }

        [Test]
        public void GetNoPageInformationFromRequestUrlQuery()
        {
            var pageSize = 1;
            var pageNumber = 1;

            var query = new Mock<IQueryCollection>();

            var abstractRequest = new AbstractRequest(query.Object);
            var pageProps = abstractRequest.Page;

            Assert.AreEqual(pageProps.Keys.Count, 2);
            Assert.IsTrue(pageProps.ContainsKey(number));
            Assert.IsTrue(pageProps.ContainsKey(size));
            Assert.AreEqual(pageProps[number], pageNumber);
            Assert.AreEqual(pageProps[size], pageSize);
            Assert.Pass();
        }


    }
}