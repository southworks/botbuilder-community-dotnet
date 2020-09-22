// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Alexa.NET.Request;
using Bot.Builder.Community.Adapters.Alexa.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Moq;
using Xunit;

namespace Bot.Builder.Community.Adapters.Alexa.Tests
{
    public class ValidationHelperTests
    {
        [Fact]
        public async Task ValidateRequestWithEmptySignatureUrlsShouldReturnFalse()
        {
            StringValues signatureChainUrls = string.Empty;
            StringValues signatureHeaders = "test-signature-header";
            var request = new Mock<HttpRequest>();
            request.SetupAllProperties();
            request.Setup(req => req.Headers.TryGetValue(AlexaAuthorizationHandler.SignatureCertChainUrlHeader, out signatureChainUrls)).Returns(true);
            request.Setup(req => req.Headers.TryGetValue(AlexaAuthorizationHandler.SignatureHeader, out signatureHeaders)).Returns(true);
            var logger = new Mock<ILogger>();
            logger.SetupAllProperties();

            var result = await ValidationHelper.ValidateRequest(request.Object, new SkillRequest(), "", "skill-id", logger.Object);

            Assert.False(result);
        }
    }
}
