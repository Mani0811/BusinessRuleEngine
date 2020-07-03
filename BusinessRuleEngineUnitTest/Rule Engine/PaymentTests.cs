using Xunit;
using BusinessRulesEngine;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRulesEngine.Tests
{
    public class PaymentTests
    {
        [Fact()]
        public void PerformTest()
        {
            var condtion = new Payment() { MemberValue = new PhysicalProduct() };
            Assert.NotNull(condtion.MemberValue);
            Assert.Equal("Physical Product", condtion.MemberValue.Name);
            var output = condtion.Perform();
            Assert.True(output);
        }
    }
}