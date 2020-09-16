using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Bot.Builder.Community.Adapters.Twitter.Hosting;
using Bot.Builder.Community.Adapters.Twitter.Webhooks.Models.Twitter;
using Microsoft.AspNetCore.Http;
using Microsoft.Bot.Builder;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Internal;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace Bot.Builder.Community.Adapters.Twitter.Tests.Hosting
{
    [Trait("TestCategory", "Twitter")]
    public class WebhookMiddlewareTests
    {
        private readonly Mock<ILogger<WebhookMiddleware>> _testLogger = new Mock<ILogger<WebhookMiddleware>>();
        private readonly Mock<IBot> _testBot = new Mock<IBot>();
        private readonly Mock<TwitterOptions> _twitterOptions = new Mock<TwitterOptions>() { Object = { ConsumerSecret = "ConsumerSecret" } };
        private readonly Mock<RequestDelegate> _testDelegate = new Mock<RequestDelegate>();
        private StringValues _values = new StringValues("test_code");

        [Fact]
        public async Task InvokeAsyncValidShouldSucceed()
        {
            var testOptions = new Mock<IOptions<TwitterOptions>>();
            testOptions.SetupGet(x => x.Value).Returns(_twitterOptions.Object);

            var adapter = new TwitterAdapter(testOptions.Object);

            var httpResponse = new Mock<HttpResponse>();
            httpResponse.SetupAllProperties();
            httpResponse.Object.Body = new MemoryStream();

            var request = new Mock<HttpRequest>();
            request.SetupAllProperties();
            request.Object.Method = HttpMethods.Get;
            request.Setup(req => req.Query.TryGetValue("crc_token", out _values)).Returns(true);

            var context = new Mock<HttpContext>();
            context.SetupGet(x => x.Response).Returns(httpResponse.Object);
            context.SetupGet(x => x.Request).Returns(request.Object);

            var middleware = new WebhookMiddleware(testOptions.Object, _testLogger.Object, _testBot.Object, adapter);

            await middleware.InvokeAsync(context.Object, _testDelegate.Object);

            Assert.Equal((int)HttpStatusCode.OK, httpResponse.Object.StatusCode);
        }

        [Fact]
        public async Task InvokeAsyncInvalidShouldLogError()
        {
            var testOptions = new Mock<IOptions<TwitterOptions>>();
            testOptions.SetupGet(x => x.Value).Returns(_twitterOptions.Object);

            var adapter = new TwitterAdapter(testOptions.Object);

            var httpResponse = new Mock<HttpResponse>();
            httpResponse.SetupAllProperties();
            httpResponse.Object.Body = new MemoryStream();

            var request = new Mock<HttpRequest>();
            request.SetupAllProperties();
            request.Object.Method = HttpMethods.Get;
            request.Setup(req => req.Query.TryGetValue("crc_token", out _values)).Returns(false);

            var context = new Mock<HttpContext>();
            context.SetupGet(x => x.Response).Returns(httpResponse.Object);
            context.SetupGet(x => x.Request).Returns(request.Object);

            var middleware = new WebhookMiddleware(testOptions.Object, _testLogger.Object, _testBot.Object, adapter);

            await middleware.InvokeAsync(context.Object, _testDelegate.Object);

            _testLogger.Verify(x => x.Log(LogLevel.Error, 0, It.IsAny<FormattedLogValues>(), null, It.IsAny<Func<object, Exception, string>>()), Times.Once);
        }

        [Fact]
        public async Task OnDirectMessageReceivedShouldSucceed()
        {
            var webhookDmResult = new WebhookDMResult
            {
                Users = new Dictionary<string, TwitterUser>
                {
                    ["sender-id"] = new TwitterUser { Id = "sender-id", ScreenName = "sender-screen-name" },
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

            var testOptions = new Mock<IOptions<TwitterOptions>>();
            testOptions.SetupGet(x => x.Value).Returns(_twitterOptions.Object);

            var adapter = new TwitterAdapter(testOptions.Object);

            var body = JsonConvert.SerializeObject(webhookDmResult);
            var hashKeyArray = Encoding.UTF8.GetBytes(_twitterOptions.Object.ConsumerSecret);
            var hmacSha256Alg = new HMACSHA256(hashKeyArray);
            var computedHash = hmacSha256Alg.ComputeHash(Encoding.UTF8.GetBytes(body));
            var localHashedSignature = $"sha256={Convert.ToBase64String(computedHash)}";
            var values = new StringValues(localHashedSignature);

            var request = new Mock<HttpRequest>();
            request.SetupAllProperties();
            request.Object.Method = HttpMethods.Post;
            request.Object.Body = new MemoryStream(Encoding.UTF8.GetBytes(body));
            request.Setup(req => req.Headers.TryGetValue("x-twitter-webhooks-signature", out values)).Returns(true);

            var httpResponse = new Mock<HttpResponse>();
            httpResponse.SetupAllProperties();
            httpResponse.Object.Body = new MemoryStream();

            var context = new Mock<HttpContext>();
            context.SetupGet(x => x.Response).Returns(httpResponse.Object);
            context.SetupGet(x => x.Request).Returns(request.Object);

            var middleware = new WebhookMiddleware(testOptions.Object, _testLogger.Object, _testBot.Object, adapter);

            await middleware.InvokeAsync(context.Object, _testDelegate.Object);

            _testBot.Verify(x => x.OnTurnAsync(It.IsAny<ITurnContext>(), default), Times.Once);
        }
    }
}
