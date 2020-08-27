// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Bot.Builder.Community.Adapters.Twitter.Webhooks.Models;
using Bot.Builder.Community.Adapters.Twitter.Webhooks.Models.Twitter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Bot.Builder.Community.Adapters.Twitter.Tests.Models
{
    [TestClass]
    [TestCategory("Twitter")]
    public class ResultTests
    {
        [TestMethod]
        public void ConstructorSucceeds()
        {
            var result = new Result<bool>();

            Assert.IsFalse(result.Success);
        }

        [TestMethod]
        public void ConstructorWithDataSucceeds()
        {
            var result = new Result<bool>(false);

            Assert.IsTrue(result.Success);
            Assert.IsFalse(result.Data);
        }

        [TestMethod]
        public void ConstructorWithTwitterErrorSucceeds()
        {
            var errors = new List<Error>
            {
                JsonConvert.DeserializeObject<Error>("{\r\n  \"Code\": \"401\",\r\n  \"Message\": \"Unauthorized\"\r\n}")
            };

            var twitterError = new TwitterError
            {
                Errors = errors
            };

            var result = new Result<bool>(twitterError);

            Assert.IsFalse(result.Success);
            Assert.AreEqual(twitterError, result.Error);
        }
    }
}
