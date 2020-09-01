using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Bot.Builder.Community.Adapters.Twitter.Webhooks.Models.Twitter;

namespace Bot.Builder.Community.Adapters.Twitter.Tests.Webhooks.Models.Twitter
{
    [TestClass]
    [TestCategory("Twitter")]
    public class WebhookResultTests
    {
        [TestMethod]
        public void WebhookResultPropertiesShouldBeSetSuccessfully()
        {
            var webhookResult = new WebhookResult()
            {
                Environments = new List<EnvironmentRegistration>()
            };

            var jsonResult = JsonConvert.DeserializeObject<WebhookResult>(JsonConvert.SerializeObject(webhookResult));
            
            Assert.AreEqual(webhookResult.Environments.GetType(), jsonResult.Environments.GetType());
        }
    }
}
