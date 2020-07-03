using Xunit;
using BusinessRulesEngine;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRulesEngine.Tests
{
    public class ActivateMembershipTests
    {

        [Fact()]
        public void PerformTest()
        {
            var rule = new ActivateMembership();
            Assert.Equal("Activated Membership", rule.Name);
            var output = rule.Perform();
            Assert.True(output);
        }
    }
}