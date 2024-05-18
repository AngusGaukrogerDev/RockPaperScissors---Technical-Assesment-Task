using System;
using System.Threading.Tasks;
using Bunit;
using Bunit.TestDoubles;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using RockPaperScissors.Components.Pages;
using RockPaperScissors.Components.UIComponents;
using Xunit;

namespace RockPaperScissors.Tests.Components.Pages
{
    public class Rock_Paper_ScissorsTests : TestContext
    {
        [Fact]
        public void RenderClassicGameControls()
        {
            // Arrange
            var parameters = ComponentParameter.CreateParameter("gameType", "classic");
            var renderedComponent = RenderComponent<Rock_Paper_Scissors>(parameters);

            // Act
            var classicGameControls = renderedComponent.FindComponent<ClassicGameControls>();

            // Assert
            Assert.NotNull(classicGameControls);
        }

        [Fact]
        public void RenderRPSLSGameControls()
        {
            // Arrange
            var parameters = ComponentParameter.CreateParameter("gameType", "rpsls");
            var renderedComponent = RenderComponent<Rock_Paper_Scissors>(parameters);

            // Act
            var rpslsGameControls = renderedComponent.FindComponent<RPSLSGameControls>();

            // Assert
            Assert.NotNull(rpslsGameControls);
        }

        [Fact]
        public void RenderResultsScreenAfterTimerExpires()
        {
            // Arrange
            var parameters = ComponentParameter.CreateParameter("gameType", "classic");
            var renderedComponent = RenderComponent<Rock_Paper_Scissors>(parameters);

            // Simulate the timer expiration
            var timerValueElement = renderedComponent.Find("h3");
            renderedComponent.Instance.timerValue = 0;
            renderedComponent.Instance.timerExpired = true;
            renderedComponent.Render();

            // Assert
            var resultsScreen = renderedComponent.FindComponent<ResultsScreen>();
            Assert.NotNull(resultsScreen);
        }


        [Fact]
        public void PlayAgainResetsGame()
        {
            // Arrange
            var parameters = ComponentParameter.CreateParameter("gameType", "classic");
            var renderedComponent = RenderComponent<Rock_Paper_Scissors>(parameters);

            // Act
            renderedComponent.Instance.timerExpired = true;
            renderedComponent.Instance.handlePlayAgainChange();

            // Assert
            Assert.False(renderedComponent.Instance.timerExpired);
            Assert.Null(renderedComponent.Instance.userSelection);
            Assert.Equal(5, renderedComponent.Instance.timerValue);
        }
    }
}
