using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Security.Authentication;
using Alexa.NET.Request;
using Bot.Builder.Community.Adapters.Alexa.Core;
using Bot.Builder.Community.Adapters.Alexa.Tests.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using Microsoft.Extensions.Primitives;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace Bot.Builder.Community.Adapters.Alexa.Tests
{
    public class AlexaTests
    {
        private static readonly Mock<HttpRequest> TestHttpRequest = new Mock<HttpRequest>();
        private static readonly Mock<HttpResponse> TestHttpResponse = new Mock<HttpResponse>();
        private static readonly Mock<IBot> TestBot = new Mock<IBot>();
        private static readonly SkillRequest TestSkillRequest = SkillRequestHelper.CreateIntentRequest();

        [Fact]
        public void ConstructorWithNoArgumentsShouldSucceed()
        {
            Assert.NotNull(new AlexaAdapter());
        }

        [Fact]
        public void ConstructorWithOptionsOnlyShouldSucceed()
        {
            Assert.NotNull(new AlexaAdapter(new Mock<AlexaAdapterOptions>().Object));
        }

        [Fact]
        public async void ContinueConversationAsyncShouldSucceed()
        {
            var callbackInvoked = false;

            var alexaAdapter = new AlexaAdapter(new Mock<AlexaAdapterOptions>().Object);
            var conversationReference = new ConversationReference();

            Task BotsLogic(ITurnContext turnContext, CancellationToken cancellationToken)
            {
                callbackInvoked = true;
                return Task.CompletedTask;
            }

            await alexaAdapter.ContinueConversationAsync(conversationReference, BotsLogic, default);
            Assert.True(callbackInvoked);
        }

        [Fact]
        public async void ContinueConversationAsyncShouldFailWithNullConversationReference()
        {
            var alexaAdapter = new AlexaAdapter(new Mock<AlexaAdapterOptions>().Object);

            static Task BotsLogic(ITurnContext turnContext, CancellationToken cancellationToken)
            {
                return Task.CompletedTask;
            }

            await Assert.ThrowsAsync<ArgumentNullException>(() => alexaAdapter.ContinueConversationAsync(null, BotsLogic, default));
        }

        [Fact]
        public async void ContinueConversationAsyncWithNoBotLogicShouldThrowArgumentNullException()
        {
            var conversationReference = new ConversationReference();
            var alexaAdapter = new AlexaAdapter();

            await Assert.ThrowsAsync<ArgumentNullException>(() => alexaAdapter.ContinueConversationAsync(conversationReference, null, default));
        }

        [Fact]
        public async void UpdateActivityAsyncShouldThrowNotImplementedException()
        {
            var alexaAdapter = new AlexaAdapter();

            await Assert.ThrowsAsync<NotImplementedException>(() => alexaAdapter.UpdateActivityAsync(default, default, default));
        }

        [Fact]
        public async void DeleteActivityAsyncShouldThrowNotImplementedException()
        {
            var alexaAdapter = new AlexaAdapter();

            await Assert.ThrowsAsync<NotImplementedException>(() => alexaAdapter.DeleteActivityAsync(default, default, default));
        }

        [Fact]
        public async void ProcessAsyncWithNoHttpRequestShouldThrowArgumentNullException()
        {
            var alexaAdapter = new AlexaAdapter();

            await Assert.ThrowsAsync<ArgumentNullException>(() => alexaAdapter.ProcessAsync(default, TestHttpResponse.Object, TestBot.Object));
        }

        [Fact]
        public async void ProcessAsyncWithNoHttpResponseShouldThrowArgumentNullException()
        {
            var alexaAdapter = new AlexaAdapter();

            await Assert.ThrowsAsync<ArgumentNullException>(() => alexaAdapter.ProcessAsync(TestHttpRequest.Object, default, TestBot.Object));
        }

        [Fact]
        public async void ProcessAsyncWithNoBotShouldThrowArgumentNullException()
        {
            var alexaAdapter = new AlexaAdapter();

            await Assert.ThrowsAsync<ArgumentNullException>(() => alexaAdapter.ProcessAsync(TestHttpRequest.Object, TestHttpResponse.Object, default));
        }

        [Fact]
        public async Task ProcessAsyncWithEmptyVersionShouldThrowException()
        {
            StringValues signatureChainUrls = string.Empty;
            StringValues signatureHeaders = "test-signature-header";

            TestHttpRequest.SetupAllProperties();
            TestHttpRequest.Setup(req => req.Headers.TryGetValue(AlexaAuthorizationHandler.SignatureCertChainUrlHeader, out signatureChainUrls))
                .Returns(true);
            TestHttpRequest.Setup(req => req.Headers.TryGetValue(AlexaAuthorizationHandler.SignatureHeader, out signatureHeaders))
                .Returns(true);
            TestSkillRequest.Version = "";
            var skillRequestJson = JsonConvert.SerializeObject(TestSkillRequest);
            TestHttpRequest.Object.Body = new MemoryStream(Encoding.UTF8.GetBytes(skillRequestJson));

            var alexaAdapter = new AlexaAdapter();

            await Assert.ThrowsAsync<Exception>(() => alexaAdapter.ProcessAsync(TestHttpRequest.Object, TestHttpResponse.Object, TestBot.Object));
        }

        [Fact]
        public async Task ProcessAsyncWithValidateRequestShouldThrowAuthenticationException()
        {
            StringValues signatureChainUrls = string.Empty;
            StringValues signatureHeaders = "test-signature-header";

            TestHttpRequest.SetupAllProperties();
            TestHttpRequest.Setup(req => req.Headers.TryGetValue(AlexaAuthorizationHandler.SignatureCertChainUrlHeader, out signatureChainUrls))
                .Returns(true);
            TestHttpRequest.Setup(req => req.Headers.TryGetValue(AlexaAuthorizationHandler.SignatureHeader, out signatureHeaders))
                .Returns(true);
            var skillRequestJson = JsonConvert.SerializeObject(TestSkillRequest);
            TestHttpRequest.Object.Body = new MemoryStream(Encoding.UTF8.GetBytes(skillRequestJson));

            var alexaAdapter = new AlexaAdapter();

            await Assert.ThrowsAsync<AuthenticationException>(() => alexaAdapter.ProcessAsync(TestHttpRequest.Object, TestHttpResponse.Object, TestBot.Object));
        }

        [Fact]
        public void ProcessOutgoingActivitiesShouldReturnMergedActivityResult()
        {
            var alexaAdapter = new AlexaAdapter();
            var activities = new List<Activity>
            {
                new Activity { Id = "activity-id", Type = ActivityTypes.EndOfConversation },
            };

            var result = alexaAdapter.ProcessOutgoingActivities(activities);

            Assert.NotNull(result);
            Assert.True(result.EndOfConversationFlagged);
        }

        [Fact]
        public void RequestToActivityShouldReturnActivity()
        {
            var alexaAdapter = new AlexaAdapter();
            var result = alexaAdapter.RequestToActivity(TestSkillRequest);

            Assert.NotNull(result);
            Assert.Equal(TestSkillRequest.Request.RequestId, result.Id);
        }

        [Fact]
        public async Task SendActivitiesAsyncShouldReturnEmptyResourceResponse()
        {
            var alexaAdapter = new AlexaAdapter();
            var result = await alexaAdapter.SendActivitiesAsync(default, default, default);

            Assert.NotNull(result);
            Assert.Empty(result);
        }
    }
}
