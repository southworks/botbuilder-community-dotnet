﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Bot.Builder.Community.Adapters.Twitter.Webhooks.Models;
using Bot.Builder.Community.Adapters.Twitter.Webhooks.Models.Twitter;
using Bot.Builder.Community.Adapters.Twitter.Webhooks.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace Bot.Builder.Community.Adapters.Twitter.Tests.Webhooks.Services
{
    [Trait("TestCategory", "Twitter")]
    public class WebhookInterceptorTests
    {
        private readonly string consumerSecret = "test";
        private readonly Mock<Action<DirectMessageEvent>> _testAction = new Mock<Action<DirectMessageEvent>>();
        private readonly Mock<HttpRequest> _testRequest = new Mock<HttpRequest>();
        private StringValues _testValues = new StringValues("test_values");

        [Fact]
        public async Task InterceptIncomingRequestWithEmptyConsumerSecretShouldFail()
        {
            var interceptor = new WebhookInterceptor(string.Empty);

            await Assert.ThrowsAsync<TwitterException>(() => interceptor.InterceptIncomingRequest(_testRequest.Object, _testAction.Object));
        }

        [Fact]
        public async Task InterceptIncomingRequestWithEmptyRequestShouldReturnUnhandled()
        {
            var interceptor = new WebhookInterceptor(consumerSecret);
            var response = await interceptor.InterceptIncomingRequest(_testRequest.Object, _testAction.Object);

            Assert.False(response.IsHandled);
        }

        [Fact]
        public async Task InterceptIncomingRequestGetAndEmptyCrcTokenShouldReturnUnhandled()
        {
            var interceptor = new WebhookInterceptor(consumerSecret);
            var request = new Mock<HttpRequest>();
            request.SetupAllProperties();
            request.Object.Method = HttpMethods.Get;
            request.Object.Query = new Mock<IQueryCollection>().Object;

            var response = await interceptor.InterceptIncomingRequest(request.Object, _testAction.Object);

            Assert.False(response.IsHandled);
        }

        [Fact]
        public async Task InterceptIncomingRequestGetAndCrcTokenShouldReturnHandled()
        {
            var interceptor = new WebhookInterceptor(consumerSecret);
            var request = new Mock<HttpRequest>();
            request.SetupAllProperties();
            request.Object.Method = HttpMethods.Get;
            request.Setup(req => req.Query.TryGetValue("crc_token", out _testValues)).Returns(true);

            var response = await interceptor.InterceptIncomingRequest(request.Object, _testAction.Object);

            Assert.True(response.IsHandled);
        }

        [Fact]
        public async Task InterceptIncomingRequestPostWithEmptyHeadersShouldReturnUnhandled()
        {
            var interceptor = new WebhookInterceptor(consumerSecret);
            var request = new Mock<HttpRequest>();
            request.SetupAllProperties();
            request.Object.Method = HttpMethods.Post;
            request.Setup(req => req.Headers.TryGetValue("x-twitter-webhooks-signature", out _testValues)).Returns(false);

            var response = await interceptor.InterceptIncomingRequest(request.Object, _testAction.Object);

            Assert.False(response.IsHandled);
        }

        [Fact]
        public async Task InterceptIncomingRequestPostWithInvalidSignatureShouldFail()
        {
            var interceptor = new WebhookInterceptor(consumerSecret);

            var request = new Mock<HttpRequest>();
            request.SetupAllProperties();
            request.Object.Method = HttpMethods.Post;
            request.Object.Body = new MemoryStream(Encoding.UTF8.GetBytes("test_body"));
            request.Setup(req => req.Headers.TryGetValue("x-twitter-webhooks-signature", out _testValues)).Returns(true);

            await Assert.ThrowsAsync<TwitterException>(() => interceptor.InterceptIncomingRequest(request.Object, _testAction.Object));
        }

        [Fact]
        public async Task InterceptIncomingRequestPostWithValidSignatureShouldReturnHandled()
        {
            var body = "test_body";
            var interceptor = new WebhookInterceptor(consumerSecret);
            var hashKeyArray = Encoding.UTF8.GetBytes(consumerSecret);
            var hmacSha256Alg = new HMACSHA256(hashKeyArray);
            var computedHash = hmacSha256Alg.ComputeHash(Encoding.UTF8.GetBytes(body));
            var localHashedSignature = $"sha256={Convert.ToBase64String(computedHash)}";
            var values = new StringValues(localHashedSignature);

            var request = new Mock<HttpRequest>();
            request.SetupAllProperties();
            request.Object.Method = HttpMethods.Post;
            request.Object.Body = new MemoryStream(Encoding.UTF8.GetBytes(body));
            request.Setup(req => req.Headers.TryGetValue("x-twitter-webhooks-signature", out values)).Returns(true);

            var response = await interceptor.InterceptIncomingRequest(request.Object, _testAction.Object);

            _testAction.Verify(e => e.Invoke(It.IsAny<DirectMessageEvent>()), Times.Never());
            Assert.True(response.IsHandled);
        }

        [Fact]
        public async Task InterceptIncomingRequestWithValidPayloadShouldExecuteOnDirectMessageRecievedInvoke()
        {
            var webhookDmResult = new WebhookDMResult
            {
                Users = new Dictionary<string, TwitterUser>
                {
                    ["sender-id"] = new TwitterUser { Id = "sender-id" },
                    ["recipient-id"] = new TwitterUser { Id = "recipient-id" }
                },
                Events = new List<DMEvent> {
                    new DMEvent
                    {
                        id = "event-id",
                        type = "message_create",
                        message_create = new Message
                        {
                            message_data = new Message_Data
                            {
                                text = "test-text",
                                attachment = new Attachment
                                {
                                    media = new MediaEntity { id = 1 }
                                },
                                entities = new TwitterEntities()
                            },
                            sender_id = "sender-id",
                            target = new Target { recipient_id = "recipient-id" }
                        }
                    }
                }
            };

            var body = JsonConvert.SerializeObject(webhookDmResult);
            var interceptor = new WebhookInterceptor(consumerSecret);
            var hashKeyArray = Encoding.UTF8.GetBytes(consumerSecret);
            var hmacSha256Alg = new HMACSHA256(hashKeyArray);
            var computedHash = hmacSha256Alg.ComputeHash(Encoding.UTF8.GetBytes(body));
            var localHashedSignature = $"sha256={Convert.ToBase64String(computedHash)}";
            var values = new StringValues(localHashedSignature);

            var request = new Mock<HttpRequest>();
            request.SetupAllProperties();
            request.Object.Method = HttpMethods.Post;
            request.Object.Body = new MemoryStream(Encoding.UTF8.GetBytes(body));
            request.Setup(req => req.Headers.TryGetValue("x-twitter-webhooks-signature", out values)).Returns(true);

            var response = await interceptor.InterceptIncomingRequest(request.Object, _testAction.Object);

            _testAction.Verify(e => e.Invoke(It.IsAny<DirectMessageEvent>()), Times.Once());
            Assert.True(response.IsHandled);
        }
    }
}
