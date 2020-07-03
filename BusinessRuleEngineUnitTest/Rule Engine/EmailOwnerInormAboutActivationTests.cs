using Xunit;
using BusinessRulesEngine;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRulesEngine.Tests
{
    public class EmailOwnerInormAboutActivationTests
    {
        [Fact()]
        public void PerformTest()
        {
            var rule = new EmailOwnerInormAboutActivation();
            Assert.Equal("Sent EmailOwner and Inormed About Activation", rule.Name);
            var output = rule.Perform();
            Assert.True(output);
        }
    }
}