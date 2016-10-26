using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FetchAndStore.DAL;
using System.Collections.Generic;
using FetchAndStore.Models;
using Moq;
using System.Data.Entity;
using System.Linq;

namespace FetchAndStore.Tests.DAL
{
    [TestClass]
    public class StoreRepositoryTests
    {
        Mock<StoreContext> mock_context { get; set; }
        Mock<DbSet<Response>> mock_response_table { get; set; }
        List<Response> responses_list { get; set; }
        StoreRepository repo { get; set; }

        public void ConnectMockstoDatastore()
        {
            var queryable_list = responses_list.AsQueryable();

            mock_response_table.As<IQueryable<Response>>().Setup(m => m.Provider).Returns(queryable_list.Provider);
            mock_response_table.As<IQueryable<Response>>().Setup(m => m.Expression).Returns(queryable_list.Expression);
            mock_response_table.As<IQueryable<Response>>().Setup(m => m.ElementType).Returns(queryable_list.ElementType);
            mock_response_table.As<IQueryable<Response>>().Setup(m => m.GetEnumerator()).Returns(() => queryable_list.GetEnumerator());

            mock_context.Setup(c => c.Responses).Returns(mock_response_table.Object);

            mock_response_table.Setup(t => t.Add(It.IsAny<Response>())).Callback((Response a) => responses_list.Add(a));
            mock_response_table.Setup(t => t.Remove(It.IsAny<Response>())).Callback((Response a) => responses_list.Remove(a));
        }

        [TestInitialize]
        public void Initialize()
        {
            mock_context = new Mock<StoreContext>();
            mock_response_table = new Mock<DbSet<Response>>();
            responses_list = new List<Response>();
            repo = new StoreRepository(mock_context.Object);

            ConnectMockstoDatastore();
        }

        [TestCleanup]
        public void TearDown()
        {
            repo = null;
        }

        [TestMethod]
        public void CanCreateAnInstanceOfRepo()
        {
            StoreRepository repo = new StoreRepository();
            Assert.IsNotNull(repo);
        }

        [TestMethod]
        public void MakeSureRepoHasContext()
        {
            StoreRepository repo = new StoreRepository();

            StoreContext actual_context = repo.Context;

            Assert.IsInstanceOfType(actual_context, typeof(StoreContext));
        }

        [TestMethod]
        public void EnsureRepoStartsEmpty()
        {
            ConnectMockstoDatastore();
            StoreRepository repo = new StoreRepository(mock_context.Object);

            List<Response> current_responses = repo.GetResponses();
            int expected_response_count = 0;
            int actual_response_count = current_responses.Count;

            Assert.AreEqual(expected_response_count, actual_response_count);
        }

        [TestMethod]
        public void CanAddResponseToDatabase()
        {
            StoreRepository repo = new StoreRepository(mock_context.Object);
            ConnectMockstoDatastore();
            Response test_response = new Response { MethodUsed = "GET", UserURL = "www.google.com", StatusCode = 200, ResponseTime = "Super fast, man." };

            repo.AddResponse(test_response);

            int expected_count = 1;
            int actual_count = repo.GetResponses().Count;

            Assert.AreEqual(expected_count, actual_count);
        }
    }
}
