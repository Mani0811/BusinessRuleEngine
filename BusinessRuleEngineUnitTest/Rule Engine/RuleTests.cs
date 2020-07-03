using Xunit;
using BusinessRulesEngine;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRulesEngine.Tests
{
    public class RuleTests
    {
        public RuleTests()
        {

        }

        [Fact()]
        public void PerformConditionTest()
        {
            var rule = new Rule
            {
                Id = 1,
                Conditions = new List<ICondtionAction> { new Payment() { MemberValue = new PhysicalProduct() } },
                ResultActions = new List<ITargetAction> { new ShipingPackingSlip() }
            };
            var output = rule.PerformCondition();
            Assert.True(output);
        }
        [Fact()]
        public void PerformResultActionTest_Success()
        {
            var rule = new Rule
            {
                Id = 1,
                Conditions = new List<ICondtionAction> { new Payment() { MemberValue = new PhysicalProduct() } },
                ResultActions = new List<ITargetAction> { new ShipingPackingSlip() }
            };
            var output = rule.PerformCondition();
            Assert.True(output);
            output = rule.PerformResultAction();
            Assert.True(output);
        }

        [Fact()]
        public void PerformResultActionTest_Failure_WithoutConditionExcecution()
        {
            var rule = new Rule
            {
                Id = 1,
                Conditions = new List<ICondtionAction> { new Payment() { MemberValue = new PhysicalProduct() } },
                ResultActions = new List<ITargetAction> { new ShipingPackingSlip() }
            };
            var output = rule.PerformResultAction();
            Assert.False(output);
        }

        [Fact()]
        public void PerformResultActionTest_Failure()
        {
            var rule = new Rule
            {
                Id = 1,
                Conditions = new List<ICondtionAction> { new Payment() { MemberValue = new PhysicalProduct() } },
                ResultActions = new List<ITargetAction> { new ShipingPackingSlip() }
            };
            rule.PerformConditionSuccess = false;
            var output = rule.PerformResultAction();
            Assert.False(output);
        }
    }
}