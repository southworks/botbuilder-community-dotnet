// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;

namespace Bot.Builder.Community.Adapters.Twitter.Tests
{
    [Trait("TestCategory", "Twitter")]
    public class ApplicationBuilderExtensionsTests
    {
        private static readonly Mock<IApplicationBuilder> TestApp = new Mock<IApplicationBuilder>();
        private static readonly Mock<IServiceProvider> TestService = new Mock<IServiceProvider>();
        private static readonly Mock<IOptions<TwitterOptions>> TestOptions = new Mock<IOptions<TwitterOptions>>();

        private static readonly TwitterOptions Options = new TwitterOptions
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
            TestOptions.SetupGet(e => e.Value).Returns(Options);
            TestService.Setup(e => e.GetService(typeof(IOptions<TwitterOptions>))).Returns(TestOptions.Object);
            TestApp.Setup(e => e.ApplicationServices).Returns(TestService.Object);
            TestApp.Setup(e => e.New()).Returns(TestApp.Object);

            TestApp.Object.UseTwitterAdapter();

            TestApp.Verify(e => e.New(), Times.Once());
        }
    }
}
