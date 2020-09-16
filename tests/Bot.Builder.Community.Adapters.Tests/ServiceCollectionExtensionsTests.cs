// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;

namespace Bot.Builder.Community.Adapters.Twitter.Tests
{
    [Trait("TestCategory", "Twitter")]
    public class ServiceCollectionExtensionsTests
    {
        private static readonly Mock<IServiceCollection> _testService = new Mock<IServiceCollection>();
        private static readonly Mock<Action<TwitterOptions>> _testAction = new Mock<Action<TwitterOptions>>();

        [Fact]
        public void AddTwitterAdapterShouldExecuteSuccessfully()
        {
            _testService.Setup(e => e.Add(default));
            _testService.Setup(e => e.GetEnumerator()).Returns(new List<ServiceDescriptor>().GetEnumerator());

            _testService.Object.AddTwitterAdapter(_testAction.Object);

            _testService.Verify(e => e.Add(It.IsAny<ServiceDescriptor>()));
            _testService.Verify(e => e.GetEnumerator());
        }
    }
}
