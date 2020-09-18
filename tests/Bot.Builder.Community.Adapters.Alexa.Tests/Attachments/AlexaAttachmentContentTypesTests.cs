// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Bot.Builder.Community.Adapters.Alexa.Core.Attachments;
using Xunit;

namespace Bot.Builder.Community.Adapters.Alexa.Tests.Attachments
{
    public class AlexaAttachmentContentTypesTests
    {
        [Fact]
        public void AlexaAttachmentContentTypesShouldBeSetSuccessfully()
        {
            Assert.Equal("application/vhd.bfalexa.card", AlexaAttachmentContentTypes.Card);
            Assert.Equal("application/vhd.bfalexa.directive", AlexaAttachmentContentTypes.Directive);
            Assert.Equal("application/vhd.bfalexa.permissionconsent", AlexaAttachmentContentTypes.PermissionConsent);
        }
    }
}
