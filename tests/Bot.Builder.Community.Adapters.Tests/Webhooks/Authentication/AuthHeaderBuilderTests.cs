// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.Http;
using Bot.Builder.Community.Adapters.Twitter.Webhooks.Authentication;
using Bot.Builder.Community.Adapters.Twitter.Webhooks.Models;
using Castle.Core.Internal;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;

namespace Bot.Builder.Community.Adapters.Twitter.Tests.Webhooks.Authentication
{
    [Trait("TestCategory", "Twitter")]
    public class AuthHeaderBuilderTests
    {
        private readonly Mock<IOptions<TwitterOptions>> _testOptions = new Mock<IOptions<TwitterOptions>>();

        [Fact]
        public void BuildWithNullUrlShouldFail()
        {
            Assert.Throws<TwitterException>(
                () =>
            {
                AuthHeaderBuilder.Build(_testOptions.Object.Value, HttpMethod.Post, null);
            });
        }

        [Fact]
        public void BuildWithInvalidOptionsShouldFail()
        {
            Assert.Throws<TwitterException>(
                () =>
                {
                    AuthHeaderBuilder.Build(_testOptions.Object.Value, HttpMethod.Post, "test_url");
                });
        }

        [Fact]
        public void BuildWithValidOptionsAndParametersShouldReturnHeader()
        {
            var testOptions = new Mock<TwitterOptions>()
            {
                Object =
                {
                    ConsumerKey = "ConsumerKey",
                    ConsumerSecret = "ConsumerSecret",
                    AccessToken = "AccessToken",
                    AccessSecret = "AccessSecret",
                    WebhookUri = "WebhookUri",
                    Environment = "Environment"
                }
            };
            var header = AuthHeaderBuilder.Build(testOptions.Object, HttpMethod.Get, "http://test_url.com?param1=val1&param2=val2");
            Assert.False(header.IsNullOrEmpty());
        }

        [Fact]
        public void BuildWithValidOptionsAndEmptyParametersShouldReturnHeader()
        {
            var testOptions = new Mock<TwitterOptions>()
            {
                Object =
                {
                    ConsumerKey = "ConsumerKey",
                    ConsumerSecret = "ConsumerSecret",
                    AccessToken = "AccessToken",
                    AccessSecret = "AccessSecret",
                    WebhookUri = "WebhookUri",
                    Environment = "Environment"
                }
            };
            var header = AuthHeaderBuilder.Build(testOptions.Object, HttpMethod.Get, "test_url");
            Assert.False(header.IsNullOrEmpty());
        }
    }
}
