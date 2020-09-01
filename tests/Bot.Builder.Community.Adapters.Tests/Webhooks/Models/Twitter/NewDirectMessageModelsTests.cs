using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Bot.Builder.Community.Adapters.Twitter.Webhooks.Models.Twitter;

namespace Bot.Builder.Community.Adapters.Twitter.Tests.Webhooks.Models.Twitter
{
    [TestClass]
    [TestCategory("Twitter")]
    public class NewDirectMessageModelsTests
    {
        [TestMethod]
        public void EventPropertiesShouldBeSetSuccessfully()
        {
            var ev = new Event()
            {
                EventType = "event-type",
                MessageCreate = new NewEvent_MessageCreate()
            };

            var jsonResult = JsonConvert.DeserializeObject<Event>(JsonConvert.SerializeObject(ev));

            Assert.AreEqual(ev.EventType, jsonResult.EventType);
            Assert.AreEqual(ev.MessageCreate.GetType(), jsonResult.MessageCreate.GetType());
        }

        [TestMethod]
        public void NewEvent_QuickReplyPropertiesShouldBeSetSuccessfully()
        {
            var ev = new NewEvent_QuickReply()
            {
                Options = new List<NewEvent_QuickReplyOption>()
            };

            var jsonResult = JsonConvert.DeserializeObject<NewEvent_QuickReply>(JsonConvert.SerializeObject(ev));

            Assert.AreEqual(ev.Options.GetType(), jsonResult.Options.GetType());
        }

        [TestMethod]
        public void NewEvent_QuickReplyOptionPropertiesShouldBeSetSuccessfully()
        {
            var ev = new NewEvent_QuickReplyOption()
            {
                Label = "event-label"
            };

            var jsonResult = JsonConvert.DeserializeObject<NewEvent_QuickReplyOption>(JsonConvert.SerializeObject(ev));

            Assert.AreEqual(ev.Label, jsonResult.Label);
        }

        [TestMethod]
        public void NewEvent_MessageCreatePropertiesShouldBeSetSuccessfully()
        {
            var ev = new NewEvent_MessageCreate()
            {
                MessageData = new NewEvent_MessageData(),
                target = new Target()
            };

            var jsonResult = JsonConvert.DeserializeObject<NewEvent_MessageCreate>(JsonConvert.SerializeObject(ev));

            Assert.AreEqual(ev.MessageData.GetType(), jsonResult.MessageData.GetType());
            Assert.AreEqual(ev.target.GetType(), jsonResult.target.GetType());
        }

        [TestMethod]
        public void NewEvent_MessageDataPropertiesShouldBeSetSuccessfully()
        {
            var ev = new NewEvent_MessageData()
            {
                QuickReply = new NewEvent_QuickReply(),
                Text = "test-text"
            };

            var jsonResult = JsonConvert.DeserializeObject<NewEvent_MessageData>(JsonConvert.SerializeObject(ev));

            Assert.AreEqual(ev.QuickReply.GetType(), jsonResult.QuickReply.GetType());
            Assert.AreEqual(ev.Text, jsonResult.Text);
        }
    }
}
