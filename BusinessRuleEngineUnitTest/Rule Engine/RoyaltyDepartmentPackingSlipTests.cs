using Xunit;
using BusinessRulesEngine;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRulesEngine.Tests
{
    public class RoyaltyDepartmentPackingSlipTests
    {
        [Fact()]
        public void PerformTest()
        {
            var royaltyDepartmentPackingSlip = new RoyaltyDepartmentPackingSlip();
            Assert.Equal("Royalty Department", royaltyDepartmentPackingSlip.Name);
            var output = royaltyDepartmentPackingSlip.Perform();
            Assert.True(output);
        }
    }
}