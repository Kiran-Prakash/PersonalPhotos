using PersonalPhotos.Controllers;
using System;
using Xunit;
using Moq;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonalPhotos.Models;
using System.Threading.Tasks;

namespace PersonalPhotos.Test
{
    public class LoginsTests
    {
        private readonly LoginsController _controller;
        private readonly Mock<ILogins> _logins;
        private readonly Mock<IHttpContextAccessor> _accessor;
        public LoginsTests()
        {
            _logins = new Mock<ILogins>();
            _accessor = new Mock<IHttpContextAccessor>();
            _controller = new LoginsController(_logins.Object, _accessor.Object);
        }
        [Fact]
        public void GivenNorReturnUrl_ReturnLoginView()
        {
            var result = (_controller.Index() as ViewResult);
            Assert.NotNull(result);
            Assert.Equal("Login", result.ViewName, ignoreCase: true);
        }

        [Fact]
        public async Task Login_GivenModelStateInvalid_ReturnLoginView()
        {
            _controller.ModelState.AddModelError("Test", "Test");
            var result = (await _controller.Login(Mock.Of<LoginViewModel>()) as ViewResult);
            Assert.Equal("Login", result.ViewName, ignoreCase: true);
        }
    }
}
