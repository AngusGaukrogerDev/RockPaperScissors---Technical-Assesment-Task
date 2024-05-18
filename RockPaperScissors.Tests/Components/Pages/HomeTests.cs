using System;
using System.Threading.Tasks;
using Bunit;
using Bunit.TestDoubles;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using RockPaperScissors.Components.Pages;
using Xunit;

namespace RockPaperScissors.Tests.Components.Pages
{
    public class HomeTests : TestContext
    {
        [Fact]
        public void ClassicButtonNavigatesCorrectly()
        {
            // Arrange
            var navigationManager = Services.GetRequiredService<FakeNavigationManager>();
            var renderedComponent = RenderComponent<Home>();

            // Act
            renderedComponent.Find("button:contains('Classic')").Click();

            // Assert
            Assert.Equal("http://localhost/rock-paper-scissors/classic", navigationManager.Uri);
        }
        [Fact]
        public void LastChoiceButtonNavigatesCorrectly()
        {
            // Arrange
            var navigationManager = Services.GetRequiredService<FakeNavigationManager>();
            var renderedComponent = RenderComponent<Home>();

            // Act
            renderedComponent.Find("button:contains('Last Choice')").Click();

            // Assert
            Assert.Equal("http://localhost/rock-paper-scissors/last-choice", navigationManager.Uri);
        }

        [Fact]
        public void RPSLSButtonNavigatesCorrectly()
        {
            // Arrange
            var navigationManager = Services.GetRequiredService<FakeNavigationManager>();
            var renderedComponent = RenderComponent<Home>();

            // Act
            renderedComponent.Find("button:contains('RPSLS')").Click();

            // Assert
            Assert.Equal("http://localhost/rock-paper-scissors/rpsls", navigationManager.Uri);
        }
    }
}

