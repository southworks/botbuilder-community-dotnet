using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bot.Builder.Community.Adapters.Twitter.Webhooks.Models.Twitter;

namespace Bot.Builder.Community.Adapters.Twitter.Tests.Webhooks.Models.Twitter
{
    [TestClass]
    [TestCategory("Twitter")]
    public class TwitterErrorTests
    {
        [TestMethod]
        public void TwitterErrorToStringShouldReturnValue()
        {
            var error = new TwitterError()
            {
                Errors = new List<Error>()
                {
                    new Error() { Code = 3, Message = "error-message" }
                }
            };

            Assert.AreEqual("Error Code: 3, Error Message: error-message", error.ToString());
        }
    }
}
