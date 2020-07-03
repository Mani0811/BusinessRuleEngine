using Xunit;
using BusinessRulesEngine;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRulesEngine.Tests
{
    public class ShipingPackingSlipTests
    {
        [Fact()]
        public void ShipingPackingSlipTest()
        {
            var packagingSlip = new ShipingPackingSlip();
            Assert.Equal("Shipping", packagingSlip.Name);
            var output = packagingSlip.Perform();
            Assert.True(output);
        }
    }
}