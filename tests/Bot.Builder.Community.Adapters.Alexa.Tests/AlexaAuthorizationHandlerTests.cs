// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Alexa.NET.Request;
using Bot.Builder.Community.Adapters.Alexa.Core;
using Bot.Builder.Community.Adapters.Alexa.Tests.Helpers;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Bot.Builder.Community.Adapters.Alexa.Tests
{
    public class AlexaAuthorizationHandlerTests
    {
        private const string AlexaSkillId = "amzn1.ask.skill.b5c74146-56d3-433d-a53d-6908f606da36";
        private const string SignatureChainUrl = "https://s3.amazonaws.com/echo.api/echo-api-cert.pem";
        private static readonly Mock<ILogger> TestLogger = new Mock<ILogger>();
        private static readonly SkillRequest TestSkillRequest = SkillRequestHelper.CreateIntentRequest();

        [Fact]
        public void ConstructorWithNoArgumentsShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new AlexaAuthorizationHandler(null));
        }

        [Fact]
        public void ConstructorWithLoggerShouldSucceed()
        {
            Assert.NotNull(new AlexaAuthorizationHandler(TestLogger.Object));
        }

        [Fact]
        public void ValidateSkillIdShouldReturnTrue()
        {
            var alexaAuthorizationHandler = new AlexaAuthorizationHandler(TestLogger.Object);
            var result = alexaAuthorizationHandler.ValidateSkillId(TestSkillRequest, AlexaSkillId);

            Assert.True(result);
        }

        [Fact]
        public void ValidateSkillIdWithNoSkillRequestShouldReturnFalse()
        {
            var alexaAuthorizationHandler = new AlexaAuthorizationHandler(TestLogger.Object);
            var result = alexaAuthorizationHandler.ValidateSkillId(null, "alexa-skill-id");

            Assert.False(result);
        }

        [Fact]
        public void ValidateSkillIdWithNoAlexaSkillIdShouldReturnFalse()
        {
            var alexaAuthorizationHandler = new AlexaAuthorizationHandler(TestLogger.Object);
            var result = alexaAuthorizationHandler.ValidateSkillId(null, null);

            Assert.False(result);
        }

        [Fact]
        public async Task ValidateSkillRequestWithNoSkillRequestShouldReturnFalse()
        {
            var alexaAuthorizationHandler = new AlexaAuthorizationHandler(TestLogger.Object);
            var result = await alexaAuthorizationHandler.ValidateSkillRequest(null, "", "", "");

            Assert.False(result);
        }

        [Fact]
        public async Task ValidateSkillRequestWithNoSignatureChainUrlShouldReturnFalse()
        {
            var alexaAuthorizationHandler = new AlexaAuthorizationHandler(TestLogger.Object);
            var result = await alexaAuthorizationHandler.ValidateSkillRequest(TestSkillRequest, "", "", "");

            Assert.False(result);
        }

        [Fact]
        public async Task ValidateSkillRequestWithWrongSignatureChainUrlShouldReturnFalse()
        {
            var alexaAuthorizationHandler = new AlexaAuthorizationHandler(TestLogger.Object);
            var result = await alexaAuthorizationHandler.ValidateSkillRequest(TestSkillRequest, "", "signature-url", "");

            Assert.False(result);
        }

        [Fact]
        public async Task ValidateSkillRequestWithNoSignatureShouldReturnFalse()
        {
            var alexaAuthorizationHandler = new AlexaAuthorizationHandler(TestLogger.Object);
            var result = await alexaAuthorizationHandler.ValidateSkillRequest(TestSkillRequest, "", SignatureChainUrl, "");

            Assert.False(result);
        }

        [Fact]
        public async Task ValidateSkillRequestWithNoSkillRequestTimestampShouldReturnFalse()
        {
            var alexaAuthorizationHandler = new AlexaAuthorizationHandler(TestLogger.Object);
            var result = await alexaAuthorizationHandler.ValidateSkillRequest(TestSkillRequest, "", SignatureChainUrl, "signature");

            Assert.False(result);
        }

        [Fact]
        public async Task ValidateSkillRequestWithCertificateValidationFailedShouldReturnFalse()
        {
            var alexaAuthorizationHandler = new AlexaAuthorizationHandler(TestLogger.Object);
            TestSkillRequest.Request.Timestamp = DateTime.Now;
            var result = await alexaAuthorizationHandler.ValidateSkillRequest(TestSkillRequest, "", SignatureChainUrl, "signature");

            Assert.False(result);
        }
    }
}
