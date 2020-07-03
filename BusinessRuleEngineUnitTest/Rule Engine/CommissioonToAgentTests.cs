using Xunit;
using BusinessRulesEngine;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRulesEngine.Tests
{
    public class CommissioonToAgentTests
    {
       

        [Fact()]
        public void PerformTest()
        {
            var rule = new CommissioonToAgent();
            Assert.Equal("Generated Commissioon To Agent", rule.Name);
            var output = rule.Perform();
            Assert.True(output);
        }
    }
}