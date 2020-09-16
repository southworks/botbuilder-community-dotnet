// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Bot.Builder.Community.Adapters.Twitter.Webhooks.Models.Twitter;
using Xunit;

namespace Bot.Builder.Community.Adapters.Twitter.Tests.Webhooks.Models.Twitter
{
    [Trait("TestCategory", "Twitter")]
    public class SymbolEntityTests
    {
        [Fact]
        public void SymbolEntityPropertiesShouldBeSetSuccessfully()
        {
            var symbolEntity = new SymbolEntity
            {
                text = "symbol-text",
                indices = new[] { 0, 1, 2 }
            };

            Assert.Equal("symbol-text", symbolEntity.text);
            Assert.Equal(3, symbolEntity.indices.Length);
        }
    }
}
