
using System;
using Microsoft.AspNetCore.Builder;
using Moq;
using Xunit;
using Microsoft.Extensions.Options;

namespace Bot.Builder.Community.Adapters.Twitter.Tests
{
    [Trait("TestCategory", "Twitter")]
    public class ApplicationBuilderExtensionsTests
    {
        private static readonly Mock<IApplicationBuilder> _testApp = new Mock<IApplicationBuilder>();
        private static readonly Mock<IServiceProvider> _testService = new Mock<IServiceProvider>();
        private static readonly Mock<IOptions<TwitterOptions>> _testOptions = new Mock<IOptions<TwitterOptions>>();

        private static readonly TwitterOptions _options = new TwitterOptions
        {
            WebhookUri = "http://url",
            AccessSecret = "access-secret",
            AccessToken = "access-token",
            ConsumerKey = "consumer-key",
            ConsumerSecret = "consumer-secret",
            Environment = "env",
            Tier = TwitterAccountApi.PremiumFree
        };

        [Fact]
        public void UseTwitterAdapterShouldCreateNewInstance()
        {
            _testOptions.SetupGet(e => e.Value).Returns(_options);
            _testService.Setup(e => e.GetService(typeof(IOptions<TwitterOptions>))).Returns(_testOptions.Object);
            _testApp.Setup(e => e.ApplicationServices).Returns(_testService.Object);
            _testApp.Setup(e => e.New()).Returns(_testApp.Object);

            _testApp.Object.UseTwitterAdapter();

            _testApp.Verify(e => e.New(), Times.Once());
        }
    }
}
