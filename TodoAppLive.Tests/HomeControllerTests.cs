using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using TodoAppLive.Controllers;
using TodoAppLive.Models;
using Xunit;

namespace TodoAppLive.Tests
{
    public class HomeControllerTests
    {

        [Fact]
        public void Index_Returns_A_View()
        {
            var repo = Substitute.For<ITodoRepository>();
            var underTest = new HomeController(repo);

            var result = underTest.Index();

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Index_Passes_Todos_To_View()
        {
            var expected = new List<Todo>();
            var repo = Substitute.For<ITodoRepository>();
            repo.GetAll().Returns(expected);

            var underTest = new HomeController(repo);

            var result = underTest.Index();
            var model = result.Model;

            Assert.Equal(expected, model);
            //Assert that all Todos were passed into View.
        }
    }
}
