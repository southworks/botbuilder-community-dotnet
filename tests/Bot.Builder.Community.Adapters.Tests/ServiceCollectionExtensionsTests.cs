// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Bot.Builder.Community.Adapters.Twitter.Tests
{
    [Trait("TestCategory", "Twitter")]
    public class ServiceCollectionExtensionsTests
    {
        private static readonly Mock<IServiceCollection> TestService = new Mock<IServiceCollection>();
        private static readonly Mock<Action<TwitterOptions>> TestAction = new Mock<Action<TwitterOptions>>();

        [Fact]
        public void AddTwitterAdapterShouldExecuteSuccessfully()
        {
            TestService.Setup(e => e.Add(default));
            TestService.Setup(e => e.GetEnumerator()).Returns(new List<ServiceDescriptor>().GetEnumerator());

            TestService.Object.AddTwitterAdapter(TestAction.Object);

            TestService.Verify(e => e.Add(It.IsAny<ServiceDescriptor>()));
            TestService.Verify(e => e.GetEnumerator());
        }
    }
}
