using Xunit;
using BusinessRulesEngine;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRulesEngine.Tests
{
    public class AddFirstAidVideoInPackingSlipTests
    {
        [Fact()]
        public void PerformTest()
        {
            var rule = new AddFirstAidVideoInPackingSlip();
            Assert.Equal("Added First Aid Video In PackingSlip", rule.Name);
            var output = rule.Perform();
            Assert.True(output);
        }
    }
}