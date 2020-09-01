// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bot.Builder.Community.Adapters.Twitter.Webhooks.Models.Twitter;

namespace Bot.Builder.Community.Adapters.Twitter.Tests.Webhooks.Models.Twitter
{
    [TestClass]
    [TestCategory("Twitter")]
    public class SymbolEntityTests
    {
        [TestMethod]
        public void SymbolEntityPropertiesShouldBeSetSuccessfully()
        {
            var symbolEntity = new SymbolEntity
            {
                text = "symbol-text",
                indices = new[] { 0, 1, 2 }
            };

            Assert.AreEqual("symbol-text", symbolEntity.text);
            Assert.AreEqual(3, symbolEntity.indices.Length);
        }
    }
}
