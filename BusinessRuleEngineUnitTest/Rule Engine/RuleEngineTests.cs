using Xunit;
using BusinessRulesEngine;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace BusinessRulesEngine.Tests
{
    public class RuleEngineTests
    {
        RuleEngine ruleEngine;

        public RuleEngineTests()
        {
            ruleEngine = new RuleEngine();
        }

        [Fact()]
        public void AddRuleTest_Success()
        {
            PrepareData();
            Assert.NotNull(ruleEngine);
            Assert.NotNull(ruleEngine.Rules);
            Assert.Equal(2,ruleEngine.Rules.Count);
            Assert.Equal(1, ruleEngine.Rules[1].Id);
            Assert.Equal(2, ruleEngine.Rules[2].Id);
        }
        [Fact()]
        public void AddRuleTest_DuplicatedIdError()
        {
            var ex = Assert.Throws<ArgumentException>(()=>PrepareDuplicateData());
            Assert.Equal("An item with the same key has already been added. Key: 1", ex.Message);
        }


        [Fact()]
        public void PerformTest_Success()
        {
            PrepareData();
            var ids = new List<int> { 1, 2};
            foreach (var id in ids)
            {
               var rule = ruleEngine.Rules[id];
               var output = ruleEngine.Perform(rule);
               Assert.True(output);
            }
        }
        [Fact]
        public void PerformTest_Failure()
        {
            PrepareData();
            var ids = new List<int> {1};
            foreach (var id in ids)
            {
                var rule = ruleEngine.Rules[id];
                var ex = Assert.Throws<ArgumentNullException>(() => ruleEngine.Perform(null));
            }
        }

        private void PrepareData()
        {
            ruleEngine.Rules.Clear();
            var rule = new Rule
            {
                Id = 1,
                Conditions = new List<ICondtionAction> { new Payment() { MemberValue = new PhysicalProduct() } },
                ResultActions = new List<ITargetAction> { new ShipingPackingSlip() }
            };
            ruleEngine.Rules.Add(rule.Id, rule);
            rule = new Rule
            {
                Id = 2,
                Conditions = new List<ICondtionAction> { new Payment() { MemberValue = new Book() } },
                ResultActions = new List<ITargetAction> { new RoyaltyDepartmentPackingSlip() }
            };
            ruleEngine.Rules.Add(rule.Id, rule);
        }

        private void PrepareDuplicateData()
        {
            ruleEngine.Rules.Clear();
            var rule = new Rule
            {
                Id = 1,
                Conditions = new List<ICondtionAction> { new Payment() { MemberValue = new PhysicalProduct() } },
                ResultActions = new List<ITargetAction> { new ShipingPackingSlip() }
            };
            ruleEngine.Rules.Add(rule.Id, rule);
            rule = new Rule
            {
                Id = 1,
                Conditions = new List<ICondtionAction> { new Payment() { MemberValue = new Book() } },
                ResultActions = new List<ITargetAction> { new RoyaltyDepartmentPackingSlip() }
            };
            ruleEngine.Rules.Add(rule.Id, rule);
        }
    }
}