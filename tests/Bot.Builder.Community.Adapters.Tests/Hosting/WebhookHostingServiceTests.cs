// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Bot.Builder.Community.Adapters.Twitter.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;

namespace Bot.Builder.Community.Adapters.Twitter.Tests.Hosting
{
    [Trait("TestCategory", "Twitter")]
    public class WebhookHostingServiceTests
    {
        private readonly Mock<ILogger<WebhookHostedService>> _testLogger = new Mock<ILogger<WebhookHostedService>>();
        private readonly Mock<IOptions<TwitterOptions>> _testOptions = new Mock<IOptions<TwitterOptions>>();
        private readonly Mock<IApplicationLifetime> _testAppLifetime = new Mock<IApplicationLifetime>();

        [Fact]
        public void StartAsyncShouldComplete()
        {
            var service = new WebhookHostedService(_testAppLifetime.Object, _testOptions.Object, _testLogger.Object);
            var start = service.StartAsync(default);
            Assert.True(start.IsCompleted);
        }

        [Fact]
        public void StopAsyncShouldComplete()
        {
            var service = new WebhookHostedService(_testAppLifetime.Object, _testOptions.Object, _testLogger.Object);
            var stop = service.StopAsync(default);
            Assert.True(stop.IsCompleted);
        }
    }
}
